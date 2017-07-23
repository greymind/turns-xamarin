﻿using System.Collections.Generic;

namespace Greymind.Turns.Android
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Person> Members { get; set; }

        public Group()
        {
            Members = new List<Person>();
        }
    }
}