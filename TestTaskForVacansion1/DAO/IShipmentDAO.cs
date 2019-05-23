using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskForVacansion1.Models;

namespace TestTaskForVacansion1.DAO
{
    public interface IShipmentDAO : IGroupByDAO<Shipment>
    {
        IEnumerable<Shipment> GetShipments();
        Shipment GetShipmentById(int id);
        void CreateShipment(Shipment shipment);
        void UpdateShipment(Shipment shipment);
        void DeleteShipment(Shipment shipment);
    }
}
