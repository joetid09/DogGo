﻿using System;
using System.Collections.Generic;
using System.Linq;
using DogGo.Models;

namespace DogGo.Repositories
{
    public class IOwnerRepository
    {
        List<Owner> GetAllOwners();

        Owner GetOwnerById(int id);

    }
}
