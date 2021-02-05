using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;
using Mapster;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Books.API.Filters.MappingFilters
{
    public class BookResultFilter : ResultFilterAttribute
    {
        public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            var mapper = context.HttpContext.RequestServices.GetRequiredService<IMapper>();
            var resultFromAction = context.Result as ObjectResult;
            if (resultFromAction?.Value != null && !(resultFromAction.StatusCode < 200) &&
                !(resultFromAction.StatusCode >= 300))
            {
                resultFromAction.Value =
                    await mapper.From(resultFromAction.Value).AdaptToTypeAsync<Models.BookDto>();
            }
            await next();
        }
    }
}
