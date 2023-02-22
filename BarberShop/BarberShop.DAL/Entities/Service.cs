using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.DAL.Entities;

public class Service
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; }
    [Required]
    [StringLength(1000)]
    public string Description { get; set; }

    public int ImageId { get; set; }

    public Image Image { get; set; }

    [Required]
    public int Price { get; set; }

    [Required]
    public TimeSpan TimeToMake { get; set; }

    public Category Category { get; set; }
  
    [Required]
    public int CategoryId { get; set; }

    public List<Order> ServiceOrder { get; set; }
}
