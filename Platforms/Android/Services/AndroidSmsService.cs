using Android.Telephony;

namespace Ranaraghini.Platforms.Android.Services;

public class AndroidSmsService
{
    public void SendSms(
        string phoneNumber,
        string message)
    {
        SmsManager smsManager =
            SmsManager.Default;

        smsManager.SendTextMessage(
            phoneNumber,
            null,
            message,
            null,
            null);
    }
}