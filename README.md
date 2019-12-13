# azharinov.Deck_RESTFul

### Реализация RESTFul сервиса по работе с колодами карт.

Основные действия:
- POST /api/deck - создать колоду карт с заданными параметрами
- GET /api/deck - получить все сохраненные колоды карты
- GET/api/deck/{deckName} - получить колоду с именем deckName
- DELETE /api/deck/{deckName} - удалить колоду с именем deckName
- POST /api/shuffle/deck/{deckName} - перетасовать колоду с именем deckName

### Ограничения и допущения

В текущей реализации доступны 3 алгоритма сортировки, которые определяются в appSettings в секции ShuffleSettings:ShuffleAlgorithm
- Manual - эмуляция ручной перетасовки, когда берется случайное число подряд идущих карт сверху колоды и перекладывается вниз
- Optimal - наиболее оптимальный алгоритм Фишера-Йетса. Обходим колоду по порядку и меняем карту со случайной из колоды.
- Fast - на момент написания кода результаты тестов показывали что это самый быстрый алгоритм. Создаем пустой список, достаем случайный элемент из исходной коллекции и вставляем его в новый список. На этапе тестирования нашлась ошибка, после исправления которой алгоритм перестал был самым быстрым, но убирать из решения уже не стал.
Количество проходов алгоритма тасовки определяется в секции ShuffleSettings:ShuffleCount

Размер колоды можно задать в секции DeckSettings:Size

В решении осознанно проигнорированы обработка ошибок и логирование, поскольку это достаточно трудоемкий функционал, но простой в реализации.

При создании колоды набор карт генерируется случайным образом, нарушая условие задачи "колода создается упорядоченной". Это было сделано случайно, но исправлять не стал.
