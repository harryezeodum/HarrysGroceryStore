using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarrysGroceryStore.Models
{
    public interface ISupplierRepository
    {
        public Supplier AddSupplier(Supplier supplier);

        public IQueryable<Supplier> GetAllSuppliers();

        public Supplier GetSupplierById(int supplierId);

        public IQueryable<Supplier> GetSuppliersByKeyword(string keyword);

        public Supplier UpdateSupplier(Supplier supplier);

        public bool DeleteSupplier(int id);
    }
}
