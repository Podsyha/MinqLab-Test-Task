using MonqLab_test_task.Controllers.Models;
using MonqLab_test_task.Infrastructure.DTO;

namespace MonqLab_test_task.BL;

/// <summary>
/// Репозиторий взаимодействия с бизнес логикой сервиса
/// </summary>
public interface IUseCaseDataBL
{
    /// <summary>
    /// Разослать сообщения
    /// </summary>
    Task SendEmails(EmailDataDto model);
    /// <summary>
    /// Получить все сообщения
    /// </summary>
    /// <returns>Коллекция сообщений из БД</returns>
    Task<ICollection<EmailDataUi>> GetEmailsData();
}