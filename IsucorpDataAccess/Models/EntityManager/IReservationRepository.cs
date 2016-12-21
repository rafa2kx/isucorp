using System.Collections.Generic;
using IsucorpDataAccess.Models.ViewModel;
using IsuCorpRound3.Models.ViewModel;

namespace IsucorpDataAccess.Models.EntityManager
{
    public interface IReservationRepository
    {
        IEnumerable<ContactTypeModel> GetContacTypes();
        ReservationModel GetReservation(int id);
        IEnumerable<ReservationModel> GetReservations(string sortBy = "Fullname", int limit = 10, int page = 0);
        void InsertReservation(ReservationModel reservationView);
        void UpdateReservation(ReservationModel reservationView);
        int GetTotalPages(int limit = 10);
        void RemoveReservation(int id);
    }
}