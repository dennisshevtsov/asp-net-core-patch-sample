// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace AspNetPatchSample.Web
{
  using System.Text.Json.Serialization;

  /// <summary>Represents a PATCH request DTO base.</summary>
  public abstract class PatchRequestDtoBase : RequestDtoBase
  {
    /// <summary>Initializes a new instance of the <see cref="AspNetPatchSample.Web.PatchRequestDtoBase"/> class.</summary>
    public PatchRequestDtoBase()
    {
      Properties = Array.Empty<string>();
    }

    /// <summary>Gets an object that represents a collection of properties to update.</summary>
    [JsonIgnore]
    public IEnumerable<string> Properties { get; internal set; }
  }
}
