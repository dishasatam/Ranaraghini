using SQLite;

namespace Ranaraghini.Models;

public class AlertHistory
{
    [PrimaryKey, AutoIncrement]

    public int Id { get; set; }

    public string Message { get; set; } = "";

    public double Latitude { get; set; }

    public double Longitude { get; set; }

    public DateTime AlertTime { get; set; }
}