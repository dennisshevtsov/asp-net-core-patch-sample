// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace AspNetPatchSample.Infrastructure.Entity
{
  using AspNetPatchSample.Domain.Entity;

  /// <summary>Represents an author entity.</summary>
  public sealed class AuthorEntity : IAuthorEntity
  {
    /// <summary>Initializes a new instance of the <see cref="AspNetPatchSample.Infrastructure.Entity.AuthorEntity"/> class.</summary>
    public AuthorEntity()
    {
      Name = string.Empty;
    }

    /// <summary>Gets an object that represents an ID of author.</summary>
    public Guid AuthorId { get; }

    /// <summary>Gets an object that represents a name of an author.</summary>
    public string Name { get; }
  }
}
