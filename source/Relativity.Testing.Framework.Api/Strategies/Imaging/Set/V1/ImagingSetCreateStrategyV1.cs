﻿using Relativity.Testing.Framework.Api.Services;
using Relativity.Testing.Framework.Models;
using Relativity.Testing.Framework.Versioning;

namespace Relativity.Testing.Framework.Api.Strategies
{
	[VersionRange(">=12.1")]
	internal class ImagingSetCreateStrategyV1 : IImagingSetCreateStrategy
	{
		private const string _BASE_CREATE_URL_FORMAT = "relativity-imaging/v1/workspaces/{0}/imaging-sets";
		private readonly IRestService _restService;
		private readonly IImagingSetValidatorV1 _imagingSetValidator;
		private readonly IImagingSetGetStrategy _imagingSetGetStrategy;

		public ImagingSetCreateStrategyV1(
			IRestService restService,
			IImagingSetValidatorV1 imagingSetValidator,
			IImagingSetGetStrategy imagingSetGetStrategy)
		{
			_restService = restService;
			_imagingSetValidator = imagingSetValidator;
			_imagingSetGetStrategy = imagingSetGetStrategy;
		}

		public ImagingSet Create(int workspaceId, ImagingSetRequest imagingSetRequest)
		{
			_imagingSetValidator.ValidateImagingSetCreateRequest(workspaceId, imagingSetRequest);

			string url = GetUrlWithParameters(workspaceId);
			var dto = new ImagingSetRequestDtoV1(imagingSetRequest);

			var createdImagingSetId = _restService.Post<int>(url, dto);

			return _imagingSetGetStrategy.Get(workspaceId, createdImagingSetId);
		}

		private static string GetUrlWithParameters(int workspaceId)
		{
			return string.Format(_BASE_CREATE_URL_FORMAT, workspaceId);
		}
	}
}
