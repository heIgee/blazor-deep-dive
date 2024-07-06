using System.ComponentModel.DataAnnotations;

namespace ServerManagement.Models
{
    public class Server
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string City { get; set; } = string.Empty;

        public bool IsOnline { get; set; }
        //public string Status => IsOnline ? "ONLINE" : "OFFLINE";

        private readonly bool _coinFlip;

        public Server()
        {
            
        }

        //public Server() { } // I do not have a right to have multiple ctors (Blazor said so)
        // for static ssr form

        public Server(int id, string name, string city)
        {
            Id = id;
            Name = name;
            City = city;

            _coinFlip = Random.Shared.Next(0, 2) == 0;
            IsOnline = _coinFlip;
        }

        //public Server(long id, string name, string city, bool isOnline)
        //{
        //    Id = id;
        //    Name = name;
        //    City = city;
        //    IsOnline = isOnline;
        //}


    }
}
