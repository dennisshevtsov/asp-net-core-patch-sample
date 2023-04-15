// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace AspNetPatchSample.Domain.Entity
{
  /// <summary>Represents a book entity.</summary>
  public interface IBookEntity : IBookIdentity, IBookData
  {
  }
}
