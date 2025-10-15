DECLARE @json NVARCHAR(MAX)

SELECT @json = BulkColumn
FROM OPENROWSET(BULK '--Путь\Заказчики.json', SINGLE_NCLOB) as j

-- Парсинг и вставка данных
INSERT INTO Заказчики (ID, Название,ИНН,Адрес,Телефон,IsSalesman,IsBuyer)
SELECT 
    id,
    name,
    inn,
    addres,
    phone,
    salesman,
    buyer
FROM OPENJSON(@json)
WITH (
    id INT '$.id',
    name NVARCHAR(100) '$.name',
    inn NVARCHAR(100) '$.inn',
    addres NVARCHAR(100) '$.addres',
    phone NVARCHAR(100) '$.phone',
    salesman BIT '$.salesman',
    buyer BIT '$.buyer'
)