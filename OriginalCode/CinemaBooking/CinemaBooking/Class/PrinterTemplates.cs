using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaBooking.Class
{
    public static class PrinterTemplates
    {
        public static string TicketTemplate;
        public static string ReceiptTemplate;

        public static void RefreshTemplates(MovieTicket ticket)
        {
            using (var entities = new CinemaBookingEntities())
            {

                string strTemplateName = "Ticket";
                if (ticket!=null)
                strTemplateName = entities.Movie.Where(o => o.MovieId == ticket.MovieTicketSale.MovieSession.MovieId).FirstOrDefault().TemplateName;

                var template = entities.PrinterTemplate.FirstOrDefault(o => o.TemplateName == strTemplateName);
                if (template != null) TicketTemplate = template.TemplateContent;
                var rTemplate = entities.PrinterTemplate.FirstOrDefault(o => o.TemplateName == "Receipt");
                if (rTemplate != null) ReceiptTemplate = rTemplate.TemplateContent;

            }
        }
        public static string GetTicketTemplate(byte tariff)
        {
            return TicketTemplate;
            //var result = "";
            //using (var dg = new Database.GetDataReader("SELECT BS.ICERIK from BILET_TARIFE_SABLON BTS, BILET_SABLON BS where BTS.SABLONID=BS.SABLONID and BTS.TARIFEID=@TARIFEID", new Dictionary<string, object> { { "TARIFEID", tariff } }))
            //{
            //    if (dg.Read()) result = dg[0].ToString();
            //}
            //if (string.IsNullOrEmpty(result))
            //{
            //    using (var dg = new Database.GetDataReader("SELECT * FROM YAZICI_SABLON WHERE KODU='TICKET'"))
            //    {
            //        if (dg.Read()) result = dg["SABLON"].ToString();
            //    }
            //}
            //return result;
        }

        public static string GetReceiptTemplate(byte tariff)
        {
            return ReceiptTemplate;
        }

    }
}
