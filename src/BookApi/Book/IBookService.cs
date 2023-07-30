// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace BookApi.Book;

/// <summary>Represents a simple API to operate instances of the <see cref="BookApi.Book.IBookEntity"/>.</summary>
public interface IBookService : IService<IBookEntity, IBookIdentity>
{
}
