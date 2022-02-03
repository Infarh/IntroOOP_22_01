using IntroOOP.Commands.Base;

namespace IntroOOP.Commands
{
    public class FileManagerHelpCommand : FileManagerCommand
    {
        public FileManagerHelpCommand()
        {
            Name = "help";
            Description = "Помощь";
        }

        public override void Execute()
        {
            foreach (var (name, command) in Program.Commands)
            {
                Console.WriteLine("\t{0}\t-\t{1}", name, command.Description);
            }

        }
    }
}
