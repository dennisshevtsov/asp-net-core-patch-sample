// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using BookApi.Web;

namespace BookApi.Book.Web;

/// <summary>Represents data to delete a book.</summary>
public sealed class DeleteBookRequestDto : IRequestDto, IBookIdentity
{
  /// <summary>Gets an objecct that represents an ID of a book.</summary>
  public Guid BookId { get; set; }
}
