﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NSE.Core.Data
{
    public interface IUnitiOfWork
    {
        Task<bool> Commit();
    }
}
