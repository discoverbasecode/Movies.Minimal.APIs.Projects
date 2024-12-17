namespace EndPoint.Minimal.Api.Utils;

public static class QueryableExtensions
{
    public static IQueryable<T> Paginate<T>(this IQueryable<T> query, int pageNumber, int pageSize)
    {
        if (pageNumber < 1) pageNumber = 1;
        if (pageSize < 1) pageSize = 10;

        return query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize);
    }

    public static IQueryable<T> Paginate<T>(this IQueryable<T> query, PaginationParams pagination)
    {
        return query.Paginate(pagination.PageNumber, pagination.PageSize);
    }
}