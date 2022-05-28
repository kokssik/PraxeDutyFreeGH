using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DutyFreePraxe.Models;

public class Users
{
    [Key]
    public int UserID { get; set; }

    public String Name { get; set; }

    public String Email { get; set; }

    public String ImageUrl { get; set; }

    public int Role { get; set; }

    public String Password { get; set; }
}