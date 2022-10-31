using MonqLab_test_task.Controllers.Models;
using MonqLab_test_task.Infrastructure.DAO;
using MonqLab_test_task.Infrastructure.DTO;
using MonqLab_test_task.Infrastructure.Repository;
using NETCore.MailKit.Core;
using Throw;

namespace MonqLab_test_task.BL;

/// <summary>
/// Класс с бизнес логикой сервиса
/// </summary>
public class UseCaseDataBL : IUseCaseDataBL
{
    public UseCaseDataBL(IEmailDataRepository emailDataRepository, IEmailService emailService)
    {
        _emailDataRepository = emailDataRepository;
        _emailService = emailService;
    }

    private readonly IEmailDataRepository _emailDataRepository;
    private readonly IEmailService _emailService;

    /// <summary>
    /// Разослать сообщения
    /// </summary>
    public async Task SendEmails(EmailDataDto model)
    {
        model.Throw().ThrowIfNull();

        foreach (var recipient in model.recipients)
        {
            EmailDataEntity entity = new()
            {
                Body = model.body,
                Subject = model.subject,
                CreatedAt = DateTime.UtcNow,
                Recipient = recipient
            };

            try
            {
                await _emailService.SendAsync(recipient, subject: model.subject, model.body);
                entity.SetOkResult();
                await _emailDataRepository.AddEmail(entity);
            }
            catch (Exception e)
            {
                entity.SetFailedResult();
                entity.AddFailedMessage(e.Message);
                await _emailDataRepository.AddEmail(entity);
            }
        }
    }

    /// <summary>
    /// Получить все сообщения
    /// </summary>
    /// <returns>Коллекция сообщений из БД</returns>
    public async Task<ICollection<EmailDataUi>> GetEmailsData() =>
        await _emailDataRepository.GetAllEmails();
}