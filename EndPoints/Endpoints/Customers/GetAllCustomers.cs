using Ardalis.ApiEndpoints;
using AutoMapper;
using EndPoints.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EndPoints.Endpoints.Customers
{
    public class GetAllCustomers : EndpointBaseAsync
        .WithoutRequest.WithResult<IEnumerable<CustomerDto>>
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper mapper;
        public GetAllCustomers(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            this.mapper = mapper;
        }
        [HttpGet("customers")]
        public override async Task<IEnumerable<CustomerDto>> HandleAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return await _appDbContext.Customers.Select(i => mapper.Map<CustomerDto>(i)).ToListAsync(cancellationToken);
        }
    }
}
