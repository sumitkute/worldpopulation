using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using world.data;

[assembly: OwinStartup(typeof(WorldPopulationService.Startup))]

namespace WorldPopulationService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
            DocumentDBRepository<Invoice>.Initialize();
        }
    }
}
