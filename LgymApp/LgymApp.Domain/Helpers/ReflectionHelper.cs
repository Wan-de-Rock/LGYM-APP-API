namespace LgymApp.Domain.Helpers;

public static class ReflectionHelper
{
    public const string PROJECT_NAME_PREFIX = "LgymApp";
    public static IEnumerable<Type> GetAllSolutionTypes()
    {
        return AppDomain.CurrentDomain.GetAssemblies()
                .Where(assembly => assembly.FullName?.StartsWith(PROJECT_NAME_PREFIX) == true)
                .SelectMany(assembly => assembly.GetTypes())
            ;
    }

    public static IEnumerable<Type> GetAllTypesImplementingInterface<T>()
    {
        return GetAllSolutionTypes()
                .Where(type => typeof(T).IsAssignableFrom(type) && type is { IsClass: true, IsAbstract: false })
            ;
    }
}