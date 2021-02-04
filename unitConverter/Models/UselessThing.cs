using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace unitConverter.Models
{
    public class UselessThing
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public float Weight { get; set; }
        public float Length  { get; set; }
    }
}
