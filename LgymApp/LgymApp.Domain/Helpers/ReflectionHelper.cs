namespace LgymApp.Domain.Helpers;

public static class ReflectionHelper
{
    /// <summary>
    /// Retrieves all types from the current application domain that are assignable from the specified type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The base type or interface to check against.</typeparam>
    /// <returns>An enumerable collection of types that are assignable from the specified type <typeparamref name="T"/>.</returns>
    public static IEnumerable<Type> GetTypesAssignableFromType<T>()
    {
        return AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(assembly => assembly.GetTypes())
            .Where(type => typeof(T).IsAssignableFrom(type));
    }
}
