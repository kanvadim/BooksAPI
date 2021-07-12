
--База данных состоит из трех таблиц. Две иаблицы с сущностями (Authors и Books) и одна вспомогательная для реализации связи многие ко многим
--СУБД PosgreSQL
--В проекте BooksAPI необходимо подставить только строку подключения в appsettings.Development.json
--При запуске IIS Express откроется страница http://localhost:<port>/swagger/ с реализованными методами


CREATE TABLE books (
    id              INT NOT NULL PRIMARY KEY GENERATED ALWAYS AS IDENTITY,                    -- Id книги
    book_name       VARCHAR(200) NOT NULL                                                     -- Название книги
);

CREATE TABLE authors (
    id              INT NOT NULL PRIMARY KEY  GENERATED ALWAYS AS IDENTITY,                   -- Id автора
    name            VARCHAR(200) NOT NULL                                                     -- Автор
);

CREATE TABLE authors_books (
    author_id        INT NOT NULL,                                                            -- Id автора
    book_id          INT NOT NULL,                                                            -- Id книги
    PRIMARY KEY (author_id ,book_id),
    FOREIGN KEY (author_id) REFERENCES authors(id),
    FOREIGN KEY (book_id ) REFERENCES books(id)
);

