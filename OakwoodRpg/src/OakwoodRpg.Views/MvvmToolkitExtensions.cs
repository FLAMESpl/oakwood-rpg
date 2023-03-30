using CommunityToolkit.Mvvm.Input;

namespace OakwoodRpg.Views;

public static class MvvmToolkitExtensions
{
    public static bool CanExecute(this IAsyncRelayCommand command) => command.CanExecute(null);
    public static Task ExecuteAsync(this IAsyncRelayCommand command) => command.ExecuteAsync(null);
}
