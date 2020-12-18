using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogGo.Models.ViewModels
{
    public class AppointmentViewModel
    {
        public int OwnerId { get; set; }
        public Walker Walker { get; set; }
        public List<Dog> Dog { get; set; }

    }
}
