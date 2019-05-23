﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskForVacansion1.DAO.QueryBuilders
{
    public interface IQueryBuilder<T> where T : class
    {
        string CreateQueryString();
    }
}
