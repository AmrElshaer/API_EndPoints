using Ardalis.ApiEndpoints;
using EndPoints.DataAccess;
using EndPoints.DomainModel;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace EndPoints.Endpoints.Customers
{
    public class CreatCustomer
    {
        [Required]
        public string Name { get; set; }
        public string Region { get; set; }
    }
    public class AddCustomer : EndpointBaseAsync.WithRequest<CreatCustomer>.WithResult<int>
    {
        private readonly AppDbContext _appDbContext;

        public AddCustomer(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        [HttpPost("customer")]
        public override async Task<int> HandleAsync([FromBody] CreatCustomer request, CancellationToken cancellationToken = new CancellationToken())
        {
            var customer = Customer.Create(request.Name, request.Region);
            _appDbContext.Customers.Add(customer);
            await _appDbContext.SaveChangesAsync(cancellationToken);
            return customer.Id;
        }
    }
}
