﻿using System.Collections.Generic;
using Relativity.Testing.Framework.Api.Strategies;
using Relativity.Testing.Framework.Models;

namespace Relativity.Testing.Framework.Api.Services
{
	/// <summary>
	/// Represents the group API service.
	/// </summary>
	/// <example>
	/// <code>
	/// _groupService = relativityFacade.Resolve&lt;IGroupService&gt;();
	/// </code>
	/// </example>
	public interface IGroupService
	{
		/// <summary>
		/// Creates the specified [Group](https://relativitydev.github.io/relativity.testing.framework/api/Relativity.Testing.Framework.Models.Group.html).
		/// </summary>
		/// <param name="entity">The [Group](https://relativitydev.github.io/relativity.testing.framework/api/Relativity.Testing.Framework.Models.Group.html) entity to create.</param>
		/// <returns>The created [Group](https://relativitydev.github.io/relativity.testing.framework/api/Relativity.Testing.Framework.Models.Group.html) entity.</returns>
		/// <example>
		/// <code>
		/// var client = relativityFacade.Resolve&lt;IClientService&gt;().Get(clientArtifactId);
		/// var entity = new Group
		/// {
		/// 	Name = Randomizer.GetString("AT_"),
		/// 	Client = client
		/// };
		/// var group = _groupService.Create(entity);
		/// </code>
		/// </example>
		Group Create(Group entity);

		/// <summary>
		/// Requires the specified group.
		/// <list type="number">
		/// <item><description>If [ArtifactID](https://relativitydev.github.io/relativity.testing.framework/api/Relativity.Testing.Framework.Models.Artifact.html#Relativity_Testing_Framework_Models_Artifact_ArtifactID) property of <paramref name="entity"/> has positive value, gets entity by ID and updates it.</description></item>
		/// <item><description>If [Name](https://relativitydev.github.io/relativity.testing.framework/api/Relativity.Testing.Framework.Models.NamedArtifact.html#Relativity_Testing_Framework_Models_NamedArtifact_Name) property of <paramref name="entity"/> have a value, gets entity by name and updates it if it exists.</description></item>
		/// <item><description>Otherwise creates a new entity using <see cref="ICreateWorkspaceEntityStrategy&lt;T&gt;"/>.</description></item>
		/// </list>
		/// </summary>
		/// <param name="entity">The entity to require.</param>
		/// <returns>The entity required.</returns>
		/// <example>
		/// <code>
		/// var name = "Some Existing Group Name";
		/// var entity = _groupService.Get(name);
		/// entity.Keywords = "Test";
		/// var group = _groupService.Require(entity); //Will get group by name, update it and return
		/// </code>
		/// </example>
		/// <example>
		/// <code>
		/// var groupId = 1;
		/// var entity = _groupService.Get(groupId);
		/// entity.Keywords = "Test";
		/// var group = _groupService.Require(entity); //Will get group by Artifact ID, update it and return
		/// </code>
		/// </example>
		/// <example>
		/// <code>
		/// var client = relativityFacade.Resolve&lt;IClientService&gt;().Get(clientArtifactId);
		/// var entity = new Group
		/// {
		/// 	Name = Randomizer.GetString("AT_"),
		/// 	Client = client
		/// };
		/// var group = _groupService.Require(entity); //Will create new group
		/// </code>
		/// </example>
		Group Require(Group entity);

		/// <summary>
		/// Deletes the group by ID.
		/// </summary>
		/// <param name="id">The artifact ID of the group.</param>
		/// <example>
		/// <code>
		/// _groupService.Delete(someExistingGroupId);
		/// </code>
		/// </example>
		void Delete(int id);

		/// <summary>
		/// Gets the group by the specified ID.
		/// </summary>
		/// <param name="id">The artifact ID of the group.</param>
		/// <param name="includeMetadata">Indicates wheter to include group Meta property. Default is false.</param>
		/// <param name="includeActions">Indicates wheter to include group Actions property. Default is false.</param>
		/// <returns>The [Group](https://relativitydev.github.io/relativity.testing.framework/api/Relativity.Testing.Framework.Models.Group.html) entity or <see langword="null"/>.</returns>
		/// <example>
		/// <code>
		/// var entity = _groupService.Get(groupArtifactId);
		/// </code>
		/// </example>
		Group Get(int id, bool includeMetadata = false, bool includeActions = false);

		/// <summary>
		/// Gets the group by the specified group name.
		/// </summary>
		/// <param name="name">The name of the group.</param>
		/// <returns>The [Group](https://relativitydev.github.io/relativity.testing.framework/api/Relativity.Testing.Framework.Models.Group.html) entity or <see langword="null"/>.</returns>
		/// <example>
		/// <code>
		/// var name = "Some Existing Group Name";
		/// var entity = _groupService.Get(name);
		/// </code>
		/// </example>
		Group Get(string name);

		/// <summary>
		/// Gets all groups by the specified names.
		/// </summary>
		/// <param name="names">The collection of group names.</param>
		/// <returns>The collection of [Group](https://relativitydev.github.io/relativity.testing.framework/api/Relativity.Testing.Framework.Models.Group.html) entities.</returns>
		/// <example>
		/// <code>
		/// var names = new List&lt;string&gt;{"Some Existing Group Name", "Other Existing Group Name"};
		/// var entity = _groupService.GetAll(names);
		/// </code>
		/// </example>
		IEnumerable<Group> GetAll(IEnumerable<string> names);

		/// <summary>
		/// Updates the specified group.
		/// </summary>
		/// <param name="entity">The entity to update.</param>
		/// <returns>Updated <see cref="Group"/>.</returns>
		/// <example>
		/// <code>
		/// var groupId = 1;
		/// var entity = new Group
		/// {
		/// 	Name = "Some Existing Group Name",
		/// 	Keywords = "Test Edited Keywords"
		/// }
		/// Group updatedGroup = _groupService.Update(entity);
		/// </code>
		/// </example>
		Group Update(Group entity);
	}
}
