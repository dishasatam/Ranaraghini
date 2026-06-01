using Microsoft.Maui.ApplicationModel.Communication;

#if ANDROID
using Ranaraghini.Platforms.Android.Services;
#endif

namespace Ranaraghini.Services;

public class SosService
{
#if ANDROID

    private readonly AndroidSmsService _androidSmsService;

    public SosService(AndroidSmsService androidSmsService)
    {
        _androidSmsService = androidSmsService;
    }

#else

    public SosService()
    {

    }

#endif

    // =========================
    // SEND DIRECT SMS
    // =========================

    public async Task SendEmergencySms(
        List<string> phoneNumbers,
        string message)
    {
        try
        {
#if ANDROID

            foreach (var number in phoneNumbers)
            {
                _androidSmsService.SendSms(
                    number,
                    message);
            }

#endif

            await Task.CompletedTask;
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert(
                "SMS Error",
                ex.Message,
                "OK");
        }
    }

    // =========================
    // AUTO CALL
    // =========================

    public async Task MakeEmergencyCall(
        string phoneNumber)
    {
        try
        {
            if (PhoneDialer.Default.IsSupported)
            {
                PhoneDialer.Default.Open(
                    phoneNumber);
            }

            await Task.CompletedTask;
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert(
                "Call Error",
                ex.Message,
                "OK");
        }
    }
}