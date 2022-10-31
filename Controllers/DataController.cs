using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using MonqLab_test_task.BL;
using MonqLab_test_task.Infrastructure.DTO;

namespace MonqLab_test_task.Controllers;

/// <summary>
/// Контроллер взаимодействия с сервисом
/// </summary>
[ApiController]
[Route("api/[action]")]
public class DataController : ControllerBase
{
    public DataController(IUseCaseDataBL useCaseDataBl)
    {
        _useCaseDataBl = useCaseDataBl;
    }

    private readonly IUseCaseDataBL _useCaseDataBl;

    /// <summary>
    /// Выполнить отправку сообщений
    /// </summary>
    /// <param name="json"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Mails([FromBody] JsonDocument json)
    {
        EmailDataDto model = json.Deserialize<EmailDataDto>();
        await _useCaseDataBl.SendEmails(model);

        return CreatedAtAction(nameof(Mails), null);
    }

    /// <summary>
    /// Получить обработанные сообщения
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> Mails() =>
        Ok(await _useCaseDataBl.GetEmailsData());
}