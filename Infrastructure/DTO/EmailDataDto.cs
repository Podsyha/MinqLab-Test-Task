namespace MonqLab_test_task.Infrastructure.DTO;

/// <summary>
/// DTO модель данных для рассылки сообщений
/// </summary>
public sealed class EmailDataDto
{
    /// <summary>
    /// Тема рассылки
    /// </summary>
    public string subject { get; init; }
    /// <summary>
    /// Тело рассылки
    /// </summary>
    public string body { get; init; }
    /// <summary>
    /// Коллекия email на рассылку
    /// </summary>
    public string[] recipients { get; init; }
}