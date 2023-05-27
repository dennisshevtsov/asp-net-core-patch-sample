// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace AspNetPatchSample.Book
{
  /// <summary>Provides a simple API to store instances of the <see cref="Domain.Entity.IBookEntity"/>.</summary>
  public interface IBookRepository : IRepository<IBookEntity, IBookIdentity>
  {
  }
}
