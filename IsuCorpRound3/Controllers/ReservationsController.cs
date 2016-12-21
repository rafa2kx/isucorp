using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Results;
using IsuCorpRound3.Models.EntityManager;
using IsuCorpRound3.Models.ViewModel;
using Newtonsoft.Json;

namespace IsuCorpRound3.Controllers
{
    public class ReservationsController : ApiController
    {
        /// <summary>
        /// </summary>
        private readonly IReservationRepository _reservationRepository;

        /// <summary>
        /// </summary>
        public ReservationsController()
        {
            _reservationRepository = new ReservationRepository();
        }

        protected override JsonResult<T> Json<T>(T content, JsonSerializerSettings serializerSettings, Encoding encoding)
        {
            
            serializerSettings.DateFormatString = "MM/dd/yyyy";
            serializerSettings.DateParseHandling = DateParseHandling.DateTime;
            
            return base.Json(content, serializerSettings, encoding);
        }

        


        /// <summary>
        /// </summary>
        /// <param name="sortBy"></param>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        // GET api/<controller>
        public JsonResult<IEnumerable<ReservationModel>> Get(string sortBy = "Fullname", int page = 1,
            int limit = 10)
        {
            return Json(_reservationRepository.GetReservations(sortBy, limit, page - 1));
        }

        /// <summary>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET api/<controller>/5
        public JsonResult<ReservationModel> Get(int id)
        {
            return Json(_reservationRepository.GetReservation(id));
        }

        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        // POST api/<controller>
        public HttpResponseMessage Post([FromBody] ReservationModel value)
        {
            try
            {
                if (ModelState.IsValid && value.Birthdate.Value.CompareTo(DateTime.Today) < 0)
                {
                    _reservationRepository.InsertReservation(value);
                    return new HttpResponseMessage(HttpStatusCode.OK);
                }
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }

        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        // PUT api/<controller>/5
        public HttpResponseMessage Put([FromBody] ReservationModel value)
        {
            try
            {
                _reservationRepository.UpdateReservation(value);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="id"></param>
        // DELETE api/<controller>/5
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                _reservationRepository.RemoveReservation(id);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }
    }
}