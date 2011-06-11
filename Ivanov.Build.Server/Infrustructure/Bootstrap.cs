using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncqrs;
using Ncqrs.Commanding.ServiceModel;
using Ncqrs.Eventing.ServiceModel.Bus;

namespace Ivanov.Build.Server.Infrustructure
{
    //public static class CqrsBootstrap
    //{
    //    public static void BootUp()
    //    {
    //        NcqrsEnvironment.SetDefault<ICommandService>(InitializeCommandService());
    //        NcqrsEnvironment.SetDefault<IEventBus>(InitializeEventBus());
    //    }

    //    private static IEventBus InitializeEventBus()
    //    {
    //        var eventBus = new InProcessEventBus();
    //        eventBus.RegisterHandler(new AddJobDenormalizer());

    //        return eventBus;
    //    }

    //    private static ICommandService InitializeCommandService()
    //    {
    //        var service = new CommandService();
    //        service.RegisterExecutor(new AddNewJobCommandExecutor());

    //        return service;
    //    }
        
    //}
}
