using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using jago.UI.Controllers.Core;
using jago.Application.ViewModel;
using jago.Application.Interfaces.Services;
using jago.domain.Interfaces.Repositories;

namespace jago.UI.Controllers
{
    public class TripController : BaseController<TripViewModel>
    {
        private readonly ITripServices _tripServices;
        private readonly IPassengerServices _passengerServices;
        private readonly ITripRepository _tripRepository;

        public TripController(ITripServices tripServices,
            IPassengerServices passengerServices, ITripRepository tripRepository)
        {
            _tripServices = tripServices;
            _passengerServices = passengerServices;
            _tripRepository = tripRepository;
        }

        public override IEnumerable<TripViewModel> GetRows()
        {
            return _tripServices.GetOrder();
        }
        public override TripViewModel GetRow(Guid id)
        {
            return _tripServices.GetById(id);

        }
        public IActionResult Index()
        {
            return View(GetRows());
        }

        // GET: Trips/Details
        public async Task<IActionResult> Details(Guid id)
        {
            var trip = _tripRepository.GetAll()
                .Include(_ => _.Passenger)
                .FirstOrDefault(_ => _.Id == id);

            return View(trip);
        }

        // GET: Trips/Create
        [HttpGet]
        public IActionResult Create()
        {
            LoadViewBags();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TripViewModel vm)
        {
            LoadViewBags();
            TempData["success"] = "Trip added successfully";
            ViewDefault("Index", vm, _tripServices.Add(vm));
            return RedirectToAction("Index");

        }

        // GET: Trips/Edit
        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            LoadViewBags();
            var item = _tripServices.GetById(id);
            return View(item);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(TripViewModel vm)
        {
            TempData["success"] = "Trip updated successfully";
            ViewDefault("Index", vm, _tripServices.Update(vm));
            return RedirectToAction("Index");
        }

        // GET: Trips/Delete
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var trip = _tripServices.GetById(id);

            return View(trip);
        }

        // POST: Trips/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(TripViewModel vm)
        {
            _tripServices.Remove(vm.Id);
            TempData["success"] = "Trip deleted successfully";
            return View("Index", _tripServices.GetAll());

        }

        public override void LoadViewBags()
        {
            LoadAsync();
        }
        public async void LoadAsync()
        {
            ViewBag.Passengers = _tripServices.GetPaxList().ToList();
        }
    }
}
