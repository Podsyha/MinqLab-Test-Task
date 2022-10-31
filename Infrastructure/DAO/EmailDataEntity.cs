namespace MonqLab_test_task.Infrastructure.DAO;

/// <summary>
/// DAO модель данных для рассылки сообщений
/// </summary>
public sealed class EmailDataEntity
{
    public EmailDataEntity()
    {
        CreatedAt = DateTime.UtcNow;
    }

    /// <summary>
    /// Id
    /// </summary>
    public Guid Id { get; init; }

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
    public DateTime CreatedAt { get; init; }

    /// <summary>
    /// Результат рассылки
    /// </summary>
    public string Result { get; private set; }

    /// <summary>
    /// Сообщение ошибки
    /// </summary>
    public string FailedMessage { get; private set; }

    /// <summary>
    /// Добавить сообщение об ошибке рассылки
    /// </summary>
    /// <param name="error">Текст ошибки</param>
    internal void AddFailedMessage(string error) => FailedMessage = error;

    /// <summary>
    /// Установить успешный результат
    /// </summary>
    internal void SetOkResult() => Result = "OK";

    /// <summary>
    /// Установить проваленный результат
    /// </summary>
    internal void SetFailedResult() => Result = "Failed";
}