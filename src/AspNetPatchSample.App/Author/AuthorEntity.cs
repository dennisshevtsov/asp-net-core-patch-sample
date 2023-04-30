// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace AspNetPatchSample.Author.App
{
  using AspNetPatchSample.App;

  /// <summary>Represents an author entity.</summary>
  public sealed class AuthorEntity : EntityBase, IAuthorEntity, IUpdatable<IAuthorEntity>
  {
    private string _name;

    /// <summary>Initializes a new instance of the <see cref="AspNetPatchSample.Author.App.AuthorEntity"/> class.</summary>
    private AuthorEntity() : base()
    {
      _name       = string.Empty;
    }

    /// <summary>Initializes a new instance of the <see cref="AspNetPatchSample.Author.App.AuthorEntity"/> class.</summary>
    /// <param name="authorEntity">An object that represents an author entity.</param>
    public AuthorEntity(IAuthorEntity authorEntity) : this()
    {
      AuthorId = authorEntity.AuthorId;
      Name     = authorEntity.Name;
    }

    /// <summary>Gets an object that represents an ID of author.</summary>
    public Guid AuthorId { get; }

    /// <summary>Gets an object that represents a name of an author.</summary>
    public string Name
    {
      get => _name;

      private set
      {
        if (_name != value)
        {
          _name = value;
          Updated(nameof(Name));
        }
      }
    }

    /// <summary>Converts this object to an instance of the <see cref="System.Guid"/>.</summary>
    /// <returns>An object that represents a Globally Unique Identifier.</returns>
    public Guid ToGuid() => AuthorId;

    /// <summary>Updates this author.</summary>
    /// <param name="newAuthorEntity">An object that represents an author entity from which this author should be updated.</param>
    /// <returns>A reference of this entity.</returns>
    public IAuthorEntity Update(IAuthorEntity newAuthorEntity)
    {
      Reset();

      Name = newAuthorEntity.Name;

      return this;
    }

    /// <summary>Updates this author.</summary>
    /// <param name="newAuthorEntity">An object that represents an author entity from which this author should be updated.</param>
    /// <param name="properties">An object that represents a collection of properties to update.</param>
    /// <returns>A reference of this entity.</returns>
    public IAuthorEntity Update(IAuthorEntity newAuthorEntity, string[] properties)
    {
      Reset();

      if (properties.Contains(nameof(Name)))
      {
        Name = newAuthorEntity.Name;
      }

      return this;
    }
  }
}
