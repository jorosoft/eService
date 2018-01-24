using System;

namespace eService.Web.ViewModels.Orders
{
    public class OrderViewModel
    {
        public int Number { get; set; }
        
        public DateTime Date { get; set; }

        public int WarrantyCardNumber { get; set; }

        public DateTime WarrantyCardDate { get; set; }
        
        public string Article { get; set; }

        public string SerialNumber { get; set; }

        public bool Priority { get; set; }

        public string Defect { get; set; }

        public string Info { get; set; }

        public string Status { get; set; }

        public string ServiceType { get; set; }

        public string CustomerName { get; set; }

        public string CustomerPhoneNumber { get; set; }

        public string CustomerTown { get; set; }

        public string CustomerStreet { get; set; }

        public int CustomerAddressNumber { get; set; }

        public int CustomerAddressFloor { get; set; }

        public int CustomerAddressApartmentNumber { get; set; }

        public string EmployeeName { get; set; }

        public string SupplierName { get; set; }
    }
}