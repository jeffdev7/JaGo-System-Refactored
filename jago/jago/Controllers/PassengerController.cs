using Microsoft.AspNetCore.Mvc;
using jago.Application.ViewModel;
using jago.UI.Controllers.Core;
using jago.Application.Interfaces.Services;

namespace jago.UI.Controllers
{
    public class PassengerController : BaseController<PassengerViewModel>
    {
        private readonly IPassengerServices _paxServices;

        public PassengerController(IPassengerServices paxServices)
        {
            _paxServices = paxServices;
        }

        public override IEnumerable<PassengerViewModel> GetRows()
        {
            return _paxServices.GetAll();
        }
        public override PassengerViewModel GetRow(Guid id)
        {
            return _paxServices.GetById(id);

        }

        // GET: Passengers
        public IActionResult Index()
        {
            return View(GetRows());
        }

        // GET: Passengers/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PassengerViewModel vm)
        {
            LoadViewBags();
            TempData["success"] = "Passenger added successfully";
            return ViewDefault("Index", vm, _paxServices.Add(vm));
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var item = _paxServices.GetById(id);
            LoadViewBags();
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(PassengerViewModel vm)
        {
            TempData["success"] = "Passenger updated successfully";
            return ViewDefault("Index", vm, _paxServices.Update(vm));
        }

        // GET: Passengers/Delete
        public async Task<IActionResult> Delete(Guid id)
        {
            var pax = _paxServices.GetById(id);

            return View(pax);
        }

        // POST: Passengers/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(PassengerViewModel vm)
        {
            _paxServices.Remove(vm.Id);
            TempData["success"] = "Passenger deleted successfully";
            return View("Index", _paxServices.GetAll());
        }

        public override void LoadViewBags()
        {
            LoadAsync();
        }
        public async void LoadAsync() { }
    }
}
