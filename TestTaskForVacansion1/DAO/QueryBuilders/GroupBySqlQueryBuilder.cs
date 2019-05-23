using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Data.Linq.Mapping;

namespace TestTaskForVacansion1.DAO.QueryBuilders
{
    public class GroupBySqlQueryBuilder<T> : IGroupByQueryBuilder<T> where T : class
    {
        private IList<string> _groupByFields;
        private IList<string> _sumFields;

        public GroupBySqlQueryBuilder()
        {
            _groupByFields = new List<string>();
            _sumFields = new List<string>();
        }

        public string CreateQueryString()
        {
            Type modelType = typeof(T);
            var tableAttribute = modelType.GetCustomAttribute<TableAttribute>();

            if (_groupByFields.Count > 0)
            {
                StringBuilder query = new StringBuilder("Select ");
                query.Append(string.Join(", ", _groupByFields.Union(_sumFields)));
                query.Append(" From " + tableAttribute.Name);
                query.Append(" Group By " + string.Join(", ", _groupByFields) + ";");
                return query.ToString();
            }

            return $"Select * From { tableAttribute.Name };";
        }

        private bool IsFieldCorrect(string fieldName)
        {
            Type modelType = typeof(T);
            if (modelType.GetFields().Where(f => f.Name == fieldName).Count() > 0)
            {
                return true;
            }
            return false;
        }

        public void AddGroupField(string field)
        {
            if (IsFieldCorrect(field))
            {
                throw new DAOException($"There are no field {field} in {typeof(T)} model.");
            }
            _groupByFields.Add(field);
        }

        public void AddSumField(string field)
        {
            if (IsFieldCorrect(field))
            {
                throw new DAOException($"There are no field {field} in {typeof(T)} model.");
            }
            _sumFields.Add($"Sum({field}) As {field}");
        }

        public void RemoveGroupField(string field)
        {
            try
            {
                _groupByFields.Remove(field);
            }
            catch (Exception ex)
            {
                throw new DAOException(ex.Message, ex);
            }
        }

        public void RemoveSumField(string field)
        {
            try
            {
                _sumFields.Remove($"Sum({field}) As {field}");
            }
            catch (Exception ex)
            {
                throw new DAOException(ex.Message, ex);
            }
        }
    }
}
