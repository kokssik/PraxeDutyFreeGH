using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DutyFreePraxe.Models;

public class Orders
{
    [Key]
    public int OrderID { get; set; }

    public DateTime DateCreated { get; set; }

    public String? Name { get; set; }

    public int Price { get; set; }

    public int UserID { get; set; }

    public int ProductID { get; set; }
}