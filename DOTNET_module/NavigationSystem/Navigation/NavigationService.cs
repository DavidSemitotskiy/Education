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

        public void InputCommand(string command)
        {
            string openDirectoryCommandPattern = "^open dir \"(\\w|[A-z]|\\W)*\"";
            string openFileCommandPattern = "^open \"((\\W|[A-z]|\\w)*|(bin|txt)$)\"";
            string sortFilesCommandPattern = @"^sort\s(filename|created|modified)$";
            if (Regex.IsMatch(command,openDirectoryCommandPattern))
            {
                var directoryPath = command.Split("\"", StringSplitOptions.RemoveEmptyEntries)[1];
                if (!Directory.Exists(directoryPath))
                {
                    Console.WriteLine("There isn't such directory");
                    Navigation.NavigationUser.Add($"User inputted incorrect directory with name {directoryPath} - {DateTime.Now}");
                    return;
                }

                OpenDirectoryCommand(directoryPath);
            }
            else if (Regex.IsMatch(command, openFileCommandPattern))
            {
                var filePath = command.Split("\"", StringSplitOptions.RemoveEmptyEntries)[1];
                if (!(filePath.EndsWith(".txt") || filePath.EndsWith(".bin")))
                {
                    Console.WriteLine("Incorrect file to read!");
                    Navigation.NavigationUser.Add($"User inputted file with incorrect extension {Path.GetExtension(filePath)} - {DateTime.Now}");
                    return;
                }

                if (!File.Exists(filePath))
                {
                    Console.WriteLine("There isn't such file");
                    Navigation.NavigationUser.Add($"User inputted incorrect file with name {filePath} - {DateTime.Now}");
                    return;
                }

                OpenFileCommand(filePath);
            }
            else if (Regex.IsMatch(command, sortFilesCommandPattern))
            {
                var categorySorting = command.Split(" ", StringSplitOptions.RemoveEmptyEntries)[1];
                SortFiles(categorySorting);
            }
            else
            {
                Console.WriteLine("Incorrect Command");
                Navigation.NavigationUser.Add($"User inputted incorrect command {command} - {DateTime.Now}");
            }
        }

        public void OpenDirectoryCommand(string path)
        {
            Navigation.CurrentDirectory = path;
            Directory.SetCurrentDirectory(Navigation.CurrentDirectory);
            Navigation.NavigationUser.Add($"User changed current directory into {Navigation.CurrentDirectory} - {DateTime.Now}");
        }

        public void OpenFileCommand(string path)
        {
            Navigation.CurrentFile = path;
            Navigation.NavigationUser.Add($@"User openned file with path: {Navigation.CurrentFile} - {DateTime.Now}");
            
            switch (path[^3..^0])
            {
                case "txt":
                    using (StreamReader streamReader = new StreamReader(path))
                    {
                        char[] bufferForFile = new char[500];
                        streamReader.Read(bufferForFile, 0, bufferForFile.Length);
                        string strFromFile = new string(bufferForFile);
                        Console.WriteLine($"Extracted first 500 characters from text file: {strFromFile}");
                    }

                    break;

                case "bin":
                    using (FileStream fileStream = new FileStream(path, FileMode.Open))
                    {
                        byte[] buffer = new byte[500];
                        if (fileStream.Length == 0)
                        {
                            return;
                        }

                        fileStream.Read(buffer, 0, buffer.Length);
                        string decodingText = Encoding.Default.GetString(buffer);
                        fileStream.Close();
                        Console.WriteLine($"Extracted first 500 bytes from binary file: {decodingText}");
                    }
               
                    break;
            }
        }

        public void SaveNavigation()
        {
            UserNavigationRepository.SaveNavigation(Navigation);
        }

        public void ShowHierarchyFilesDirectories()
        {
            var drivers = DriveInfo.GetDrives();
            Console.WriteLine("Drivers:");
            foreach (var drive in drivers)
            {
                Console.WriteLine(drive.Name);
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
    }
}
