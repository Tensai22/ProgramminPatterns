using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Facade
            TV tv = new TV();
            AudioSystem audio = new AudioSystem();
            DVDPlayer dvd = new DVDPlayer();
            GameConsole console = new GameConsole();

            HomeTheaterFacade homeTheater = new HomeTheaterFacade(tv, audio, dvd, console);

            homeTheater.WatchMovie();
            homeTheater.EndMovie();

            homeTheater.PlayGame();
            homeTheater.ListenToMusic();

            homeTheater.TurnOffAll();

            //Composite
            File file1 = new File("Document.txt", 120);
            File file2 = new File("Photo.jpg", 300);
            File file3 = new File("Video.mp4", 1500);

            Directory folder1 = new Directory("MyDocuments");
            folder1.Add(file1);
            folder1.Add(file2);

            Directory folder2 = new Directory("Media");
            folder2.Add(file3);

            Directory root = new Directory("Root");
            root.Add(folder1);
            root.Add(folder2);

            root.Display(0);
            Console.WriteLine($"\nTotal Size: {root.GetSize()}KB");
        }
    }
}
