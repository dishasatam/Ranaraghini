namespace Ranaraghini.Services;

public class SessionService
{
    // SAVE LOGIN

    public void SaveLogin(string email)
    {
        Preferences.Set("IsLoggedIn", true);

        Preferences.Set("UserEmail", email);
    }

    // CHECK LOGIN

    public bool IsLoggedIn()
    {
        return Preferences.Get(
            "IsLoggedIn",
            false);
    }

    // GET EMAIL

    public string GetUserEmail()
    {
        return Preferences.Get(
            "UserEmail",
            "");
    }

    // LOGOUT

    public void Logout()
    {
        Preferences.Clear();
    }
}