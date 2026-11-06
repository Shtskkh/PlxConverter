using PlxConverter.Cli;
using PlxConverter.Input;

var rootCommand = CliBuilder.Build();

rootCommand.SetAction(async parseResult =>
{
    var inputFile = parseResult.GetValue(Options.InputOption)
                    ?? throw new InvalidOperationException("Файл для преобразования не найден.");

    await using var input = inputFile.OpenRead();
    await PlxReader.ReadAsync(input);
});

return await rootCommand.Parse(args).InvokeAsync();