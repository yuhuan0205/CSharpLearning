/* 1 */
CREATE TABLE [StockDB].[dbo].[日收盤_新人訓練_陳祐桓欄位-型態]
(
	[CTIME] datetime,
	[MTIME] int,
	[RecordID] bigint,
	[日期] nvarchar(8),
	[股票代碼] nvarchar(10),
	[股票名稱] nvarchar(20),
	[開盤價] decimal(9,2),
	[最高價] decimal(9,2),
	[最低價] decimal(9,2),
	[收盤價] decimal(9,2),
	[漲跌] decimal(9,2),
);
/* DELETE FROM [StockDB].[dbo].[日收盤_新人訓練_陳祐桓欄位-型態]; */

/* 12 */
INSERT INTO [StockDB].[dbo].[日收盤_新人訓練_陳祐桓欄位-型態](日期, 股票代碼, 股票名稱, 開盤價)
 VALUES('20181218', '0000', '測試', 0);

/* 13 */
UPDATE [StockDB].[dbo].[日收盤_新人訓練_陳祐桓欄位-型態]
SET 開盤價 = 1
WHERE 股票名稱 LIKE '測試';

/* 14 */
DELETE [StockDB].[dbo].[日收盤_新人訓練_陳祐桓欄位-型態]
WHERE 開盤價 = 1;

/* 15 */
INSERT INTO [StockDB].[DBO].[日收盤_新人訓練_陳祐桓欄位-型態]
SELECT [CTIME], [MTIME], [RecordID], [日期], [股票代號], [股票名稱], [開盤價], [最高價], [最低價], [收盤價], [漲跌] FROM [StockDB].[dbo].[日收盤] WHERE 日期 LIKE '20181214';

/* 16 */
DELETE [StockDB].[dbo].[日收盤_新人訓練_陳祐桓欄位-型態];

/* 19 */
SELECT * FROM [StockDB].[dbo].[日收盤]
WHERE [日期] LIKE '20181206';

/* 20 */
SELECT * FROM [StockDB].[dbo].[日收盤]
WHERE (日期 BETWEEN '20181201' AND '20181206') AND 股票代號 IN ('0050', '006201', '00721B');

/* 21 */
SELECT DISTINCT 股票代號 FROM [StockDB].[dbo].[日收盤]
WHERE (日期 BETWEEN '20181201' AND '20181206');

/* 22 */
SELECT 日期, COUNT(*) AS 資料筆數 FROM [StockDB].[dbo].[日收盤]
GROUP BY 日期
HAVING 日期 LIKE '2018%'

/* 23 */
SELECT 股票代號, SUM(開盤價) AS 開盤價總和, MIN(最高價) AS 最小最高價, MAX(最低價) AS 最大最低價, AVG(收盤價) AS 平均收盤價 FROM [StockDB].[dbo].[日收盤]
WHERE 日期 BETWEEN '20181201' AND '20181206'
GROUP BY 股票代號;

/* 24 */
SELECT DISTINCT 股票名稱, SUBSTRING(股票名稱,0,3) AS 縮寫 FROM [StockDB].[dbo].[日收盤]
WHERE 日期 BETWEEN '20181201' AND '20181206'

/* 25 */
SELECT DISTINCT RTRIM (LTRIM(股票名稱)) AS 頭尾去空白 FROM [StockDB].[dbo].[日收盤]
WHERE 日期 BETWEEN '20181201' AND '20181206'

/* 26 */
SELECT * FROM [StockDB].[dbo].[日收盤]
WHERE 日期 BETWEEN '20181201' AND '20181206'
ORDER BY 股票代號 DESC, 日期 ASC

/* 27 */
SELECT 股票代號, AVG(收盤價) AS 平均收盤價 FROM [StockDB].[dbo].[日收盤]
WHERE 日期 BETWEEN '20181201' AND '20181206'
GROUP BY 股票代號
HAVING AVG(收盤價) < 80

/* 28 */
SELECT COUNT(*) AS 總資料筆數 FROM [StockDB].[dbo].[日收盤]
WHERE 日期 LIKE '2018%'

/* 29 */
/* solution 1 */
SELECT COUNT(*) AS 總資料筆數
FROM ( (SELECT 股票代號, 日期 FROM [StockDB].[dbo].[日收盤]
WHERE 日期 LIKE '2018%' )
EXCEPT
(SELECT 股票代號, 日期 FROM [StockDB].[dbo].[日收盤]
WHERE 日期 LIKE '2018%' AND 收盤價 IS NULL
)) AS 非空收盤價

/* solution 2 */
SELECT COUNT(*) AS 總資料筆數
FROM [StockDB].[dbo].[日收盤]
WHERE 日期 LIKE '2018%' AND (收盤價 >=0 OR 收盤價 < 0)


