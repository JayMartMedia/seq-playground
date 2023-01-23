using NLog;

namespace dotnet_seq;

// seq dotnet docs: https://docs.datalust.co/docs/logging-from-net
// nlog specific docs: https://docs.datalust.co/docs/using-nlog


class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        LogManager.LoadConfiguration("./NLog.config");

        // var config = new NLog.Config.LoggingConfiguration();
        // var logconsole = new NLog.Targets.ConsoleTarget("logconsole");
        // config.AddRule(LogLevel.Info, LogLevel.Fatal, logconsole);
        // var logseq = new NLog.Targets.Seq({})
        // LogManager.Configuration = config;

        Logger logger = LogManager.GetCurrentClassLogger();
        logger.Info("here is a message");
        LogManager.Shutdown();
    }
}
