// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace AspNetPatchSample.Book.Web
{
  /// <summary>Represents data to delete a book.</summary>
  public sealed class DeleteBookRequestDto : IBookIdentity
  {
    /// <summary>Gets an object that represents an ID of a book.</summary>
    public Guid BookId { get; set; }

    /// <summary>Converts this object to an instance of the <see cref="System.Guid"/>.</summary>
    /// <returns>An object that represents a Globally Unique Identifier.</returns>
    public Guid ToGuid() => BookId;
  }
}
