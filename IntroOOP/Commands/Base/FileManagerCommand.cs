namespace IntroOOP.Commands.Base
{
    public abstract class FileManagerCommand
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public abstract void Execute();
    }
}
