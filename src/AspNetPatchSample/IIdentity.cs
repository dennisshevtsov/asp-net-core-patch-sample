// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace AspNetPatchSample
{
  /// <summary>Represents an identity.</summary>
  public interface IIdentity
  {
    /// <summary>Gets an object that represents a GUID representation of this identity.</summary>
    public Guid Id { get; }
  }
}
