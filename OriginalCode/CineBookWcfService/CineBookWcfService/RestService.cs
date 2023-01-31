using System;
using System.Collections.Generic;
using System.Net;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using CineBookWcfService.ViewModels;

namespace CineBookWcfService
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]


    public class RestService : IRestService
    {

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "Movie?Status=Active", BodyStyle = WebMessageBodyStyle.Bare)]
        public MovieViewModel[] GetMovies_Active()
        {
            return MovieViewModel.GetMovies_Active();
        }

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "Movie?Status=NowPlaying", BodyStyle = WebMessageBodyStyle.Bare)]
        public MovieViewModel[] GetMovies_NowPlaying()
        {
            return MovieViewModel.GetMovies_NowPlaying();
        }

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "Movie?Status=ComingSoon", BodyStyle = WebMessageBodyStyle.Bare)]
        public MovieViewModel[] GetMovies_ComingSoon()
        {
            return MovieViewModel.GetMovies_ComingSoon();
        }


        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "Blocks?SessionId={sessionId}", BodyStyle = WebMessageBodyStyle.Bare)]
        public List<BlockViewModel> GetBlockTemplate(int sessionId)
        {
            if (!MovieSessionViewModel.Check(sessionId, out var reason)) { SetStatusCode(HttpStatusCode.BadRequest, reason); return null; }
            return MovieSeatTemplateDetailViewModel.GetBlocks(sessionId);
        }

 
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "SeatTemplate?SessionId={sessionId}&Block={block}", BodyStyle = WebMessageBodyStyle.Bare)]
        public List<MovieSeatTemplateDetailViewModel> GetSeatTemplate(int sessionId, String block)
        {
            if (!MovieSessionViewModel.Check(sessionId, out var reason)) { SetStatusCode(HttpStatusCode.BadRequest, reason); return null; }
            return MovieSeatTemplateDetailViewModel.Get(sessionId, block);
        }

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "SeatStatus?SessionId={sessionId}&WebSessionId={webSessionId}", BodyStyle = WebMessageBodyStyle.Bare)]
        public MovieSessionReservationViewModel GetSeatStatus(int sessionId, string webSessionId)
        {
            if (!MovieSessionViewModel.Check(sessionId, out var reason)) { SetStatusCode(HttpStatusCode.BadRequest, reason); return null; }
            if (string.IsNullOrEmpty(webSessionId)) { SetStatusCode(HttpStatusCode.BadRequest, "WebSessionId is invalid."); return null; }
            return MovieSessionReservationViewModel.Get(sessionId, webSessionId);
        }

        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "SeatStatus?SessionId={sessionId}&WebSessionId={webSessionId}&Block={block}&SeatCode={seatCode}", BodyStyle = WebMessageBodyStyle.Bare)]
        public void SetSeatStatusCheck(int sessionId, string webSessionId, int block,string seatCode)
        {
            if (!MovieSessionViewModel.Check(sessionId, out var reason)) { SetStatusCode(HttpStatusCode.BadRequest, reason); return; }
            if (string.IsNullOrEmpty(webSessionId)) { SetStatusCode(HttpStatusCode.BadRequest, "WebSessionId is invalid."); return; }
            if (!MovieSessionReservationViewModel.Check(sessionId, webSessionId, block, seatCode, out reason)) SetStatusCode(HttpStatusCode.BadRequest, reason);
        }

        [WebInvoke(Method = "DELETE", ResponseFormat = WebMessageFormat.Json, UriTemplate = "SeatStatus?SessionId={sessionId}&WebSessionId={webSessionId}&SeatCode={seatCode}", BodyStyle = WebMessageBodyStyle.Bare)]
        public void SetSeatStatusUncheck(int sessionId, string webSessionId, string seatCode)
        {
            if (!MovieSessionViewModel.Check(sessionId, out var reason)) { SetStatusCode(HttpStatusCode.BadRequest, reason); return; }
            if (string.IsNullOrEmpty(webSessionId)) { SetStatusCode(HttpStatusCode.BadRequest, "WebSessionId is invalid."); return; }
            var result = seatCode == null ? MovieSessionReservationViewModel.Uncheck(sessionId, webSessionId) : MovieSessionReservationViewModel.Uncheck(sessionId, webSessionId, seatCode);
            if (!result) SetStatusCode(HttpStatusCode.BadRequest, "Something is wrong.");
        }

        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "Alive?SessionId={sessionId}&WebSessionId={webSessionId}", BodyStyle = WebMessageBodyStyle.Bare)]
        public void SetAlive(int sessionId, string webSessionId)
        {
            if (!MovieSessionViewModel.Check(sessionId, out var reason)) { SetStatusCode(HttpStatusCode.BadRequest, reason); return; }
            if (string.IsNullOrEmpty(webSessionId)) { SetStatusCode(HttpStatusCode.BadRequest, "WebSessionId is invalid."); return; }
            if (!MovieSessionReservationViewModel.Alive(sessionId, webSessionId)) SetStatusCode(HttpStatusCode.BadRequest, "Something is wrong.");
        }

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "CardCheck?SessionId={sessionId}&SerialNumber={serialNumber}", BodyStyle = WebMessageBodyStyle.Bare)]
        public CustomerAuthorizationCheckViewModel CardCheck(int sessionId, string serialNumber)
        {
            if (!MovieSessionViewModel.Check(sessionId, out var reason)) { SetStatusCode(HttpStatusCode.BadRequest, reason); return null; }
            var modelFind = CustomerAuthorizationFindTagIdViewModel.Get(serialNumber);
            if (modelFind == null) { SetStatusCode(HttpStatusCode.BadRequest, "Something is wrong. (#1)"); return null; }
            if (!modelFind.Result) { return new CustomerAuthorizationCheckViewModel { Result = modelFind.Result, Content = modelFind.Content, Description = modelFind.Description }; }
            var modelCheck = CustomerAuthorizationCheckViewModel.GetForBooking(modelFind.Content, sessionId);
            if (modelCheck == null) { SetStatusCode(HttpStatusCode.BadRequest, "Something is wrong. (#2)"); return null; }
            return modelCheck;
        }

        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "Reservation?SessionId={sessionId}&WebSessionId={webSessionId}&CustomerPhone={customerPhone}&CustomerName={customerName}&CustomerEmail={customerEmail}&SerialNumber={serialNumber}&TariffId={tariffId}&Amount={amount}", BodyStyle = WebMessageBodyStyle.Bare)]
        public ReservationViewModel CreateReservation(int sessionId, string webSessionId, string customerPhone, string customerName, string customerEmail, string serialNumber, int tariffId, decimal amount)
        {
            if (!MovieSessionViewModel.Check(sessionId, out var reason)) { SetStatusCode(HttpStatusCode.BadRequest, reason); return null; }
            var reservationViewModel = MovieSessionReservationViewModel.Get(sessionId, webSessionId);
            if (reservationViewModel == null) { SetStatusCode(HttpStatusCode.BadRequest, "Something is wrong. (#1)"); return null; }
            if (reservationViewModel.ReservatingByMe.Count == 0) { SetStatusCode(HttpStatusCode.BadRequest, "Please select a seat."); return null; }
            if (reservationViewModel.ReservatingByMe.Count > 1) { SetStatusCode(HttpStatusCode.BadRequest, "Please select only one seat."); return null; }
            //var cardCheck = CardCheck(sessionId, serialNumber);
            //if (cardCheck == null) return null;
            //if (!cardCheck.Result) { SetStatusCode(HttpStatusCode.BadRequest, cardCheck.Description); return null; }
            //var result = ReservationViewModel.CreateForAnnual(sessionId, webSessionId, customerPhone, customerName, customerEmail, cardCheck.Content, out reason);
            //customerPhone, customerName, customerEmail,
            var result = ReservationViewModel.CreateForAnnual(sessionId, webSessionId,  serialNumber, tariffId, amount, out reason);

            if (result == null) { SetStatusCode(HttpStatusCode.BadRequest, "Something is wrong. (#2)"); return null; }
            return result;
        }

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "Reservation?ReservationId={reservationId}", BodyStyle = WebMessageBodyStyle.Bare)]
        public ReservationViewModel GetReservation(string reservationId)
        {
            var result = ReservationViewModel.Get(reservationId, true);
            if (result == null) { SetStatusCode(HttpStatusCode.BadRequest, "Reservation could not be found."); return null; }
            return result;
        }

        [WebInvoke(Method = "DELETE", ResponseFormat = WebMessageFormat.Json, UriTemplate = "Reservation?ReservationId={reservationId}&WebSessionId={webSessionId}", BodyStyle = WebMessageBodyStyle.Bare)]
        public void CancelReservation(string reservationId, string webSessionId)
        {
            var result = ReservationViewModel.Cancel(reservationId, webSessionId, out var reason);
            if (!result) { SetStatusCode(HttpStatusCode.BadRequest, reason); }
        }

        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "PreSale?SessionId={sessionId}&WebSessionId={webSessionId}&CustomerPhone={customerPhone}&CustomerName={customerName}&CustomerEmail={customerEmail}&Tariffs={tariffs}", BodyStyle = WebMessageBodyStyle.Bare)]
        public ReservationViewModel CreatePreSale(int sessionId, string webSessionId, string customerPhone, string customerName, string customerEmail, string tariffs)
        {
            if (!MovieSessionViewModel.Check(sessionId, out var reason)) { SetStatusCode(HttpStatusCode.BadRequest, reason); return null; }
            var reservationViewModel = MovieSessionReservationViewModel.Get(sessionId, webSessionId);
            if (reservationViewModel == null) { SetStatusCode(HttpStatusCode.BadRequest, "Something is wrong. (#1)"); return null; }
            if (reservationViewModel.ReservatingByMe.Count == 0) { SetStatusCode(HttpStatusCode.BadRequest, "Please select at least one seat."); return null; }
            if (string.IsNullOrEmpty(tariffs)) { SetStatusCode(HttpStatusCode.BadRequest, "Tariffs parameter is invalid."); return null; }
            var tariffList = new List<int>();
            foreach (var tariff in tariffs.Split(',')) if (int.TryParse(tariff, out var value)) tariffList.Add(value);
            if (reservationViewModel.ReservatingByMe.Count != tariffList.Count) { SetStatusCode(HttpStatusCode.BadRequest, "Seats count not matched with tariffs count."); return null; }
            var result = ReservationViewModel.CreateForSale(sessionId, webSessionId, customerPhone, customerName, customerEmail, tariffList.ToArray(), out reason);
            if (result == null) { SetStatusCode(HttpStatusCode.BadRequest, "Something is wrong. (#2)"); return null; }
            return result;
        }

        [WebInvoke(Method = "DELETE", ResponseFormat = WebMessageFormat.Json, UriTemplate = "PreSale?ReservationId={reservationId}&WebSessionId={webSessionId}", BodyStyle = WebMessageBodyStyle.Bare)]
        public void CancelPreSale(string reservationId, string webSessionId)
        {
            var result = ReservationViewModel.Cancel(reservationId, webSessionId, out var reason);
            if (!result) { SetStatusCode(HttpStatusCode.BadRequest, reason); }
        }

        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "Sale?ReservationId={reservationId}&WebSessionId={webSessionId}&TransactionId={transactionId}", BodyStyle = WebMessageBodyStyle.Bare)]
        public void CreateSale(string reservationId, string webSessionId, string transactionId)
        {
            var result = ReservationViewModel.ConvertToSale(reservationId, webSessionId, transactionId, out var reason);
            if (!result) { SetStatusCode(HttpStatusCode.BadRequest, reason); }
        }

        private static void SetStatusCode(HttpStatusCode statusCode, string statusDescription = null)
        {
            var context = WebOperationContext.Current;
            if (context == null) return;
            context.OutgoingResponse.StatusCode = statusCode;
            if (statusDescription != null) context.OutgoingResponse.StatusDescription = statusDescription;
        }

    }
}
