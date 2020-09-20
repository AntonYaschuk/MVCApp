using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryMVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChartsController : ControllerBase
    {
        private readonly DBLibraryContext _context;
        public ChartsController(DBLibraryContext context)
        {
            _context = context;
        }
        [HttpGet("JsonData")]
        public JsonResult JsonData()
        {
        var categories = _context.Categories.Include(b => b.Books).ToList();
            List<object> catBook = new List<object>();
            catBook.Add(new[] { "Категорія", "Кількість книжок" });
            foreach (var c in categories)
            {
                catBook.Add(new object[] { c.Name, c.Books.Count() });
            }
            return new JsonResult(catBook);
        }
    }
}
