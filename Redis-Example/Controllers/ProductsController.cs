using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.CQRS.Products.Commands.CreateProduct;
using Shop.Application.CQRS.Products.Commands.DeleteProduct;
using Shop.Application.CQRS.Products.Commands.UpdateProduct;
using Shop.Application.CQRS.Products.Queries;
using Shop.Application.CQRS.Products.Queries.GetProductById;

namespace Redis_Example.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public sealed class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(
            IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            CreateProductCommand command,
            CancellationToken cancellationToken)
        {
            var result =
                await _mediator.Send(
                    command,
                    cancellationToken);

            if (result.IsFailure)
                return BadRequest(result.Error);

            return Ok(result.Value);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(
             int pageNumber = 1,
             int pageSize = 10,
             CancellationToken cancellationToken = default)
        {
            //await Task.Delay(9000);
            //await Task.Delay(9000, cancellationToken);
            var result =
                await _mediator.Send(
                    new GetProductsQuery(
                        pageNumber,
                        pageSize),
                    cancellationToken);

            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(
            Guid id,
            CancellationToken cancellationToken)
        {
            var result =
                await _mediator.Send(
                    new GetProductByIdQuery(id),
                    cancellationToken);

            return Ok(result);
        }
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(
            Guid id,
            UpdateProductCommand command,
            CancellationToken cancellationToken)
        {
            if (id != command.Id)
                return BadRequest();

            var result =
                await _mediator.Send(
                    command,
                    cancellationToken);

            if (result.IsFailure)
                return BadRequest(result.Error);

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id,CancellationToken cancellationToken)
        {
            var result =
                await _mediator.Send(
                    new DeleteProductCommand(id),
                    cancellationToken);

            if (result.IsFailure)
                return NotFound(result.Error);

            return NoContent();
        }
    }
}
