using Ardalis.ApiEndpoints;
using EndPoints.DataAccess;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace EndPoints.Endpoints.Customers
{
    public class UpdateCustomerRequest
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Region { get; set; }
    }
    public class UpdateCustomer : EndpointBaseAsync.WithRequest<UpdateCustomerRequest>.WithResult<int>
    {
        private readonly AppDbContext _appDbContext;

        public UpdateCustomer(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        [HttpPut("customer")]
        public override async Task<int> HandleAsync([FromBody] UpdateCustomerRequest request, CancellationToken cancellationToken = new CancellationToken())
        {
            var customer = await _appDbContext.Customers.FindAsync(request.Id);
            ArgumentNullException.ThrowIfNull(customer);
            customer.Update(request.Name, request.Region);
            await _appDbContext.SaveChangesAsync(cancellationToken);
            return customer.Id;
        }
    }
}
