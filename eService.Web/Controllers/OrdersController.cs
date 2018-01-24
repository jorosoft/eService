using System;
using System.Linq;
using System.Web.Mvc;
using eService.Services.Contracts;
using eService.Web.ViewModels.Orders;

namespace eService.Web.Controllers
{
    public class OrdersController : Controller
    {
        private const int FinishedOrderMinWorkwlowLevel = 9;
        private readonly IOrderService orderService;
        private readonly IHistoryService historyService;

        public OrdersController(IOrderService orderService, IHistoryService historyService)
        {
            this.orderService = orderService;
            this.historyService = historyService;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Search(int number)
        {
            if (!ModelState.IsValid)
            {
                return this.View(number);
            }

            var viewModel = this.orderService
                .GetAll()
                .Where(x => x.Number == number)
                .Select(x => new OrderHistoryViewModel
                {
                    Id = x.Id,
                    Number = x.Number,
                    Article = x.Article,
                    SerialNumber = x.SerialNumber
                })
                .SingleOrDefault();

            if (viewModel == null)
            {
                // TODO
            }

            viewModel.History = this.historyService
                .GetAll()
                .Where(x => x.Order.Id == viewModel.Id)
                .OrderBy(x => x.Date)
                .Select(x => new HistoryViewModel
                {
                    Date = x.Date,
                    Status = x.Status.Name
                })
                .ToList();
           
            return this.View(viewModel);
        }

        public ActionResult All()
        {
            var orders = this.orderService
                .GetAll()
                .OrderByDescending(x => x.Date)
                .Select(x => new OrderViewModel
                {
                    Number = x.Number,
                    Date = x.Date,
                    WarrantyCardNumber = x.WarrantyCardNumber,
                    WarrantyCardDate = x.WarrantyCardDate,
                    Article = x.Article,
                    SerialNumber = x.SerialNumber,
                    Priority = x.Priority,
                    Defect = x.Defect,
                    Info = x.Info,
                    Status = x.Status.Name,
                    ServiceType = x.ServiceType.Name,
                    CustomerName = x.Customer.Name,
                    CustomerPhoneNumber = x.Customer.PhoneNumber,
                    CustomerTown = x.Customer.Address.Town.Name,
                    CustomerStreet = x.Customer.Address.Street.Name,
                    CustomerAddressNumber = x.Customer.Address.Number,
                    CustomerAddressFloor = x.Customer.Address.Floor,
                    CustomerAddressApartmentNumber = x.Customer.Address.ApartmentNumber,
                    EmployeeName = x.Employee.Name,
                    SupplierName = x.Supplier.Name
                })
                .ToList();

            var viewModel = new OrdersListViewModel
            {
                Orders = orders
            };

            return this.View(viewModel);
        }

        public ActionResult UnFinished()
        {
            var orders = this.orderService
                .GetAll()
                .Where(x => x.Status.WorkFlowLevel < FinishedOrderMinWorkwlowLevel)
                .OrderByDescending(x => x.Date)
                .Select(x => new OrderViewModel
                {
                    Number = x.Number,
                    Date = x.Date,
                    WarrantyCardNumber = x.WarrantyCardNumber,
                    WarrantyCardDate = x.WarrantyCardDate,
                    Article = x.Article,
                    SerialNumber = x.SerialNumber,
                    Priority = x.Priority,
                    Defect = x.Defect,
                    Info = x.Info,
                    Status = x.Status.Name,
                    ServiceType = x.ServiceType.Name,
                    CustomerName = x.Customer.Name,
                    CustomerPhoneNumber = x.Customer.PhoneNumber,
                    CustomerTown = x.Customer.Address.Town.Name,
                    CustomerStreet = x.Customer.Address.Street.Name,
                    CustomerAddressNumber = x.Customer.Address.Number,
                    CustomerAddressFloor = x.Customer.Address.Floor,
                    CustomerAddressApartmentNumber = x.Customer.Address.ApartmentNumber,
                    EmployeeName = x.Employee.Name,
                    SupplierName = x.Supplier.Name
                })
                .ToList();

            var viewModel = new OrdersListViewModel
            {
                Orders = orders
            };

            return this.View(viewModel);
        }

        public ActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(OrderViewModel order)
        {
            if (!ModelState.IsValid)
            {
                return this.View(order);
            }

            var entity = this.orderService.GetDbModel();
            entity.Number = order.Number;
            entity.Date = order.Date;
            entity.WarrantyCardNumber = order.WarrantyCardNumber;
            entity.WarrantyCardDate = order.WarrantyCardDate;
            entity.Article = order.Article;
            entity.SerialNumber = order.SerialNumber;
            entity.Priority = order.Priority;
            entity.Defect = order.Defect;
            entity.Info = order.Info;
            entity.Status.Name = order.Status;
            entity.ServiceType.Name = order.ServiceType;
            entity.Customer.Name = order.CustomerName;
            entity.Customer.PhoneNumber = order.CustomerPhoneNumber;
            entity.Customer.Address.Town.Name = order.CustomerTown;
            entity.Customer.Address.Street.Name = order.CustomerStreet;
            entity.Customer.Address.Number = order.CustomerAddressNumber;
            entity.Customer.Address.Floor = order.CustomerAddressFloor;
            entity.Customer.Address.ApartmentNumber = order.CustomerAddressApartmentNumber;
            entity.Employee.Name  = order.EmployeeName;
            entity.Supplier.Name = order.SupplierName;

            this.orderService.Add(entity);

            return this.RedirectToAction("All", "Orders");
        }

        public ActionResult Edit(Guid orderId)
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(OrderViewModel order)
        {
            if (!ModelState.IsValid)
            {
                return this.View(order);
            }

            var entity = this.orderService.GetDbModel();
            entity.Number = order.Number;
            entity.Date = order.Date;
            entity.WarrantyCardNumber = order.WarrantyCardNumber;
            entity.WarrantyCardDate = order.WarrantyCardDate;
            entity.Article = order.Article;
            entity.SerialNumber = order.SerialNumber;
            entity.Priority = order.Priority;
            entity.Defect = order.Defect;
            entity.Info = order.Info;
            entity.Status.Name = order.Status;
            entity.ServiceType.Name = order.ServiceType;
            entity.Customer.Name = order.CustomerName;
            entity.Customer.PhoneNumber = order.CustomerPhoneNumber;
            entity.Customer.Address.Town.Name = order.CustomerTown;
            entity.Customer.Address.Street.Name = order.CustomerStreet;
            entity.Customer.Address.Number = order.CustomerAddressNumber;
            entity.Customer.Address.Floor = order.CustomerAddressFloor;
            entity.Customer.Address.ApartmentNumber = order.CustomerAddressApartmentNumber;
            entity.Employee.Name = order.EmployeeName;
            entity.Supplier.Name = order.SupplierName;

            this.orderService.Update(entity);

            return this.RedirectToAction("All", "Orders");
        }
    }
}