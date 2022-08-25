using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace jago.UI.Controllers.Core
{
    public abstract class BaseController<TViewModel> : Controller where TViewModel : class, new()
    {

        public abstract IEnumerable<TViewModel> GetRows();
        public abstract TViewModel GetRow(Guid id);

        public abstract void LoadViewBags();

        protected IActionResult ViewDefault(string action, TViewModel vm, ValidationResult validationResult)
        {
            LoadViewBags();
            if (!ModelState.IsValid)
                return View(vm);

            if (validationResult.Errors.Count > 0)
            {
                foreach (var error in validationResult.Errors)
                {
                    AddError(error.PropertyName, error.ErrorMessage);
                }
                return View(vm);
            }
            else
            {
                return RedirectToAction(action);
            }
        }
        //protected IActionResult ViewForm(Guid id)
        //{
        //    LoadViewBags();

        //    if (id == Guid.Empty)
        //        return View(new TViewModel());
        //    else
        //        return View(GetRow(id));
        //}

        private void AddError(string propertyName, string errorMessage)
        {
            throw new NotImplementedException();
        }
    }

}
