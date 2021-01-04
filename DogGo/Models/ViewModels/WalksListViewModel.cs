using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogGo.Models.ViewModels
{
    public class LoginViewModel
    {
        List<Dog> Dogs { get; set; }
        List<Walks> Walks { get; set; }
        List<Owner> Owners { get; set; }
    }
}
