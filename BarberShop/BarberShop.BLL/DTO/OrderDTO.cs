using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.BLL.DTO;

public class OrderDTO
{
    public int Id { get; set; }

    public BarberDTO Barber { get; set; }

    public int BarberId { get; set; }

    public UserDTO User { get; set; }

    public int UserId { get; set; }

    public ServiceDTO Service { get; set; }

    public int ServiceId { get; set; }

    public PlaceDTO Place { get; set; }

    public int PlaceId { get; set; }

    public DateTime date { get; set; }

    public TimeSpan time { get; set; }
}
