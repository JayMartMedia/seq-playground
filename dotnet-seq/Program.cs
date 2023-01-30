using NLog;
using NLog.Config;
using NLog.Targets;
using NLog.Targets.Seq;

namespace dotnet_seq;

// seq dotnet docs: https://docs.datalust.co/docs/logging-from-net
// nlog specific docs: https://docs.datalust.co/docs/using-nlog


class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        // LogManager.LoadConfiguration("NLog.config");

        // Uncomment below line to configure NLog programmatically
        // ConfigureNlogProgrammatically();

        Logger logger = LogManager.GetCurrentClassLogger();
        logger.Info("here is a message");
        LogManager.Shutdown();
    }

    private static void ConfigureNlogProgrammatically() {
        // create configuration
        LoggingConfiguration config = new LoggingConfiguration();

        // create targets
        ConsoleTarget consoleTarget = new ConsoleTarget("logconsole");
        SeqTarget seqTarget = new SeqTarget
        {
            ServerUrl = "http://localhost:5341",
            ApiKey = "wy9A95L3ww0R0BTioZnQ"
        };

        // add rules to send to targets
        config.AddRule(LogLevel.Info, LogLevel.Fatal, consoleTarget);
        config.AddRule(LogLevel.Info, LogLevel.Fatal, seqTarget);

        // set configuration
        LogManager.Configuration = config;
    }
}
