namespace WMS.Infrastructure.Models;

public class SmsMetadata
{
    public string UserName { get; init; }
    public string PhoneNumber { get; init; }
    public string Message { get; init; }

    public SmsMetadata(string userName, string phoneNumber, string message)
    {
        UserName = userName;
        PhoneNumber = phoneNumber;
        Message = message;
    }
}
