using System.Collections.Generic;
using System.Linq;

namespace DirectoryExplorerLib
{
    public interface IFileSystem
    {
        string[] GetFiles(string path);
    }

    public class DirectoryExplorer
    {
        private readonly IFileSystem fileSystem;

        public DirectoryExplorer(IFileSystem fileSystem)
        {
            this.fileSystem = fileSystem;
        }

        public List<string> GetTextFiles(string path)
        {
            return fileSystem
                .GetFiles(path)
                .Where(f => f.EndsWith(".txt"))
                .ToList();
        }
    }
}