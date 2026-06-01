using SQLite;

namespace Ranaraghini.Models;

public class CallHistory
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public string PhoneNumber { get; set; } = "";

    public DateTime CallTime { get; set; }
}