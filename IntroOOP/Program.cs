namespace IntroOOP;

public static class Program
{
    public static void Main(string[] args)
    {
        //FileOperations.Test();

        var do_work = true;
        while (do_work)
        {
            Console.Write("Введите команду >");
            var command = Console.ReadLine();

            switch (command.ToLower())
            {
                case "copy": break;
                case "cd": break;
                case "md": break;
                case "help":
                    Console.WriteLine("copy, cd, md, help");
                    break;
                case "exit":
                    do_work = false;
                    break;
                default:
                    Console.WriteLine("Непонятная команда {0}", command);
                    break;
            }
        }

        Console.WriteLine("Программа завершена");
    }
}