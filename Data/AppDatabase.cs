using SQLite;
using Ranaraghini.Models;

namespace Ranaraghini.Data;

public class AppDatabase
{
    private readonly SQLiteAsyncConnection _database;

    public AppDatabase(string dbPath)
    {
        _database = new SQLiteAsyncConnection(dbPath);

        // CREATE TABLES

        _database.CreateTableAsync<EmergencyContact>().Wait();

        _database.CreateTableAsync<AlertHistory>().Wait();

        _database.CreateTableAsync<UserAccount>().Wait();

        _database.CreateTableAsync<LiveLocation>().Wait();

        _database.CreateTableAsync<LoginHistory>().Wait();

        _database.CreateTableAsync<SmsHistory>().Wait();

        _database.CreateTableAsync<CallHistory>().Wait();
    }

    // =========================================
    // EMERGENCY CONTACTS
    // =========================================

    public Task<List<EmergencyContact>>
        GetContactsAsync()
    {
        return _database
            .Table<EmergencyContact>()
            .ToListAsync();
    }

    public Task<int>
        SaveContactAsync(
            EmergencyContact contact)
    {
        if (contact.Id != 0)
        {
            return _database.UpdateAsync(contact);
        }
        else
        {
            return _database.InsertAsync(contact);
        }
    }

    public Task<int>
        DeleteContactAsync(
            EmergencyContact contact)
    {
        return _database.DeleteAsync(contact);
    }

    // =========================================
    // ALERT HISTORY
    // =========================================

    public Task<List<AlertHistory>>
        GetAlertsAsync()
    {
        return _database
            .Table<AlertHistory>()
            .ToListAsync();
    }

    public Task<int>
        SaveAlertAsync(
            AlertHistory alert)
    {
        return _database.InsertAsync(alert);
    }

    // =========================================
    // USER ACCOUNT
    // =========================================

    public Task<int>
        SaveUserAsync(
            UserAccount user)
    {
        return _database.InsertAsync(user);
    }

    public Task<List<UserAccount>>
        GetUsersAsync()
    {
        return _database
            .Table<UserAccount>()
            .ToListAsync();
    }

    // CHECK USER BY EMAIL

    public async Task<UserAccount>
        GetUserByEmailAsync(
            string email)
    {
        return await _database
            .Table<UserAccount>()
            .FirstOrDefaultAsync(x =>
                x.Email == email);
    }

    // LOGIN USER

    public async Task<UserAccount>
        LoginUserAsync(
            string email,
            string password)
    {
        return await _database
            .Table<UserAccount>()
            .FirstOrDefaultAsync(x =>
                x.Email == email &&
                x.Password == password);
    }

    // =========================================
    // LIVE LOCATION
    // =========================================

    public Task<int>
        SaveLocationAsync(
            LiveLocation location)
    {
        return _database.InsertAsync(location);
    }

    public Task<List<LiveLocation>>
        GetLocationsAsync()
    {
        return _database
            .Table<LiveLocation>()
            .ToListAsync();
    }
    // =========================================
    // LOGIN HISTORY
    // =========================================

    public Task<int> SaveLoginHistoryAsync(
     LoginHistory login)
    {
        return _database.InsertAsync(login);
    }

    public Task<List<LoginHistory>> GetLoginHistoryAsync()
    {
        return _database
            .Table<LoginHistory>()
            .ToListAsync();
    }
    // =========================================
    // SMS HISTORY
    // =========================================
    public Task<int> SaveSmsHistoryAsync(
    SmsHistory sms)
    {
        return _database.InsertAsync(sms);
    }

    public Task<List<SmsHistory>> GetSmsHistoryAsync()
    {
        return _database
            .Table<SmsHistory>()
            .ToListAsync();
    }
    // =========================================
    // CALL HISTORY
    // =========================================
    public Task<int> SaveCallHistoryAsync(
    CallHistory call)
    {
        return _database.InsertAsync(call);
    }

    public Task<List<CallHistory>> GetCallHistoryAsync()
    {
        return _database
            .Table<CallHistory>()
            .ToListAsync();
    }

}