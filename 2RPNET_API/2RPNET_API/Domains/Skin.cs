﻿using System;
using System.Collections.Generic;

#nullable disable

namespace _2RPNET_API.Domains
{
    public partial class Skin
    {
        public Skin()
        {
            LibrarySkins = new HashSet<LibrarySkin>();
        }

        public int IdSkin { get; set; }
        public string Title { get; set; }
        public string SkinImages { get; set; }
        public string SkinDescription { get; set; }
        public int? PrecoSkin { get; set; }

        public virtual ICollection<LibrarySkin> LibrarySkins { get; set; }
    }
}
