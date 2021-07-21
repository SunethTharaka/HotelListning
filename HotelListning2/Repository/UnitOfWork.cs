using HotelListning2.Data;
using HotelListning2.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelListning2.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContaxt _contaxt;

        private IGenericRepository<Country> _countries;
        private IGenericRepository<Hotel> _hotels;

        public UnitOfWork(DatabaseContaxt contaxt)
        {
            _contaxt = contaxt;
        }

        public IGenericRepository<Country> Countries => _countries ??= new GenericRepository<Country>(_contaxt);
        public IGenericRepository<Hotel> Hotels => _hotels ??= new GenericRepository<Hotel>(_contaxt);

        public void Dispose()
        {
            _contaxt.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            await _contaxt.SaveChangesAsync();
        }
    }
}
