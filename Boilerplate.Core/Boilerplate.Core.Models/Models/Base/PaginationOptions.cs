namespace Boilerplate.Core.Models.Models.Base;

public class PaginationOptions<Model>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }

    public Model Parameter { get; set; }

    public PaginationOptions()
    {

    }
    public PaginationOptions(int pageNumber, int pageSize)
    {
        PageNumber = pageNumber < 1 ? 1 : pageNumber;
        PageSize = pageSize < 1 ? 2 : pageSize;
    }
}