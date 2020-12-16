using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogGo.Models.ViewModels
{
    public class WalkerListViewModel
    {
        public List<Walker> Walker { get; set; }
        public Neighborhood Neighborhood { get; set; }
    }
}
