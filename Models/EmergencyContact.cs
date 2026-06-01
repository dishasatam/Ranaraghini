using SQLite;

namespace Ranaraghini.Models;

public class EmergencyContact
{
    [PrimaryKey, AutoIncrement]

    public int Id { get; set; }

    public string Name { get; set; }

    public string PhoneNumber { get; set; }

    public string Relationship { get; set; }

    public int Priority { get; set; }
}