using MonqLab_test_task.Controllers.Models;
using MonqLab_test_task.Infrastructure.DAO;

namespace MonqLab_test_task.Infrastructure.Repository;
/// <summary>
/// Репозиторий взаимодействия с БД
/// </summary>
public interface IEmailDataRepository
{
    /// <summary>
    /// Добавить обработанное сообщение
    /// </summary>
    /// <param name="entity">Сущность сообщения</param>
    Task AddEmail(EmailDataEntity entity);
    /// <summary>
    /// Получить все сообщения
    /// </summary>
    /// <returns>Коллекция сообщений из БД</returns>
    Task<ICollection<EmailDataUi>> GetAllEmails();
}