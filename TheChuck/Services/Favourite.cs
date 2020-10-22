using System;
using SQLite;
namespace TheChuck.Services
{
    public class Favourite
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Value { get; set; }
        //public string Category { get; set; }
       
    }
}
