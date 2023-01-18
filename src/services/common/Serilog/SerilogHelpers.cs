using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serilog;
using Serilog.Events;

namespace Services.Common.Serilog
{
    public static class SerilogHelpers
    {
        public static ILogger ConfigureSerilogConsole()
        {
            return new LoggerConfiguration().MinimumLevel
                .Override("Microsoft", LogEventLevel.Information)
                .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
                .Enrich.FromLogContext()
                .WriteTo.Console(
                    LogEventLevel.Information,
                    outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj} [{SourceContext}] {ActionName} {NewLine}{Exception}"
                )
                .CreateLogger();
        }
    }
}
