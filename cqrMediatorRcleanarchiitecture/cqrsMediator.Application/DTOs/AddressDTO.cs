﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cqrsMediator.Application.DTOs
{
    public class AddressDTO
    {
        public int Id { get; set; }
        public string Country { get; set; } = string.Empty;

    }
}
