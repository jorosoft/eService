using System;
using System.Collections.Generic;

namespace eService.Web.ViewModels.Orders
{
    public class OrderHistoryViewModel
    {
        public Guid Id { get; set; }

        public int Number { get; set; }

        public string Article { get; set; }

        public string SerialNumber { get; set; }

        public List<HistoryViewModel> History { get; set; }
    }
}