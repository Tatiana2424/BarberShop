using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.DAL.Entities;

public class Barber
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; }
    
    [StringLength(1000)]
    public string? Description { get; set; }

    [StringLength(500)]
    public string? Position { get; set; }

    public int? Experience { get; set; }

    public int ImageId { get; set; }
    public Image? Image { get; set; }

    public double Rate { get; set; }

    public List<Order> OrederBarber { get; set; }
}
