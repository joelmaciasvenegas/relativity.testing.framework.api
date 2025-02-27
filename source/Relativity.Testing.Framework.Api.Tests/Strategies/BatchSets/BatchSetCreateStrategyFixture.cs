﻿using System;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using Relativity.Testing.Framework.Api.Services;
using Relativity.Testing.Framework.Api.Strategies;
using Relativity.Testing.Framework.Models;

namespace Relativity.Testing.Framework.Api.Tests.Strategies
{
	[TestFixture]
	[TestOf(typeof(BatchSetCreateStrategyV1))]
	public class BatchSetCreateStrategyFixture
	{
		private const string _INVALID_DATA_SOURCE_EXCEPTION_MESSAGE = "Data Source must not be null and have Artifact ID greater than zero";
		private const string _INVALID_BATCH_SET_NAME_EXCEPTION_MESSAGE = "Batch Set Name cannot be null, empty nor whitespace.";

		private BatchSetCreateStrategyV1 _sut;

		[OneTimeSetUp]
		public void SetUp()
		{
			var mockRestService = new Mock<IRestService>();
			var mockBatchSetValidator = new Mock<IBatchSetValidatorV1>();
			_sut = new BatchSetCreateStrategyV1(mockRestService.Object, mockBatchSetValidator.Object);
		}

		[Test]
		public void Create_WithInavlidDataSourceId_ThrowsException()
		{
			var batchSet = new BatchSet
			{
				Name = Randomizer.GetString(),
				BatchSize = 1500,
				BatchPrefix = Randomizer.GetString("BS", 3),
				DataSource = new NamedArtifact
				{
					ArtifactID = -1
				}
			};
			TestIfCreateThrowsExpectedException(batchSet, _INVALID_DATA_SOURCE_EXCEPTION_MESSAGE);
		}

		[Test]
		public void Create_WithNullDataSource_ThrowsException()
		{
			var batchSet = new BatchSet
			{
				Name = Randomizer.GetString(),
				BatchSize = 1500,
				BatchPrefix = Randomizer.GetString("BS", 3),
				DataSource = null
			};

			TestIfCreateThrowsExpectedException(batchSet, _INVALID_DATA_SOURCE_EXCEPTION_MESSAGE);
		}

		[Test]
		public void Create_WithNullName_ThrowsException()
		{
			var batchSet = new BatchSet
			{
				Name = null,
				BatchSize = 1500,
				BatchPrefix = Randomizer.GetString("BS", 3),
				DataSource = new NamedArtifact
				{
					ArtifactID = 1
				}
			};

			TestIfCreateThrowsExpectedException(batchSet, _INVALID_BATCH_SET_NAME_EXCEPTION_MESSAGE);
		}

		[Test]
		public void Create_WithEmptyName_ThrowsException()
		{
			var batchSet = new BatchSet
			{
				Name = string.Empty,
				BatchSize = 1500,
				BatchPrefix = Randomizer.GetString("BS", 3),
				DataSource = new NamedArtifact
				{
					ArtifactID = 1
				}
			};

			TestIfCreateThrowsExpectedException(batchSet, _INVALID_BATCH_SET_NAME_EXCEPTION_MESSAGE);
		}

		[Test]
		public void Create_WithWhitespaceName_ThrowsException()
		{
			var batchSet = new BatchSet
			{
				Name = "	",
				BatchSize = 1500,
				BatchPrefix = Randomizer.GetString("BS", 3),
				DataSource = new NamedArtifact
				{
					ArtifactID = 1
				}
			};

			TestIfCreateThrowsExpectedException(batchSet, _INVALID_BATCH_SET_NAME_EXCEPTION_MESSAGE);
		}

		private void TestIfCreateThrowsExpectedException(BatchSet batchSet, string expectedExceptionMessage)
		{
			var result = Assert.Throws<ArgumentException>(() =>
				_sut.Create(1, batchSet));

			result.Message.Should().Contain(expectedExceptionMessage);
		}
	}
}
