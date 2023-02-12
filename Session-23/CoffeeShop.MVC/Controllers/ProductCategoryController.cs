using CoffeeShop.EF.Repositories;
using CoffeeShop.Model;
using CoffeeShop.MVC.Models.ProductCategory;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShop.MVC.Controllers {
    public class ProductCategoryController : Controller {
        private IEntityRepo<ProductCategory> _prodCatRepo;
        public ProductCategoryController(IEntityRepo<ProductCategory> prodCatRepo) {
            _prodCatRepo = prodCatRepo;
        }
        #region Index
        // GET: ProductCategoryCustomer
        public ActionResult Index() {
            var prodCats = _prodCatRepo.GetAll();
            var prodCategories = prodCats.ToList();
            return View(model: prodCategories);
        }
        #endregion
        #region Details
        // GET: ProductCategoryCustomer/Details/5
        public ActionResult Details(int? id) {
            var prodCat = _prodCatRepo.GetById(id.Value);
            if (id == null) {
                return NotFound();
            }
            if (prodCat == null) {
                return NotFound();
            }
            var viewProductCategory = new ProductCategoryDetailsDto {
                Id = prodCat.Id,
                Description = prodCat.Description,
                Code = prodCat.Code,
                ProductType = prodCat.ProductType 
            };
            return View(model: viewProductCategory);
        }
        #endregion
        #region create
        // GET: ProductCategoryCustomer/Create
        public ActionResult Create() {
            var newProductCategory = new ProductCategoryCreateDto();
            var prodCats = _prodCatRepo.GetAll();
            return View(model:newProductCategory);
            
        }

            // POST: ProductCategoryCustomer/Create
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Create(ProductCategoryCreateDto prodcat) {
            if (!ModelState.IsValid) {
                return View();
            }
            var dbProductCategory = new ProductCategory(prodcat.Code, prodcat.Description, prodcat.ProductType);
            _prodCatRepo.Create(dbProductCategory);
            try {
                    
                    return RedirectToAction(nameof(Index));
                }
                catch {
                    return View();
                }
            }
        #endregion
        #region Edit
        // GET: ProductCategoryCustomer/Edit/5
        public ActionResult Edit(int id) {
            if (id == null) {
                return NotFound();
            }
            var dbProductCategory = _prodCatRepo.GetById(id);
            if (dbProductCategory == null) {
                return NotFound();
            }
            var viewProductCategory =new ProductCategoryEditDto {
            Id = dbProductCategory.Id };
            return View(model: viewProductCategory);
            }

            // POST: ProductCategoryCustomer/Edit/5
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Edit(int id, ProductCategoryEditDto productCategory) {
            if (!ModelState.IsValid) {
                return View();
            }
            var dbProductCategory = _prodCatRepo.GetById(id);
            if (dbProductCategory == null) {
                return NotFound();
            }
            dbProductCategory.Code = productCategory.Code;
            dbProductCategory.Description = productCategory.Description;
            dbProductCategory.ProductType = productCategory.ProductType;
            _prodCatRepo.Update(id,dbProductCategory);
            return RedirectToAction(nameof(Index));
    }
        #endregion
        #region Delete
        // GET: ProductCategoryCustomer/Delete/5
        public ActionResult Delete(int id) {
                var dbProductCategory = _prodCatRepo.GetById(id);
                if (dbProductCategory == null) {
                    return NotFound();
                }
                var viewProductCategory = new ProductCategoryDeleteDto {
                    Id = dbProductCategory.Id,
                    Description = dbProductCategory.Description,
                    Code = dbProductCategory.Code
                };
                return View(model: viewProductCategory);
            }

            // POST: ProductCategoryCustomer/Delete/5
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Delete(int id, IFormCollection collection) {
                _prodCatRepo.Delete(id);
                return RedirectToAction(nameof(Index));

            }
        #endregion
    }
} 

