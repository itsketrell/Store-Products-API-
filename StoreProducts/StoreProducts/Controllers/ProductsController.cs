using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace StoreProducts.Controllers
{
    [ApiController]
    [Route("api/Products")]
    public class ProductsController : ControllerBase
    {
        private static List<Products> storeProducts = new List<Products>
            {
            new Products {  ProductId = 1, ProductName = "Burger", Category = "Food", Price = 15},
            new Products {  ProductId = 2, ProductName = "Pasta", Category = "Food", Price = 25},
            new Products {  ProductId = 3, ProductName = "Pizza", Category = "Food", Price = 10},
            new Products {  ProductId = 4, ProductName = "Chicken", Category = "Food", Price = 8},
            new Products {  ProductId = 5, ProductName = "French Fries", Category = "Food", Price = 7},
            new Products {  ProductId = 6, ProductName = "Engine", Category = "Transportation", Price = 1500},
            new Products {  ProductId = 7, ProductName = "Cold Air Intake", Category = "Transportation", Price = 110},
            new Products {  ProductId = 8, ProductName = "Upper Pulley", Category = "Transportation", Price = 350},
            new Products {  ProductId = 9, ProductName = "WindShield Wipers", Category = "Transportation", Price = 15},
            new Products {  ProductId = 10, ProductName = "Headlights", Category = "Transportation", Price = 200},
            new Products {  ProductId = 11, ProductName = "Xbox", Category = "Electronics", Price = 300},
            new Products {  ProductId = 12, ProductName = "PlayStation 5", Category = "Electronics", Price = 500},
            new Products {  ProductId = 13, ProductName = "IPhone", Category = "Electronics", Price = 1350},
            new Products {  ProductId = 14, ProductName = "PC", Category = "Electronics", Price = 1000},
            new Products {  ProductId = 15, ProductName = "Monitor", Category = "Electronics", Price = 200},

            };
        
        [HttpGet]
   
        public ActionResult<List<Products>> GetProducts()
        {
            if (GetProducts == null)
            {
                return NotFound("Product Does Not Exist");
            }
            else return Ok(storeProducts);
        }
        [HttpGet("{id}")]
        public ActionResult<List<Products>> GetProduct(int id)
        {
            var storeProduct = storeProducts.Find(p => p.ProductId == id);
            if (storeProduct == null)
                return BadRequest("Product Does Not Exist");
            return Ok(storeProduct);
        }
        [HttpPost]
        public ActionResult<List<Products>> AddProducts(Products product)
        {
            if (storeProducts == null)
                return NotFound("Product Does Not Exist");

            storeProducts.Add(product);
            return Ok(product);
        }
        [HttpPut]
        public ActionResult<List<Products>> UpdateProduct(Products request)
        {
            var storeProduct = storeProducts.Find(p => p.ProductId == request.ProductId);
            if (storeProduct == null)
                return BadRequest("Product Does Not Exist");

            storeProduct.ProductName = request.ProductName;
            storeProduct.ProductId = request.ProductId;
            storeProduct.Category = request.Category;
            storeProduct.Price = request.Price;
            return Ok(storeProduct);
        }
        [HttpDelete("{id}")]
        public ActionResult<List<Products>> DeleteProduct(int id)
        {
            var storeProduct = storeProducts.Find(p => p.ProductId == id);
            if (storeProduct == null)
                return BadRequest("Product Does Not Exist");

            storeProducts.Remove(storeProduct);
            return Ok(storeProduct);
        }

    }
}