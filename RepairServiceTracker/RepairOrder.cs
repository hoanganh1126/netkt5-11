using System;

namespace RepairServiceTracker
{
    /// <summary>Đơn đăng ký dịch vụ sửa chữa.</summary>
    public class RepairOrder
    {
        public string Id { get; set; }
        public string CustomerName { get; set; }
        public string Phone { get; set; }
        public string DeviceType { get; set; }
        public string Description { get; set; }
        public DateTime ReceivedDate { get; set; }
        public decimal EstimatedCost { get; set; }
        public string Status { get; set; }
        public string ImagePath { get; set; }
    }
}
