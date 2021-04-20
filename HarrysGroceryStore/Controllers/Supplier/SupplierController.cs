using HarrysGroceryStore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarrysGroceryStore.Controllers
{
    public class SupplierController : Controller
    {
        private int _pageSize = 10;
        private ISupplierRepository _repository;

        public SupplierController(ISupplierRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult AddSupplier()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddSupplier(Supplier supplier)
        {
            _repository.AddSupplier(supplier);
            return RedirectToAction("Index");
        }

        public IActionResult Index(int supplierPage = 1)
        {
            IQueryable<Supplier> allSuppliers = _repository.GetAllSuppliers();
            IQueryable<Supplier> someSuppliers = allSuppliers.OrderBy(p => p.SupplierId).Skip((supplierPage - 1) * _pageSize).Take(_pageSize);

            ListViewModel lvm = new ListViewModel();

            PagingInfo pi = new PagingInfo();
            pi.TotalItems = allSuppliers.Count();
            pi.ItemsPerPage = _pageSize;
            pi.CurrentPage = supplierPage;

            lvm.PagingInformation = pi;

            lvm.Suppliers = someSuppliers;

            return View(lvm);
        }

        public IActionResult SupplierDetail(int id)
        {
            Supplier supplier = _repository.GetSupplierById(id);
            if (supplier != null)
            {
                return View(supplier);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Search(string keyword)
        {
            IQueryable<Supplier> suppliers = _repository.GetSuppliersByKeyword(keyword);
            return View(suppliers);
        }

        [HttpGet]
        public IActionResult UpdateSupplier(int id)
        {
            Supplier supplier = _repository.GetSupplierById(id);
            if (supplier != null)
            {
                return View(supplier);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult UpdateSupplier(Supplier supplier)
        {
            Supplier updatedSupplier = _repository.UpdateSupplier(supplier);
            return RedirectToAction("SupplierDetail", new { id = supplier.SupplierId });
        }

        [HttpGet]
        public IActionResult DeleteSupplier(int id)
        {
            Supplier supplier = _repository.GetSupplierById(id);
            if (supplier != null)
            {
                return View(supplier);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteSupplier(Supplier supplier, int id)
        {
            _repository.DeleteSupplier(id);
            return RedirectToAction("Index");
        }
    }
}
