using FileUpload.Models;
using FileUpload.Services;
using FileUpload.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Reflection.Metadata;

namespace FileUpload.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IFileUploadService _uploadService;
        private readonly AppDbContext _context;

        public HomeController(ILogger<HomeController> logger, AppDbContext context, IFileUploadService uploadService)
        {
            _logger = logger;
            _context = context;
            _uploadService = uploadService;
        }

        public IActionResult Index()
        {

            var resutl = _context.Products.ToListAsync().Result;

            return View(resutl);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductVM model)//Model Binding
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Lütfen tüm alanları doğru girdiğinizden emin olun.");
                return View(model);
            }
            Product product = new Product
            {
                Name = model.Name,
                Price = model.Price,
                Description = model.Description,
                CreatedTime = DateTime.Now,
                ModifiedTime = DateTime.Now,

            };
            product.ImageUrl = await _uploadService.UploadFileAsync(model.ImageUrl);
         

            _context.Products.Add(product);

            await _context.SaveChangesAsync();

            return RedirectToAction("index");
        }

    }
}