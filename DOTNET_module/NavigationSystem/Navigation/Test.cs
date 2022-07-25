using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Navigation
{
    public class Test
    {
        public static void Main()
        {
            UserNavigationRepository repository = new UserNavigationRepository();
            NavigationService navigationService = new NavigationService(repository);
            navigationService.ShowHierarchyFilesDirectories();
            while (navigationService.InputCommand(Console.ReadLine()))
            {
            }

            navigationService.SaveNavigation();
        }
    }
}
