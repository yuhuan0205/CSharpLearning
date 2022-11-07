/* 1 */
CREATE TABLE [StockDB].[dbo].[日收盤_新人訓練_陳祐桓欄位-型態]
(
	[CTIME] datetime DEFAULT GETDATE(),
	[MTIME] int,
	[RecordID] bigint,
	[日期] nvarchar(8),
	[股票代號] nvarchar(10),
	[股票名稱] nvarchar(20),
	[開盤價] decimal(9,2),
	[最高價] decimal(9,2),
	[最低價] decimal(9,2),
	[收盤價] decimal(9,2),
	[漲跌] decimal(9,2),
	PRIMARY KEY(日期 DESC, 股票代號 ASC)
);

CREATE 
NONCLUSTERED INDEX MTIME_INDEX
ON [StockDB].[dbo].[日收盤_新人訓練_陳祐桓欄位-型態](MTIME DESC)
/* DELETE FROM [StockDB].[dbo].[日收盤_新人訓練_陳祐桓欄位-型態]; */

/* 12 */
INSERT INTO [StockDB].[dbo].[日收盤_新人訓練_陳祐桓欄位-型態](日期, 股票代號, 股票名稱, 開盤價)
 VALUES(N'20181218', N'0000', N'測試', 0);

/* 13 */
UPDATE [StockDB].[dbo].[日收盤_新人訓練_陳祐桓欄位-型態]
SET 開盤價 = 1
WHERE 股票名稱 LIKE N'測試';

/* 14 */
DELETE [StockDB].[dbo].[日收盤_新人訓練_陳祐桓欄位-型態]
WHERE 開盤價 = 1;

/* 15 */
INSERT INTO [StockDB].[dbo].[日收盤_新人訓練_陳祐桓欄位-型態]
SELECT [CTIME], [MTIME], [RecordID], [日期], [股票代號], [股票名稱], [開盤價], [最高價], [最低價], [收盤價], [漲跌] FROM [StockDB].[dbo].[日收盤] WHERE 日期 LIKE N'20181214';

/* 16 */
DELETE [StockDB].[dbo].[日收盤_新人訓練_陳祐桓欄位-型態];

TRUNCATE TABLE [StockDB].[dbo].[日收盤_新人訓練_陳祐桓欄位-型態];

/* 17 */
DROP TABLE [StockDB].[dbo].[日收盤_新人訓練_陳祐桓欄位-型態]

/* 19 */
SELECT * FROM [StockDB].[dbo].[日收盤]
WHERE [日期] LIKE N'20181206';

/* 20 */
SELECT * FROM [StockDB].[dbo].[日收盤]
WHERE (日期 BETWEEN N'20181201' AND N'20181206') AND 股票代號 IN (N'0050', N'006201', N'00721B');

/* 21 */
SELECT DISTINCT 股票代號 FROM [StockDB].[dbo].[日收盤]
WHERE (日期 BETWEEN N'20181201' AND N'20181206');

/* 22 */
SELECT 日期, COUNT(*) AS 資料筆數 FROM [StockDB].[dbo].[日收盤]
GROUP BY 日期
HAVING 日期 LIKE N'2018%'

/* 23 */
SELECT 股票代號, SUM(開盤價) AS 開盤價總和, MIN(最高價) AS 最小最高價, MAX(最低價) AS 最大最低價, AVG(收盤價) AS 平均收盤價 FROM [StockDB].[dbo].[日收盤]
WHERE 日期 BETWEEN N'20181201' AND N'20181206'
GROUP BY 股票代號;

/* 24 */
SELECT DISTINCT 股票名稱, SUBSTRING(股票名稱,0,3) AS 縮寫 FROM [StockDB].[dbo].[日收盤]
WHERE 日期 BETWEEN N'20181201' AND N'20181206'

/* 25 */
SELECT DISTINCT RTRIM (LTRIM(股票名稱)) AS 頭尾去空白 FROM [StockDB].[dbo].[日收盤]
WHERE 日期 BETWEEN N'20181201' AND N'20181206'

/* 26 */
SELECT * FROM [StockDB].[dbo].[日收盤]
WHERE 日期 BETWEEN N'20181201' AND N'20181206'
ORDER BY 股票代號 DESC, 日期 ASC

/* 27 */
SELECT 股票代號, AVG(收盤價) AS 平均收盤價 FROM [StockDB].[dbo].[日收盤]
WHERE 日期 BETWEEN N'20181201' AND N'20181206'
GROUP BY 股票代號
HAVING AVG(收盤價) < 80

