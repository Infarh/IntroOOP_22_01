using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntroOOP.Commands.Base;

namespace IntroOOP.Commands
{
    public class FileManagerPrintDrivesCommand : FileManagerCommand
    {
        public FileManagerPrintDrivesCommand()
        {
            Name = "PrintDrives";
            Description = "";
        }

        public override void Execute()
        {
            var drives = DriveInfo.GetDrives();
            foreach (var drive in drives)
                Console.WriteLine("{0} : {1}", drive.Name, drive.RootDirectory.Name);
        }
    }
}
