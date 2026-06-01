using SQLite;

namespace Ranaraghini.Models;

public class LoginHistory
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public string Email { get; set; } = "";

    public DateTime LoginTime { get; set; }
}
