using Microsoft.EntityFrameworkCore;

namespace EndPoint.Minimal.Api.Utils;

public static class HttpContextExtensions
{
    public static async Task InsertPaginationParameterResponseHeader<T>(this HttpContext context, IQueryable<T> query)
    {
        var totalCount = await query.CountAsync();
        context.Response.Headers.Append("X-Total-Count", totalCount.ToString());
    }
}