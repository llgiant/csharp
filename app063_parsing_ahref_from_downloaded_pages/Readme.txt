﻿Парсинг ссылок на web-страницах

Создать консольное приложение, которое запрашивает у пользователья url-адрес
какой-либо web-страницы. Программа скачивает файл страницы и выполняет поиск
всех вхождений ссылок (теги <a>). URL-адрес каждой ссылки находится в атрибуте
href, который есть (или нет) у ссылок. После, программа выводит на консоль
список найденных у ссылок адресов с результатом проверки: какой код отдан при
запросе по адресу ссылки. При этом учитывать относительные пути ссылок.
При запросе кода ответа сервер должен "думать", что запрос выполнет браузер.