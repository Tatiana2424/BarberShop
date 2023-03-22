using AutoMapper;
using BarberShop.BLL.DTO;
using BarberShop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.BLL.Mapping;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserDTO>().ReverseMap();

        CreateMap<UserDTO, User>().ReverseMap();
    }
}
