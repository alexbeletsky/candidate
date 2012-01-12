using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject;
using Ninject.Extensions.Conventions;

namespace Candidate.Core
{
    public static class RegisterServices
    {
        public static void ForKernel(IKernel kernel)
        {
            kernel.Scan(scanner =>
                            {
                                scanner.FromCallingAssembly();
                                scanner.BindWithDefaultConventions();
                            });
        }
    }
}
