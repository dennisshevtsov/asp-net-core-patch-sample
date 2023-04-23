// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace AspNetPatchSample.Author.Web
{
  /// <summary>Represents the GET author response data.</summary>
  public sealed class GetAuthorResponseDto : IAuthorEntity
  {
    /// <summary>Initializes a new instance of the <see cref="AspNetPatchSample.Author.Web.GetAuthorResponseDto"/> class.</summary>
    /// <param name="authorEntity">An object that represents an author entity.</param>
    public GetAuthorResponseDto(IAuthorEntity authorEntity)
    {
      AuthorId = authorEntity.AuthorId;
      Name     = authorEntity.Name;
    }

    /// <summary>Gets an object that represents an ID of author.</summary>
    public Guid AuthorId { get; }

    /// <summary>Gets an object that represents a name of an author.</summary>
    public string Name { get; }

    /// <summary>Converts this object to an instance of the <see cref="System.Guid"/>.</summary>
    /// <returns>An object that represents a Globally Unique Identifier.</returns>
    public Guid ToGuid() => AuthorId;
  }
}
