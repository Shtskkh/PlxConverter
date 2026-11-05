using PlxConverter.Cli;

var rootCommand = CliBuilder.Build();

rootCommand.Parse(args).Invoke();