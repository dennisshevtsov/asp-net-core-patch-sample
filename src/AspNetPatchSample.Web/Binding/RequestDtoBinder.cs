// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace AspNetPatchSample.Web.Binding
{
  using Microsoft.AspNetCore.Mvc.ModelBinding;

  /// <summary>Provides a simple API to create an instance of a model from HTTP request.</summary>
  public sealed class RequestDtoBinder : IModelBinder
  {
    /// <summary>Attempts to bind a model.</summary>
    /// <param name="bindingContext">A object that contains operating information for model binding and validation.</param>
    /// <returns>An object that represents an asynchronous operation.</returns>
    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
      return Task.CompletedTask;
    }
  }
}