/* 28 */
SELECT COUNT(*) AS 總資料筆數 FROM [StockDB].[dbo].[日收盤]
WHERE 日期 LIKE N'2018%'

/* 29 */
/* solution 1 */
SELECT COUNT(*) AS 總資料筆數
FROM ( (SELECT 股票代號, 日期 FROM [StockDB].[dbo].[日收盤]
WHERE 日期 LIKE N'2018%' )
EXCEPT
(SELECT 股票代號, 日期 FROM [StockDB].[dbo].[日收盤]
WHERE 日期 LIKE N'2018%' AND 收盤價 IS NULL
)) AS 非空收盤價

/* solution 2 */
SELECT COUNT(*) AS 總資料筆數
FROM [StockDB].[dbo].[日收盤]
WHERE 日期 LIKE N'2018%' AND (收盤價 >=0 OR 收盤價 < 0)

/* solution3 */
SELECT COUNT(收盤價) AS 總資料筆數
FROM [StockDB].[dbo].[日收盤]
WHERE 日期 LIKE N'2018%'


/* 30 */
SELECT DISTINCT 股票代號 FROM [StockDB].[dbo].[日收盤]
WHERE 日期 LIKE N'2018%' AND LEN(股票代號) > 4

/* 31 */
SELECT DISTINCT REPLACE(股票名稱, N'指數', N'__') AS 名稱包含指數之股票 FROM [StockDB].[dbo].[日收盤]
WHERE 日期 LIKE N'2018%' AND 股票名稱 LIKE N'%指數%'

/* 32 */
SELECT * from [StockDB].[DBO].[日收盤] 
WHERE DATEDIFF(dd, CAST(日期 AS DATE), GETDATE()) = 0

/* solution 2 */
DECLARE @TODAY NVARCHAR(8) = CONVERT(NVARCHAR(8), GETDATE(), 112)
SELECT * from [StockDB].[DBO].[日收盤] 
WHERE 日期 LIKE @TODAY

/* 33 */
SELECT * FROM (SELECT *,  ROW_NUMBER() OVER(PARTITION BY 股票代號 ORDER BY 日期) AS [Rank] FROM [StockDB].[dbo].[日收盤] WHERE 股票代號 LIKE N'1%' AND 日期 LIKE N'2018%') AS 分組
WHERE 分組.[Rank] = 6

/* 34 */
SELECT DISTINCT 股票代號 FROM [StockDB].[dbo].[日收盤]
WHERE [日期] LIKE N'20181206'
EXCEPT
SELECT DISTINCT 股票代號 FROM [StockDB].[dbo].[日收盤]
WHERE [日期] LIKE N'20181205'

/* 35 */
SELECT DISTINCT 股票代號 FROM [StockDB].[dbo].[日收盤]
WHERE [日期] LIKE N'20181206'
INTERSECT 
SELECT DISTINCT 股票代號 FROM [StockDB].[dbo].[日收盤]
WHERE [日期] LIKE N'20181205'

/* 36 */
SELECT 日收盤.* , 上市櫃.英文名稱  
FROM [StockDB].[dbo].[日收盤] AS 日收盤 JOIN [StockDB].[dbo].[上市櫃基本資料表] AS 上市櫃 ON 日收盤.股票代號 = 上市櫃.股票代號 AND SUBSTRING(日收盤.日期, 0, 5) LIKE  上市櫃.年度
WHERE 日收盤.日期 LIKE N'2018%'

/* 37 */
SELECT 日收盤.日期, 日收盤.股票名稱, ETF.年度, ETF.名稱 
FROM (SELECT * FROM [StockDB].[dbo].[日收盤] WHERE 日期 LIKE N'20181214' ) AS 日收盤 
JOIN 
(SELECT 年度, 名稱, 代號 FROM [StockDB].[dbo].[ETF基本資料表] WHERE 年度 LIKE N'2018') AS ETF
ON 日收盤.股票代號 = ETF.代號
WHERE 日收盤.股票名稱 NOT LIKE ETF.名稱

/* 38 */
SELECT 上市櫃 = 
CASE 上市櫃
	WHEN 1 THEN N'上市'
	WHEN 2 THEN N'上櫃'
	WHEN 3 THEN N'興櫃'
	WHEN 4 THEN N'公發'
	ELSE N'其他'
