﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskForVacansion1.DAO
{
    public class DAOException : Exception
    {
        public DAOException(string message) : base(message) { }
        public DAOException(string message, Exception ex) : base(message, ex) { }
    }
}
