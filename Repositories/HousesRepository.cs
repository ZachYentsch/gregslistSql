using System.Collections.Generic;
using System.Data;
using System.Linq;
using gregslistSql.Models;
using Dapper;

namespace gregslistSql.Repositories
{
    public class HousesRepository
    {
        private readonly IDbConnection _db;

        public HousesRepository(IDbConnection db)
        {
            _db = db;
        }

        internal List<House> get()
        {
            string sql = "SELECT * FROM houses;";
            List<House> houses = _db.Query<House>(sql).ToList();
            return houses;
        }

        internal House getById(int id)
        {
            string sql = "SELECT * FROM houses WHERE id = @id;";
            House house = _db.QueryFirstOrDefault<House>(sql, new { id });
            return house;
        }

        internal House Create(House newHouse)
        {
            string sql = @"
            INSERT INTO houses
            (address, city, state, beds, sqft, price)
            VALUES
            (@Address, @City, @State, @Beds, @Sqft, @Price);
            SELECT LAST_INSERT_ID();
            ";
            int id = _db.ExecuteScalar<int>(sql, newHouse);
            newHouse.Id = id;
            return newHouse;
        }

        internal void Edit(House original)
        {
            string sql = @"
            UPDATE houses
            SET
            address = @Address,
            city = @City,
            state = @State,
            beds = @Beds,
            sqft = @Sqft,
            price = @Price
            WHERE id = @id;
            ";
            _db.Execute(sql, original);
        }

        internal void Remove(int id)
        {
            string sql = "DELETE FROM houses WHERE id = @id LIMIT 1";
            int changed = _db.Execute(sql, new { id });
            if (changed == 0)
            {
                throw new System.Exception("Error, House was not deleted");
            }
        }
    }
}