using IntroOOP.Commands.Base;

namespace IntroOOP.Commands
{
    public class FileManagerPrintFilesCommand : FileManagerCommand
    {
        public FileManagerPrintFilesCommand()
        {
            Name = "PrintFiles";
            Description = "Печать файлов в текущей директории";
        }

        public override void Execute() { throw new NotImplementedException(); }
    }
}
