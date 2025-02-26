namespace LgymApp.Domain.Helpers;

public static class ReflectionHelper
{
    public static IEnumerable<Type> GetAllSolutionTypes()
    {
        return AppDomain.CurrentDomain.GetAssemblies()
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
