﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogGo.Models.ViewModels
{
    public class LocalWalkerListViewModel
    {
        public List<Walker> Walker { get; set; }
        public List<Neighborhood> Neighborhoods { get; set; }
    }
}
