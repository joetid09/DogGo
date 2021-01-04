using System;
using System.Collections.Generic;

namespace DogGo.Models.ViewModels
{
    public class WalksListViewModels
    {
        public List<Dog> Dogs { get; set; }
        public List<Walks> Walks { get; set; }
        public List<Owner> Owners { get; set; }
    }
}
