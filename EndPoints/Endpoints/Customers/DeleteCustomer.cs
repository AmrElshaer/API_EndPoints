using Ardalis.ApiEndpoints;
using EndPoints.DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace EndPoints.Endpoints.Customers
{
    public class DeleteCustomer : EndpointBaseAsync
        .WithRequest<int>
        .WithActionResult
    {
        private readonly AppDbContext _appDbContext;

        public DeleteCustomer(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpDelete("customers/{id}")]
        public override async Task<ActionResult> HandleAsync(int id, CancellationToken cancellationToken = new CancellationToken())
        {
            var customer = await _appDbContext.Customers.FindAsync(id);
            if (customer is null) return NoContent();
            _appDbContext.Customers.Remove(customer);
            await _appDbContext.SaveChangesAsync(cancellationToken);
            return Ok();
        }
    }
}
