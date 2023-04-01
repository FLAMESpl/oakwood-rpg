using Microsoft.AspNetCore.Components;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace OakwoodRpg.Views;

public static class PagePathProvider
{
    private class CachedPath<T> where T : ComponentBase
    {
        public static string? Value { get; }

        [MemberNotNullWhen(true, nameof(Value))]
        public static bool IsValidPage { get; }

        static CachedPath()
        {
            if (typeof(T).GetCustomAttribute<RouteAttribute>() is { } attribute)
            {
                IsValidPage = true;
                Value = attribute.Template;
            }
        }
    }

    public static string GetFromComponent<TComponent>() where TComponent : ComponentBase
    {
        return CachedPath<TComponent>.IsValidPage
            ? CachedPath<TComponent>.Value
            : throw new ArgumentException($"{typeof(TComponent).Name} is not a valid page.");
    }
}
