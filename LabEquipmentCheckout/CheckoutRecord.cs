using System;

namespace LabEquipmentCheckout
{
    /// <summary>Phiếu mượn thiết bị.</summary>
    public class CheckoutRecord
    {
        public const string StatusBorrowing = "Đang mượn";
        public const string StatusReturned = "Đã trả";
        public const string StatusOverdue = "Quá hạn";

        public string Id { get; set; }
        public string StudentId { get; set; }
        public string StudentName { get; set; }
        public string Equipment { get; set; }
        public int Quantity { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }

        /// <summary>Tình trạng được TỰ ĐỘNG xác định từ ngày trả thực tế và hạn trả.</summary>
        public string Status
        {
            get { return ComputeStatus(DueDate, ReturnDate); }
        }

        /// <summary>Ngày trả thực tế dạng chuỗi để hiển thị trên lưới (rỗng nếu chưa trả).</summary>
        public string ReturnDateText
        {
            get { return ReturnDate.HasValue ? ReturnDate.Value.ToString("dd/MM/yyyy") : ""; }
        }

        public static string ComputeStatus(DateTime dueDate, DateTime? returnDate)
        {
            if (returnDate.HasValue) return StatusReturned;
            if (dueDate.Date < DateTime.Today) return StatusOverdue;   // chưa trả và hạn đã qua
            return StatusBorrowing;
        }
    }
}
