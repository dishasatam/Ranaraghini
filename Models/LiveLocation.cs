using SQLite;

namespace Ranaraghini.Models;

public class LiveLocation
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public double Latitude { get; set; }

    public double Longitude { get; set; }

    public string Address { get; set; } = "";

    public DateTime DateTime { get; set; }
}