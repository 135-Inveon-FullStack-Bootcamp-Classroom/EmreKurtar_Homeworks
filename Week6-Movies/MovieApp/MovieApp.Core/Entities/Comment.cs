﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Core.Entities
{
    public class Comment
    {
        public int ID { get; set; }
        public string Text { get; set; }
        public Movie Movie { get; set; }

    }
}
