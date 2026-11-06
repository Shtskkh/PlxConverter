using System.CommandLine;

namespace PlxConverter.Cli;

public static class CliBuilder
{
    public static RootCommand Build()
    {
        var rootCommand = new RootCommand("CLI-конвертер plx файлов в человекочитаемый формат (json, yaml).")
        {
            Options.InputOption,
            Options.OutputOption,
            Options.OutputFormatsOption
        };

        return rootCommand;
    }
}