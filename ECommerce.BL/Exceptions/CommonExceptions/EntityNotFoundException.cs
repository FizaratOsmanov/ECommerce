﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BL.Exceptions.CommonExceptions
{
    public class EntityNotFoundException:Exception
    {
        public EntityNotFoundException(string message) : base(message) { }
        public EntityNotFoundException() : base("Entity not found") { }
    }
}
