using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Results;
using IsuCorpRound3.Models.EntityManager;
using IsuCorpRound3.Models.ViewModel;

namespace IsuCorpRound3.Controllers
{
    public class ReservationsController : ApiController
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly ReservationRepository _reservationRepository;

        /// <summary>
        /// 
        /// </summary>
        public ReservationsController()
        {
            _reservationRepository = new ReservationRepository();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sortBy"></param>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        // GET api/<controller>
        public JsonResult<IEnumerable<ReservationViewModel>> Get(string sortBy = "Fullname", int page = 1,
            int limit = 10)
        {
            return Json(_reservationRepository.GetReservations(sortBy, limit, page - 1));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET api/<controller>/5
        public JsonResult<ReservationViewModel> Get(int id)
        {
            return Json(_reservationRepository.GetReservation(id)); ;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        // POST api/<controller>
        public void Post([FromBody] ReservationViewModel value)
        {
            _reservationRepository.InsertReservation(value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        // PUT api/<controller>/5
        public void Put([FromBody] ReservationViewModel value)
        {
            _reservationRepository.UpdateReservation(value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}