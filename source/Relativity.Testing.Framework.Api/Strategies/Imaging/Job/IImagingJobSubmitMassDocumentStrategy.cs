﻿using Relativity.Testing.Framework.Models;

namespace Relativity.Testing.Framework.Api.Strategies
{
	internal interface IImagingJobSubmitMassDocumentStrategy
	{
		long SubmitMassDocument(int workspaceId, ImagingMassJobRequest imagingMassJobRequest);
	}
}
