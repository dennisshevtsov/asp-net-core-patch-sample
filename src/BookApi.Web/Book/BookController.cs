// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace BookApi.Book.Web
{
  using System;

  using Microsoft.AspNetCore.Mvc;

  /// <summary>Provides a simple API to handle HTTP request.</summary>
  [ApiController]
  [Route("api/book")]
  [Produces("application/json")]
  public sealed class BookController : ControllerBase
  {
    private readonly IBookService _bookService;

    /// <summary>Initializes a new instance of the <see cref="BookApi.Web.Controllers.BookController"/> class.</summary>
    /// <param name="bookService">An object that represents a simple API to operate instances of the <see cref="Domain.Book.IBookEntity"/>.</param>
    public BookController(IBookService bookService)
    {
      _bookService = bookService ?? throw new ArgumentNullException(nameof(bookService));
    }

    /// <summary>Handles the GET book query request.</summary>
    /// <param name="requestDto">An object that represents a condition to query a book.</param>
    /// <param name="cancellationToken">An object that propagates notification that operations should be canceled.</param>
    /// <returns>An object that represents an asynchronous operation that produces a result at some time in the future. The result is an instance of the <see cref="Microsoft.AspNetCore.Mvc.IActionResult"/>.</returns>
    [HttpGet("{bookId}", Name = nameof(BookController.GetBook))]
    [ProducesResponseType(typeof(GetBookResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetBook(GetBookRequestDto requestDto, CancellationToken cancellationToken)
    {
      var bookEntity = await _bookService.GetAsync(requestDto, cancellationToken);

      if (bookEntity == null)
      {
        return NotFound();
      }

      return Ok(new GetBookResponseDto(bookEntity));
    }

    /// <summary>Handles the POST book command request.</summary>
    /// <param name="requestDto">An object that represents data to add a book.</param>
    /// <param name="cancellationToken">An object that propagates notification that operations should be canceled.</param>
    /// <returns>An object that represents an asynchronous operation that produces a result at some time in the future. The result is an instance of the <see cref="Microsoft.AspNetCore.Mvc.IActionResult"/>.</returns>
    [HttpPost(Name = nameof(BookController.PostBook))]
    [ProducesResponseType(typeof(GetBookResponseDto), StatusCodes.Status201Created)]
    [Consumes(typeof(PostBookRequestDto), "application/json")]
    public async Task<IActionResult> PostBook(PostBookRequestDto requestDto, CancellationToken cancellationToken)
    {
      var bookEntity = await _bookService.AddAsync(requestDto, cancellationToken);

      return CreatedAtRoute(
        nameof(BookController.GetBook),
        new GetBookRequestDto(bookEntity),
        new GetBookResponseDto(bookEntity));
    }

    /// <summary>Handles the PUT book command request.</summary>
    /// <param name="requestDto">An object that represents data to update a book.</param>
    /// <param name="cancellationToken">An object that propagates notification that operations should be canceled.</param>
    /// <returns>An object that represents an asynchronous operation that produces a result at some time in the future. The result is an instance of the <see cref="Microsoft.AspNetCore.Mvc.IActionResult"/>.</returns>
    [HttpPut("{bookId}", Name = nameof(BookController.PutBook))]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Consumes(typeof(PutBookRequestDto), "application/json")]
    public async Task<IActionResult> PutBook(PutBookRequestDto requestDto, CancellationToken cancellationToken)
    {
      var bookEntity = await _bookService.GetAsync(requestDto, cancellationToken);

      if (bookEntity == null)
      {
        return NotFound();
      }

      await _bookService.UpdateAsync(bookEntity, requestDto, cancellationToken);

      return NoContent();
    }

    /// <summary>Handles the PATCH book command request.</summary>
    /// <param name="requestDto">An object that represents data to update a book partially.</param>
    /// <param name="cancellationToken">An object that propagates notification that operations should be canceled.</param>
    /// <returns>An object that represents an asynchronous operation that produces a result at some time in the future. The result is an instance of the <see cref="Microsoft.AspNetCore.Mvc.IActionResult"/>.</returns>
    [HttpPatch("{bookId}", Name = nameof(BookController.PatchBook))]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Consumes(typeof(PatchBookRequestDto), "application/json")]
    public async Task<IActionResult> PatchBook(PatchBookRequestDto requestDto, CancellationToken cancellationToken)
    {
      var bookEntity = await _bookService.GetAsync(requestDto, requestDto.Properties, cancellationToken);

      if (bookEntity == null)
      {
        return NotFound();
      }

      await _bookService.UpdateAsync(bookEntity, requestDto, requestDto.Properties, cancellationToken);

      return NoContent();
    }

    /// <summary>Handles the DELETE book command request.</summary>
    /// <param name="requestDto">An object that represents data to delete a book.</param>
    /// <param name="cancellationToken">An object that propagates notification that operations should be canceled.</param>
    /// <returns>An object that represents an asynchronous operation that produces a result at some time in the future. The result is an instance of the <see cref="Microsoft.AspNetCore.Mvc.IActionResult"/>.</returns>
    [HttpDelete("{bookId}", Name = nameof(BookController.DeleteBook))]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteBook(DeleteBookRequestDto requestDto, CancellationToken cancellationToken)
    {
      var bookEntity = await _bookService.GetAsync(requestDto, cancellationToken);

      if (bookEntity == null)
      {
        return NotFound();
      }

      await _bookService.DeleteAsync(bookEntity, cancellationToken);

      return NoContent();
    }
  }
}
