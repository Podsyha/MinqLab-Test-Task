# MinqLab-test-task

### Настройка:
- В файле `appsettings.json` в строке **"DefaultConnection"** указать настройки для подключения к БД Postgre
- В файле `appsettings.json` в секцие **"MailKitSettings"** указать настройки для подключения к SMTP клиенту
- Выполните команду обновления БД из миграций:
```
dotnet ef database update --project "MonqLab test task.csproj" --startup-project "MonqLab test task.csproj" --context MonqLab_test_task.Infrastructure.Context.AppDbContext --configuration Debug 20221031162346_Initial
```
