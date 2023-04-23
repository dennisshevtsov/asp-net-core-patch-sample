﻿// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace AspNetPatchSample.Book
{
  /// <summary>Represents an identity of a book.</summary>
  public interface IBookIdentity : IIdentity
  {
    /// <summary>Gets an object that represents an ID of a book.</summary>
    public Guid BookId { get; }
  }
}
