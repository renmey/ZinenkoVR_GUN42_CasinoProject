using CasinoProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CasinoProject.Player
{
    public class PlayerProfile
    {
        public string Name { get; set; }
        public int Balance { get; set; }

        public PlayerProfile(string name, int balance)
        {
            Name = name;
            Balance = balance;

        }

        public void AddMoney(int amount)
        {
            Balance += amount;
        }

        public void RemoveMoney(int amount)
        {
            Balance -= amount;
        }

        public PlayerProfile CreateProfile()
        {
            Console.WriteLine("Enter your name:");

            string name = Console.ReadLine();

            return new PlayerProfile(name, 1000);
        }

        public override string ToString()
        {
            return $"Name: {this.Name}, balance: {this.Balance}";
        }


        public void SavePlayer(PlayerProfile player, ISaveLoadService<string> service)
        {
            string data = $"{player.Name},{player.Balance}";
            service.SaveData(data, "player");
        }

        public PlayerProfile LoadPlayer(ISaveLoadService<string> service)
        {

            string data = service.LoadData("player");

            var parts = data.Split(',');

            string name = parts[0];
            int balance = int.Parse(parts[1]);

            return new PlayerProfile(name, balance);
        }
    }
}