END,
[CTIME], [MTIME], [RecordID], [日期], [股票代號], [股票名稱], [參考價], [開盤價], [最高價], [最低價], [收盤價], [漲跌], [產業代號], [漲停價], [跌停價], [漲跌狀況], [最後委買價], [最後委賣價], [漲幅(%)], [振幅(%)], [成交量], [成交量(股)], [成交筆數], [成交金額(千)], [成交值比重(%)], [成交量變動(%)], [股本(百萬)2], [均張變動(%)], [均張], [總市值(億)], [市值比重(%)], [類股本益比], [類股股價淨值比], [類股股價淨值比2], [本益比], [本益比(近四季)], [股東權益(百萬)], [股價淨值比], [股價淨值比2], [舊股本(百萬)], [委買張數], [委賣張數], [次日參考價], [成交金額_元], [均價], [股本(百萬)], [週轉率], [漲跌停]
FROM [StockDB].[dbo].[日收盤] AS 日收盤
WHERE 日期 BETWEEN N'20181201' AND N'20181206'

/* 39 */
SELECT [Range] = 
CASE 
	WHEN 收盤價<10 THEN N'Under_10'
	WHEN 收盤價 >= 10 AND 收盤價 < 50 THEN N'Under_50'
	WHEN 收盤價 >= 50 AND 收盤價 < 100 THEN N'Under_100'
	WHEN 收盤價>=100 THEN N'Over_100'
END, *
FROM [StockDB].[dbo].[日收盤] AS 日收盤
WHERE 日期 BETWEEN N'20181201' AND N'20181206'

/* 40 */

/* SOLUTION 1 */
SELECT * FROM [StockDB].[dbo].[日收盤]
WHERE 日期 LIKE N'20181206'
ORDER BY 
CASE
	WHEN 收盤價 > 5 THEN 收盤價
	WHEN 收盤價 <=5 THEN 收盤價*-1
	END
DESC 

/* SOLUTION 2 */
SELECT * FROM [StockDB].[dbo].[日收盤]
WHERE 日期 LIKE N'20181206'
ORDER BY 
CASE WHEN 收盤價 > 5 THEN 收盤價 END DESC,
CASE WHEN 收盤價 <=5 THEN 收盤價 END ASC


/* 41 */
SELECT * FROM
(
	SELECT *, ROW_NUMBER() OVER(PARTITION BY 股票代號 ORDER BY 日期 DESC) AS 筆數 
	FROM [StockDB].[dbo].[日收盤]
	WHERE 股票代號 IN (SELECT DISTINCT TOP 1000 股票代號 FROM [StockDB].[dbo].[日收盤])
) AS 頭1000檔股票
WHERE 頭1000檔股票.筆數 = 1


SELECT 原始.* FROM 
(SELECT * FROM [StockDB].[dbo].[日收盤]) AS 原始, (SELECT TOP 1000 股票代號, MAX(日期) AS 最大日期 FROM [StockDB].[dbo].[日收盤] GROUP BY 股票代號) AS 分組
WHERE 原始.股票代號 LIKE 分組.股票代號 AND 原始.日期 LIKE 分組.最大日期


/* 45 */
DECLARE @上市最新年度 char(4)
DECLARE @興櫃最新年度 char(4)
DECLARE @公發最新年度 char(4)

SELECT @上市最新年度 = MAX(年度) FROM [StockDB].[dbo].[上市櫃基本資料表]
SELECT @興櫃最新年度 = MAX(年度) FROM [StockDB].[dbo].[興櫃基本資料表]
SELECT @公發最新年度 = MAX(年度) FROM [StockDB].[dbo].[公開發行基本資料表]

SELECT 股票名稱, 股票代號, 上市上櫃 AS 市場別, 上市上櫃 AS 信評市場別, 公司名稱, 統一編號 FROM [StockDB].[dbo].[上市櫃基本資料表]
WHERE 年度 LIKE @上市最新年度 AND 掛牌交易中 = 1
UNION
SELECT 名稱 AS 股票名稱, 代號 AS 股票代號, 上市上櫃 AS 市場別, 上市上櫃 AS 信評市場別, 公司名稱, 統一編號 FROM [StockDB].[dbo].[興櫃基本資料表]
WHERE 年度 LIKE @興櫃最新年度 AND 啟用 = 1
UNION
SELECT 名稱 AS 股票名稱, 代號 AS 股票代號, 上市上櫃 AS 市場別, 上市上櫃 AS 信評市場別, 公司名稱, 統一編號 FROM [StockDB].[dbo].[公開發行基本資料表]
WHERE 年度 LIKE @公發最新年度 AND 啟用 = 1 AND 代號 NOT LIKE N'6536'


