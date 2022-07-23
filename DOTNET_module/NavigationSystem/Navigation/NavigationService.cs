using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Navigation
{
    public class NavigationService : INavigationSystem
    {
        public NavigationService(IUserNavigationRepository userNavigationRepository)
        {
            UserNavigationRepository = userNavigationRepository;
            Navigation = new UserNavigation();
        }

        public IUserNavigationRepository UserNavigationRepository { get; private set; }

        public UserNavigation Navigation { get; private set; }

        public bool InputCommand(string command)
        {
            string openDirectoryCommandPattern = "^open dir \"(\\w|[A-z]|\\W)*\"";
            string openFileCommandPattern = "^open \"((\\W|[A-z]|\\w)*|(bin|txt)$)\"";
            string sortFilesCommandPattern = @"^sort\s(filename|created|modified)$";
            if (Regex.IsMatch(command, openDirectoryCommandPattern))
            {
                var directoryPath = command.Split("\"", StringSplitOptions.RemoveEmptyEntries)[1];
                OpenDirectoryCommand(directoryPath);
            }
            else if (Regex.IsMatch(command, openFileCommandPattern))
            {
                var filePath = command.Split("\"", StringSplitOptions.RemoveEmptyEntries)[1];
                OpenFileCommand(filePath);
            }
            else if (Regex.IsMatch(command, sortFilesCommandPattern))
            {
                var categorySorting = command.Split(" ", StringSplitOptions.RemoveEmptyEntries)[1];
                SortFiles(categorySorting);
            }
            else if (command == "exit")
            {
                return false;
            }
            else
            {
                Console.WriteLine("Incorrect Command");
                Navigation.NavigationUser.Add($"User inputted incorrect command {command} - {DateTime.Now}");
            }

            return true;
        }

        public void OpenDirectoryCommand(string path)
        {
            if (!Directory.Exists(path))
            {
                Console.WriteLine("There isn't such directory");
                Navigation.NavigationUser.Add($"User inputted incorrect directory with name {path} - {DateTime.Now}");
                return;
            }

            Navigation.CurrentDirectory = path;
            Directory.SetCurrentDirectory(Navigation.CurrentDirectory);
            Console.WriteLine($"Current Directory: {Navigation.CurrentDirectory}");
            Navigation.NavigationUser.Add($"User changed current directory into {Navigation.CurrentDirectory} - {DateTime.Now}");
        }
        public void OpenFileCommand(string path)
        {
            if (!File.Exists(path))
            {
                Console.WriteLine("There isn't such file");
                Navigation.NavigationUser.Add($"User inputted incorrect file with name {path} - {DateTime.Now}");
                return;
            }

            Navigation.CurrentFile = path;
            try
            {
                using (FileStream file = new FileStream(path, FileMode.Open))
                {
                    byte[] buffer = new byte[100];
                    file.Read(buffer, 0, buffer.Length);
                    string str = Encoding.Default.GetString(buffer);
                    if (str.Any(symbol => char.IsControl(symbol) && symbol != '\r' && symbol != '\n' && symbol != '\t'))
                    {
                        byte[] binaryBuffer = new byte[500];
                        file.Read(binaryBuffer, 0, binaryBuffer.Length);
                        string strBinary = Encoding.Default.GetString(binaryBuffer);
                        Console.WriteLine(strBinary);
                    }
                    else
                    {
                        char[] bufferForText = new char[500];
                        using StreamReader streamReader = new StreamReader(file);
                        streamReader.Read(bufferForText, 0, bufferForText.Length);
                        string strText = new string(bufferForText);
                        Console.WriteLine(strText);
                        streamReader.Close();
                    }
                    file.Close();
                }
                Navigation.NavigationUser.Add($@"User openned file with path: {Navigation.CurrentFile} - {DateTime.Now}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Navigation.NavigationUser.Add($@"File can't be readed: {Navigation.CurrentFile} - {DateTime.Now}");

            }
        }

        public void SaveNavigation()
        {
            UserNavigationRepository.SaveNavigation(Navigation);
        }

        public void ShowHierarchyFilesDirectories()
        {
            var drivers = DriveInfo.GetDrives();
            foreach (var drive in drivers)
            {
                Console.WriteLine(drive.Name);
                if (!drive.IsReady)
                {
                    Console.WriteLine("\tThis drive isn't able to read!");
                    continue;
                }
                ShowDirectoriesAndFiles(drive.RootDirectory.ToString());
            }

            Console.WriteLine($"Current Directory: {Navigation.CurrentDirectory}");
        }

        public void SortFiles(string categorySorting)
        {
            DirectoryInfo dir = new DirectoryInfo(Directory.GetCurrentDirectory());
            var files = dir.GetFiles();
            var listType = typeof(List<>).MakeGenericType(typeof(FileInfo));
            var resultOrdering = (List<FileInfo>)Activator.CreateInstance(listType);
            switch (categorySorting)
            {
                case "filename":
                    resultOrdering = files.OrderBy(file => file.FullName).ToList();
                    break;
                case "created":
                    resultOrdering = files.OrderBy(file => file.CreationTime).ToList();
                    break;
                case "modified":
                    resultOrdering = files.OrderBy(file => file.LastWriteTime).ToList();
                    break;
            }

            Console.WriteLine("List of files after ordering:");
            foreach (var file in resultOrdering)
            {
                Console.WriteLine(file.FullName);
            }
        }

        private void ShowDirectoriesAndFiles(string path)
        {
            DirectoryInfo directory = null;
            FileInfo[] files = null;
            try
            {
                foreach (var dir in Directory.GetDirectories(path))
                {
                    directory = new DirectoryInfo(dir);
                    Console.WriteLine($"\tDirectory {directory.FullName}");

                    files = directory.GetFiles();
                    foreach (var file in files)
                    {
                        Console.WriteLine($"\t\t File {file.FullName}");
                    }

                    ShowDirectoriesAndFiles(directory.FullName);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\t\t\t Can't read {ex.Message}");
            }
        }
    }
}