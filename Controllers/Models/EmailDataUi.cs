namespace MonqLab_test_task.Controllers.Models;

/// <summary>
/// Объект данных для UI
/// </summary>
public sealed class EmailDataUi
{
    /// <summary>
    /// Id
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// Тема рассылки
    /// </summary>
    public string Subject { get; set; }
    /// <summary>
    /// Тело рассылки
    /// </summary>
    public string Body { get; set; }
    /// <summary>
    /// Получатель сообщений
    /// </summary>
    public string Recipient { get; set; }
    /// <summary>
    /// Дата создания
    /// </summary>
    public DateTime CreatedAt { get; set; }
    /// <summary>
    /// Результат рассылки
    /// </summary>
    public string Result { get; set; }
    /// <summary>
    /// Сообщение ошибки
    /// </summary>
    public string FailedMessage { get; set; }
}