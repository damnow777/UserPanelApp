using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users_Kurs_API.Entities;
using Users_Kurs_API.Models;

namespace Users_Kurs_API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>()
            .ForMember(m => m.City, x => x.MapFrom(s => s.Address.City))
            .ForMember(m => m.Street, x => x.MapFrom(s => s.Address.Street))
            .ForMember(m => m.PostalCode, x => x.MapFrom(s => s.Address.PostalCode));

            CreateMap<CreateUserDto, User>()
                .ForMember(r => r.Address, x => x.MapFrom(dto => new Address
                {
                    City = dto.City,
                    Street = dto.Street,
                    PostalCode = dto.PostalCode
                }
                ));

            //CreateMap<Address, AddressDto>()
            //    .ForMember(x => x.Name, z => z.MapFrom(s => s.User.Name))
            //    .ForMember(x => x.Lastname, z => z.MapFrom(s => s.User.Lastname));
        }
    }
}
