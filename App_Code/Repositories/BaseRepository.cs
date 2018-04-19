using WebMatrix.Data;

public class BaseRepository
{
    protected Database RequestDB()
    {
        return Database.Open("HBDB");
    }
}