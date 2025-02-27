﻿using FluentAssertions;
using NUnit.Framework;
using Relativity.Testing.Framework.Api.Strategies;
using Relativity.Testing.Framework.Models;
using Relativity.Testing.Framework.Versioning;

namespace Relativity.Testing.Framework.Api.FunctionalTests.Strategies
{
	[TestOf(typeof(IImagingSetCreateStrategy))]
	internal class ImagingSetCreateStrategyFixture : ImagingStrategyAbstractFixture<IImagingSetCreateStrategy>
	{
		[Test]
		[VersionRange(">=12.1")]
		public void Create_ValidParameters_ReturnsExpectedImagingSet()
		{
			var imagingSetCreateRequest = ArrangeImagingSetRequestWithImagingProfile();
			var expectedImagingSet = GetExpectedImageSetFromImagingSetRequest(imagingSetCreateRequest);

			var createdImagingSet = Sut.Create(DefaultWorkspace.ArtifactID, imagingSetCreateRequest);

			TestIfImagingSetIsEquivalentToExpected(createdImagingSet, expectedImagingSet);
		}

		private void TestIfImagingSetIsEquivalentToExpected(ImagingSet createdImagingSet, ImagingSet expectedImagingSet)
		{
			createdImagingSet.Should().BeEquivalentTo(
				expectedImagingSet,
				o => o.Excluding(x => x.ArtifactID)
					.Excluding(x => x.Status)
					.Including(x => x.ImagingProfile.ArtifactID));
		}
	}
}
