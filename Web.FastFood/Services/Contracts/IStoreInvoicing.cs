﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebFastFood.Services.Contracts
{
   public interface IStoreInvoicing
    {
         void AddStoreInvoicing( string productId, int currentUserId);

    }
}
