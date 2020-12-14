using System;
using System.Collections.Generic;
using DogGo.Models;

namespace DogGo.Models.ViewModels
{
    public class OwnerFormViewModel
    {
       public Owner Owner { get; set; }
       public List<Neighborhood> Neighborhood { get; set; }
    }
}
