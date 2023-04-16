// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace AspNetPatchSample.WebApi.Dtos
{
  using Microsoft.AspNetCore.Mvc;

  using AspNetPatchSample.Domain.Entity;

  /// <summary>Represents a condition to query a book.</summary>
  public sealed class GetBookRequestDto : IBookIdentity
  {
    /// <summary>Gets an object that represents an ID of a book.</summary>
    [FromRoute]
    public Guid BookId { get; }
  }
}
