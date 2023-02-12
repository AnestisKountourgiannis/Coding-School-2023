using CoffeeShop.EF.Repositories;
using CoffeeShop.Model;
using CoffeeShop.MVC.Models.Product;
using CoffeeShop.MVC.Models.ProductCategory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShop.MVC.Controllers {
    

    public class ProductController : Controller {
        private IEntityRepo<Product> _prodRepo;
        private IEntityRepo<ProductCategory> _categoryRepo;
        public ProductController(IEntityRepo<Product> prodRepo , IEntityRepo<ProductCategory> prodCatRepo) {
            _prodRepo = prodRepo;
            _categoryRepo = prodCatRepo;
        }
        #region Index
        // GET: ProductController
        public ActionResult Index() {
            var prod = _prodRepo.GetAll();
            var products = prod.ToList();
            return View(model:products) ;
        }
        #endregion
        #region Details
        // GET: ProductController/Details/5
        public ActionResult Details(int id) {
            var prod = _prodRepo.GetById(id);
            if (id == null) {
                return NotFound();
            }
            if (prod == null) {
                return NotFound();
            }
            var viewProduct = new ProductDetailsDto {
               Id = prod.Id,
               Cost = prod.Cost,
               Price= prod.Price,
               Code= prod.Code,
               Description= prod.Description,
               ProductCategory= _categoryRepo.GetById(prod.ProductCategoryId)  
            };
            return View(model: viewProduct);
           
        }
        #endregion
        #region Create
        // GET: ProductController/Create
        public ActionResult Create() {
            var newProduct = new ProductCreateDto();
            var prodCats =_categoryRepo.GetAll();
            foreach (var cat in prodCats) {
                newProduct.ProductCategories.Add(new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem(cat.Code, cat.Id.ToString()));
            }

            return View(model:newProduct);
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductCreateDto product) {
            if (!ModelState.IsValid) {
                return View();
            }
            var dbProduct = new Product(product.Code,product.Description,product.Price,product.Cost);
            dbProduct.ProductCategoryId = product.ProductCategoryId;
            _prodRepo.Create(dbProduct);
            return RedirectToAction("Index");
        }
        #endregion
        #region Edit
        // GET: ProductController/Edit/5
        public ActionResult Edit(int id) {
            var dbProduct = _prodRepo.GetById(id);
            if(dbProduct == null) {
                return NotFound();
            }
            var prodCats = _categoryRepo.GetAll();
            var editProduct = new ProductEditDto {
                Id = dbProduct.Id    
            };
            foreach (var cat in prodCats) {
                editProduct.ProductCategories.Add(new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem(cat.Code, cat.Id.ToString()));
            }
            return View(model:editProduct);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProductEditDto product) {
            if (!ModelState.IsValid) {
                return View();
            }
            var dbProduct = new Product(product.Code, product.Description, product.Price, product.Cost);
            dbProduct.ProductCategoryId = product.ProductCategoryId;
            _prodRepo.Update(product.Id,dbProduct);
            return RedirectToAction("Index");
        }
        #endregion
        #region Delete
        // GET: ProductController/Delete/5
        public ActionResult Delete(int id) {
            var dbProduct = _prodRepo.GetById(id);
            if (dbProduct == null) {
                return NotFound();
            }
            var viewProduct = new ProductDeleteDto {
                Id = dbProduct.Id,
                Description = dbProduct.Description,
                Code = dbProduct.Code,
                Price = dbProduct.Price,
                Cost= dbProduct.Cost,
                ProductCategory = _categoryRepo.GetById(dbProduct.ProductCategoryId)
            };
            return View(model: viewProduct);
        }

        // POST: ProductCategoryCustomer/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection) {
            _prodRepo.Delete(id);
            return RedirectToAction(nameof(Index));

        }
        #endregion
    }
}
