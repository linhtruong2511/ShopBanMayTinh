using SellComputer.Models.Entities;

public class CategoryResponse : Category
{
    public CategoryResponse(Category category, int totalCountProduct)
    {
        this.Id = category.Id;
        this.Computers = category.Computers;
        this.Name = category.Name;
        this.CreateAt = category.CreateAt;
        this.TotalCountComputer = totalCountProduct;
    } 
    public int TotalCountComputer { get; set; }
}