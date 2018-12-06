using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppThirdAuth.Middlewares
{
    public static class TestUse
    {
        public static IApplicationBuilder UseTest(this IApplicationBuilder app)
        {
            return app.Use((context, next) =>
           {
               System.Diagnostics.Debug.WriteLine("Use Test call.");
               return next();
           });
        }
    }
}
