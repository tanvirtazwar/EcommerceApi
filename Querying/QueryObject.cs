namespace EcommerceApi.Querying;

public class QueryObject
{
    public string Name { get; set; } = null!;
    public string BrandName { get; set; } = null!;
    public string Color { get; set; } = null!;
    public string Ram { get; set; } = null!;
    public string Rom { get; set; } = null!;
    public int? CameraMp { get; set; } = null;
    public decimal? Price { get; set; } = null;
    public string? SortBy { get; set; } = null;
    public bool IsDescending { get; set; } = false;
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}