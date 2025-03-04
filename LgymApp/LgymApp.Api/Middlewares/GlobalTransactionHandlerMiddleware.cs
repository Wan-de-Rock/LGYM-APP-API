using System.Transactions;

namespace LgymApp.Api.Middlewares;

public class GlobalTransactionHandlerMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        // Пропускаем GET-запросы без транзакции
        if (context.Request.Method == HttpMethods.Get)
        {
            await next(context);
            return;
        }

        using var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);

        try
        {
            await next(context); // Выполняем запрос
            scope.Complete(); // Фиксируем транзакцию
        }
        catch
        {
            // TODO: Логирование ошибок
            // Откат транзакции автоматически, если scope.Complete() не вызван
            throw;
        }
    }
}