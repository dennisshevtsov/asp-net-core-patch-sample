// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace AspNetPatchSample.Author.Data
{
  using AspNetPatchSample.Book.Data;
  using AspNetPatchSample.Data;

  /// <summary>Represents an author entity.</summary>
  public sealed class AuthorEntity : EntityBase, IAuthorEntity
  {
    /// <summary>Initializes a new instance of the <see cref="AspNetPatchSample.Author.Data.AuthorEntity"/> class.</summary>
    public AuthorEntity()
    {
      Name  = string.Empty;
      Books = new List<BookEntity>();
    }

    /// <summary>Initializes a new instance of the <see cref="AspNetPatchSample.Author.Data.AuthorEntity"/> class.</summary>
    /// <param name="authorEntity">An object that represents an author entity.</param>
    public AuthorEntity(IAuthorEntity authorEntity) : this()
    {
      Id   = authorEntity.Id;
      Name = authorEntity.Name;
    }

    /// <summary>Gets an object that represents a name of an author.</summary>
    public string Name { get; }

    /// <summary>Gets an object that represents a collection of this author's books.</summary>
    public IEnumerable<BookEntity> Books { get; set; }
  }
}
