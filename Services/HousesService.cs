using System;
using System.Collections.Generic;
using gregslistSql.Models;
using gregslistSql.Repositories;

namespace gregslistSql.Services
{
    public class HousesService
    {
        private readonly HousesRepository _repo;

        public HousesService(HousesRepository repo)
        {
            _repo = repo;
        }

        internal List<House> get()
        {
            List<House> houses = _repo.get();
            return houses;
        }

        internal House getById(int id)
        {
            House house = _repo.getById(id);
            if (house == null)
            {
                throw new Exception("Invalid Id");
            }
            return house;
        }

        internal House Create(House newHouse)
        {
            House house = _repo.Create(newHouse);
            return house;
        }

        internal House Edit(House updated, int id)
        {
            House original = getById(id);
            original.Address = updated.Address;
            original.City = updated.City != null ? updated.City : original.City;
            original.State = updated.State != null ? updated.State : original.State;
            original.Beds = updated.Beds != 0 ? updated.Beds : original.Beds;
            original.Sqft = updated.Sqft != 0 ? updated.Sqft : original.Sqft;
            original.Price = updated.Price != 0 ? updated.Price : original.Price;
            _repo.Edit(original);
            return original;
        }

        internal void Remove(int id)
        {
            getById(id);
            _repo.Remove(id);
        }
    }
}