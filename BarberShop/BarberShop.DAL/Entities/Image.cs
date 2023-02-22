using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations; 

namespace BarberShop.DAL.Entities;

[Table("images", Schema = "media")]
public class Image
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [MaxLength(100)]
    public string? Title { get; set; }

    [MaxLength(100)]
    public string? Alt { get; set; }

    [Required]
    public string Url { get; set; }

    public List<Category> CategoryImages { get; set; }

    public List<Service> ServiceImages { get; set; }

    public List<Barber> BarberImages { get; set; }

}
