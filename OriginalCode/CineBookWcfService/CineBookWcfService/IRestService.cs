using System.Collections.Generic;
using System.ServiceModel;
using CineBookWcfService.ViewModels;

namespace CineBookWcfService
{
    [ServiceContract]
    internal interface IRestService
    {
        [OperationContract]
        MovieViewModel[] GetMovies_Active();

        [OperationContract]
        MovieViewModel[] GetMovies_NowPlaying();

        [OperationContract]
        MovieViewModel[] GetMovies_ComingSoon();
        
        [OperationContract]
        List<MovieSeatTemplateDetailViewModel> GetSeatTemplate(int sessionId, string block);

        [OperationContract]
        List<BlockViewModel> GetBlockTemplate(int sessionId);

        [OperationContract]
        MovieSessionReservationViewModel GetSeatStatus(int sessionId, string webSessionId);

        [OperationContract]
        void SetSeatStatusCheck(int sessionId, string webSessionId, int block, string seatCode);

        [OperationContract]
        void SetSeatStatusUncheck(int sessionId, string webSessionId, string seatCode);
        
        [OperationContract]
        void SetAlive(int sessionId, string webSessionId);

        [OperationContract]
        CustomerAuthorizationCheckViewModel CardCheck(int sessionId, string serialNumber);

        [OperationContract]
        ReservationViewModel GetReservation(string reservationId);

        [OperationContract]
        ReservationViewModel CreateReservation(int sessionId, string webSessionId, string customerPhone, string customerName, string customerEmail, string serialNumber, int tariffId, decimal amount);

        [OperationContract]
        ReservationViewModel CreatePreSale(int sessionId, string webSessionId, string customerPhone, string customerName, string customerEmail, string tariffs);

        [OperationContract]
        void CancelReservation(string reservationId, string webSessionId);

        [OperationContract]
        void CancelPreSale(string reservationId, string webSessionId);

        [OperationContract]
        void CreateSale(string reservationId, string webSessionId, string transactionId);

    }
}