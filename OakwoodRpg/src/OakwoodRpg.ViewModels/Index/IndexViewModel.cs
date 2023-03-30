using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.AspNetCore.Components;

namespace OakwoodRpg.ViewModels.Index;

public class IndexViewModel : ObservableObject
{
    private readonly HttpClient httpClient;
    private readonly NavigationManager navigationManager;

    public IndexViewModel(HttpClient httpClient, NavigationManager navigationManager)
    {
        this.httpClient = httpClient;
        this.navigationManager = navigationManager;
    }

    public IAsyncRelayCommand NavigateToFacebookLoginCommand { get; } => new AsyncRelayCommand(NavigateToFacebookLogin);

    private async Task NavigateToFacebookLogin()
    {

    }

    private string GetHost() => new Uri(navigationManager.Uri).Host;
}
