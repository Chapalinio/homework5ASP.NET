namespace homework5ASP.NET.Models;

public class Game
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Genre { get; set; } = string.Empty;
    public int Rating { get; set; }
    public bool IsCompleted { get; set; }

}
