Программа представляет собой WPF приложение для шифрации\дешифрации текста шифром Виженера. 
# Структура проекта
![image](https://user-images.githubusercontent.com/51886546/166065767-ec7f0738-76d0-4711-ae58-701d69d69af5.png)

Приложение состоит из основного главного окна, двух дополнительных окон и вспомогательного класса FileWorker, отвечающего за основную логику программы.
# Основное окно
![image](https://user-images.githubusercontent.com/51886546/166063870-cfbfc461-62f2-4831-961f-9eee11ae8c86.png)

# Класс FileWorker
Содержит в себе 5 методов: OpenFileDialog(), Decoder(), Coder(), SaveFileDialog() и Parser(). Также содержит 6 полей:
![image](https://user-images.githubusercontent.com/51886546/166066879-92a5ae5e-d5a7-4532-9377-031c538549cd.png)

### OpenFileDialog()
![image](https://user-images.githubusercontent.com/51886546/166066710-b81a97c1-0f49-46ab-8520-21c75c6f0e57.png)

Позволяет пользователю самому выбрать файл. Т.к. по условиям курсовой нужна поддержка .txt файлов, то включена фильтрация файлов только с такими расширениями. Суть метода - получить от пользователя путь до выбранного им файла.
### Parser()
![image](https://user-images.githubusercontent.com/51886546/166067912-692cfd86-662c-489e-bd9f-38878bbf69bb.png)

Использую стрим для получения текста из файла и сразу же передаю в метод для декодинга.
### Decoder()
По условию был задан начальный ключ в виде слова "скорпион", а так же .txt файл с уже закодированным сообщением. За парсинг отвечали ранее описаные методы. Здесь же 
ставлю в булево поле cod значение true, таким образом отмечая что программа сейчас направленна на декодинг. Забиваю поле кодированного текста переданной в метод строкой из прошлого метода Parser(), а поле декодированного текста делаю пустой строкой. отдельно определяю список строк отвечающий за русские буквы и, напоследок, переменную-счётчик.

![image](https://user-images.githubusercontent.com/51886546/166068604-1283c025-cd4d-4ac6-adbe-8fd3493c7be9.png)

После чего начинаю в цикле проходиться по закодированному тексту. Если символ входит в список русских букво тогда начинаю обрабатывать, если нет то перехожу к следующему символу. Дешифровку осуществляю за счёт обработки индексов и прибавления значений из поля с дефолтным ключом.

![image](https://user-images.githubusercontent.com/51886546/166068804-680c1c73-2341-4846-bdf7-40862f6851c1.png)

### Coder()
Тот же декодер, только в профиль) Логика обратная декодеру, только на вход уже подаётся текст и ключ, и добавлен перевод ключа из строки русских букв в список их порядковых номеров в алфавите.

![image](https://user-images.githubusercontent.com/51886546/166069243-b69e7698-b6b1-48c2-acc4-3207453dd937.png)

### SaveFileDialog()
Как и OpenFileDialog() позволяет пользователю самому выбирать где сохранить файл, с фильтрацией только .txt формата. И, в зависимости от того, кодировалось ли сообщение или декодировалось (за это отвечает поле cod), сохраняет в файл закодированное или раскодированное сообщение.

![image](https://user-images.githubusercontent.com/51886546/166069533-6f1163cf-6f9b-4dff-9db3-ff2a51da17fe.png)

# TextEnter
![image](https://user-images.githubusercontent.com/51886546/166069897-0aaef0a9-0556-40af-a1c1-fb13722d2a7d.png)

Отдельное окно, созданное для получения текста для кодировки от пользователя и последующей его (текста) обработки. 

![image](https://user-images.githubusercontent.com/51886546/166070021-6087fdf0-a46c-4e5c-b40c-cc131c165f26.png)

Сохраняем полученый текст в поле. А вот копка уже проверяет введённый текст на кооректность символов, и если всё хорошо открывает следующее окно ввода ключа.

![image](https://user-images.githubusercontent.com/51886546/166070215-e4dc524a-63e8-4ef8-af4b-1927c3695903.png)

# KeyEnter
Полная копия прошлого окна.

![image](https://user-images.githubusercontent.com/51886546/166070296-017118ec-5a5f-48e7-8673-b032ed9c87d8.png)

Разве что при нажатии на кнопку и проверки на корректность символов программа вызовет метод кодировки с полученными ключом и текстом.

![image](https://user-images.githubusercontent.com/51886546/166070468-f8fb77ea-4ac7-445c-8d04-8773d6e5fd2f.png)

# MainWindow
Описано поведение четырёх соновных кнопок: 
1. Кнопка выбора файла. Проверяем, не загружен ли уже у нас файл, после чего вывзваем метод OpenFileDialog(), если же загружен, опрашиваем пользователя, провести ли новую загрузку
2. Кнопка дешифровки загруженного файла. Так же проверка "а был ли вообще загружен файл?". Если был то вызываем метод Parser(), а после него и Decoder(). Если же файл ещй не загружали, то выводим сообщение о том, что файл всё-таки надо бы загрузить.
3. Кнопка шифровки текста. Если пользователь уже загрузил файл для дешифровки, то выведется предупреждение о несохранении его данных если он захочет продолжить шифровку. После чего (если пользователь соглсен с условием или если файл и вовсе не был загружен) откроется окно TextEnter и дальше по списку...
4. Кнопка сохранения текста. Проверяет, пустые ли строки кодировки и декодирования, если да, то выдаёт сообщение о том что вы ещё ничего не декодировали и не кодировали. Если же это произошло то вызывает метод  SaveFileDialog().


# Реализованные функциональные возможности:
 * В программу можно передать файл с определенной
информацией. Входящий и исходящий формат файла .txt. Известно, что информация, находящаяся в файле – зашифрована одним из методов простой замены с ключом. Знаки препинания, и прочие элементы не относящиеся к алфавиту сообщения не изменяются. В сообщении используется десятичная система счисления и русский алфавит.
 * Программа осуществляет дешифровку информации, находящейся в файле и выводит её на экран пользователя.
 * Программа предоставляет возможность сохранения дешифрованной информации в отдельный файл, с указанием его названия и директории для сохранения.
 * Программа обладает интерфейсом для взаимодействия с пользователем, а также меню для управления функциональными возможностями программы и является WPF приложением.
 * Программа предоставляет возможность для зашифровывания шифром Виженера информации, введенной пользователем с клавиатуры, а также возможность указать ключ.
 * Результат шифрования можно сохранить в отдельный файл, с указанием его названия и директории для сохранения.
 * Основные методы шифрации\дешифрации покрыты автоматическими Unit тестами, с использованием стандартных возможностей Unit Testing Framework.
