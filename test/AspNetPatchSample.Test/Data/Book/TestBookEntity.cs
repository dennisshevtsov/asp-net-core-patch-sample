// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using AspNetPatchSample.Author;

namespace AspNetPatchSample.Book.Data.Test
{
  public sealed class TestBookEntity : IBookEntity
  {
    public Guid BookId { get; set; }

    public string Title { get; }

    public string Description { get; }

    public int Pages { get; }

    public IEnumerable<IAuthorEntity> Authors { get; }
  }
}
