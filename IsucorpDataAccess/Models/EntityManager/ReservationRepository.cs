using System;
using System.Collections.Generic;
using System.Linq;
using IsucorpDataAccess.Models.DB;
using IsucorpDataAccess.Models.ViewModel;
using IsuCorpRound3.Models.Entities;
using IsuCorpRound3.Models.ViewModel;

namespace IsucorpDataAccess.Models.EntityManager
{
    public enum ReservationOrderableFields
    {
        Fullname,
        Rating,
        Birthday
    }

    public class ReservationRepository : IReservationRepository
    {
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ContactTypeModel> GetContacTypes()
        {
            using (var entities = new IsucorpContext())
            {
                var query = from contactTypes in entities.ContactTypes select contactTypes;

                return query.ToList().Select(ct => new ContactTypeModel
                {
                    name = ct.Name,
                    description = ct.Description,
                    Id = ct.ID
                }).ToList();
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ReservationModel GetReservation(int id)
        {
            using (var entities = new IsucorpContext())
            {
                var r = entities.Reservations.Find(id);
                return new ReservationModel
                {
                    Fullname = r.Fullname,
                    Birthdate = r.Birthdate,
                    Description = r.Description,
                    ContactTypeId = r.ContactTypeID,
                    PhoneNumber = r.PhoneNumber,
                    Id = r.ID
                };
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="sortBy"></param>
        /// <param name="limit"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public IEnumerable<ReservationModel> GetReservations(string sortBy = "Fullname", int limit = 10,
            int page = 0)
        {
            using (var entities = new IsucorpContext())
            {
                var totalCount = entities.Reservations.Count();

                if (!entities.Reservations.Any())
                    return new List<ReservationModel>();

                var offset = page*limit;
                if (totalCount == 0 || offset > entities.Reservations.Count())
                    return new List<ReservationModel>();

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
                            ? entities.Reservations.OrderByDescending(reservation => reservation.Fullname)
                            : entities.Reservations.OrderBy(reservation => reservation.Fullname);
                        break;
                    }
                    case ReservationOrderableFields.Birthday:
                    {
                        query = desc
                            ? entities.Reservations.OrderByDescending(reservation => reservation.Birthdate)
                            : entities.Reservations.OrderBy(reservation => reservation.Birthdate);
                        break;
                    }
                    case ReservationOrderableFields.Rating:
                    {
                        query = desc
                            ? entities.Reservations.OrderByDescending(reservation => reservation.Rating)
                            : entities.Reservations.OrderBy(reservation => reservation.Rating);
                        break;
                    }

                    default:
                    {
                        query = desc
                            ? entities.Reservations.OrderByDescending(reservation => reservation.ID)
                            : entities.Reservations.OrderBy(reservation => reservation.ID);
                        break;
                    }
                }

                return query.Select(reservation => new ReservationModel
                {
                    Birthdate = reservation.Birthdate,
                    Description = reservation.Description,
                    Fullname = reservation.Fullname,
                    Id = reservation.ID,
                    PhoneNumber = reservation.PhoneNumber,
                    Rating = reservation.Rating ?? 0,
                    IsFavorite = reservation.IsFavorite
                }).ToList().GetRange(offset, count);
            }
        }


        /// <summary>
        /// </summary>
        /// <param name="reservationView"></param>
        public void InsertReservation(ReservationModel reservationView)
        {
            using (var entities = new IsucorpContext())
            {
                if (reservationView.ContactTypeId != null)
                {
                    var re = new Reservation
                    {
                        Fullname = reservationView.Fullname,
                        Birthdate = reservationView.Birthdate,
                        Description = reservationView.Description,
                        ContactTypeID = (int) reservationView.ContactTypeId,
                        PhoneNumber = reservationView.PhoneNumber
                    };
                    entities.Reservations.Add(re);
                }
                entities.SaveChanges();
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="reservationView"></param>
        public void UpdateReservation(ReservationModel reservationView)
        {
            using (var entities = new IsucorpContext())
            {
                var r = entities.Reservations.Find(reservationView.Id);
                if (reservationView.Fullname != null)
                    r.Fullname = reservationView.Fullname;

                if (reservationView.Description != null)
                    r.Description = reservationView.Description;

                if (reservationView.PhoneNumber != null)
                    r.PhoneNumber = reservationView.PhoneNumber;

                if (reservationView.IsFavorite != null)
                    r.IsFavorite = (bool) reservationView.IsFavorite;

                if (reservationView.Rating != null)
                    r.Rating = reservationView.Rating;

                if (reservationView.Birthdate != null)
                    r.Birthdate = reservationView.Birthdate;

                if (reservationView.ContactTypeId != null)
                    r.ContactTypeID = (int) reservationView.ContactTypeId;
                entities.SaveChanges();
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="limit"></param>
        /// <returns></returns>
        public int GetTotalPages(int limit = 10)
        {
            var rem = 0;
            using (var entities = new IsucorpContext())
            {
                var pages = Math.DivRem(entities.Reservations.Count(), limit, out rem);
                if (rem > 0)
                    pages++;
                return pages;
            }
        }

        public void RemoveReservation(int id)
        {
            throw new NotImplementedException();
        }
    }
}