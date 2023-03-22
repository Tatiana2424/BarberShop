using AutoMapper;
using BarberShop.BLL.DTO;
using BarberShop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.BLL.Mapping;

public class ServiceProfile: Profile
{
    public ServiceProfile()
    {
        CreateMap<Service, ServiceDTO>().ReverseMap();
           // .ForPath(dto => dto.Image.de, conf => conf.MapFrom(ol => ol.A))
    }
}
