using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class UnitOfWork : IDisposable
    {
        private MyDBContext _dBContext;
        private CategoryRepository _categoryRepository;
        private CityRepository _cityRepository;
        private ProductRepository _productRepository;
        private SupplierRepository _supplierRepository;
        private bool _disposed;

        public UnitOfWork()
        {
            _dBContext = new MyDBContext();
            _categoryRepository = new CategoryRepository(_dBContext);
            _cityRepository = new CityRepository(_dBContext);
            _productRepository = new ProductRepository(_dBContext);
            _supplierRepository = new SupplierRepository(_dBContext);
            _disposed = false;
        }
        public CategoryRepository CategoryRepository
        {
            get
            {
                if (_categoryRepository == null)
                    _categoryRepository = new CategoryRepository(_dBContext);
                return _categoryRepository;
            }
        }
        public CityRepository CityRepository
        {
            get
            {
                if (_cityRepository == null)
                    _cityRepository = new CityRepository(_dBContext);
                return _cityRepository;
            }
        }
        public ProductRepository ProductRepository
        {
            get
            {
                if (_productRepository == null)
                    _productRepository = new ProductRepository(_dBContext);
                return _productRepository;
            }
        }
        public SupplierRepository SupplierRepository
        {
            get
            {
                if (_supplierRepository == null)
                    _supplierRepository = new SupplierRepository(_dBContext);
                return _supplierRepository;
            }
        }
        public void Save()
        {
            _dBContext.SaveChanges();
        }
        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                    _dBContext.Dispose();
                _disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
