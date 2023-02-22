using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.DAL.Entities;

public class Order
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public Barber Barber { get; set; }

    [Required]
    public int BarberId { get; set; }

    public User User { get; set; }

    public int UserId { get; set; }

    public Service Service { get; set; }
 
    public int ServiceId { get; set; }

    public Place Place { get; set; }

    public int PlaceId { get; set; }

    [Required]
    [DataType(DataType.Date)]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
    public DateTime date { get; set; }

    [Required]
    public TimeSpan time { get; set; }
}
