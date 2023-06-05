// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace BookApi.Author.Web
{
  using System;

  using Microsoft.AspNetCore.Mvc;

  /// <summary>Provides a simple API to handle HTTP request.</summary>
  [ApiController]
  [Route("api/author")]
  [Produces("application/json")]
  public sealed class AuthorController : ControllerBase
  {
    private readonly IAuthorService _authorService;

    /// <summary>Initializes a new instance of the <see cref="BookApi.Author.Web.AuthorController"/> class.</summary>
    /// <param name="authorService">An object that provides a simple API to execute a task with an instance of the <see cref="BookApi.Author.IAuthorEntity"/>.</param>
    public AuthorController(IAuthorService authorService)
    {
      _authorService = authorService ?? throw new ArgumentNullException(nameof(authorService));
    }

    /// <summary>Handles the GET author request.</summary>
    /// <param name="requestDto">An object that represents the GET author request data.</param>
    /// <param name="cancellationToken">An object that propagates notification that operations should be canceled.</param>
    /// <returns>An object that represents an asynchronous operation that produces a result at some time in the future. The result is an instance of the <see cref="Microsoft.AspNetCore.Mvc.IActionResult"/>.</returns>
    [HttpGet("{authorId}", Name = nameof(AuthorController.GetAuthor))]
    [ProducesResponseType(typeof(GetAuthorResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAuthor(GetAuthorRequestDto requestDto, CancellationToken cancellationToken)
    {
      var authorEntity = await _authorService.GetAsync(requestDto, cancellationToken);

      if (authorEntity == null)
      {
        return NotFound();
      }

      return Ok(new GetAuthorResponseDto(authorEntity));
    }

    /// <summary>Handles the POST author request.</summary>
    /// <param name="requestDto">An object that represents the POST author request data.</param>
    /// <param name="cancellationToken">An object that propagates notification that operations should be canceled.</param>
    /// <returns>An object that represents an asynchronous operation that produces a result at some time in the future. The result is an instance of the <see cref="Microsoft.AspNetCore.Mvc.IActionResult"/>.</returns>
    [HttpPost(Name = nameof(AuthorController.PostAuthor))]
    [ProducesResponseType(typeof(GetAuthorResponseDto), StatusCodes.Status201Created)]
    [Consumes(typeof(PostAuthorRequestDto), "application/json")]
    public async Task<IActionResult> PostAuthor(PostAuthorRequestDto requestDto, CancellationToken cancellationToken)
    {
      var authorEntity = await _authorService.AddAsync(requestDto, cancellationToken);

      return CreatedAtRoute(
        nameof(AuthorController.GetAuthor),
        new GetAuthorRequestDto(authorEntity),
        new GetAuthorResponseDto(authorEntity));
    }

    /// <summary>Handles the PUT author request.</summary>
    /// <param name="requestDto">An object that represents the PUT author request data.</param>
    /// <param name="cancellationToken">An object that propagates notification that operations should be canceled.</param>
    /// <returns>An object that represents an asynchronous operation that produces a result at some time in the future. The result is an instance of the <see cref="Microsoft.AspNetCore.Mvc.IActionResult"/>.</returns>
    [HttpPut("{authorId}", Name = nameof(AuthorController.PutAuthor))]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Consumes(typeof(PutAuthorRequestDto), "application/json")]
    public async Task<IActionResult> PutAuthor(PutAuthorRequestDto requestDto, CancellationToken cancellationToken)
    {
      var authorEntity = await _authorService.GetAsync(requestDto, cancellationToken);

      if (authorEntity == null)
      {
        return NotFound();
      }

      await _authorService.UpdateAsync(authorEntity, requestDto, cancellationToken);

      return NoContent();
    }

    /// <summary>Handles the PATCH author request.</summary>
    /// <param name="requestDto">An object that represents the PATCH author request data.</param>
    /// <param name="cancellationToken">An object that propagates notification that operations should be canceled.</param>
    /// <returns>An object that represents an asynchronous operation that produces a result at some time in the future. The result is an instance of the <see cref="Microsoft.AspNetCore.Mvc.IActionResult"/>.</returns>
    [HttpPatch("{authorId}", Name = nameof(AuthorController.PatchAuthor))]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Consumes(typeof(PatchAuthorRequestDto), "application/json")]
    public async Task<IActionResult> PatchAuthor(PatchAuthorRequestDto requestDto, CancellationToken cancellationToken)
    {
      var authorEntity = await _authorService.GetAsync(requestDto, cancellationToken);

      if (authorEntity == null)
      {
        return NotFound();
      }

      await _authorService.UpdateAsync(
        authorEntity, requestDto, requestDto.Properties, cancellationToken);

      return NoContent();
    }

    /// <summary>Handles the DELETE author request.</summary>
    /// <param name="requestDto">An object that represents the DELETE author request data.</param>
    /// <param name="cancellationToken">An object that propagates notification that operations should be canceled.</param>
    /// <returns>An object that represents an asynchronous operation that produces a result at some time in the future. The result is an instance of the <see cref="Microsoft.AspNetCore.Mvc.IActionResult"/>.</returns>
    [HttpDelete("{authorId}", Name = nameof(AuthorController.DeleteAuthor))]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Consumes(typeof(DeleteAuthorRequestDto), "application/json")]
    public async Task<IActionResult> DeleteAuthor(DeleteAuthorRequestDto requestDto, CancellationToken cancellationToken)
    {
      var authorEntity = await _authorService.GetAsync(requestDto, cancellationToken);

      if (authorEntity == null)
      {
        return NotFound();
      }

      await _authorService.DeleteAsync(requestDto, cancellationToken);

      return NoContent();
    }
  }
}
