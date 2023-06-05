// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace BookApi.Book.Data.Test
{
  public sealed class TestBookIdentity : IBookIdentity
  {
    public TestBookIdentity(Guid bookdId)
    {
      BookId = bookdId;
    }

    public Guid BookId { get; }

    public static IBookIdentity New() => new TestBookIdentity(Guid.NewGuid());
  }
}
