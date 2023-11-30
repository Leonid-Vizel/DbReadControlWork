/*30.11.2023 | Визель Леонид | 09-122 | Вариант 1*/

/*Задача 1*/
/*Определить продавцов, все покупатели которых живут в городе Казани.*/

/*Считываю всех продавцов,
потом оставляю лишь тех у которых не существует таких покупателей, которые не живут в Казани.
Поставил много пробелов, так как тип char(20), иначе сравнение строк пройдёт неверно*/
SELECT sales."Id", sales."NAME"
FROM "Salesmans" as sales
WHERE NOT EXISTS(
    SELECT custom."Id"
    FROM "Customers" as custom
    WHERE sales."Id" = custom."SM_Ref" AND custom."CITY" != 'Казань              ');

/*Задача 2*/
/*Определить продавцов, все покупатели которых живут в том же самом городе (что и продавец).*/

/*Считываю всех продавцов,
потом оставляю лишь тех у которых не существует таких покупателей, которые не живут в том же городе что и продавец.
Поставил много пробелов, так как тип char(20), иначе сравнение строк пройдёт неверно*/
SELECT sales."Id", sales."NAME"
FROM "Salesmans" as sales
WHERE NOT EXISTS(
    SELECT custom."Id"
    FROM "Customers" as custom
    WHERE sales."Id" = custom."SM_Ref" AND custom."CITY" != sales."CITY");

/*Задача 3*/
/*Определить продавцов и их покупателей, живущих в одном городе.*/

/*Считываю всех продавцов,
затем к ним через INNER JOIN считываю покупателей.
Таким образом получаем пару (Покупатель, Продавец).
Оставляем лишь те пары у которых совпадают города и выбираем лишь нужные нам поля Name*/
SELECT sales."NAME", custom."NAME"
FROM "Salesmans" as sales
INNER JOIN "Customers" as custom
ON sales."Id" = custom."SM_Ref"
WHERE custom."CITY" = sales."CITY";