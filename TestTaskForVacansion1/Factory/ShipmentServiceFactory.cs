using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskForVacansion1.DAO;
using TestTaskForVacansion1.Business;
using TestTaskForVacansion1.Models;
using TestTaskForVacansion1.Repository;
using System.Configuration;

namespace TestTaskForVacansion1.Factory
{
    public static class ShipmentServiceFactory
    {
        private static IShipmentDAO _dao;

        static ShipmentServiceFactory()
        {
            string connectionStr = ConfigurationManager.ConnectionStrings["database"].ConnectionString;
            _dao = new ShipmentSqlDAO(connectionStr);
        }

        public static IGroupByService<Shipment> CreateShipmentGroupByService()
        {
            return new ShipmentGroupByService(_dao);
        }

        public static IShipmentRepository CreateShipmentRepository()
        {
            return new ShipmentSqlRepository(_dao);
        }
    }
}
