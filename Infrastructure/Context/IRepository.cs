using Microsoft.EntityFrameworkCore.Storage;

namespace MonqLab_test_task.Infrastructure.Context
{
    /// <summary>
    /// Репозиторий данных.
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// Добавить модель данных в БД.
        /// </summary>
        /// <typeparam name="T">Тип данных.</typeparam>
        /// <param name="model">Модель данных.</param>
        Task AddModelAsync<T>(T model) where T : class;

        /// <summary>
        /// Получить транзакцию.
        /// </summary>
        /// <returns></returns>
        IDbContextTransaction GetTransaction();
    }
}