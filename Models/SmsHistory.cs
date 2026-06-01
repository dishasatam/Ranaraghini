using SQLite;

namespace Ranaraghini.Models;

public class SmsHistory
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public string PhoneNumber { get; set; } = "";

    public string Message { get; set; } = "";

    public DateTime SentTime { get; set; }
}