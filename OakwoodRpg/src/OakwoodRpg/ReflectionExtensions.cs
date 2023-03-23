using System.Reflection;
using System.Runtime.ExceptionServices;

namespace OakwoodRpg;

public static class ReflectionExtensions
{
    public static async Task<T> InvokeWithTargetInvocationExceptionUnpacking<T>(
        this MethodInfo methodInfo, 
        object? instance, 
        object[] parameters)
    {
        var task = (Task<T>)(methodInfo.Invoke(instance, parameters) 
            ?? throw new InvalidOperationException("Method returned null object"));

        try
        {
            return await task;
        }
        catch (TargetInvocationException exception) when (exception.InnerException != null)
        {
            ExceptionDispatchInfo.Throw(exception.InnerException);
        }

        return default;
    }

    public static async Task InvokeWithTargetInvocationExceptionUnpacking(
        this MethodInfo methodInfo,
        object? instance,
        object[] parameters)
    {
        await methodInfo.InvokeWithTargetInvocationExceptionUnpacking<object>(instance, parameters);
    }
}