/* 46 */

SELECT * 
FROM (
	SELECT *,  ROW_NUMBER() OVER(PARTITION BY 股票代號 ORDER BY 日期 DESC) AS [Rank] 
	FROM [StockDB].[dbo].[日收盤] 
	WHERE 股票代號 IN 
		(
		SELECT 股票代號 
		FROM [StockDB].[dbo].[上市櫃基本資料表] 
		WHERE 年度 LIKE N'2018' AND 掛牌交易中 = 1
		)
	AND 日期 LIKE N'2018%'
	) AS 分組
WHERE 分組.[Rank] = 1

/* SOLUTION2 */

SELECT * FROM [StockDB].[dbo].[日收盤] AS 股票資料
INNER JOIN
(SELECT 股票代號, MAX(日期) AS 最大日期
FROM [StockDB].[dbo].[日收盤] 
GROUP BY 股票代號)
AS 股票日期
ON 股票日期.最大日期 = 股票資料.日期 AND 股票日期.股票代號 = 股票資料.股票代號
WHERE 股票資料.股票代號 IN 
	(
	SELECT 股票代號 
	FROM [StockDB].[dbo].[上市櫃基本資料表] 
	WHERE 年度 LIKE N'2018' AND 掛牌交易中 = 1
	)


/* 47 */
SELECT 日借貸前.日期,日借貸今.股票代號, 日借貸前.券商不限用途借貸餘額, 日借貸今.日期, 日借貸今.股票代號, 日借貸今.券商不限用途借貸前日餘額
FROM 
(SELECT ROW_NUMBER() OVER(PARTITION BY 股票代號 ORDER BY 日期 DESC) AS [日期RANK], * FROM [StockDB].[dbo].[日借貸款項擔保品餘額表]) AS 日借貸今 
JOIN 
(SELECT ROW_NUMBER() OVER(PARTITION BY 股票代號 ORDER BY 日期 DESC) AS [日期RANK], * FROM [StockDB].[dbo].[日借貸款項擔保品餘額表]) AS 日借貸前 
ON 日借貸今.股票代號 = 日借貸前.股票代號 AND 日借貸今.日期RANK = 日借貸前.日期RANK-1
WHERE 日借貸今.券商不限用途借貸前日餘額 != 日借貸前.券商不限用途借貸餘額

/* 48 */
SELECT 新訓.股票代號 , 新訓.收盤價 AS 新訓收盤, 日收盤.股票代號, 日收盤.收盤價 AS 日收盤 FROM 
(SELECT * FROM [StockDB].[dbo].[日收盤_新人訓練_2016] WHERE 日期 LIKE N'20161212' ) AS 新訓
JOIN 
(SELECT * FROM [StockDB].[dbo].[日收盤] WHERE 日期 LIKE N'20161212' ) AS 日收盤
ON 日收盤.股票代號 = 新訓.股票代號
WHERE 日收盤.收盤價 != 新訓.收盤價

/* OR THIS*/
SELECT 新訓.股票代號 , 新訓.收盤價 AS 新訓收盤, 日收盤.股票代號, 日收盤.收盤價 AS 日收盤 FROM 
[StockDB].[dbo].[日收盤_新人訓練_2016] AS 新訓
JOIN 
[StockDB].[dbo].[日收盤] AS 日收盤
ON 日收盤.日期 LIKE N'20161212' AND 新訓.日期 LIKE N'20161212' AND 日收盤.股票代號 = 新訓.股票代號
WHERE 日收盤.收盤價 != 新訓.收盤價

/* 49 */
/* ANS SHOULD BE 14895 */

WITH 
公司最大年度 AS(
SELECT 港股.年度, 港股.公司統一編號, MAX(SHGSTUDTLCOM.最大CHADATE) AS 最大CHADATE
FROM
[StockDB].[dbo].[港股上市公司基本資料表] AS 港股
JOIN
(SELECT HK.COMUNIC, 最大日期.最大CHADATE, HK.NUMPUSH 
FROM
(SELECT * FROM [New_HK_DB].[dbo].[HK_SHGSTUDTLCOM])AS HK
JOIN 
(SELECT COMUNIC, MAX(CHDATE) AS 最大CHADATE 
FROM [New_HK_DB].[dbo].[HK_SHGSTUDTLCOM]
WHERE [REFCSHGTY] = 1 AND [AREAREFCSHG] = 1 AND [NUMPUSH] > 0 AND [ISVALID] = 1
GROUP BY COMUNIC, SUBSTRING(CONVERT(nvarchar, CHDATE, 112),0, 5)) AS 最大日期
ON HK.COMUNIC = 最大日期.COMUNIC AND HK.CHDATE = 最大日期.最大CHADATE ) AS SHGSTUDTLCOM
ON 港股.公司統一編號 = SHGSTUDTLCOM.COMUNIC AND 港股.年度 >= SUBSTRING(CONVERT(nvarchar, SHGSTUDTLCOM.最大CHADATE, 112),0, 5)
GROUP BY 港股.公司統一編號, 港股.年度
)


