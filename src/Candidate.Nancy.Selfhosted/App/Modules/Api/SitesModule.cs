using System.Linq;
using Candidate.Core.Model;
using Nancy;
using Raven.Client;
using Candidate.Core.Logger;

namespace Candidate.Nancy.Selfhosted.App.Modules.Api
{
    public class SitesModule : NancyModule
    {
        private readonly ILogger _logger;
        private readonly IDocumentStore _documentStore;

        public SitesModule(ILogger logger, IDocumentStore documentStore) : base("/api/sites")
        {
            _logger = logger;
            _documentStore = documentStore;

            Get["/"] = parameters =>
                           {
                               using (var session = _documentStore.OpenSession())
                               {
                                   var sites = session.Query<Site>().OrderBy(s => s.Created);
                                   return Response.AsJson(sites.ToArray());
                               }
                           };
        }
    }
}
