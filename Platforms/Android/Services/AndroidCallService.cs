using Android.Content;
using Ranaraghini.Services;

namespace Ranaraghini.Platforms.Android.Services;

public class AndroidCallService : ICallService
{
    public void MakePhoneCall(string number)
    {
        try
        {
            Intent intent =
                new Intent(Intent.ActionCall);

            intent.SetData(
                global::Android.Net.Uri.Parse(
                    $"tel:{number}"));

            intent.SetFlags(
                ActivityFlags.NewTask);

            global::Android.App.Application.Context
                .StartActivity(intent);
        }
        catch (Exception ex)
        {
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                await Shell.Current.DisplayAlert(
                    "Call Error",
                    ex.ToString(),
                    "OK");
            });
        }
    }
}