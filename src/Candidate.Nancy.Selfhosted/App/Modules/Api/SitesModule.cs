using System.Linq;
using Candidate.Core.Model;
using Nancy;
using Raven.Client;

namespace Candidate.Nancy.Selfhosted.App.Modules.Api
{
    public class SitesModule : NancyModule
    {
        private readonly IDocumentStore _documentStore;

        public SitesModule(IDocumentStore documentStore) : base("/api/sites")
        {
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
