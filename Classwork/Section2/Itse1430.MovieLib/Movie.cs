﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itse1430.MovieLib
{
    public class Movie
    {
        public string Name
        {
            get { return _name ?? ""; }   // string get ()
            set { _name = value; }  // void set ( string value )
        }
        //public string GetName ()
        //{
        //    return _name ?? "";
        //}
        private string _name = "";

        public string Description
        {
            get { return _description ?? ""; }
            set { _description = value; }
        }
        private string _description;

        public int ReleaseYear { get; set; } = 1900;
        //{
        //    get { return _releaseYear; }
        //    set
        //    {
        //        if (value >= 1900)
        //            _releaseYear = value;
        //    }
        //}
        //private int _releaseYear = 1900;


        public int RunLength { get; set; }

        //public int RunLength
        //{
        //    get { return _runLength; }
        //    set
        //    {
        //        if (value >= 0)
        //            _runLength = value;
        //    }
        //}
        //private int _runLength;


        int someValue;
        private int someValue2;

        //void Foo ()
        //{
        //    var x = RunLength;

        //    var isLong = x > 100;

        //    var y = someValue;
        //}

        public int Id { get; private set; }

        public bool IsColor
        {
            get { return ReleaseYear > 1940; }
        }
    }
}
