using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DutyFreePraxe.Models;

public class Products
{
    [Key]
    public int ProductID { get; set; }

    public DateTime DateCreated { get; set; }

    public int CreatedBy { get; set; }

    public DateTime DateUpdated { get; set; }

    public int UpdatedBy { get; set; }

    public bool IsDeleted { get; set; }

    public String? Name { get; set; }

    public int Price { get; set; }

    public int Quantity { get; set; }

    public String? ImageUrl { get; set; }

    [NotMapped]
    public IFormFile? Image { get; set; }


    public ICollection<Orders> Orders { get; set; }
}

