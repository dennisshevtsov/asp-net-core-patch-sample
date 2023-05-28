// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace AspNetPatchSample.Book.Web
{
  using AspNetPatchSample.Author;

  /// <summary>Represents a book entity.</summary>
  public sealed class GetBookResponseDto : IBookEntity
  {
    /// <summary>Initializes a new instance of the <see cref="AspNetPatchSample.Web.Dtos.GetBookResponseDto"/> class.</summary>
    /// <param name="orderEntity">An object that represents a book entity.</param>
    public GetBookResponseDto(IBookEntity orderEntity)
    {
      BookId      = orderEntity.BookId;
      Title       = orderEntity.Title;
      Description = orderEntity.Description;
      Pages       = orderEntity.Pages;
      Authors     = AuthorDto.Copy(orderEntity.Authors);
    }

    /// <summary>Gets/sets an object that represents an ID of a book.</summary>
    public Guid BookId { get; }

    /// <summary>Gets an object that represents a title of a book.</summary>
    public string Title { get; }

    /// <summary>Gets an object that represents a description of a book.</summary>
    public string Description { get; }

    /// <summary>Gets an object that represents a description of a book.</summary>
    public int Pages { get; }

    /// <summary>Gets an object that represents a collection of authors of this book.</summary>
    public IEnumerable<IAuthorEntity> Authors { get; }

    /// <summary>Represents an author entity.</summary>
    public sealed class AuthorDto : IAuthorEntity
    {
      /// <summary>Initializes a new instance of the <see cref="AspNetPatchSample.Book.Web.GetBookResponseDto.AuthorDto"/> class.</summary>
      /// <param name="authorEntity">An object that represents an author entity.</param>
      public AuthorDto(IAuthorEntity authorEntity)
      {
        AuthorId = authorEntity.AuthorId;
        Name     = authorEntity.Name;
      }

      /// <summary>Gets an object that represents an ID of an author.</summary>
      public Guid AuthorId { get; }

      /// <summary>Gets an object that represents a name of an author.</summary>
      public string Name { get; }

      public static IEnumerable<IAuthorEntity> Copy(IEnumerable<IAuthorEntity> authorEntities)
        => authorEntities.Select(entity => new AuthorDto(entity))
                         .ToArray();
    }
  }
}
