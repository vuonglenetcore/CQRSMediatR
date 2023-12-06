using CQRSMediatR.Commands;
using CQRSMediatR.Models;
using CQRSMediatR.Notifications;
using CQRSMediatR.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CQRSMediatR.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly IPublisher _publisher;

        public ProductsController(ISender sender, IPublisher publisher)
        {
            _sender = sender;
            _publisher = publisher;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = _sender.Send(new GetProductsQuery());
            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product)
        {
            await _sender.Send(new AddProductCommand(product));
            await _publisher.Publish(new ProductAddNotification(product));
            return StatusCode(201);
        }

        [HttpGet("getProductById/{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _sender.Send(new GetProductByIdQuery(id));
            return Ok(product);
        }
    }
}