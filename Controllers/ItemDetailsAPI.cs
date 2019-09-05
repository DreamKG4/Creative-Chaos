using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MyMVC.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyMVC.Controllers
{
    [Produces("application/json")]
    [Route("api/ItemDetailsAPI")]
    public class ItemDetailsAPI : Controller
    {
        private readonly ApplicationDbContext _context;

        public ItemDetailsAPI(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/values  

        [HttpGet]
        [Route("Details")]
        public IEnumerable<ItemDetails> GetItemDetails()
        {
            return _context.ProductsTB;

        }

        // GET api/values/5  
        [HttpGet]
        [Route("Details/{ItemName}")]
        public IEnumerable<ItemDetails> GetItemDetails(string ItemName)
        {
            return _context.ProductsTB.Where(i => i.Item_Name == ItemName).ToList(); ;  
            
        }
    }
}
