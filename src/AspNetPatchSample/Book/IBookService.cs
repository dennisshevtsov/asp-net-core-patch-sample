// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace AspNetPatchSample.Book
{
  /// <summary>Represents a simple API to operate instances of the <see cref="AspNetPatchSample.Book.IBookEntity"/>.</summary>
  public interface IBookService : IService<IBookEntity, IBookIdentity>
  {
  }
}
