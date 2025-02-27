﻿namespace Relativity.Testing.Framework.Api.Strategies
{
	/// <summary>
	/// Represents the strategy of entity requirement.
	/// </summary>
	/// <typeparam name="T">The type of the entity.</typeparam>
	internal interface IRequireWithEnsureNewStrategy<T>
	{
		/// <summary>
		/// Requires the specified entity.
		/// Returns existing object if the <paramref name="entity"/> has the properties (ArtifactID, Name, etc.) set to be able to get the entity;
		/// otherwise creates a new entity.
		/// </summary>
		/// <param name="entity">The entity to require.</param>
		/// <param name="ensureNew">The boolean value indicating whether we going to delete the same entity. By default true.</param>
		/// <returns>The entity required.</returns>
		T Require(T entity, bool ensureNew = true);
	}
}
