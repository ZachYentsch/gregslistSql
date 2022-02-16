using System.Collections.Generic;
using System.Data;
using System.Linq;
using gregslistSql.Models;
using Dapper;

namespace gregslistSql.Repositories
{
    public class CarsRepository
    {
        private readonly IDbConnection _db;

        public CarsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal List<Car> get()
        {
            string sql = "SELECT * FROM cars;";
            List<Car> cars = _db.Query<Car>(sql).ToList();
            return cars;
        }

        internal Car getById(int id)
        {
            string sql = "SELECT * FROM cars WHERE id = @id;";
            Car car = _db.QueryFirstOrDefault<Car>(sql, new { id });
            return car;
        }

        internal Car Create(Car newCar)
        {
            string sql = @"
            INSERT INTO cars
            (make, model, description, imgUrl, yearMade, price)
            VALUES
            (@Make, @Model, @Description, @ImgUrl, @YearMade, @Price);
            SELECT LAST_INSERT_ID();
            ";
            int id = _db.ExecuteScalar<int>(sql, newCar);
            newCar.Id = id;
            return newCar;
        }

        internal void edit(Car original)
        {
            string sql = @"
            UPDATE cars
            SET
            make = @Make,
            model = @Model,
            description = @Description,
            imgUrl = @ImgUrl,
            yearMade = @YearMade,
            price = @Price
            WHERE id = @id;
            ";
            _db.Execute(sql, original);
        }

        internal void remove(int id)
        {
            string sql = "DELETE FROM cars WHERE id = @id LIMIT 1";
            int changed = _db.Execute(sql, new { id });
            if (changed == 0)
            {
                throw new System.Exception("Error, Car was not deleted");
            }
        }
    }
}