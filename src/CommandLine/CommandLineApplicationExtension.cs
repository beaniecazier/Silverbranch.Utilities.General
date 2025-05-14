using CommandLine;
using Serilog;

namespace Gay.Silverbranch.Utilities.General.CommandLine;

#pragma warning disable CS1591

public static class CommandLineApplicationExtension
{
    public static bool BeVerbose = false;
    
    public static T ParseCommandLine<T>(string[] args) where T : BaseCmdOptions
    {
        if (args.Contains("-v") || args.Contains("--verbose")) BeVerbose = true;
        
        var argsList = args.Where(x => !x.Contains("--applicationName") &&
                                    !x.Contains("--environment") &&
                                    !x.Contains("--contentRoot"));
        
        var results = Parser.Default.ParseArguments<T>(argsList)
            .WithParsed<T>(RunOptions)
            .WithNotParsed(HandleParseError);

        return results.Value;
    }

    static void RunOptions<T>(T opts) where T : BaseCmdOptions
    {
    }

    static void HandleParseError(IEnumerable<Error> errs)
    {
        foreach (var error in errs) Log.Error("", error);
        throw new Exception("One or more errors occurred.\n" +
                            "The provided cli arguments are not valid.\n" +
                            "Terminating program.");
    }
}

#pragma warning restore CS1591