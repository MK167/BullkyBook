using BullkyBookWeb.DataContext;
using BullkyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BullkyBookWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public CategoryController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        //Get All Data
        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _applicationDbContext.Categories.Where(x => x.IsDeleted == false);
            //Category objCategoryList1 = _applicationDbContext.Categories.FirstOrDefault(x => x.IsDeleted == false);
            return View(objCategoryList);
        }

        //Create Method
        public IActionResult Create()
        {
            return View();
        }

        //Add Data And Save 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            //Validation in HTML
            if (obj.CategoryName == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("CategoryName", "The DisplayOrder cannot exactly match the Name");
            }
            if (ModelState.IsValid)
            {
                _applicationDbContext.Add(obj);
                _applicationDbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(obj);
            }
        }

        //Edit Data and Save
        public IActionResult Edit(int? ID)
        {
            if (ID == null || ID == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _applicationDbContext.Categories.Find(ID);
            //var categoryFromDbFirst = _applicationDbContext.Categories.FirstOrDefault(u => u.ID == ID);
            //var categoryFromDbSingle = _applicationDbContext.Categories.SingleOrDefault(u => u.ID == ID);

            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        //Edit Data And Save 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            //Validation in HTML
            if (obj.CategoryName == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("CategoryName", "The DisplayOrder cannot exactly match the Name");
            }
            if (ModelState.IsValid)
            {
                _applicationDbContext.Update(obj);
                _applicationDbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(obj);
            }
        }


        //Delete Data and Save
        public IActionResult Delete(int? ID)
        {
            if (ID == null || ID == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _applicationDbContext.Categories.Find(ID);
            //var categoryFromDbFirst = _applicationDbContext.Categories.FirstOrDefault(u => u.ID == ID);
            //var categoryFromDbSingle = _applicationDbContext.Categories.SingleOrDefault(u => u.ID == ID);

            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        //Delete Data And Save 
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? ID)
        {
            var obj = _applicationDbContext.Categories.Find(ID);
            if (obj == null)
            {
                return NotFound();

            }
            var entity = _applicationDbContext.Categories.FirstOrDefault(u => u.ID == ID);
            entity.IsDeleted = true;
            //_applicationDbContext.Remove(entity);
            _applicationDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    
    }
}
