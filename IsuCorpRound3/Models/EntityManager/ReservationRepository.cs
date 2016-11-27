using System;
using System.Collections.Generic;
using System.Linq;
using IsuCorpRound3.Models.DB;
using IsuCorpRound3.Models.ViewModel;

namespace IsuCorpRound3.Models.EntityManager
{
    public enum ReservationOrderableFields
    {
        Fullname,
        Rating,
        Birthday
    }

    public class ReservationRepository
    {
        /// <summary>
        /// </summary>
        private readonly isuCorpTestEntities _entities;

        /// <summary>
        /// 
        /// </summary>
        public ReservationRepository()
        {
            _entities = new isuCorpTestEntities();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ContactTypeViewModel> GetContacTypes()
        {
            var query = from contactTypes in _entities.ContactTypes select contactTypes;

            return query.ToList().Select(ct => new ContactTypeViewModel
            {
                name = ct.name,
                description = ct.description,
                Id = ct.Id
            }).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ReservationViewModel GetReservation(int id)
        {
            var r = _entities.Reservations.Find(id);
            return new ReservationViewModel
            {
                Fullname = r.fullname,
                Birthdate = r.birthdate,
                Description = r.description,
                ContactTypeId = r.ContactType_Id,
                PhoneNumber = r.phone,
                Id = r.Id
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sortBy"></param>
        /// <param name="limit"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public IEnumerable<ReservationViewModel> GetReservations(string sortBy = "Fullname", int limit = 10,
            int page = 0)
        {
            var totalCount = _entities.Reservations.Count();

            if (!_entities.Reservations.Any())
                return new List<ReservationViewModel>();

            var offset = page*limit;
            if (totalCount == 0 || offset > _entities.Reservations.Count())
                return new List<ReservationViewModel>();

            var count = offset + limit > totalCount ? totalCount - offset : limit;
            var splittedSort = sortBy.Split(' ');
            var desc = splittedSort.Length > 1 && splittedSort[1].Equals("DESC");
            ReservationOrderableFields field;
            Enum.TryParse(splittedSort[0], true, out field);

            IQueryable<Reservation> query = null;

            switch (field)
            {
                case ReservationOrderableFields.Fullname:
                {
                    query = desc
                        ? _entities.Reservations.OrderByDescending(reservation => reservation.fullname)
                        : _entities.Reservations.OrderBy(reservation => reservation.fullname);
                    break;
                }
                case ReservationOrderableFields.Birthday:
                {
                    query = desc
                        ? _entities.Reservations.OrderByDescending(reservation => reservation.birthdate)
                        : _entities.Reservations.OrderBy(reservation => reservation.birthdate);
                    break;
                }
                case ReservationOrderableFields.Rating:
                {
                    query = desc
                        ? _entities.Reservations.OrderByDescending(reservation => reservation.rating)
                        : _entities.Reservations.OrderBy(reservation => reservation.rating);
                    break;
                }

                default:
                {
                    query = desc
                        ? _entities.Reservations.OrderByDescending(reservation => reservation.Id)
                        : _entities.Reservations.OrderBy(reservation => reservation.Id);
                    break;
                }
            }
            return query.Select(reservation => new ReservationViewModel
            {
                Birthdate = reservation.birthdate,
                Description = reservation.description,
                Fullname = reservation.fullname,
                Id = reservation.Id,
                PhoneNumber = reservation.phone,
                Rating = reservation.rating ?? 0,
                IsFavorite = reservation.is_favorite
            }).ToList().GetRange(offset, count);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reservationView"></param>
        public void InsertReservation(ReservationViewModel reservationView)
        {
            using (var db = new isuCorpTestEntities())
            {
                if (reservationView.ContactTypeId != null)
                {
                    var re = new Reservation
                    {
                        fullname = reservationView.Fullname,
                        birthdate = reservationView.Birthdate,
                        description = reservationView.Description,
                        ContactType_Id = (int) reservationView.ContactTypeId,
                        phone = reservationView.PhoneNumber
                    };
                    db.Reservations.Add(re);
                }
                db.SaveChanges();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reservationView"></param>
        public void UpdateReservation(ReservationViewModel reservationView)
        {
            using (var db = new isuCorpTestEntities())
            {
                var r = db.Reservations.Find(reservationView.Id);
                if (reservationView.Fullname != null)
                    r.fullname = reservationView.Fullname;

                if (reservationView.Description != null)
                    r.description = reservationView.Description;

                if (reservationView.PhoneNumber != null)
                    r.phone = reservationView.PhoneNumber;

                if (reservationView.IsFavorite != null)
                    r.is_favorite = (bool) reservationView.IsFavorite;

                if (reservationView.Rating != null)
                    r.rating = reservationView.Rating;

                if (reservationView.Birthdate != null)
                    r.birthdate = reservationView.Birthdate;

                if (reservationView.ContactTypeId != null)
                    r.ContactType_Id = (int) reservationView.ContactTypeId;
                db.SaveChanges();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="limit"></param>
        /// <returns></returns>
        public int GetTotalPages(int limit = 10)
        {
            var rem = 0;
            var pages = Math.DivRem(_entities.Reservations.Count(), limit, out rem);
            if (rem > 0)
                pages++;
            return pages;
        }
    }
}