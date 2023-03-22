using AutoMapper;
using BarberShop.BLL.DTO;
using BarberShop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.BLL.Mapping;

public class OrderProfile: Profile
{
    public OrderProfile() 
    {
        CreateMap<Order, OrderDTO>().ReverseMap();
    }
}
