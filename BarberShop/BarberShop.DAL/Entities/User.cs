using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BarberShop.DAL.Entities;

public class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [StringLength(30)]
    public string Username { get; set; }

    [Required]
    [StringLength(500)]
    public string Password { get; set; }

    [Required]
    [StringLength(45)]
    [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
    public string Email { get; set; }

    [StringLength(45)]
    public string Name { get; set; }

    [StringLength(45)]
    public string Surname { get; set; }

    public Status Status { get; set; }
   
    [Required]
    public int statusId { get; set; }

    public List<Order>? UserOrder { get; set; }
}
