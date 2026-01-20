namespace YC3.Interfaces;

public interface ILoginTracker
{
    void TrackLogin(); // Gọi mỗi khi có người login thành công
    int GetTotalLogins(); // Lấy tổng số lượt login để hiển thị
}