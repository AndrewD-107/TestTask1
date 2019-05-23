using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskForVacansion1.Models;
using TestTaskForVacansion1.DAO;

namespace TestTaskForVacansion1.Repository
{
    public class ShipmentSqlRepository : IShipmentRepository
    {
        private IShipmentDAO _dao;

        public ShipmentSqlRepository(IShipmentDAO dao)
        {
            _dao = dao;
        }

        public void Create(Shipment item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Shipment item)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Shipment> GetAll()
        {
            return _dao.GetShipments();
        }

        public Shipment GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Shipment item)
        {
            throw new NotImplementedException();
        }
    }
}
