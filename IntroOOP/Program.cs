using IntroOOP.Commands;
using IntroOOP.Commands.Base;
using IntroOOP.Models;

namespace IntroOOP;

public static class Program
{
    public static DirectoryModel CurrentDirectory { get; set; }
    public static FileModel CurrentFile { get; set; }

    public static IReadOnlyDictionary<string, FileManagerCommand> Commands { get; } = CreateCommands();

    private static Dictionary<string, FileManagerCommand> CreateCommands()
    {
        var help_command = new FileManagerHelpCommand();
        FileManagerCommand[] commands =
        {
            help_command,
            new FileManagerPrintDirectoriesCommand(),
            new FileManagerPrintDrivesCommand(),
            new FileManagerPrintFilesCommand(),
        };

        var result = commands.ToDictionary(cmd => cmd.Name);

        result["?"] = help_command;

        return result;
    }

    private static readonly Dictionary<(char, int), string> __StringsPool = new ();

    private static string GetString(char c, int Count)
    {
        if (__StringsPool.TryGetValue((c, Count), out var str))
            return str;

        str = new string(c, Count);
        __StringsPool[(c, Count)] = str;

        return str;
    }

    public static void Main(string[] args)
    {

        //FileOperations.Test();

        var do_work = true;
        while (do_work)
        {
            Console.Write("Введите команду >");
            var command_line = Console.ReadLine();

            if (!Commands.TryGetValue(command_line, out var command))
            {
                Console.WriteLine("Неизвестная команда {0}. Для помощи напишите help", command_line);
            }
            else
            {
                command.Execute();
            }
        }

        Console.WriteLine("Программа завершена");
    }
}