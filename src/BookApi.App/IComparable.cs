// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace BookApi.App;

/// <summary>Provides a simple API to compare an entity.</summary>
/// <typeparam name="TEntity">A type of an entity from which this entity should be compared.</typeparam>
public interface IComparable<TEntity>
{
  /// <summary>Compares this entity.</summary>
  /// <param name="otherEntity">An object that represents an entity from which this entity should be compared.</param>
  /// <returns>An object that represents a collection of different properties.</returns>
  public string[] Compare(TEntity otherEntity);

  /// <summary>Compares this entity.</summary>
  /// <param name="otherEntity">An object that represents an entity from which this entity should be compared.</param>
  /// <param name="propertiesToCompare">An object that represents a collection of properties to compare.</param>
  /// <returns>An object that represents a collection of different properties.</returns>
  public string[] Compare(TEntity otherEntity, string[] propertiesToCompare);
}
