using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskForVacansion1.Models;
using TestTaskForVacansion1.DAO.QueryBuilders;

namespace TestTaskForVacansion1.DAO
{
    public interface IGroupByDAO<T> where T : class
    {
        IGroupByQueryBuilder<T> GroupByQueryBuilder { get; set; }

        IEnumerable<Shipment> GetGroupedShipments();
        IEnumerable<Shipment> GetGroupedShipments(string[] aggregatedFields, 
            params string[] groupedFields);
    }
}
