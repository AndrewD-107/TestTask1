using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskForVacansion1.Models;
using TestTaskForVacansion1.DAO;
using TestTaskForVacansion1.DAO.QueryBuilders;

namespace TestTaskForVacansion1.Business
{
    public class ShipmentGroupByService : IGroupByService<Shipment>
    {
        private IGroupByDAO<Shipment> _dao;

        public IGroupByQueryBuilder<Shipment> GroupByQueryBuilder => _dao.GroupByQueryBuilder;

        public ShipmentGroupByService(IGroupByDAO<Shipment> dao)
        {
            _dao = dao;
        }

        public IEnumerable<object> GetGroupedObjects()
        {
            return _dao.GetGroupedShipments();
        }
    }
}
