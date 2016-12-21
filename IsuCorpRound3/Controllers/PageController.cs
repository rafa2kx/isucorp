using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using IsucorpDataAccess.Models.EntityManager;

namespace IsuCorpRound3.Controllers
{
    public class PageController : Controller
    {
        /// <summary>
        /// </summary>
        private readonly IReservationRepository _reservationRepository;

        /// <summary>
        /// </summary>
        public PageController()
        {
            _reservationRepository = new ReservationRepository();
            ViewBag.culture = Thread.CurrentThread.CurrentCulture.Name;
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            ViewBag.pages = _reservationRepository.GetTotalPages();
            return View(_reservationRepository.GetReservations());
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            var contactTypes = _reservationRepository.GetContacTypes();
            var items =
                contactTypes.Select(
                    contactType => new SelectListItem {Text = contactType.name, Value = contactType.Id.ToString()})
                    .ToList();
            ViewBag.ContactTypes = items;

            return View();
        }

        /// <summary>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(int id)
        {
            var reservation = _reservationRepository.GetReservation(id);
            var contactTypes = _reservationRepository.GetContacTypes();
           
            var items = contactTypes.Select(contactType => new SelectListItem
            {
                Text = contactType.name,
                Value = contactType.Id.ToString(),
                Selected = contactType.Id.Equals(reservation.ContactTypeId)
            }).ToList();
            ViewBag.ContactTypes = items;

            return View(reservation);
        }

        /// <summary>
        /// </summary>
        /// <param name="language"></param>
        /// <returns></returns>
        public ActionResult SetLanguage(string language)
        {
            if (language != null)
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);
            }
            var languageCookie = new HttpCookie("languageCookie") {Value = language};
            Response.Cookies.Add(languageCookie);

            return Redirect(Request.UrlReferrer.LocalPath);
        }
    }
}