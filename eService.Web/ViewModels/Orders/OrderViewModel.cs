using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace eService.Web.ViewModels.Orders
{
    public class OrderViewModel
    {
        public Guid? Id { get; set; }

        public int? Number { get; set; }
        
        public DateTime? Date { get; set; }

        [Range(0, int.MaxValue)]
        public int? WarrantyCardNumber { get; set; }

        public DateTime? WarrantyCardDate { get; set; }
        
        [Required(ErrorMessage = "Задължително поле!")]
        public string Article { get; set; }

        public string SerialNumber { get; set; }

        public bool IsHighPriority { get; set; }

        [Required(ErrorMessage = "Задължително поле!")]
        public string Defect { get; set; }

        public string Info { get; set; }

        public string Status { get; set; }

        public bool IsWarrantyService { get; set; }

        [Required(ErrorMessage = "Задължително поле!")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Задължително поле!")]
        public string CustomerPhoneNumber { get; set; }

        [Required(ErrorMessage = "Задължително поле!")]
        public string CustomerTown { get; set; }

        public string CustomerStreet { get; set; }

        public int? CustomerAddressNumber { get; set; }

        [StringLength(1)]
        public string CustomerAddressEntry { get; set; }

        public int? CustomerAddressFloor { get; set; }

        public int? CustomerAddressApartmentNumber { get; set; }

        public string EmployeeName { get; set; }

        public string SupplierName { get; set; }

        public List<string> Towns { get; set; }
    }
}