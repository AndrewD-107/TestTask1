using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskForVacansion1.Models;
using System.Configuration;
using System.Data.SqlClient;
using TestTaskForVacansion1.DAO.QueryBuilders;

namespace TestTaskForVacansion1.DAO
{
    public class ShipmentSqlDAO : IShipmentDAO
    {
        private string _connectionStr;

        public IGroupByQueryBuilder<Shipment> GroupByQueryBuilder { get; set; }

        public ShipmentSqlDAO(string connection)
        {
            try
            {
                _connectionStr = connection;
                GroupByQueryBuilder = new GroupBySqlQueryBuilder<Shipment>();
            }
            catch (Exception ex)
            {
                // Log Error detail
                throw new DAOException("Initialize DAO Error", ex);
            }
        }

        public ShipmentSqlDAO(string connection, IGroupByQueryBuilder<Shipment> groupByQueryBuilder)
        {
            try
            {
                _connectionStr = ConfigurationManager.ConnectionStrings[connection].ConnectionString;
                GroupByQueryBuilder = groupByQueryBuilder;
            }
            catch (Exception ex)
            {
                // Log Error Detail
                throw new DAOException("Initialize DAO Error", ex);
            }
        }

        public void CreateShipment(Shipment shipment)
        {
            throw new NotImplementedException();
        }

        public void DeleteShipment(Shipment shipment)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Shipment> GetGroupedShipments()
        {
            return FetchGroupedData();
        }

        public IEnumerable<Shipment> GetGroupedShipments(string[] aggregatedFields, 
            params string[] groupedFields)
        {
            try
            {
                FillGroupBuilder(aggregatedFields, groupedFields);
                return FetchGroupedData();
            }
            catch (Exception ex)
            {
                // Log Error Details
                throw new DAOException("There is some error while group fields", ex);
            }
        }

        public Shipment GetShipmentById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Shipment> GetShipments()
        {
            try
            {
                IList<Shipment> shipmentList = new List<Shipment>();
                using (SqlConnection connection = new SqlConnection(_connectionStr))
                {
                    connection.Open();
                    string queryStr = "Select * From Shipments;";
                    using (SqlCommand command = new SqlCommand(queryStr, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                shipmentList.Add(GetShipmentFromReader(reader));
                            }
                        }
                    }
                }
                return shipmentList;
            }
            catch (Exception ex)
            {
                // Log Error Details
                throw new DAOException("There is some error while get all shipments", ex);
            }
        }

        public void UpdateShipment(Shipment shipment)
        {
            throw new NotImplementedException();
        }

        private IEnumerable<Shipment> FetchGroupedData()
        {
            IList<Shipment> shipmentList = new List<Shipment>();
            using (SqlConnection connect = new SqlConnection(_connectionStr))
            {
                connect.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connect;
                    command.CommandText = GroupByQueryBuilder.CreateQueryString();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            shipmentList.Add(GetShipmentFromReader(reader));
                        }
                    }
                }
            }
            return shipmentList;
        }

        private void FillGroupBuilder(string[] sumFields, string[] groupedFields)
        {
            foreach (string field in sumFields)
            {
                GroupByQueryBuilder.AddSumField(field);
            }
            foreach (string field in groupedFields)
            {
                GroupByQueryBuilder.AddSumField(field);
            }
        }

        private Shipment GetShipmentFromReader(SqlDataReader reader)
        {
            Shipment shipment = new Shipment();

            for (int i = 0; i < reader.FieldCount; i++)
            {
                switch (reader.GetName(i))
                {
                    case "Id": shipment.Id = reader.GetInt32(i); break;
                    case "RegistrationDate":
                        shipment.RegistrationDate = reader.GetDateTime(i); break;
                    case "Organization":
                        shipment.Organization = reader.GetString(i); break;
                    case "City": shipment.City = reader.GetString(i); break;
                    case "Country": shipment.Country = reader.GetString(i); break;
                    case "Manager": shipment.Manager = reader.GetString(i); break;
                    case "Quantity": shipment.Quantity = reader.GetInt32(i); break;
                    case "Price": shipment.Price = reader.GetDecimal(i); break;
                }
            }

            return shipment;
        }
    }
}
