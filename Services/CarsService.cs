using System;
using System.Collections.Generic;
using gregslistSql.Models;
using gregslistSql.Repositories;

namespace gregslistSql.Services
{
    public class CarsService
    {
        private readonly CarsRepository _repo;

        public CarsService(CarsRepository repo)
        {
            _repo = repo;
        }

        internal List<Car> get()
        {
            List<Car> cars = _repo.get();
            return cars;
        }

        internal Car getById(int id)
        {
            Car car = _repo.getById(id);
            if (car == null)
            {
                throw new Exception("Invalid ID");
            }
            return car;
        }

        internal Car Create(Car newCar)
        {
            Car car = _repo.Create(newCar);
            return car;
        }

        internal Car Edit(Car updated, int id)
        {
            Car original = getById(id);
            original.Make = updated.Make;
            original.Model = updated.Model != null ? updated.Model : original.Model;
            original.Description = updated.Description != null ? updated.Description : original.Description;
            original.imgUrl = updated.imgUrl != null ? updated.imgUrl : original.imgUrl;
            original.YearMade = updated.YearMade != 0 ? updated.YearMade : original.YearMade;
            original.Price = updated.Price != 0 ? updated.Price : original.Price;
            _repo.edit(original);
            return original;
        }

        internal void remove(int id)
        {
            getById(id);
            _repo.remove(id);
        }
    }
}