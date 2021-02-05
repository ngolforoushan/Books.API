using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Books.API.Filters.MappingFilters
{
    public class BooksResultFilter : ResultFilterAttribute
    {
        public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            var mapper = context.HttpContext.RequestServices.GetRequiredService<IMapper>();

            var resultFromAction = context.Result as ObjectResult;
            if (resultFromAction?.Value != null && !(resultFromAction.StatusCode < 200) &&
                !(resultFromAction.StatusCode >= 300))
            {
                if (resultFromAction.Value is IEnumerable)
                {
                    resultFromAction.Value =
                        await mapper.From(resultFromAction.Value)
                        .AdaptToTypeAsync<IEnumerable<Models.BookDto>>();
                }
            }
            await next();
        }
    }
}