UPDATE [StockDB].[dbo].[港股上市公司基本資料表]
SET [StockDB].[dbo].[港股上市公司基本資料表].[普通股發行股數(百萬股)] = CAST(年度對應.NUMPUSH/1000000 AS DECIMAL(10,3))
FROM 
(SELECT 公司最大年度.最大CHADATE, 公司最大年度.公司統一編號, 公司最大年度.年度, 港股.[普通股發行股數(百萬股)], HK.NUMPUSH FROM 
公司最大年度
JOIN
[StockDB].[dbo].[港股上市公司基本資料表] AS 港股
ON 公司最大年度.年度 = 港股.年度 AND 公司最大年度.公司統一編號 = 港股.公司統一編號
JOIN 
((SELECT * FROM [New_HK_DB].[dbo].[HK_SHGSTUDTLCOM] WHERE [REFCSHGTY] = 1 AND [AREAREFCSHG] = 1 AND [NUMPUSH] > 0 AND [ISVALID] = 1)AS HK
JOIN 
(SELECT COMUNIC, MAX(CHDATE) AS 最大CHADATE 
FROM [New_HK_DB].[dbo].[HK_SHGSTUDTLCOM] WHERE [REFCSHGTY] = 1 AND [AREAREFCSHG] = 1 AND [NUMPUSH] > 0 AND [ISVALID] = 1
GROUP BY COMUNIC, SUBSTRING(CONVERT(nvarchar, CHDATE, 112),0, 5)) AS 最大日期
ON HK.COMUNIC = 最大日期.COMUNIC AND HK.CHDATE = 最大日期.最大CHADATE)
ON 公司最大年度.最大CHADATE = HK.CHDATE AND 公司最大年度.公司統一編號 = HK.COMUNIC) AS 年度對應

WHERE [StockDB].[dbo].[港股上市公司基本資料表].公司統一編號 = 年度對應.公司統一編號 





/* 51 */
GO;
CREATE PROC TWORETURN 
AS
	RETURN 2
GO;

/* 52 */
ALTER PROC TWORETURN
AS 
	RETURN '2'
GO;

DROP PROC TWORETURN


/* 53 */
GO;
CREATE PROC TWORETURN 
AS
	RETURN 2
GO;

DECLARE @two INT
EXEC @two = TWORETURN 

GO
DROP PROC TWORETURN
GO;

CREATE PROC TWORETURN @TWO INT OUTPUT
AS
	SELECT @TWO = 2

GO

DECLARE @two INT
EXEC TWORETURN @two OUTPUT
GO;


/* 55 */
CREATE FUNCTION Get日收盤By日期
(@日期 nvarchar(8))
RETURNS TABLE

RETURN (SELECT * FROM [StockDB].[dbo].[日收盤] WHERE 日期 LIKE @日期 )

GO

SELECT * FROM Get日收盤By日期('20181214')
GO

/* 56 */
CREATE FUNCTION Get日收盤最大日期
()
RETURNS nvarchar(8)
BEGIN
DECLARE @最大日期 nvarchar(8)
 SELECT @最大日期 = MAX(日期) FROM [StockDB].[dbo].[日收盤]

RETURN @最大日期
END

GO
SELECT dbo.Get日收盤最大日期()

/* 60 */
USE StockDB
GO
CREATE TRIGGER 日收盤異動
ON [日收盤]
AFTER INSERT, UPDATE, DELETE
AS
SELECT MTIME = 0
GO

/* 61 */
ENABLE TRIGGER 日收盤異動 ON [日收盤]
GO
DISABLE TRIGGER 日收盤異動 ON [日收盤]
GO
DROP TRIGGER 日收盤異動
GO

/* 63 */
WITH 
TESTCTE AS
(
	SELECT * FROM [StockDB].[dbo].[日收盤]
	WHERE 日期 LIKE N'20181214'
)
SELECT * FROM TESTCTE






