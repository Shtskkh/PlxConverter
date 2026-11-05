using System.CommandLine;

namespace PlxConverter.Cli;

public static class CliBuilder
{
    public static RootCommand Build()
    {
        var rootCommand = new RootCommand("CLI-конвертер plx файлов в человеко-читаемый формат (json, yaml).")
        {
            Options.InputFileOption,
            Options.OutputFormatsOption
        };

        return rootCommand;
    }
}