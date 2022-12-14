namespace Koffe.Context;

public static class Connector
{
    private static ApplicationDbContext _db;

    public static ApplicationDbContext GetContext()
    {
        return _db ??= new ApplicationDbContext();
    }
}