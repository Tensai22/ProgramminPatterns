using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw10
{
    public class TV
    {
        public void On() => Console.WriteLine("TV is On");
        public void Off() => Console.WriteLine("TV is Off");
        public void SetChannel(int channel) => Console.WriteLine($"TV Channel set to {channel}");
    }
    public class AudioSystem
    {
        private int volume = 5;

        public void On() => Console.WriteLine("Audio System is On");
        public void Off() => Console.WriteLine("Audio System is Off");

        public void SetVolume(int level)
        {
            volume = level;
            Console.WriteLine($"Audio System volume set to {volume}");
        }
    }
    public class DVDPlayer
    {
        public void Play() => Console.WriteLine("DVD is Playing");
        public void Pause() => Console.WriteLine("DVD is Paused");
        public void Stop() => Console.WriteLine("DVD is Stopped");
    }
    public class GameConsole
    {
        public void On() => Console.WriteLine("Game Console is On");
        public void StartGame() => Console.WriteLine("Game is Starting");
    }
    public class HomeTheaterFacade
    {
        private readonly TV tv;
        private readonly AudioSystem audio;
        private readonly DVDPlayer dvd;
        private readonly GameConsole console;

        public HomeTheaterFacade(TV tv, AudioSystem audio, DVDPlayer dvd, GameConsole console)
        {
            this.tv = tv;
            this.audio = audio;
            this.dvd = dvd;
            this.console = console;
        }

        public void WatchMovie()
        {
            Console.WriteLine("\nSetting up to watch a movie...");
            tv.On();
            tv.SetChannel(3);
            audio.On();
            audio.SetVolume(7);
            dvd.Play();
        }

        public void EndMovie()
        {
            Console.WriteLine("\nShutting down movie mode...");
            dvd.Stop();
            audio.Off();
            tv.Off();
        }

        public void PlayGame()
        {
            Console.WriteLine("\nSetting up to play a game...");
            console.On();
            audio.On();
            audio.SetVolume(6);
            console.StartGame();
        }

        public void ListenToMusic()
        {
            Console.WriteLine("\nSetting up to listen to music...");
            tv.On();
            audio.On();
            audio.SetVolume(8);
        }

        public void TurnOffAll()
        {
            Console.WriteLine("\nTurning off all systems...");
            dvd.Stop();
            console.On();
            audio.Off();
            tv.Off();
        }
    }

}
