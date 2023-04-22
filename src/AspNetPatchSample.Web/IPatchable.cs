// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace AspNetPatchSample.Web
{
  /// <summary>Represents an entity that can be updated partially.</summary>
  public interface IPatchable
  {
    /// <summary>Gets an object that represents a collection of properties to update.</summary>
    public string[] Properties { get; }
  }
}
