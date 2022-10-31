using Microsoft.EntityFrameworkCore;
using MonqLab_test_task.Controllers.Models;
using MonqLab_test_task.Infrastructure.Context;
using MonqLab_test_task.Infrastructure.DAO;

namespace MonqLab_test_task.Infrastructure.Repository;

/// <summary>
/// Объект обработки запросов БД
/// </summary>
public class EmailDataRepository : AppDbFunc, IEmailDataRepository
{
    public EmailDataRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
    
    /// <summary>
    /// Добавить обработанное сообщение
    /// </summary>
    /// <param name="entity">Сущность сообщения</param>
    public async Task AddEmail(EmailDataEntity entity)
    {
        await AddModelAsync(entity);
        await SaveChangeAsync();
    }

    /// <summary>
    /// Получить все сообщения
    /// </summary>
    /// <returns>Коллекция сообщений из БД</returns>
    public async Task<ICollection<EmailDataUi>> GetAllEmails()
    {
        ICollection<EmailDataUi> collection = ConvertToUi(await _dbContext.EmailData.ToListAsync());
        return collection;
    }

    /// <summary>
    /// Замапить dao в ui model
    /// </summary>
    /// <param name="emailDataEntities">Сущность пользователя</param>
    /// <returns>Коллекция UI моделей</returns>
    private static ICollection<EmailDataUi> ConvertToUi(ICollection<EmailDataEntity> emailDataEntities)
    {
        ICollection<EmailDataUi> codeValuesUi = emailDataEntities.Select(emailDataEntity => new EmailDataUi()
        {
            Id = emailDataEntity.Id,
            Body = emailDataEntity.Body,
            Subject = emailDataEntity.Subject,
            Recipient = emailDataEntity.Recipient,
            Result = emailDataEntity.Result,
            FailedMessage = emailDataEntity.FailedMessage,
            CreatedAt = emailDataEntity.CreatedAt
        }).ToList();

        return codeValuesUi;
    }
}