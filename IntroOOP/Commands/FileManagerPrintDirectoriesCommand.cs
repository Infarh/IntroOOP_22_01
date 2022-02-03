using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntroOOP.Commands.Base;
using StudentsOperations.Extensions;

namespace IntroOOP.Commands
{
    public class FileManagerPrintDirectoriesCommand : FileManagerCommand
    {
        public FileManagerPrintDirectoriesCommand()
        {
            Name = "PrintDirectories";
            Description = "";
        }

        public override void Execute()
        {
            Program.CurrentDirectory
               .EnumerateDirectories()
               .Foreach(d => Console.WriteLine(d.Name));
        }
    }
}
