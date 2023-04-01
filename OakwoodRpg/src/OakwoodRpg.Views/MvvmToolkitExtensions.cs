using CommunityToolkit.Mvvm.Input;

namespace OakwoodRpg.Views;

public static class MvvmToolkitExtensions
{
    public static bool CanExecuteWithoutParameter(this IAsyncRelayCommand command) => command.CanExecute(null);
    public static Task ExecuteAsyncWithoutParameter(this IAsyncRelayCommand command) => command.ExecuteAsync(null);
}
