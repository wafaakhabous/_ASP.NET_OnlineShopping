using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ModelAsp1.Data;
using ModelAsp1.Models;

namespace ModelAsp1.Pages.Products
{
    public class CreateModel : PageModel
    {
        private readonly ModelAsp1.Data.ModelAsp1Context _context;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public CreateModel(ModelAsp1.Data.ModelAsp1Context context, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Product Product { get; set; }

        [BindProperty]
        public IFormFile ImageFile { get; set; }
        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (ImageFile != null && ImageFile.Length > 0)
            {
                // Generate a unique filename using a timestamp
                var fileName = DateTime.Now.Ticks + Path.GetExtension(ImageFile.FileName);

                var uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");
                var filePath = Path.Combine(uploadsFolder, fileName);

                // Ensure the uploads folder exists
                Directory.CreateDirectory(uploadsFolder);

                // Save the file to the server
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await ImageFile.CopyToAsync(fileStream);
                }

                // Save the file path in your database
                Product.imageUrl = "/images/" + fileName; // Update the path as per your project structure
            }
                _context.Product.Add(Product);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}