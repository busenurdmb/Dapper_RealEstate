using Dapper;
using ReakEstate.Entites.Abstract;
using ReakEstate.Entites.Concrete;
using RealEstate.Data.Concrete.DapperContext;
using RealEstate.Data.IRepositroy;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Data.Repository
{

    public class DapperRepository<T> : IDapperRepository<T> where T : class, IEntity, new()

    {
        private readonly Context _context;
        private readonly string _tableName;

        public DapperRepository(string tableName, Context context)
        {

            _tableName = tableName;
            _context = context;
        }


        public async Task<IEnumerable<T>> GetAll()
        {
            string query = $"SELECT * FROM {_tableName}";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<T>(query);
                return values.ToList();
            }
        }

        public async Task<T> GetById(int id)
        {
            string query = $"SELECT * FROM {_tableName} WHERE {_tableName}ID  = @Id";
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                var entity = await connection.QueryFirstOrDefaultAsync<T>(query, new { Id = id });
                return entity;
            }
        }


        public async Task<int> Insert(T entity)
        {

            var properties = GetProperties(entity).Where(p => !p.Name.Contains("ID"));

            var propertyNames = string.Join(", ", properties.Select(p => p.Name));
            var propertyValues = string.Join(", ", properties.Select(p => "@" + p.Name));

            string query = $"INSERT INTO {_tableName} ({propertyNames}) VALUES ({propertyValues})";

            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                return await connection.ExecuteAsync(query, entity);
            }
        }

        public async Task<bool> Update(T entity)
        {
            // Id özelliğini içermeyen özellikleri al
            var properties = GetProperties(entity).Where(p => !p.Name.Contains("ID"));

            // Güncellenen alanları oluştur
            var updateFields = string.Join(", ", properties.Select(p => $"{p.Name} = @{p.Name}"));

            // Id özelliğini içeren Property'yi al
            var idProperty = GetProperties(entity).FirstOrDefault(p => p.Name.Contains("ID"));

            // Id özelliğinin adını ve değerini al
            var idPropertyName = idProperty?.Name;

            // Sorguyu oluştur

            string query = $"UPDATE {_tableName} SET {updateFields} WHERE {idPropertyName} = @{idPropertyName}";

            using (var connection = _context.CreateConnection())
            {
                connection.Open();

                // Sorguyu çalıştır ve etkilenen satır sayısını al
                int rowsAffected = await connection.ExecuteAsync(query, entity);

                // Etkilenen satır sayısına göre başarılı veya başarısız olduğunu belirle
                return rowsAffected > 0;
            }
        }

        #region use DynamicParameters();
        //public async Task<bool> Update(T entity)
        //{
        //    // Id özelliğini içermeyen özellikleri al
        //    var properties = GetProperties(entity);

        //    // Güncellenen alanları oluştur
        //    var updateFields = string.Join(", ", properties.Select(p => $"{p.Name} = @{p.Name}"));

        //    // Id özelliğini içeren Property'yi al
        //    var idProperty = GetProperties(entity).FirstOrDefault(p => p.Name.Contains("ID"));

        //    // Id özelliğinin adını ve değerini al
        //    var idPropertyName = idProperty?.Name;
        //    var idValue = idProperty?.GetValue(entity);

        //    // Sorguyu oluştur
        //    string query = $"UPDATE {_tableName} SET {updateFields} WHERE {idPropertyName} = @{idPropertyName}";

        //    // Parametreleri oluştur
        //    var parameters = new DynamicParameters();
        //    foreach (var property in properties)
        //    {
        //        parameters.Add(property.Name, property.GetValue(entity));
        //    }
        //    parameters.Add(idPropertyName, idValue);

        //    using (var connection = _context.CreateConnection())
        //    {
        //        connection.Open();

        //        // Sorguyu çalıştır ve etkilenen satır sayısını al
        //        int rowsAffected = await connection.ExecuteAsync(query, parameters);

        //        // Etkilenen satır sayısına göre başarılı veya başarısız olduğunu belirle
        //        return rowsAffected > 0;
        //    }
        //}
        #endregion

        public async Task<bool> Delete(int id)
        {

            string query = $"DELETE FROM {_tableName} WHERE {_tableName}ID = @{_tableName}ID";
            var parameters = new DynamicParameters();
            parameters.Add("@CategoryID", id);
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                int rowsAffected = await connection.ExecuteAsync(query, parameters);
                return rowsAffected > 0;
            }
        }



        private IEnumerable<PropertyInfo> GetProperties(T entity)
        {
            return typeof(T).GetProperties();
        }
    }
}



