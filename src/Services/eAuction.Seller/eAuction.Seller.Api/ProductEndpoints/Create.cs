using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace eAuction.Seller.Api.ProductEndpoints
{
    public class Create : BaseAsyncEndpoint
       .WithRequest<AddProductCommand>
       .WithResponse<AddProductResult>
    {


        public Create()
        {

        }

        [HttpPost(AddProductCommand.ROUTE)]
        [SwaggerOperation(
            Summary = "Creates a new Product",
            Description = "Creates a new Product",
            OperationId = "Product.Create",
            Tags = new[] { "ProductEndpoints" })
        ]
        public override async Task<ActionResult<AddProductResult>> HandleAsync([FromBody] AddProductCommand request, CancellationToken cancellationToken)
        {
            return Ok("ok");
        }
    }
}
