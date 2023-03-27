using CommunityToolkit.Mvvm.ComponentModel;
using OakwoodRpg.Bootstrapping;
using OakwoodRpg.Models.Users;

namespace OakwoodRpg.ViewModels.Users;

[Scoped]
public partial class UserViewModel : ObservableObject
{
    [ObservableProperty]
    private string displayName = string.Empty;

    [ObservableProperty]
    private IdentityProvider identityProvider;

    public UserViewModel()
    {
        
    }
}
