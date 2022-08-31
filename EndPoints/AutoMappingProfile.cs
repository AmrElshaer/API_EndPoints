using AutoMapper;
using EndPoints.DomainModel;
using EndPoints.Endpoints.Customers;

namespace EndPoints
{
    public class AutoMappingProfile : Profile
    {
        public AutoMappingProfile()
        {
            CreateMap<Customer, CustomerDto>();
        }
    }
}
