// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace AspNetPatchSample.Book.Web
{
  using System.Text.Json.Serialization;
  
  using AspNetPatchSample.Web;

  /// <summary>Represents a book DTO base.</summary>
  public abstract class BookRequestDtoBase : IRequestDto, IBookIdentity
  {
    /// <summary>Gets/sets an object that represents an ID of a book.</summary>
    [JsonIgnore]
    public Guid Id { get => BookId; set => BookId = value; }

    /// <summary>Gets an objecct that represents an ID of a book.</summary>
    public Guid BookId { get; set; }
  }
}
