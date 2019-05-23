using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskForVacansion1.DAO.QueryBuilders
{
    public interface IGroupByQueryBuilder<T> : IQueryBuilder<T> where T : class
    {
        void AddGroupField(string field);
        void RemoveGroupField(string field);
        void AddSumField(string field);
        void RemoveSumField(string field);
    }
}
