namespace dutyfreeButReact;

public class Products
{
    public int ProductID { get; set; }

    public DateTime DateCreated { get; set; }

    public int CreatedBy { get; set; }
    
    public DateTime DateUpdated { get; set; }
    
    public int UpdatedBy { get; set; }
    
    public bool IsDeleted { get; set; }
    
    public String Name { get; set; }
    
    public int Price { get; set; }
    
    public int Quantity { get; set; }
    
    public String ImageUrl { get; set; }
    
    public IFormFile Image { get; set; }
}

