﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerLogbook.Services.DTOs
{
    public class TownDTO
    {
        public int Id { get; set; }

        public string TownName { get; set; }

        public IReadOnlyCollection<BusinessUnitDTO> BusinessUnits { get; set; }
    }
}


