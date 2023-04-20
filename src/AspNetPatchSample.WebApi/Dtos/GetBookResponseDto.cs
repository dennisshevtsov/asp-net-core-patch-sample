using AspNetPatchSample.Book;

namespace AspNetPatchSample.WebApi.Dtos
{
    public sealed class GetBookResponseDto : IBookEntity
  {
    /// <summary>Initializes a new instance of the <see cref="AspNetPatchSample.WebApi.Dtos.GetBookResponseDto"/> class.</summary>
    /// <param name="orderEntity">An object that represents a book entity.</param>
    public GetBookResponseDto(IBookEntity orderEntity)
    {
      BookId = orderEntity.BookId;
      Name = orderEntity.Name;
      Author = orderEntity.Author;
      Description = orderEntity.Description;
      Pages = orderEntity.Pages;
    }

    /// <summary>Gets an object that represents an ID of a book.</summary>
    public Guid BookId { get; }

    /// <summary>Gets an object that represents a name of a book.</summary>
    public string Name { get; }

    /// <summary>Gets an object that represents a description of a book.</summary>
    public string Author { get; }

    /// <summary>Gets an object that represents a description of a book.</summary>
    public string Description { get; }

    /// <summary>Gets an object that represents a description of a book.</summary>
    public int Pages { get; }
  }
}
