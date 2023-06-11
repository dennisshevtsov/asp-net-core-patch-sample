// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.
namespace BookApi.Web.Filters
{
  using Microsoft.AspNetCore.Mvc.Filters;

  /// <summary>Suppresses validation for skipped properties in the PATCH HTTP request.</summary>
  public sealed class SuppressValidationFilter : IActionFilter, IOrderedFilter
  {
    /// <summary>Gets the order value for determining the order of execution of filters. It uses -10000 because filter <see cref="Microsoft.AspNetCore.Mvc.Infrastructure.ModelStateInvalidFilter"/> uses -2000. This filter should be executed first to prevent incorrect calling <see cref="Microsoft.AspNetCore.Mvc.Infrastructure.ModelStateInvalidFilter"/>.</summary>
    public int Order => -10000;

    /// <summary>Called before the action executes, after model binding is complete.</summary>
    /// <param name="context">The <see cref="Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext"/>.</param>
    public void OnActionExecuting(ActionExecutingContext context)
    {
      if (context.HttpContext.Request.Method == HttpMethods.Patch)
      {
        var requestDto = context.ActionArguments.Select(argument => argument.Value)
                                                .FirstOrDefault(argument => argument is IPatchRequestDto);

        if (requestDto != null)
        {
          var properties = ((IPatchRequestDto)requestDto).Properties.ToHashSet();
          var errors     = context.ModelState.Select(error => error.Key)
                                             .Where(error => !properties.Contains(error))
                                             .ToList();

          foreach (var error in errors )
          {
            context.ModelState.Remove(error);
          }
        }
      }
    }

    /// <summary>Called after the action executes, before the action result.</summary>
    /// <param name="context">The <see cref="Microsoft.AspNetCore.Mvc.Filters.ActionExecutedContext"/>.</param>
    public void OnActionExecuted(ActionExecutedContext context) { }
  }
}
