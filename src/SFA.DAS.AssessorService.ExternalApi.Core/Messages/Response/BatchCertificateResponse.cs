﻿namespace SFA.DAS.AssessorService.ExternalApi.Core.Messages.Response
{
    using SFA.DAS.AssessorService.ExternalApi.Core.Models.Certificates;
    using System.Collections.Generic;

    public class BatchCertificateResponse
    {
        public Certificate Certificate { get; set; }

        public CertificateData ProvidedCertificateData { get; set; }

        public List<string> ValidationErrors { get; set; } = new List<string>();
    }
}
