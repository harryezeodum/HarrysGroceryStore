using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarrysGroceryStore.Models
{
    public class EfSupplierRepository : ISupplierRepository
    {
        private AppDbContext _context;

        public EfSupplierRepository(AppDbContext context)
        {
            _context = context;
        }

        public Supplier AddSupplier(Supplier supplier)
        {
            _context.Suppliers.Add(supplier);
            _context.SaveChanges();
            return supplier;
        }

        public IQueryable<Supplier> GetAllSuppliers()
        {
            return _context.Suppliers;
        }

        public Supplier GetSupplierById(int supplierId)
        {
            Supplier supplier = _context.Suppliers.Include(s => s.Products).Where(s => s.SupplierId == supplierId).FirstOrDefault();
            return supplier;
        }

        public IQueryable<Supplier> GetSuppliersByKeyword(string keyword)
        {
            IQueryable<Supplier> suppliers = _context.Suppliers.Where(p => p.CompanyName.Contains(keyword));
            return suppliers;
        }

        public Supplier UpdateSupplier(Supplier supplier)
        {
            Supplier supplierToUpdate = _context.Suppliers.Find(supplier.SupplierId);
            if (supplierToUpdate != null)
            {
                supplierToUpdate.CompanyName = supplier.CompanyName;
                supplierToUpdate.ContactName = supplier.ContactName;
                supplierToUpdate.ContactEmail = supplier.ContactEmail;
                supplierToUpdate.ContactPhone = supplier.ContactPhone;
                _context.SaveChanges();
            }
            return supplierToUpdate;
        }

        public bool DeleteSupplier(int id)
        {
            Supplier supplierToDelete = GetSupplierById(id);
            if (supplierToDelete == null)
            {
                return false;
            }
            _context.Suppliers.Remove(supplierToDelete);
            _context.SaveChanges();
            return true;
        }
    }
}
