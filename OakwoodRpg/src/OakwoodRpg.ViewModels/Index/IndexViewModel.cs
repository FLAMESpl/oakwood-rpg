using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;
using OakwoodRpg.Authentication;
using OakwoodRpg.Bootstrapping;

namespace OakwoodRpg.ViewModels.Index;

[Scoped]
public class IndexViewModel : ObservableObject
{
    private readonly NavigationManager navigationManager;

    public IndexViewModel(
        IOptions<AuthenticationSettings> authenticationSettings,
        NavigationManager navigationManager)
    {
        this.navigationManager = navigationManager;

        NavigateToFacebookLoginCommand = new AsyncRelayCommand(
            execute: NavigateToFacebookLogin, 
            canExecute: () => authenticationSettings.Value.Facebook is not null);
    }

    public IAsyncRelayCommand NavigateToFacebookLoginCommand { get; }

    private Task NavigateToFacebookLogin()
    {
        navigationManager.NavigateTo("/login", forceLoad: true);
        return Task.CompletedTask;
    }
}
