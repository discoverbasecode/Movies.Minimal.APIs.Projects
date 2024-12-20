namespace EndPoint.Minimal.Api.Utils;

public class PaginationParams
{
    private int _pageNumber = 1;
    private int _pageSize = 10;

    private const int MaxPageSize = 100;

    public int PageNumber
    {
        get => _pageNumber;
        set => _pageNumber = value < 1 ? 1 : value;
    }

    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = value < 1 ? 1 : (value > MaxPageSize ? MaxPageSize : value);
    }
}