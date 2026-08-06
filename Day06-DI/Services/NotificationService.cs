namespace Day06.Services;
public class NotificationService
{
    public event Action<string>? OnEmployeeAdded;
    public void Notify(string employeeName)
    {
        OnEmployeeAdded?.Invoke(employeeName);
    }
}