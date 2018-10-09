﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreator
{
    public class Character
    {
        public string Username
        {
            get { return _name ?? ""; }
            set { _name = value; }
        }
        private string _name;
        public string Profession
        {
            get { return _profession ?? ""; }
            set { _profession = value; }
        }
        private string _profession;

        public string Race
        {
            get { return _race ?? ""; }
            set { _race = value; }
        }
        private string _race;

        public int Attributes { get; set; }
        public int Strength { get; set; }
    }
}
