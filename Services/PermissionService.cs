using Microsoft.Maui.ApplicationModel;

namespace Ranaraghini.Services;

public class PermissionService
{
    public async Task<bool> RequestPermissions()
    {
        try
        {
            var location =
                await Permissions.RequestAsync<Permissions.LocationWhenInUse>();

            var phone =
                await Permissions.RequestAsync<Permissions.Phone>();

            await Application.Current.MainPage.DisplayAlert(
                "Permission Status",
                $"Location: {location}\nPhone: {phone}",
                "OK");

            return true;
        }
        catch (Exception ex)
        {
            await Application.Current.MainPage.DisplayAlert(
                "Permission Exception",
                ex.Message,
                "OK");

            return false;
        }
    }
}