/* 30 */
SELECT DISTINCT 股票代號 FROM [StockDB].[dbo].[日收盤]
WHERE 日期 LIKE '2018%' AND LEN(股票代號) > 4

/* 31 */
SELECT DISTINCT REPLACE(股票名稱, '指數', '__') AS 名稱包含指數之股票 FROM [StockDB].[dbo].[日收盤]
WHERE 日期 LIKE '2018%' AND 股票名稱 LIKE '%指數%'

/* 32 */
SELECT * from [StockDB].[DBO].[日收盤] 
WHERE DATEDIFF(dd, CTIME, GETDATE()) = 0

/* 33 */
SELECT * FROM (SELECT *,  ROW_NUMBER() OVER(PARTITION BY 股票代號 ORDER BY 日期) AS [Rank] FROM [StockDB].[dbo].[日收盤] WHERE 股票代號 LIKE '1%' AND 日期 LIKE '2018%') AS 分組
WHERE 分組.[Rank] = 6

/* 34 */
SELECT DISTINCT 股票代號 FROM [StockDB].[dbo].[日收盤]
WHERE [日期] LIKE '20181206'
EXCEPT
SELECT DISTINCT 股票代號 FROM [StockDB].[dbo].[日收盤]
WHERE [日期] LIKE '20181205'

/* 35 */
SELECT DISTINCT 股票代號 FROM [StockDB].[dbo].[日收盤]
WHERE [日期] LIKE '20181206'
INTERSECT 
SELECT DISTINCT 股票代號 FROM [StockDB].[dbo].[日收盤]
WHERE [日期] LIKE '20181205'

/* 36 */
SELECT 日收盤.* , 上市櫃.英文名稱  
FROM [StockDB].[dbo].[日收盤] AS 日收盤 JOIN [StockDB].[dbo].[上市櫃基本資料表] AS 上市櫃 ON 日收盤.股票代號 = 上市櫃.股票代號 AND SUBSTRING(日收盤.日期, 0, 5) LIKE  上市櫃.年度
WHERE 日收盤.日期 LIKE '2018%'

/* 37 */
SELECT 日收盤.日期, 日收盤.股票名稱, ETF.年度, ETF.名稱 
FROM (SELECT * FROM [StockDB].[dbo].[日收盤] WHERE 日期 LIKE '20181214' ) AS 日收盤 
JOIN 
(SELECT 年度, 名稱, 代號 FROM [StockDB].[dbo].[ETF基本資料表] WHERE 年度 LIKE '2018') AS ETF
ON 日收盤.股票代號 = ETF.代號 AND SUBSTRING(日收盤.日期, 0, 5) LIKE  ETF.年度

/* 38 */
SELECT 上市櫃 = 
CASE 上市櫃
	WHEN 1 THEN '上市'
	WHEN 2 THEN '上櫃'
	WHEN 3 THEN '興櫃'
	WHEN 4 THEN '公發'
	ELSE '其他'
END,
[CTIME], [MTIME], [RecordID], [日期], [股票代號], [股票名稱], [參考價], [開盤價], [最高價], [最低價], [收盤價], [漲跌], [產業代號], [漲停價], [跌停價], [漲跌狀況], [最後委買價], [最後委賣價], [漲幅(%)], [振幅(%)], [成交量], [成交量(股)], [成交筆數], [成交金額(千)], [成交值比重(%)], [成交量變動(%)], [股本(百萬)2], [均張變動(%)], [均張], [總市值(億)], [市值比重(%)], [類股本益比], [類股股價淨值比], [類股股價淨值比2], [本益比], [本益比(近四季)], [股東權益(百萬)], [股價淨值比], [股價淨值比2], [舊股本(百萬)], [委買張數], [委賣張數], [次日參考價], [成交金額_元], [均價], [股本(百萬)], [週轉率], [漲跌停]
FROM [StockDB].[dbo].[日收盤] AS 日收盤
WHERE 日期 BETWEEN '20181201' AND '20181206'

/* 39 */
SELECT [Range] = 
CASE 
	WHEN 收盤價<10 THEN 'Under_10'
	WHEN 收盤價 >= 10 AND 收盤價 < 50 THEN 'Under_50'
	WHEN 收盤價 >= 50 AND 收盤價 < 100 THEN 'Under_100'
	WHEN 收盤價>=100 THEN 'Over_100'
END, *
FROM [StockDB].[dbo].[日收盤] AS 日收盤
WHERE 日期 BETWEEN '20181201' AND '20181206'

/* 40 */
SELECT * FROM [StockDB].[dbo].[日收盤]
WHERE 日期 LIKE '20181206'
ORDER BY 
CASE
	WHEN 收盤價 > 5 THEN 收盤價
	WHEN 收盤價 <=5 THEN 收盤價*-1
	END
DESC 