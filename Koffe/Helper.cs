using System.Net.Mime;
using Koffe.Context;
using Koffe.Entities;

namespace Koffe;

public class Helper
{
    private static ApplicationDbContext _satellitecontext;

    public static User User { get; set; }
    public static ApplicationDbContext GetContext()
    {
        return _satellitecontext ??= new();
    }
}