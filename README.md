Backend и Frontend для отображения результатов поиска по статьям о нанозимах.

Запускается командой

{{ $ dotnet run }}

В терминале в папке проекта. 
Для успешного выполнения команды необходимо наличие окружения dotnet [доступного по ссылке](https://dotnet.microsoft.com/en-us/download)  

Если все прошло успешно, то после запуска приложение доступно по адресу http://localhost:5079/Home/Resolve 

Пример заданного вопроса и пример полученного ответа:
![plot](/src/genView.png)

Примечание:
Конфигурации nanozimes_bot, такие как адрес бота в сети интернет и наименование контроллера могут был изменены в файле конфигурации appsettings.json
![plot](/src/editCnfg.png)