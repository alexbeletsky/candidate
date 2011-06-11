using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject.Modules;
using Ivanov.Build.Server.Core.Settings;

namespace Ivanov.Build.Server.Infrustructure
{
    class Services : NinjectModule
    {
        public override void Load()
        {
            Bind<ISettingsManager>().To<SettingsManager>();
        }
    }
}