// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace AspNetPatchSample.Book.Web
{
  /// <summary>Represents data to delete a book.</summary>
  public sealed class DeleteBookRequestDto : BookRequestDtoBase, IBookIdentity
  {
  }
}
