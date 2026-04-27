using CasinoProject.Games.Casino;
using CasinoProject.Services;
namespace CasinoProject.Games
    
{
    public class Program
    {
        static void Main(string[] args)
        {

            FileSystemSaveLoadService service = new FileSystemSaveLoadService(@"C:\Users\deadb\source\repos");
            CasinoGame casino = new CasinoGame(service);
            casino.StartGame();

            
        }
    }
}
