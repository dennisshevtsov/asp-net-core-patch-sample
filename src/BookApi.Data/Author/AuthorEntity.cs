// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace BookApi.Author.Data
{
  using BookApi.Book.Data;
  using BookApi.Data;

  /// <summary>Represents an author entity.</summary>
  public sealed class AuthorEntity : EntityBase, IAuthorEntity
  {
    /// <summary>Initializes a new instance of the <see cref="BookApi.Author.Data.AuthorEntity"/> class.</summary>
    public AuthorEntity()
    {
      Name  = string.Empty;
      Books = new List<BookEntity>();
    }

    /// <summary>Initializes a new instance of the <see cref="BookApi.Author.Data.AuthorEntity"/> class.</summary>
    /// <param name="authorIdentity">An object that represents an author identity.</param>
    public AuthorEntity(IAuthorIdentity authorIdentity) : this()
    {
      AuthorId = authorIdentity.AuthorId;
    }

    /// <summary>Initializes a new instance of the <see cref="BookApi.Author.Data.AuthorEntity"/> class.</summary>
    /// <param name="authorEntity">An object that represents an author entity.</param>
    public AuthorEntity(IAuthorEntity authorEntity) : this((IAuthorIdentity)authorEntity)
    {
      Name = authorEntity.Name;
    }

    /// <summary>Gets an object that represents an ID of an author.</summary>
    public Guid AuthorId { get => Id; set => Id = value; }

    /// <summary>Gets an object that represents a name of an author.</summary>
    public string Name { get; set; }

    /// <summary>Gets an object that represents a collection of this author's books.</summary>
    public IEnumerable<BookEntity> Books { get; set; }
  }
}
