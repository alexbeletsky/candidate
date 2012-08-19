using System;
using System.Linq;
using Candidate.Core.Model;
using Nancy;
using Nancy.ModelBinding;
using Nancy.Validation;
using Raven.Client;

namespace Candidate.Nancy.Selfhosted.App.Modules.Api
{
    public class SiteModule : NancyModule
    {
        private readonly ILogger _logger;
        private readonly IDocumentStore _documentStore;

        public SiteModule(ILogger logger, IDocumentStore documentStore)
            : base("/api/site")
        {
            _logger = logger;
            _documentStore = documentStore;

            Get["/{id}"] = parameters =>
                               {
                                   var id = parameters.id;

                                   if (string.IsNullOrEmpty(id))
                                   {
                                       _logger.Debug(string.Format("Invalid Id passed to /api/site DELETE method"));
                                       return HttpStatusCode.PreconditionFailed;
                                   }

                                   using (var session = _documentStore.OpenSession())
                                   {
                                       string entityId = string.Format("sites/{0}", id);
                                       var site = session.Query<Site>().Single(s => s.Id == entityId);
                                       if (site == null)
                                       {
                                           return HttpStatusCode.NotFound;
                                       }

                                       return Response.AsJson(site);
                                   }
                               };

            Post["/"] = parameters =>
                            {
                                var site = this.Bind<Site>("name", "description");

                                var result = this.Validate(site);
                                if (!result.IsValid)
                                {
                                    _logger.Debug(string.Format("Validation for Site model failed, {0}", result.Errors.ToString()));
                                    return HttpStatusCode.PreconditionFailed;
                                }

                                site.Created = DateTime.UtcNow;
                                site.Status = "Created";

                                using (var session = _documentStore.OpenSession())
                                {
                                    session.Store(site);
                                    session.SaveChanges();
                                }

                                _logger.Debug(string.Format("New site configuration created successfully, Id: {0}", site.Id));
                                return Response.AsJson(site);
                            };

            Delete["/{id}"] = parameters =>
                                  {
                                      var id = parameters.id;

                                      if (string.IsNullOrEmpty(id))
                                      {
                                          _logger.Debug(string.Format("Invalid Id passed to /api/site DELETE method"));
                                          return HttpStatusCode.PreconditionFailed;
                                      }

                                      using (var session = _documentStore.OpenSession())
                                      {
                                          session.Advanced.DatabaseCommands.Delete(id, null);
                                      }

                                      _logger.Debug(string.Format("Site configuration with Id:{0} deleted successfully", id));
                                      return HttpStatusCode.NoContent;
                                  };
        }
    }
}
