using System;
using Nancy;
using Nancy.Authentication.Forms;
using Nancy.Security;

namespace Candidate.Nancy.Selfhosted.App
{
    public class UserMapper : IUserMapper
    {
        public IUserIdentity GetUserFromIdentifier(Guid identifier, NancyContext context)
        {
            throw new NotImplementedException();
        }
    }
}
