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
        private readonly IDateService dateService;
        private readonly IDataServices dataServices;

        public OrdersController(IDateService dateService, IDataServices dataServices)
        {            
            this.dateService = dateService;
            this.dataServices = dataServices;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Search(int serviceNumber)
        {
            if (!ModelState.IsValid)
            {
                return this.View(serviceNumber);
            }

            var viewModel = this.dataServices.OrderService
                .GetAll()
                .Where(x => x.Number == serviceNumber)
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

            viewModel.History = this.dataServices.HistoryService
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
            var orders = this.dataServices.OrderService
                .GetAll()
                .OrderByDescending(x => x.Number)
                .Select(x => new OrderViewModel
                {
                    Number = x.Number,
                    Date = x.Date,
                    WarrantyCardNumber = x.WarrantyCardNumber,
                    WarrantyCardDate = x.WarrantyCardDate,
                    Article = x.Article,
                    SerialNumber = x.SerialNumber,
                    IsHighPriority = x.IsHighPriority,
                    Defect = x.Defect,
                    Info = x.Info,
                    Status = x.Status.Name,
                    IsWarrantyService = x.IsWarrantyService,
                    CustomerName = x.Customer.Name,
                    CustomerPhoneNumber = x.Customer.PhoneNumber,
                    CustomerTown = x.Customer.Address.Town.Name,
                    CustomerStreet = x.Customer.Address.Street.Name,
                    CustomerAddressNumber = x.Customer.Address.Number,
                    CustomerAddressEntry = x.Customer.Address.Entry,
                    CustomerAddressFloor = x.Customer.Address.Floor,
                    CustomerAddressApartmentNumber = x.Customer.Address.ApartmentNumber,
                    EmployeeName = x.User.EmployeeName,
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
            var orders = this.dataServices.OrderService
                .GetAll()
                .Where(x => x.Status.WorkFlowLevel < FinishedOrderMinWorkwlowLevel)
                .OrderByDescending(x => x.Number)
                .Select(x => new OrderViewModel
                {
                    Number = x.Number,
                    Date = x.Date,
                    WarrantyCardNumber = x.WarrantyCardNumber,
                    WarrantyCardDate = x.WarrantyCardDate,
                    Article = x.Article,
                    SerialNumber = x.SerialNumber,
                    IsHighPriority = x.IsHighPriority,
                    Defect = x.Defect,
                    Info = x.Info,
                    Status = x.Status.Name,
                    IsWarrantyService = x.IsWarrantyService,
                    CustomerName = x.Customer.Name,
                    CustomerPhoneNumber = x.Customer.PhoneNumber,
                    CustomerTown = x.Customer.Address.Town.Name,
                    CustomerStreet = x.Customer.Address.Street.Name,
                    CustomerAddressNumber = x.Customer.Address.Number,
                    CustomerAddressEntry = x.Customer.Address.Entry,
                    CustomerAddressFloor = x.Customer.Address.Floor,
                    CustomerAddressApartmentNumber = x.Customer.Address.ApartmentNumber,
                    EmployeeName = x.User.EmployeeName,
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
            var towns = this.dataServices.TownService
                .GetAll()
                .Select(x => x.Name)                
                .ToList();

            var viewModel = new OrderViewModel
            {
                Towns = towns
            };

            return this.View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(OrderViewModel order)
        {
            if (!ModelState.IsValid)
            {
                return this.View(order);
            }

            var entity = this.dataServices.OrderService.GetDbModel();
            entity.Number = this.dataServices.OrderService.GetAvailableOrderNumber();
            entity.Date = this.dateService.Today;
            entity.Customer = this.dataServices.CustomerService.GetDbModel();
            entity.Customer.Address = this.dataServices.AddressService
                .GetDbModel(order.CustomerTown, order.CustomerStreet);
            entity.User = this.dataServices.UserService.GetAll()
                .First(x => x.UserName == User.Identity.Name);
            entity.Status = this.dataServices.StatusService.GetAll()
                .First(x => x.Name == "Приет");

            entity.WarrantyCardNumber = order.WarrantyCardNumber;
            entity.WarrantyCardDate = order.WarrantyCardDate;
            entity.Article = order.Article;
            entity.SerialNumber = order.SerialNumber;
            entity.IsHighPriority = order.IsHighPriority;
            entity.Defect = order.Defect;
            entity.Info = order.Info;
            entity.IsWarrantyService = order.IsWarrantyService;
                                  
            entity.Customer.Name = order.CustomerName;
            entity.Customer.PhoneNumber = order.CustomerPhoneNumber;
            entity.Customer.Address.Number = order.CustomerAddressNumber;
            entity.Customer.Address.Entry = order.CustomerAddressEntry;
            entity.Customer.Address.Floor = order.CustomerAddressFloor;
            entity.Customer.Address.ApartmentNumber = order.CustomerAddressApartmentNumber;

            this.dataServices.OrderService.Add(entity);

            var newHistory = this.dataServices.HistoryService.GetDbModel();
            newHistory.Date = this.dateService.Today;
            newHistory.Order = entity;
            newHistory.Status = entity.Status;

            this.dataServices.HistoryService.Add(newHistory);

            return this.RedirectToAction("UnFinished", "Orders");
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

            var entity = this.dataServices.OrderService.GetAll()
                .First(x => x.Id == order.Id);

            if (entity.Status.Name != order.Status)
            {
                var newHistory = this.dataServices.HistoryService.GetDbModel();
                newHistory.Date = this.dateService.Today;
                newHistory.Order = entity;
                newHistory.Status = this.dataServices.StatusService.GetAll()
                    .First(x => x.Name == order.Status);

                this.dataServices.HistoryService.Add(newHistory);
            }

            entity.WarrantyCardNumber = order.WarrantyCardNumber;
            entity.WarrantyCardDate = order.WarrantyCardDate;
            entity.Article = order.Article;
            entity.SerialNumber = order.SerialNumber;
            entity.IsHighPriority = order.IsHighPriority;
            entity.Defect = order.Defect;
            entity.Info = order.Info;
            entity.Status.Name = order.Status;
            entity.IsWarrantyService = order.IsWarrantyService;
            entity.Customer.Name = order.CustomerName;
            entity.Customer.PhoneNumber = order.CustomerPhoneNumber;
            entity.Customer.Address.Town.Name = order.CustomerTown;
            entity.Customer.Address.Street.Name = order.CustomerStreet;
            entity.Customer.Address.Number = order.CustomerAddressNumber;
            entity.Customer.Address.Entry = order.CustomerAddressEntry;
            entity.Customer.Address.Floor = order.CustomerAddressFloor;
            entity.Customer.Address.ApartmentNumber = order.CustomerAddressApartmentNumber;
            entity.User.EmployeeName = order.EmployeeName;
            entity.Supplier.Name = order.SupplierName;

            this.dataServices.OrderService.Update(entity);

            return this.RedirectToAction("UnFinished", "Orders");
        }
    }
}