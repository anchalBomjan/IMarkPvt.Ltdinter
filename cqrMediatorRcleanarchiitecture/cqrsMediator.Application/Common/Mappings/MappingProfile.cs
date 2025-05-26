using AutoMapper;
using cqrsMediator.Application.DTOs;
using cqrsMediator.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cqrsMediator.Application.Common.Mappings
{
    public  class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Developer, DeveloperDTO>()
            .ForMember(dest => dest.Address,
                      opt => opt.MapFrom(src => src.Address));
            CreateMap<Address, AddressDTO>();

        }
            
    }
}
