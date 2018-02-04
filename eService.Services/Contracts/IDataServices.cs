namespace eService.Services.Contracts
{
    public interface IDataServices
    {
        IAddressService AddressService { get; }

        ICustomerService CustomerService { get; }

        IHistoryService HistoryService { get; }

        IOrderService OrderService { get; }

        IStatusService StatusService { get; }

        IStreetService StreetService { get; }

        ISupplierService SupplierService { get; }

        ITownService TownService { get; }

        IUserService UserService { get; }
    }
}
