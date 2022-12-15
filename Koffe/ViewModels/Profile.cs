using Koffe.Entities;

namespace Koffe.ViewModels;

public class Profile : ViewModelBase
{
    private static User AuthUserNow { get; set; }
    
    public Profile()
    {
        AuthUserNow = Authorization.AuthUser;
    }
}