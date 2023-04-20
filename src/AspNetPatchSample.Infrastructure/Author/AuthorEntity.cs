// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace AspNetPatchSample.Author.Infrastructure
{
  /// <summary>Represents an author entity.</summary>
  public sealed class AuthorEntity : IAuthorEntity
  {
    /// <summary>Initializes a new instance of the <see cref="AspNetPatchSample.Author.Infrastructure.AuthorEntity"/> class.</summary>
    public AuthorEntity()
    {
      Name = string.Empty;
    }

    /// <summary>Initializes a new instance of the <see cref="AspNetPatchSample.Author.Infrastructure.AuthorEntity"/> class.</summary>
    /// <param name="authorData">An object that represents author data.</param>
    public AuthorEntity(IAuthorData authorData)
    {
      Name = authorData.Name;
    }

    /// <summary>Initializes a new instance of the <see cref="AspNetPatchSample.Author.Infrastructure.AuthorEntity"/> class.</summary>
    /// <param name="authorEntity">An object that represents an author entity.</param>
    public AuthorEntity(IAuthorEntity authorEntity) : this((IAuthorData)authorEntity)
    {
      AuthorId = authorEntity.AuthorId;
    }

    /// <summary>Gets an object that represents an ID of author.</summary>
    public Guid AuthorId { get; }

    /// <summary>Gets an object that represents a name of an author.</summary>
    public string Name { get; }
  }
}
