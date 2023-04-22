// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace AspNetPatchSample.Web.Author
{
  using Microsoft.AspNetCore.Mvc;

  /// <summary>Provides a simple API to handle HTTP request.</summary>
  [ApiController]
  [Route("api/author")]
  [Produces("application/json")]
  public sealed class AuthorController : ControllerBase
  {
    /// <summary>Handles the GET author request.</summary>
    /// <param name="requestDto">An object that represents the GET author request data.</param>
    /// <param name="cancellationToken">An object that propagates notification that operations should be canceled.</param>
    /// <returns>An object that represents an asynchronous operation that produces a result at some time in the future. The result is an instance of the <see cref="Microsoft.AspNetCore.Mvc.IActionResult"/>.</returns>
    [HttpGet("{authorId}", Name = nameof(AuthorController.GetAuthor))]
    [ProducesResponseType(typeof(GetAuthorResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public Task<IActionResult> GetAuthor(GetAuthorRequestDto requestDto, CancellationToken cancellationToken)
    {
      return Task.FromResult<IActionResult>(Ok());
    }

    /// <summary>Handles the GET authors request.</summary>
    /// <param name="requestDto">An object that represents the GET authors request data.</param>
    /// <param name="cancellationToken">An object that propagates notification that operations should be canceled.</param>
    /// <returns>An object that represents an asynchronous operation that produces a result at some time in the future. The result is an instance of the <see cref="Microsoft.AspNetCore.Mvc.IActionResult"/>.</returns>
    [HttpGet(Name = nameof(AuthorController.GetAuthors))]
    [ProducesResponseType(typeof(GetAuthorsResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public Task<IActionResult> GetAuthors(GetAuthorsRequestDto requestDto, CancellationToken cancellationToken)
    {
      return Task.FromResult<IActionResult>(Ok());
    }
  }
}
