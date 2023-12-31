using System.Collections.Generic;
using System.Linq;
using Assingment01.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Tokens;

namespace Assingment01.Pages.Admin
{
    public class ManageProductsModel : PageModel
    {
        private readonly Prn221Asm1Context _context;

        public ManageProductsModel(Prn221Asm1Context context)
        {
            _context = context;
            ProductInput = new ProductInputModel();
        }
        public List<Product> Products { get; set; }
        public List<Category> Categories { get; set; }
        public List<Supplier> Suppliers { get; set; }

        [BindProperty]
        public ProductInputModel ProductInput { get; set; }

        public IActionResult OnGet()
        {
            var accountId = HttpContext.Session.GetInt32("AccountId");
            if (accountId != null)
            {
                var account = _context.Accounts.FirstOrDefault(a => a.AccountId == accountId);
                if (account.Type.Contains("Staff"))
                {
                    Products = _context.Products.ToList();
                    Categories = _context.Categories.ToList();
                    Suppliers = _context.Suppliers.ToList();
                    return Page();
                }
                else
                {
                    string Message = "Your account is not permitted to edit!";
                    TempData["Mess"] = Message;
                    return RedirectToPage("/login/index");
                }
            }
            else
            {
                string Message = "Your account is not permitted to edit!";
                TempData["Mess"] = Message;
                return RedirectToPage("/login/index");
            }

        }

        public IActionResult OnPostDelete(int productId)
        {
            var product = _context.Products.Find(productId);
            if (product == null)
            {
                string errorMessage = "Product not found!";
                TempData["ErrorMessDelete"] = errorMessage;
                return RedirectToPage();
            }
            else
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
                string Message = "Delete product Succesfully";
                TempData["Mess"] = Message;
                return RedirectToPage();
            }
        }

        public IActionResult OnPostAdd(ProductInputModel productInput)
        {
            if (!ModelState.IsValid)
            {
                string errorMessage = "Some field is not valid!";
                TempData["ErrorMessAdd"] = errorMessage;
                return RedirectToPage();
            }
            else
            {
                Products = _context.Products.ToList();
                int lastId = Products.Max(p => p.ProductId);
                lastId++;
                var product = new Product
                {
                    ProductId = lastId,
                    ProductName = productInput.ProductName,
                    SupplierId = productInput.SupplierId,
                    CategoryId = productInput.CategoryId,
                    UnitPrice = productInput.UnitPrice,
                    ProductImage = productInput.ProductImage
                };

                _context.Products.Add(product);
                _context.SaveChanges();

                string Message = "Add new product Succesfully";
                TempData["Mess"] = Message;

                return RedirectToPage("/Admin/ManageProduct");
            }

        }

        public IActionResult OnPostUpdate()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var product = _context.Products.Find(ProductInput.ProductId);
            if (product == null)
            {
                string errorMessage = "Product not found!";
                TempData["ErrorMessUpdate"] = errorMessage;
                return RedirectToPage();
            }

            product.ProductName = ProductInput.ProductName;
            product.SupplierId = ProductInput.SupplierId;
            product.CategoryId = ProductInput.CategoryId;
            product.UnitPrice = ProductInput.UnitPrice;
            product.ProductImage = ProductInput.ProductImage;

            _context.SaveChanges();

            return RedirectToPage();
        }
    }

    public class ProductInputModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int SupplierId { get; set; }
        public int CategoryId { get; set; }
        public decimal UnitPrice { get; set; }
        public string ProductImage { get; set; }
    }
}