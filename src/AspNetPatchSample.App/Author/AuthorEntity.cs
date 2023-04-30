// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace AspNetPatchSample.Author.App
{
  using AspNetPatchSample.App;

  /// <summary>Represents an author entity.</summary>
  public sealed class AuthorEntity : IAuthorEntity, IUpdatable<IAuthorEntity>, IPatchable
  {
    /// <summary>Initializes a new instance of the <see cref="AspNetPatchSample.Author.App.AuthorEntity"/> class.</summary>
    public AuthorEntity()
    {
      Name       = string.Empty;
      Properties = Array.Empty<string>();
    }

    /// <summary>Initializes a new instance of the <see cref="AspNetPatchSample.Author.App.AuthorEntity"/> class.</summary>
    /// <param name="authorEntity">An object that represents an author entity.</param>
    public AuthorEntity(IAuthorEntity authorEntity) : this()
    {
      Name     = authorEntity.Name;
      AuthorId = authorEntity.AuthorId;
    }

    /// <summary>Gets an object that represents an ID of author.</summary>
    public Guid AuthorId { get; }

    /// <summary>Gets an object that represents a name of an author.</summary>
    public string Name { get; private set; }

    /// <summary>Converts this object to an instance of the <see cref="System.Guid"/>.</summary>
    /// <returns>An object that represents a Globally Unique Identifier.</returns>
    public Guid ToGuid() => AuthorId;

    /// <summary>Gets an object that represents a collection of properties to update.</summary>
    public string[] Properties { get; private set; }

    /// <summary>Updates this author.</summary>
    /// <param name="newAuthorEntity">An object that represents an author entity from which this author should be updated.</param>
    /// <returns>A reference of this entity.</returns>
    public IAuthorEntity Update(IAuthorEntity newAuthorEntity)
    {
      Name       = newAuthorEntity.Name;
      Properties = new[] {nameof(Name)};

      return this;
    }

    /// <summary>Updates this author.</summary>
    /// <param name="newAuthorEntity">An object that represents an author entity from which this author should be updated.</param>
    /// <param name="properties">An object that represents a collection of properties to update.</param>
    /// <returns>A reference of this entity.</returns>
    public IAuthorEntity Update(IAuthorEntity newAuthorEntity, string[] properties)
    {
      if (properties.Contains(nameof(Name)))
      {
        Name       = newAuthorEntity.Name;
        Properties = new[] { nameof(Name) };
      }

      return this;
    }
  }
}
