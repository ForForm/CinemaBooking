using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using CineBookWcfService.Classes;
using CineBookWcfService.Models;

namespace CineBookWcfService.ViewModels
{
    public class MovieSeatTemplateDetailViewModel
    {
        internal int MovieSeatTypeId { get; set; }
        public int RowIndex { get; set; }
        public int ColumnIndex { get; set; }
        public string Prefix { get; set; }
        public string Suffix { get; set; }
        public string SeatCode { get; set; }
        public MovieSeatTypeViewModel SeatType { get; set; }
        public BlockViewModel Block { get; set; }
        public List<MovieTariffPriceViewModel> PriceList { get; set; }
        public static List<MovieSeatTemplateDetailViewModel> Get(int movieSessionId, String block)
        {
            List<MovieSeatTemplateDetailViewModel> result = null;
            try
            {
                using (var entities = new CineBookEntitiesExt())
                {
                    if (entities.GetCurrentSessions().Any(o => o.MovieSessionId == movieSessionId))
                    {
                        var movieSession = entities.MovieSession.FirstOrDefault(o => o.MovieSessionId == movieSessionId);

                        if (movieSession != null)
                        {
                            List<MovieTheatrePlaceTemplateDetails> results;
                            if (block != null)
                                results = movieSession.MovieTheatrePlace.MovieTheatrePlaceTemplate.MovieTheatrePlaceTemplateDetails.Where(o => o.Block == Convert.ToInt32(block)).ToList();
                            else
                                results = movieSession.MovieTheatrePlace.MovieTheatrePlaceTemplate.MovieTheatrePlaceTemplateDetails.ToList();

                            result = results.Select(o =>                            
                            new MovieSeatTemplateDetailViewModel
                            {
                                MovieSeatTypeId = o.MovieSeatTypeId,
                                RowIndex = o.RowIndex,
                                ColumnIndex = o.ColumnIndex,
                                Prefix = o.Prefix,
                                Suffix = o.Suffix,
                                Block =
                                (movieSession.MovieTheatrePlace.MovieTheatrePlaceTemplate.MovieTheatrePlaceTemplateBlock.Where(p => p.BlockIndex == o.Block).Count() > 0) ?
                                new BlockViewModel
                                {
                                    Id = (movieSession.MovieTheatrePlace.MovieTheatrePlaceTemplate.MovieTheatrePlaceTemplateBlock.Where(p => p.BlockIndex == o.Block).FirstOrDefault().BlockIndex ?? 0),
                                    Name = movieSession.MovieTheatrePlace.MovieTheatrePlaceTemplate.MovieTheatrePlaceTemplateBlock.Where(p => p.BlockIndex == o.Block).FirstOrDefault().MovieTheaterBlockName
                                }:null,
                                SeatCode = o.SeatCode,
                                SeatType = new MovieSeatTypeViewModel
                                {
                                    Id = o.MovieSeatTypeId,
                                    Name = o.MovieSeatType.MovieSeatTypeName,
                                    Background = o.MovieSeatType.MovieSeatTypeBackground,
                                    Foreground = o.MovieSeatType.MovieSeatTypeForeground,
                                    Salable = o.MovieSeatType.Salable
                                },
                                PriceList = (o.MovieSeatTypeId == 7) ? (movieSession.MovieSessionAmount.Where(p => p.MovieSeatTypeId == o.MovieSeatTypeId
                                 && p.MovieTheatrePlaceTemplateDetailsId == o.Id).Select(p => new MovieTariffPriceViewModel
                                 {
                                     Id = p.MovieTariffId,
                                     Name = p.MovieTariff.MovieTariffName,
                                     Price = p.Amount
                                 }).ToList().Count() > 0 ?
                                    movieSession.MovieSessionAmount.Where(p => p.MovieSeatTypeId == o.MovieSeatTypeId
                                     && p.MovieTheatrePlaceTemplateDetailsId == o.Id).Select(p => new MovieTariffPriceViewModel
                                     {
                                         Id = p.MovieTariffId,
                                         Name = p.MovieTariff.MovieTariffName,
                                         Price = p.Amount
                                     }).ToList() :
                                     movieSession.MovieSessionAmount.Where(p => p.MovieSeatTypeId == o.MovieSeatTypeId && p.MovieTariffId == 7
                                     && p.MovieTheatrePlaceTemplateDetailsId == null).Select(p => new MovieTariffPriceViewModel
                                     {
                                         Id = p.MovieTariffId,
                                         Name = p.MovieTariff.MovieTariffName,
                                         Price = p.Amount
                                     }).ToList()) : movieSession.MovieSessionAmount.Where(p => p.MovieSeatTypeId == o.MovieSeatTypeId && p.MovieTariffId != 7).Select(p => new MovieTariffPriceViewModel
                                     {
                                         Id = p.MovieTariffId,
                                         Name = p.MovieTariff.MovieTariffName,
                                         Price = p.Amount
                                     }).ToList()
                            }
                            ).OrderBy(o => o.RowIndex).ThenBy(o => o.ColumnIndex).ToList();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return null;
            }
            return result;
        }
        public static List<BlockViewModel> GetBlocks(int movieSessionId)
        {
            List<BlockViewModel> result = new List<BlockViewModel>();
            try
            {
                using (var entities = new CineBookEntitiesExt())
                {
                    if (entities.GetCurrentSessions().Any(o => o.MovieSessionId == movieSessionId))
                    {
                        var movieSession = entities.MovieSession.FirstOrDefault(o => o.MovieSessionId == movieSessionId);
                        if (movieSession != null)
                        {
                            foreach (var blocks in movieSession.MovieTheatrePlace.MovieTheatrePlaceTemplate.MovieTheatrePlaceTemplateBlock)
                            {
                                BlockViewModel item = new BlockViewModel();
                                //item.Id = blocks.MovieTheaterBlockId;
                                item.Id = blocks.BlockIndex ?? 0;
                                item.Name = blocks.MovieTheaterBlockName;
                                result.Add(item);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return null;
            }
            return result;
        }
    }
}