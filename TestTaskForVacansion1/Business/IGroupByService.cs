using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskForVacansion1.DAO.QueryBuilders;

namespace TestTaskForVacansion1.Business
{
    public interface IGroupByService<T> where T : class
    {
        IGroupByQueryBuilder<T> GroupByQueryBuilder { get; }
        IEnumerable<object> GetGroupedObjects();
    }
}
