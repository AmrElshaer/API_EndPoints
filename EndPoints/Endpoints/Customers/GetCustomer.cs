using Ardalis.ApiEndpoints;
using AutoMapper;
using EndPoints.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EndPoints.Endpoints.Customers
{
    public class GetCustomer : EndpointBaseAsync
        .WithRequest<int>
        .WithActionResult<CustomerDto>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public GetCustomer(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet("customers/{id}")]
        public override async Task<ActionResult<CustomerDto>> HandleAsync(int id, CancellationToken cancellationToken = new CancellationToken())
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Id == id, cancellationToken: cancellationToken);
            if (customer is null) return NotFound();
            return _mapper.Map<CustomerDto>(customer);
        }
    }
}
