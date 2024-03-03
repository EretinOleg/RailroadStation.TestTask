Приложение реализовано в архитектуре DDD со следующей структурой проектов:
<ul>
  <li>Domain - доменная модель. Использована библиотека [CSharpFunctionalExtensions](https://github.com/vkhorikov/CSharpFunctionalExtensions) для быстрого старта</li>
  <li>Application - бизнес логика. Реализована с использованием [MediatR](https://github.com/jbogard/MediatR) по принципу CQRS</li>
  <li>Infrastructure - инфраструктура, вспомогательные алгоритмы</li>
  <li>Persistence - данные</li>
  <li>Console - консольное приложение</li>
  <li>Tests - модульные тесты. xUnit + Moq. Несколько тестов, для нормального покрытия еще необходимо много написать</li>
</ul>
