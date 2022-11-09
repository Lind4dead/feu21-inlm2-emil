using Inlm_2.Data;
using Inlm_2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Inlm_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly DataContext _context;

        public ProductsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {

                return new OkObjectResult(await _context.Products.ToListAsync());
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return new BadRequestResult();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductRequest req)
        {
            try
            {
                
                var specs = new List<Specification>();
                for (int i = 0; i < req.Specifications.Count; i++)
                {
                    
                    var info = new List<SpecInformation>();
                    foreach (var _row in req.Specifications[i].SpecInfo.ToList())
                    {
                        info.Add(_row);
                        
                    }
                    specs.Add(new Specification
                    {
                        Title = req.Specifications[i].Title,
                        SpecInfo = info
                    });

                }
                
                

                _context.Add(new Product
                {
                    Name = req.Name,
                    ArtNr = req.ArtNr,
                    Price = req.Price,
                    Description = req.Description,
                    Category = req.Category,
                    Specifications = specs

                });
                await _context.SaveChangesAsync();
                return new OkResult();
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return new BadRequestResult();
        }
    }
}
