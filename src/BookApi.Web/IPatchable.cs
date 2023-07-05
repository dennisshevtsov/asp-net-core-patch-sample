// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace BookApi.Web;

/// <summary>Represents a PATCH request DTO base.</summary>
public interface IPatchable
{
  /// <summary>Gets an object that represents a collection of properties to update.</summary>
  public IEnumerable<string> Properties { get; set; }
}
