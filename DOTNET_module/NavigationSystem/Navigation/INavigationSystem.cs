using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Navigation
{
    public interface INavigationSystem
    {
        void ShowHierarchyFilesDirectories();

        bool InputCommand(string command);

        void OpenDirectoryCommand(string path);

        void OpenFileCommand(string path);

        void SaveNavigation();

        void SortFiles(string categorySorting);
    }
}
