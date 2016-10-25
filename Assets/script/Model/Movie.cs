using System;

public struct Movie
{
    public int ID;
    public string Title;
    public string Genre;
    public DateTime ReleaseDate;
    public int Duration;
    public string Resume;

    public int RealisatorID;

    public Movie(int id, string title, string genre, DateTime releaseDate, int duration, string resume, int realisationId)
    {
        ID = id;
        Title = title;
        Genre = genre;
        ReleaseDate = releaseDate;
        Duration = duration;
        Resume = resume;
        RealisatorID = realisationId;
    }
}
