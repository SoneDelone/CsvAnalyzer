# CsvAnalyzer InfoTecs TZ

## Структура проекта

Приложение следует шаблону чистой архитектуры со следующими компонентами:

- **CsvAnalyzer.Api** - Web API контроллеры и эндпоинты
- **CsvAnalyzer.Application** - Логика приложения и сервисы
- **CsvAnalyzer.Domain** - Доменные модели и бизнес-логика
- **CsvAnalyzer.Infrastructure** - Доступ к данным и внешние сервисы

## Начало работы

### Предварительные требования

- .NET 8.0 или выше
- Docker и Docker Compose

### Настройка БД

Приложение использует PostgreSQL для хранения данных. Docker Compose:

```bash
docker-compose up -d postgres_db
```

- User: postgres
- Pass: postgres
- DB: csvanalyzer
- Port: 5432

### Применить миграции перед запуском (CsvAnalyzer.Infrastructure)

```bash
Update-Database
```

### Можно запускать
