# Тестовый проект

### Структура

* ForTest.Core - инфраструктура + работа с базой данных
* ForTest.Web - web-сайт
* Tools/AddTestData - добавление тестовых данных в бд
* Tests/UnitTests - юнит тесты
* db - база данных для работы

### Начало работы

* Чтобы посмотреть список из базы нужно в адресной строке добавить "/admin" далее в меню выбрать "customers"

### Немного описания

* Вывод данных на страничку
* Использование DI-контейнеров с помощью Ninject
* Логирование сортировки и фильтрации с помощью log4net
* ORM - Entity Framework
* Linq
* Тестовые данные в бд добавляются с помощью консольного приложения AddTestData с использованием Bogus