﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW.Models.Base
{
    public interface IBaseEntity
    {
        Guid Id { get; set; }

        DateTime? DateCreated { get; set; }

        DateTime? DateModified { get; set; }
    }
}
