using LogForU.Core.Exceptions;
using LogForU.Core.IO.Interfaces;

namespace LogForU.Core.IO
{
    public class LogFile : ILogFile
    {
        private const string DefaultExtension = "txt";
        private static readonly string DefaultName = $"Log_{DateTime.Now:yyyy-MM-dd-HH-mm-ss}";
        private static readonly string DefaultPath = Directory.GetCurrentDirectory();

        private string name;
        private string extension;
        private string path;

        public LogFile()
        {
            this.Name = DefaultName;
            this.Extension = DefaultExtension;
            this.Path = DefaultPath;
        }

        public LogFile(string name, string extension, string path)
            : this()
        {
            this.Name = name;
            this.Extension = extension;
            this.Path = path;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new EmptyFileNameException();
                }

                this.name = value;
            }
        }
        public string Extension
        {
            get
            {
                return this.extension;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new EmptyFileExtensionException();
                }

                this.extension = value;
            }
        }

        public string Path
        {
            get
            {
                return this.path;
            }
            private set
            {
                if (!Directory.Exists(value))
                {
                    throw new InvalidPathException();
                }

                this.path = value;
            }
        }

        public string FullPath => System.IO.Path.GetFullPath($"{this.Path}/{this.Name}.{this.Extension}");

        public int Size => File.ReadAllBytes(this.FullPath).Length;
    }
}
