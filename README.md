# EmailSenderWebService
1) Реализовать скрипт(ы) SQL для создания таблиц и связей между ними:
- таблица «Сотрудники» (ИД, ФИО, Email),
- таблица «Группы» (ИД, Название).

В системе может быть множество групп, обязательно создать группы с названиями «Администраторы» и «Руководство».
Создать по умолчанию несколько тестовых сотрудников.
Реализовать требование, что один и тот же сотрудник может находится сразу в нескольких группах. Добавить произвольных пользователей в произвольные группы.

2) Реализовать простой веб-сервис, содержащий методы:
- на вход принимает ИД группы, в результате отдает список сотрудников, входящих в эту группу,
- на вход принимает текст письма и отправляет электронное письмо всем сотрудникам, не входящим в группу «Руководство»

3) Реализовать простую html-страницу (или компонент angular/vue.js) с полем для ввода текста сообщения и кнопку, при нажатии на которую формируется и отправляется электронное письмо всем сотрудникам, не входящим в группу «Руководство», с текстом из поля выше.

При выполнении использовать SQL, C#, .NET, Entity Framework, html, javascript (или angular/vue.js).
