using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Candidate.Infrustructure.Error;

namespace Candidate.Areas
{
    [Authorize]
    [HandleJsonError]
    public class SecuredController : Controller
    {
    }
}
