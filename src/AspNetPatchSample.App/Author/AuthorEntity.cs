// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace AspNetPatchSample.Author.App
{
  using AspNetPatchSample.App;

  /// <summary>Represents an author entity.</summary>
  public sealed class AuthorEntity : EntityBase, IAuthorEntity, IUpdatable<IAuthorEntity>
  {
    /// <summary>Initializes a new instance of the <see cref="AspNetPatchSample.Author.App.AuthorEntity"/> class.</summary>
    /// <param name="authorEntity">An object that represents an author entity.</param>
    public AuthorEntity(IAuthorEntity authorEntity) : base(authorEntity)
    {
      Name = authorEntity.Name;
    }

    /// <summary>Gets an object that represents a name of an author.</summary>
    public string Name { get; private set; }

    /// <summary>Updates this author.</summary>
    /// <param name="newAuthorEntity">An object that represents an author entity from which this author should be updated.</param>
    /// <returns>A reference of this entity.</returns>
    public IAuthorEntity Update(IAuthorEntity newAuthorEntity) => (IAuthorEntity)base.Update(newAuthorEntity);

    /// <summary>Updates this author.</summary>
    /// <param name="newAuthorEntity">An object that represents an author entity from which this author should be updated.</param>
    /// <param name="properties">An object that represents a collection of properties to update.</param>
    /// <returns>A reference of this entity.</returns>
    public IAuthorEntity Update(IAuthorEntity newAuthorEntity, IEnumerable<string> properties) =>
      (IAuthorEntity)base.Update(newAuthorEntity, properties);
  }
}
