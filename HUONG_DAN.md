# Bài tập Windows Forms (C# / .NET 8)

Mở `BaiTap_WinForms.sln` bằng **Visual Studio 2022** (cần workload ".NET desktop development").
Chuột phải project muốn chạy -> **Set as Startup Project** -> nhấn **F5**.
Mỗi `MainForm.cs` có thể mở bằng **Designer** (Shift+F7) để kéo thả / chỉnh giao diện.

| Bài | Project | Ghi chú nhanh |
|---|---|---|
| 1 | ClinicAppointmentManager | SĐT: `0xxxxxxxxx` hoặc `+84xxxxxxxxx`; ngày hẹn không được ở quá khứ |
| 2 | LabEquipmentCheckout | Tình trạng tự tính; nút "Đánh dấu đã trả"; dòng quá hạn tô đỏ |
| 3 | RepairServiceTracker | Chọn ảnh thiết bị (PictureBox Zoom); chi phí dạng N0 |

## Kịch bản kiểm thử gợi ý
**Bài 1:** nhập SĐT `123` -> báo lỗi; chọn ngày hôm qua -> báo lỗi; gõ `0912` ở ô tìm kiếm -> chỉ còn lịch của SĐT đó; sửa/xóa/lọc -> StatusStrip đổi số lượng.
**Bài 2:** đặt hạn trả trước ngày mượn -> báo lỗi; phiếu PM001 (hạn đã qua, chưa trả) hiện "Quá hạn"; chọn phiếu -> "Đánh dấu đã trả" -> ngày trả + trạng thái cập nhật.
**Bài 3:** nhập chi phí `-5` hoặc bỏ trống mô tả lỗi -> báo lỗi; chọn ảnh -> hiển thị không méo; đổi trạng thái sang "Hoàn tất" -> tổng chi phí ở StatusStrip giảm.
