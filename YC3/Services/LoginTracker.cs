namespace YC3.Services;

using YC3.Interfaces;

public class LoginTracker : ILoginTracker
{
    private int _loginCount = 0;

    // Singleton giữ giá trị này trong RAM, dùng chung cho tất cả các User
    public void TrackLogin() => _loginCount++;
    public int GetTotalLogins() => _loginCount;
}