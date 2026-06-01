using Firebase.Database;
using Firebase.Database.Query;
using Ranaraghini.Models;

namespace Ranaraghini.Services;

public class FirebaseService
{
    private readonly FirebaseClient firebase =
        new FirebaseClient(
            "https://ranaraghini-a1919-default-rtdb.asia-southeast1.firebasedatabase.app/");

    // ADD CONTACT

    public async Task AddContact(EmergencyContact contact)
    {
        await firebase
            .Child("contacts")
            .PostAsync(contact);
    }

    // GET CONTACTS

    public async Task<List<EmergencyContact>> GetContacts()
    {
        var data = await firebase
            .Child("contacts")
            .OnceAsync<EmergencyContact>();

        return data
            .Select(x => x.Object)
            .ToList();
    }

    // DELETE CONTACT

    public async Task DeleteContact(string phoneNumber)
    {
        var contacts = await firebase
            .Child("contacts")
            .OnceAsync<EmergencyContact>();

        var item = contacts
            .FirstOrDefault(x =>
                x.Object.PhoneNumber == phoneNumber);

        if (item != null)
        {
            await firebase
                .Child("contacts")
                .Child(item.Key)
                .DeleteAsync();
        }
    }
}