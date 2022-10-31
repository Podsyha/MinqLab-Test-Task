using Microsoft.EntityFrameworkCore.Storage;
using Throw;

namespace MonqLab_test_task.Infrastructure.Context
{
    /// <summary>
    /// Абстрактный класс описания функциональности взаимодействия с БД.
    /// </summary>
    public class AppDbFunc : IRepository
    {
        protected AppDbFunc(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        protected readonly AppDbContext _dbContext;

        /// <summary>
        /// Добавить модель данных в БД.
        /// </summary>
        /// <typeparam name="T">Тип данных.</typeparam>
        /// <param name="model">Модель данных.</param>
        public async Task AddModelAsync<T>(T model) where T : class
        {
            model.Throw().ThrowIfNull();
            await _dbContext.AddAsync(model);
        }

        /// <summary>
        /// Получить транзакцию.
        /// </summary>
        /// <returns></returns>
        public IDbContextTransaction GetTransaction() =>
            _dbContext.Database.CurrentTransaction ?? _dbContext.Database.BeginTransaction();

        /// <summary>
        /// Сохранить модифицированные сущности в контексте БД
        /// </summary>
        protected async Task SaveChangeAsync() =>
            await _dbContext.SaveChangesAsync();
    }
}