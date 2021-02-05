using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json.Linq;

namespace Books.API.Filters.MappingFilters
{
    public class BooksResultFilter : ResultFilterAttribute
    {
        public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            var resultFromAction = context.Result as ObjectResult;
            if (resultFromAction?.Value != null && !(resultFromAction.StatusCode < 200) &&
                !(resultFromAction.StatusCode >= 300))
            {
                if (resultFromAction.Value is IEnumerable)
                {
                    resultFromAction.Value = resultFromAction.Value.Adapt<IEnumerable<Models.BookDto>>();
                }
            }
            await next();
        }
    }
}
