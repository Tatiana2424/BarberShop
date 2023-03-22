using BarberShop.BLL.DTO;
using BarberShop.DAL.Entities;
using AutoMapper;

namespace BarberShop.BLL.Mapping;

public class CategoryProfile: Profile
{
    public CategoryProfile()
    {
        CreateMap<Category, CategoryDTO>().ReverseMap();
    }
}
