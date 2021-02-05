using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;
using Mapster;

namespace Books.API.Filters.MappingFilters
{
    public class BookResultFilter : ResultFilterAttribute
    {
        public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            var resultFromAction = context.Result as ObjectResult;
            if (resultFromAction?.Value != null && !(resultFromAction.StatusCode < 200) &&
                !(resultFromAction.StatusCode >= 300))
            {
                resultFromAction.Value = resultFromAction.Value.Adapt<Models.BookDto>();
            }
            await next();
        }
    }
}
