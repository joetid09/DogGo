﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogGo.Models.ViewModels
{
    public class WalkerProfileViewModel
    {
        Walker Walker { get; set; }
        public List<Walks> Walks {get; set;}


    }
}
