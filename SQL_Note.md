# SQL 練習題目及答案

補充知識：

`資料完整性：`
* 實體完整性：Database會拒絕加入重複的primary key來保證實體完整性。
* 區域完整性：Database會拒絕加入資料類型超出預設範圍的資料，來確保區域完整性。
* 參考完整性：若 TableA 的 foreign key 指向的 TableB 的 primary key 將被刪除，Database會拒絕操作以確保參考完整性。

`在SQL server中，若一表未建立叢集索引，資料表則會以Heap Table(查詢時無序)的方式建立，好處是新增資料時因不必考慮排序，可以有更快的速度。`


`資料庫儲存資料的最小單位為資料頁－－page，`

每個資料頁大小約為8Kbytes，開頭96bytes，都是存放metadata。

資料頁分成以下幾種類型：
* 資料頁：存放資料列的頁面(除特定資料類型 text, image...等)
* 索引頁：存放指向資料頁索引的頁面
* 文字/影像頁：存放 text, image等特殊資料型態
* 系統相關資料頁：存放跟資料表相關的資訊。

`B Tree 與 B+ Tree 的差別`

```
B Tree 是一個 Balenced m Tree，意即 *會自動平衡的m階樹狀結構*
每個節點會有資料與指標，指標會指向子節點，而子節點的資料會介於父節點的指標前後的資料範圍。
一個節點最多只向M個節點，當指向的節點超過M時，會拆分父節點重新定位子節點。

B+Tree 也是一個 Balenced m Tree，只是在針對資料庫邏輯與硬碟的物理限制上做了優化。
與B Tree類似，但B+Tree的資料都只存放在葉節點，非葉節點都存放指標，由於指標不大，相較於同時存放資料
的B Tree，B+ Tree可以存放更多指標在一個節點中，指標的順序即是葉節點的順序，也就是資料的順序。
而葉節點還存了左右葉節點的指標，使得整體存取效率更高。而這樣的結構也使整顆B+Tree的樹高落在 1-3之間。
不會有B Tree 在資料量大的時候會有深度過深的問題。
```

`索引破碎`
* 外部破碎－ 指當同一index下存放的資料頁滿時，系統在開新的資料頁裝資料，造成同一索引下資料不連續的問題。
* 內部破碎－ 指當同一index下的資料頁中，有資料修改或刪除時，導致資料列之間有多餘的空間。

此時就該進行索引重組或重建。

`VIEW 修改的情況`
* VIEW可以做CRUD。
* VIEW不能新增資料的特殊情況是，當VIEW只指定了部分欄位，新增資料時沒辦法在VIEW上指定其對應的資料表上的所有NOT NULL欄位，因而造成無法新增資料的情況。

`LIKE 與 = 的差異`
* LIKE 可以使用萬用字元來進行比對，= 則否。
* 當LIKE使用萬用字元進行查找時，其搜尋模式會根據其模式而有差別。如 
  在有索引的欄位以條件 LIKE'%abc%'會進行全表掃描；'abc%'會先到 'abc'的位置在進行掃描。
  而 = 是精確搜索，用Seek的方式而不是採全表掃描。

`CAST 與 CONVERT 的差異`
* CAST 為 SQL明確制定的轉型方法，所有DBMS都有，CONVERT則不是每個DBMS都有提供。
* MSSQL 提供CONVERT方法作為轉型，比起CAST多了一個STYLE參數，但在不加STYLE參數的情況下使用上與CAST無異
* STYLE 參數提供了日期、時間、數字的格式化處理。

`CTE 與 TEMP 的比較`
* TEMP TABLE 在創建時需要宣告表的結構。
* CTE 創建只需要設陳述式而不需要事先宣告表結構便能建立一張表。
* CTE 支援遞迴查詢。
語法：
```SQL
/* 可以複製表結構到新表 */
SELECT * INTO new_table FROM TABLE_A WHERE 1 = 0;

SELECT DISTINCT COL FROM TABLE_A;
SELECT TOP n * FROM TABLE_A;
SELECT TOP n PERCENT * FROM TABLE_A;

/* 針對每個在CUBE裡的欄位做分組 COL1 + COL2, COL1 + NULL, COL2 + NULL, NULL + NULL */
SELECT COL1, COL2, SUM(COUNTS) AS Total
FROM TABLE_A
GROUP BY CUBE(COL1, COL2)

/* 針對每個在ROLLUP裡第一個欄位做分組 COL1 + COL2, COL1 + NULL, NULL + NULL */
SELECT COL1, COL2, SUM(COUNTS) AS Total
FROM TABLE_A
GROUP BY ROLLUP(COL1, COL2)

/* 萬用字元 */
/* % 代表數個任意字元*/
'%SQL%'
/* _代表一個任意字元 */
'__筆' /* 螢光筆，原子筆 */
/* []範圍內的字 */
'[A-C]at', '[ABCD]at' /* Bat, Cat */
/* 不在[^]範圍內的字 */
'[^A-C]at' /* Eat, Rat */

```
## 第一題
請在192.168.10.180的StockDB底下建立一張資料表，資料表需求如下：
```
表名：日收盤_新人訓練_{YourName}欄位 - 型態：
CTIME - datetime
MTIME - int
RecordID - bigint
日期 - nvarchar(8)
股票代號 - nvarchar(10)
股票名稱 - nvarchar(20)
開盤價 - decimal(9, 2)
最高價 - decimal(9, 2)
最低價 - decimal(9, 2)
收盤價 - decimal(9, 2)
漲跌 - decimal(9, 2)
PK(主鍵)：日期(DESC)、股票代號(ASC)
非叢集索引：MTIME(DESC)
CTIME預設值：getdate()
```
Answer
```Sql
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
```
`也可以使用 USE StockDB 然後直接 CREATE TABLE [日收盤_新人訓練_陳祐桓欄位-型態]。`

## 第二題
以下常用的欄位型態分別是存什麼樣的資料？他的儲存大小為何？
### 數值
* tinyint  整數，範圍從 `0 ~ 255(2^8 -1)` `1 byte(2^8)`
* smallint 整數，範圍從 `(-2^15) ~ (2^15 -1)` `2 bytes(2^16)` 前 1個 bit 存 sign，後15個 bits 存數字。
* int 整數，範圍從 `(-2^31) ~ (2^31 -1)` `4 bytes(2^32)` 前 1個 bit 存 sign，後31個 bits 存數字。
* bigint 整數，範圍從 `(-2^63) ~ (2^63 -1)` `8 bytes(2^64)` 前 1個 bit 存 sign，後63個 bits 存數字。
* float 浮點數(近似值) `(-1.79*10^308) ~ (1.79*10^308) 最多表示15位數` `8 btyes` 雙精度浮點數
* real 浮點數(近似值) `(-3.40*10^38) ~ (3.40*10^38) 最多表示7位數` `4 btyes` 單精度浮點數
* numeric 精確位數，使用時須指定 (精確度, 小數點後位數)，資料範圍`-10^38 ~ 10^38 - 1`，儲存大小則視精確位數決定：
```
精確度，可指定範圍 1~38，小數位數則是最小為 0，最大不能超過指定的精確度。
1-9 : 5bytes
10-19 : 9bytes
20-28 : 13bytes
29-38 : 17bytes
```
* decimal 基本上與numeric無異，除了 `decimal會保留超出精確度的數值，numeric則完全依照指定的規範儲存。 `
### 字串
* char(n) 資料範圍 `1-8000個字元`，每個字元 1 byte，為固定長度，未填滿的部分會填上空白字元。
* varchar(n) 資料範圍 `1-8000個字元`，每個字元 1 byte，為變動長度，儲存多少字元就佔多少空間。
* varchar(max) 資料範圍 `1 ~ (2^31 -1)` 個字元，為變動長度，儲存多少字元就佔多少空間，最多2GB
* text 資料範圍 `1 ~ (2^31 - 1)` 個字元，為變動長度，儲存多少字元就佔多少空間，最多2GB

`補充，text與varchar(max)的差異：當資料未超過8000個字元(8K byte)，varchar(max)會將資料存進row中，text則是都存進blob，row存放指向blob的索引。`
### Unicode字串
`Unicode字串一個字元為2bytes`
* nchar(n) 資料範圍 `1-4000個字元`，每個字元 2 byte，為固定長度，未填滿的部分會填上空白字元。
* nvarchar(n) 資料範圍 `1-4000個字元`，每個字元 2 byte，為變動長度，儲存多少字元就佔多少空間。
* nvarchar(max) 資料範圍 `1 ~ (2^30 -1)` 個字元，為變動長度，儲存多少字元就佔多少空間，最多2GB
* ntext 資料範圍 `1 ~ (2^30 - 1)` 個字元，為變動長度，儲存多少字元就佔多少空間，最多2GB
### 日期
* datetime `1753/1/1 ~ 9999/12/31 精確到 3.33ms` 共 8bytes，前 4 date，後 4 time。
* datetime2 `0001-01-1 00:00:00.0000000 ~ 999-12-31 23:59:59.9999999 精確到 100ns` 共 6-8bytes。
* smalldatetime `1900/1/1 ~ 2079/6/6 精確到 min` 共 4bytes， 前 2 date，後 2 time。雖會顯示出秒，但會進位會捨棄(大於或小於30秒)。
* date `0001:01:01 ~ 9999:12:31 精確到 day` 共 3 bytes。
* time `00:00:00.0000000 ~ 23:59:59.9999999 精確到 100ns` 共 3~5個byte。
* datetimeoffset 同datetime2 差別在於加上時以表示特定時間點。
### 其他不常用到的類別
* 貨幣－ 用於儲存貨幣相關的數字。
* 二元碼字串－ 與字串類型結構相似，差別在於二元碼字串直接使用byte儲存，而不是採用字元。
* XML－ 儲存符合XML格式的任何資料，最大2GB

## 第三題 
char、nchar、varchar、nvarchar有什麼差別？

可參考上方筆記
|差異|char|nchar|varchar|nvarchar|
|---|---|---|---|---|
|字元大小|1Byte|2Bytes|1Byte|1Byte|
|可變動|固定長度|固定長度|可變動|可變動|

## 第四題
decimal(9,2)代表什麼跟decimal(19,4)差別？
為何不用real、float？什麼是浮點數誤差？
`decimal(精確度, 小數後位數) 123.5 精確度為數字總位數－4，小數後位數－1`

`浮點數儲存原理： 以單精度浮點數 real 為例， 4 bytes 中 第 1 個 bit 表示 正負，後 8 個 bits 表示指數項，最後 23 個bits表示尾數。如把數字 8.5 轉換成浮點數，會經由以下若干轉換。`

轉換過程
* 將 8.5 轉換成 2^3 + 2^-1 表示為 1000.1
* 將 1000.1 轉換成 1.0001 * 2^3
* 浮點數表示為 ： `0 (+)` `1000(127)` `0010(3)` `0001 0000 0000 0000 0000 000`

浮點數誤差產生原因：若小數部分無法以 (1/2)^n 相加而來，就會出現誤差。例如 1.9 為 1 * (0.5 + 0.25 + 0.125 +... )
= 1.89999997615814208.... 近似於 1.9。

## 第五題
什麼是PrimaryKey(PK or 主鍵)?什麼是ForeignKey(FK or 外來鍵)？

一個資料表中有若干種鍵，其關係如下：
* 超鍵 Superkeys － 一表中，一或多個欄位組成不重複的鍵值(唯一性)，則稱為超鍵，一表中可有多個超鍵。
* 候選鍵 Candidate Keys － 為一超鍵(滿足唯一性)，同時仍須滿足最小性，意即，若組成候選鍵的複數個欄位中，有刪除後還能保持唯一性的欄位，則違反最小性。
* 主鍵 Primary Key － 候選鍵中的其中一個，一個表必須且只能要有一個主鍵。
* 替代鍵 Alternate Keys － 除主鍵外的其他候選鍵。
* 外來鍵 Foreign Keys － 表中一欄位對應到其他表中的主鍵(MSSQL中可以是受UNIQUE約束的欄位)。可以有多個外來鍵。用於串聯其他Table。

## 第六題
為什麼要設定PK或FK？
* PK為識別一筆資料的唯一標記，若沒有PK，則可能加入多筆重複資料，浪費空間的同時，還不能保證資料的實體完整性。
* 且PK建立時，表會自動生成PK索引，以加快跟PK相關的查詢。
* FK可以連結兩表的資料，避免重複的資料浪費空間。
* FK可以避免再資料表把某些資料刪除時導致部分資料欄的資料缺失。利用參考完整性來保證資料不缺失。
* FK可以讓資料的修改更有效率。

## 第七題
叢集索引是什麼？非叢集索引是什麼？

叢集索引：
* 表中資料列的實體儲存順序(邏輯上而非物理)，是依照叢集索引排序的。
* 也因此，每個表只能有 *一個* 叢集索引，系統預設是PK。
* 類似一本書的頁次。

非叢集索引：
* 我們常聽到的索引指的就是這個。一個表中最多可以有249個非叢集索引。
* 非叢集索引儲存在另一顆B+Tree中，並根據設定的索引欄位進行排序。
* 其葉節點不存放資料，而是存放指向資料的位置。
* 類似一本原文書最後根據關鍵字字母，給出該關鍵字對應的頁次。

## 第八題
建立索引能帶來什麼好處？壞處？

好處：
* 針對有建立索引的欄位進行查詢會更加有快速。

壞處：
* 每建立一個索引就會建一棵新的B+Tree，會占用一定的空間。
* 每次新增、刪除、修改資料，就必須針對每個索引的B+Tree修改並維護，會占用一定時間。

## 第九題
條件約束有哪些？其中Primary Key與UNIQUE有何差別？

條件約束的種類：
* Primary Key 主鍵 － 約束該欄位的值必須是唯一且不可為NULL。每個表只能有一個。
* Foreign Key 外鍵 － 約束該欄位的值必須是來自其所參考到的資料欄位(但可為NULL)，否則拒絕寫入。
* NOT NULL － 約束該欄位不可為空。系統預設為 NULL(可為空值)。
* DEFAULT － 約束該欄位在未輸入資料時，會填入預設的值。
* CHECK － 約束該欄位輸入的值必須在定義的範圍內。
* UNIQUE － 約束該欄位不能輸入重複的值，可輸入NULL但也只能有一個。

Primary Key與UNIQUE的差異：
* PK不可為空，UNIQUE則可以為空(但只能有一個)
* PK一個表中只能有一個，而UNIQUE則可以有多個。

`疑惑：若A表有一外鍵指向B表UNIQUE之欄位，當B表的UNIQUE欄位中有NULL時，A表外鍵插入NULL會指向哪裡？`

## 第十題
VIEW是什麼？

VIEW 檢視表 － 是一個將查詢敘述簡化的資料呈現方式，可以將冗長的查詢敘述替換成一個檢視表，以利日後重複使用該查詢敘述。VIEW只儲存敘述而不儲存資料，資料依舊是從資料表中取得，因此檢視表並不佔用空間。

## 第十一題
什麼情況下會使用VIEW？

* 當一個查詢敘述很常使用，就可以考慮使用VIEW替代該敘述來增加可讀性。
* 針對不同的使用者建立不同的檢視表，可以限制使用者所能看到的資料。來自同一份資料表的資料可以利用VIEW根據不同的情境給予使用者不同的資料。
* 可以隔離程式與底層資料，防止其耦合程度過高。當底層資料表結構改變時，只需要改變VIEW而不用更改程式


## 第十二題
請使用語法新增一筆資料到第一題所建立的表中
```SQL
INSERT INTO [StockDB].[dbo].[日收盤_新人訓練_陳祐桓欄位-型態](日期, 股票代號, 股票名稱, 開盤價)
 VALUES(N'20181218', N'0000', N'測試', 0);
```

## 第十三題
請使用語法校正上一題新增的資料
```SQL
UPDATE [StockDB].[dbo].[日收盤_新人訓練_陳祐桓欄位-型態]
SET 開盤價 = 1
WHERE 股票名稱 LIKE N'測試';
/*補充：SET的WHERE也可以比對多個資料表*/
UPDATE TABLE_A
SET ...
FROM TABLE_B
WHERE TABLE_A.ID = TABLE_B.ID;
```

## 第十四題
請使用語法刪除上一題修改的資料
```SQL
DELETE [StockDB].[dbo].[日收盤_新人訓練_陳祐桓欄位-型態]
WHERE 開盤價 = 1;

/*條件來自其他表*/
DELETE TABLE_A
FROM TABLE_B
WHERE TABLE_A.ID = TABLE_B.ID;
```

## 第十五題
請使用語法新增資料到第一題所建立的表中
```SQL
INSERT INTO [StockDB].[DBO].[日收盤_新人訓練_陳祐桓欄位-型態]
 SELECT [CTIME], [MTIME], [RecordID], [日期], [股票代號], [股票名稱], [開盤價], [最高價], [最低價], [收盤價], [漲跌] FROM [StockDB].[dbo].[日收盤] WHERE 日期 LIKE '20181214';
```

## 第十六題
請使用兩種不同語法一次刪除第一題所建立的資料表內的所有資料
```SQL
DELETE [StockDB].[DBO].[日收盤_新人訓練_陳祐桓欄位-型態];

TRUNCATE TABLE [StockDB].[DBO].[日收盤_新人訓練_陳祐桓欄位-型態];
```

## 第十七題
請使用語法刪除第一題建出來的table
```SQL
DROP TABLE [StockDB].[dbo].[日收盤_新人訓練_陳祐桓欄位-型態];
```

## 第十八題
以下語法有何差異?
```SQL
/* DELETE 屬於 DML 會被記錄到交易日誌中，執行後不會馬上把資料清掉，而是標記為刪除，可以回復資料。*/
/* 此操作並不會刪除表結構、索引、約束條件*/
/* 可作用於檢視圖 */
DELETE FROM TABLE_A;

/* TRUNCATE 屬於 DDL 不會被記錄到交易日誌中，執行後後馬上把資料清掉，無法回復資料。*/
/* 有被其他表使用外鍵參考的話，該表無法使用 TRUNCATE*/
/* 此操作並不會刪除表結構、索引、約束條件*/
/* 不可作用於檢視圖 */
TRUNCATE TABLE TABLE_A;

/* DROP 屬於 DDL 不會被記錄到交易日誌，並且表結構會連同資料一起被刪除，若有被參考，則會連約束條件一起改為INVAILD狀態*/
/* 可作用於檢視圖 */
DROP TABLE TABLE_A;
```

`網路上簡單說明：我手上有瓶可樂，DELETE就是把可樂藏起來了，但可樂跟瓶子都還在；TRUNCATE就是把可樂喝完了，留了個瓶子；DROP就是可樂喝完了，瓶子也丟了。`

## 第十九題
找出日期為 20181206的所有資料
```SQL
SELECT * FROM [StockDB].[dbo].[日收盤]
WHERE [日期] LIKE N'20181206';
```

## 第二十題
股票代號為0050、006201、00680L、00721B
日期在20181201到20181206的所有資料
```SQL
SELECT * FROM [StockDB].[dbo].[日收盤]
WHERE (日期 BETWEEN N'20181201' AND N'20181206') AND 股票代號 IN (N'0050', N'006201', N'00721B');
```

## 第二十一題
所有20181201到20181206中不相同的股票代號
```SQL
SELECT DISTINCT 股票代號 FROM [StockDB].[dbo].[日收盤]
WHERE (日期 BETWEEN N'20181201' AND N'20181206');
```

## 第二十二題
2018年每個日期的資料筆數
```SQL
SELECT 日期, COUNT(*) AS 資料筆數 FROM [StockDB].[dbo].[日收盤]
GROUP BY 日期
HAVING 日期 LIKE N'2018%'
```

## 第二十三題
每檔股票在20181201到20181206的開盤價總和、最小最高價、最大最低價、平均收盤價
```SQL
SELECT 股票代號, SUM(開盤價) AS 開盤價總和, MIN(最高價) AS 最小最高價, MAX(最低價) AS 最大最低價, AVG(收盤價) AS 平均收盤價 FROM [StockDB].[dbo].[日收盤]
WHERE 日期 BETWEEN N'20181201' AND N'20181206'
GROUP BY 股票代號;
```

## 第二十四題
所有在20181201到20181206 不相同股票名稱的前兩個字
```SQL
SELECT DISTINCT 股票名稱, SUBSTRING(股票名稱,0,3) AS 縮寫 FROM [StockDB].[dbo].[日收盤]
WHERE 日期 BETWEEN N'20181201' AND N'20181206'
```

## 第二十五題
所有在20181201到20181206的不相同股票名稱且頭尾要去空白
```SQL
SELECT DISTINCT RTRIM (LTRIM(股票名稱)) AS 頭尾去空白 FROM [StockDB].[dbo].[日收盤]
WHERE 日期 BETWEEN N'20181201' AND N'20181206'
```

## 第二十六題
20181201到20181206的所有股票，先依照股票代號由大到小排序，再依照日期由小到大排序
```SQL
SELECT * FROM [StockDB].[dbo].[日收盤]
WHERE 日期 BETWEEN N'20181201' AND N'20181206'
ORDER BY 股票代號 DESC, 日期 ASC
```

## 第二十七題
20181201到20181206所有平均收盤價低於80的股票代號
```SQL
SELECT 股票代號, AVG(收盤價) AS 平均收盤價 FROM [StockDB].[dbo].[日收盤]
WHERE 日期 BETWEEN N'20181201' AND N'20181206'
GROUP BY 股票代號
HAVING AVG(收盤價) < 80
```

## 第二十八題
2018年總資料筆數
```SQL
SELECT COUNT(*) AS 總資料筆數 FROM [StockDB].[dbo].[日收盤]
WHERE 日期 LIKE N'2018%'
```

## 第二十九題
2018年忽略收盤價為null的總資料筆數，不能用where 收盤價 IS NOT NULL
```SQL
SELECT COUNT(*) AS 總資料筆數
FROM ( (SELECT 股票代號, 日期 FROM [StockDB].[dbo].[日收盤]
WHERE 日期 LIKE N'2018%' )
EXCEPT
(SELECT 股票代號, 日期 FROM [StockDB].[dbo].[日收盤]
WHERE 日期 LIKE N'2018%' AND 收盤價 IS NULL
)) AS 非空收盤價

SELECT COUNT(*) AS 總資料筆數
FROM [StockDB].[dbo].[日收盤]
WHERE 日期 LIKE N'2018%' AND (收盤價 >=0 OR 收盤價 < 0)

SELECT COUNT(收盤價) AS 總資料筆數
FROM [StockDB].[dbo].[日收盤]
WHERE 日期 LIKE N'2018%'
```

## 第三十題
2018年股票代號長度大於4的所有不相同股票代號
```SQL
SELECT DISTINCT 股票代號 FROM [StockDB].[dbo].[日收盤]
WHERE 日期 LIKE N'2018%' AND LEN(股票代號) > 4
```

## 第三十一題
2018年包含"指數"且不相同的股票名稱，在顯示股票名稱時把"指數"換成"__"
```SQL
SELECT DISTINCT REPLACE(股票名稱, N'指數', N'__') AS 名稱包含指數之股票 FROM [StockDB].[dbo].[日收盤]
WHERE 日期 LIKE N'2018%' AND 股票名稱 LIKE N'%指數%'
```

## 第三十二題
"今天"的所有資料，不能把日期寫死(可能沒有)
```SQL
/* 用日期轉型 */
SELECT * from [StockDB].[DBO].[日收盤] 
WHERE DATEDIFF(dd, CAST(日期 AS DATE), GETDATE()) = 0

/* 日期轉型字串 */
/* https://kknews.cc/zh-tw/code/ga46yp8.html */
DECLARE @TODAY NVARCHAR(8) = CONVERT(NVARCHAR(8), GETDATE(), 112)
SELECT * from [StockDB].[DBO].[日收盤] 
WHERE 日期 LIKE @TODAY

/* 本日 */
SELECT * from [StockDB].[DBO].[日收盤] 
WHERE DATEDIFF(dd, CTIME, GETDATE()) = 0

/* 3日內 */
SELECT * from [StockDB].[DBO].[日收盤] 
WHERE DATEDIFF(dd, CTIME, GETDATE()) <= 3

/* 本月 */
SELECT * from [StockDB].[DBO].[日收盤] 
WHERE DATEDIFF(MM, CTIME, GETDATE()) = 0
```

## 第三十三題
找到2018年所有股票代號1開頭的股票各自的第6個交易日資料
```SQL
SELECT * FROM (SELECT *,  ROW_NUMBER() OVER(PARTITION BY 股票代號 ORDER BY 日期) AS [Rank] FROM [StockDB].[dbo].[日收盤] WHERE 股票代號 LIKE N'1%' AND 日期 LIKE N'2018%') AS 分組
WHERE 分組.[Rank] = 6
```

## 第三十四題
20181206有但20181205沒有的股票代號
```SQL
SELECT DISTINCT 股票代號 FROM [StockDB].[dbo].[日收盤]
WHERE [日期] LIKE N'20181206'
EXCEPT
SELECT DISTINCT 股票代號 FROM [StockDB].[dbo].[日收盤]
WHERE [日期] LIKE N'20181205'
```

## 第三十五題
20181206有但20181205也有的股票代號
```SQL
SELECT DISTINCT 股票代號 FROM [StockDB].[dbo].[日收盤]
WHERE [日期] LIKE N'20181206'
INTERSECT 
SELECT DISTINCT 股票代號 FROM [StockDB].[dbo].[日收盤]
WHERE [日期] LIKE N'20181205'
```

## 第三十六題
2018所有日收盤資料加上該檔股票的英文名稱(使用[日收盤]、在[上市櫃資本資料表]中找出該筆資料所符合的年度與股票代號所對應的英文名稱)
```SQL
SELECT 日收盤.* , 上市櫃.英文名稱  
FROM [StockDB].[dbo].[日收盤] AS 日收盤 JOIN [StockDB].[dbo].[上市櫃基本資料表] AS 上市櫃 ON 日收盤.股票代號 = 上市櫃.股票代號 AND SUBSTRING(日收盤.日期, 0, 5) LIKE  上市櫃.年度
WHERE 日收盤.日期 LIKE N'2018%'
```

## 第三十七題
[ETF基本資料表]中2018年的資料，以及該ETF在20181214的[日收盤]資料，且[ETF基本資料表]的[名稱]與[日收盤]的[股票名稱]不同，顯示[ETF基本資料表]的[年度][名稱]，以及[日收盤]的[日期][股票名稱]。
```SQL
SELECT 日收盤.日期, 日收盤.股票名稱, ETF.年度, ETF.名稱 
FROM (SELECT * FROM [StockDB].[dbo].[日收盤] WHERE 日期 LIKE N'20181214' ) AS 日收盤 
JOIN 
(SELECT 年度, 名稱, 代號 FROM [StockDB].[dbo].[ETF基本資料表] WHERE 年度 LIKE N'2018') AS ETF
ON 日收盤.股票代號 = ETF.代號
WHERE 日收盤.股票名稱 NOT LIKE ETF.名稱
```

## 第三十八題
20181201到20181206的所有資料，[上市櫃]欄位的規則：[上市櫃] = 1時顯示上市，[上市櫃]=2時顯示上櫃，[上市櫃]=3時顯示興櫃，[上市櫃]=4時顯示公發，[上市櫃]=其他數字時顯示其他
```SQL
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
```

## 第三十九題
20181201到20181206的所有股票資料
並新加一個欄位[Range]
當收盤價<10時顯示Under_10
10<=收盤價<50顯示Under_50
50<=收盤價<100顯示Under_100
收盤價>=100時顯示Over_100
```SQL
SELECT [Range] = 
CASE 
	WHEN 收盤價<10 THEN N'Under_10'
	WHEN 收盤價 >= 10 AND 收盤價 < 50 THEN N'Under_50'
	WHEN 收盤價 >= 50 AND 收盤價 < 100 THEN N'Under_100'
	WHEN 收盤價>=100 THEN N'Over_100'
END, *
FROM [StockDB].[dbo].[日收盤] AS 日收盤
WHERE 日期 BETWEEN N'20181201' AND N'20181206'
```

## 第四十題
20181206的所有股票資料，並以收盤價>5遞減、收盤價<=5遞增排序
```SQL
SELECT * FROM [StockDB].[dbo].[日收盤]
WHERE 日期 LIKE N'20181206'
ORDER BY 
CASE
	WHEN 收盤價 > 5 THEN 收盤價
	WHEN 收盤價 <=5 THEN 收盤價*-1
	END
DESC 
```

## 第四十一題
找出頭1000檔股票"各自"最大日期的所有欄位資料
```SQL
SELECT * FROM
(
	SELECT *, ROW_NUMBER() OVER(PARTITION BY 股票代號 ORDER BY 日期 DESC) AS 筆數 
	FROM [StockDB].[dbo].[日收盤]
	WHERE 股票代號 IN (SELECT DISTINCT TOP 1000 股票代號 FROM [StockDB].[dbo].[日收盤])
) AS 頭1000檔股票
WHERE 頭1000檔股票.筆數 = 1
```


## 第四十二題
UNION、UNION ALL差別?

UNION會略掉重複的資料，UNION ALL 則會把所有資料都垂直合併。

## 第四十三題
UNION、EXCEPT、INTERSECT差別?畫出交集圖

UNION為聯集，取出集合中所有元素。

INTERSECT為交集，取出集合中有重疊的部分元素。

EXCEPT為差集，取出第一個集合且不在第二個集合的元素。

## 第四十四題
解釋 INNER JOIN、RIGHT JOIN、LEFT JOIN、OUTER JOIN

JOIN的時候，有分成 *左表* 與 *右表* ，根據設定的條件合併左右兩表。
* INNER JOIN 是預設的 JOIN，只顯示符合條件後合併的資料。
* RIGHT JOIN 顯示符合條件後合併的資料，以及右表不符合條件的資料(沒有合併到的欄位為NULL)。
* LEFT JOIN 顯示符合條件後合併的資料，以及左表不符合條件的資料(沒有合併到的欄位為NULL)。
* OUTTER JOIN 顯示符合條件後合併的資料，以及兩表不符合條件的資料(沒有合併到的欄位為NULL)。

`表左`
|水果|進價|
|---|---|
|香蕉|20|
|蘋果|30|

`表右`
|水果|售價|
|---|---|
|香蕉|40|
|西瓜|50|

`INNER JOIN ON 水果`
|水果|進價|售價|
|---|---|---|
|香蕉|20|40|

`RIGHT JOIN ON 水果`
|水果|進價|售價|
|---|---|---|
|香蕉|20|40|
|西瓜|NULL|40|

`LEFT JOIN ON 水果`
|水果|進價|售價|
|---|---|---|
|香蕉|20|40|
|蘋果|30|NULL|

`OUTTER JOIN ON 水果`
|水果|進價|售價|
|---|---|---|
|香蕉|20|40|
|蘋果|30|NULL|
|西瓜|NULL|40|

## 第四十五題

```SQL
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
```


## 第四十六題
找出日收盤內2018年正在掛牌交易中的各檔股票的最大日期資料(使用[日收盤]、在[上市
櫃基本資料表]中找出該筆資料所符合的年度與股票代號所對應的掛牌交易中)
```SQL
SELECT * 
FROM (
	SELECT *,  ROW_NUMBER() OVER(PARTITION BY 股票代號 ORDER BY 日期 DESC) AS [Rank] 
	FROM [StockDB].[dbo].[日收盤] 
	WHERE 股票代號 IN 
		(
		SELECT 股票代號 
		FROM [StockDB].[dbo].[上市櫃基本資料表] 
		WHERE 年度 LIKE '2018' AND 掛牌交易中 = 1
		)
	AND 日期 LIKE '2018%'
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
```

## 第四十七題
請找出[日借貸款項擔保品餘額表]中，[券商不限用途借貸前日餘額]不等於[券商不限用途借貸餘額]的資料
```SQL
SELECT 日借貸前.日期,日借貸今.股票代號, 日借貸前.券商不限用途借貸餘額, 日借貸今.日期, 日借貸今.股票代號, 日借貸今.券商不限用途借貸前日餘額
FROM 
(SELECT ROW_NUMBER() OVER(PARTITION BY 股票代號 ORDER BY 日期 DESC) AS [日期RANK], * FROM [StockDB].[dbo].[日借貸款項擔保品餘額表]) AS 日借貸今 
JOIN 
(SELECT ROW_NUMBER() OVER(PARTITION BY 股票代號 ORDER BY 日期 DESC) AS [日期RANK], * FROM [StockDB].[dbo].[日借貸款項擔保品餘額表]) AS 日借貸前 
ON 日借貸今.股票代號 = 日借貸前.股票代號 AND 日借貸今.日期RANK = 日借貸前.日期RANK-1
WHERE 日借貸今.券商不限用途借貸前日餘額 != 日借貸前.券商不限用途借貸餘額
```

## 第四十八題
找出20161212所有[日收盤_新人訓練_2016]的收盤價不等於[日收盤]的收盤價的資料
```SQL
SELECT 新訓.股票代號 , 新訓.收盤價 AS 新訓收盤, 日收盤.股票代號, 日收盤.收盤價 AS 日收盤 FROM 
(SELECT * FROM [StockDB].[dbo].[日收盤_新人訓練_2016] WHERE 日期 LIKE N'20161212' ) AS 新訓
JOIN 
(SELECT * FROM [StockDB].[dbo].[日收盤] WHERE 日期 LIKE N'20161212' ) AS 日收盤
ON 日收盤.股票代號 = 新訓.股票代號
WHERE 日收盤.收盤價 != 新訓.收盤價

/* SOLUTION2 */
SELECT 新訓.股票代號 , 新訓.收盤價 AS 新訓收盤, 日收盤.股票代號, 日收盤.收盤價 AS 日收盤 FROM 
[StockDB].[dbo].[日收盤_新人訓練_2016] AS 新訓
JOIN 
[StockDB].[dbo].[日收盤] AS 日收盤
ON 日收盤.日期 LIKE N'20161212' AND 新訓.日期 LIKE N'20161212' AND 日收盤.股票代號 = 新訓.股票代號
WHERE 日收盤.收盤價 != 新訓.收盤價
```

## 第四十九題
```SQL
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
```

## 第五十題
預存程序是什麼？

預存程式是一種將敘述或程式碼預先寫好並編譯後，存放來待用的方式。其主要優點在於，能夠把繁瑣的步驟化為單一的指令，供使用者重複使用。由於已經編譯過，因此每次執行也不必重新建立執行計畫，可以提升效率。最後預存程序還能提供類似封裝的效果，讓使用者透過預存程序來存取資料表，就不容易透過指令更改到表中的內容。

預存程序分為3種：
* 系統預存程序：sp_ 為開頭，為SQL系統內建的預存程序，通常是用來進行設定、取得資訊或進行管理工作等。
* 延伸預存程序：xp_為開頭，通常由外部的程式語言(如C++)撰寫而成，內容以DLL單獨存放在SQL Server外。
* 使用者自訂預存程序：名稱自訂，建立後會以物件形式存放於 *可程式性/預存程序* 項目中。

## 第五十一題
建立一個預存程序，回傳整數2
```SQL
CREATE PROC TWORETURN AS
RETURN 2
```

## 第五十二題
修改、刪除預存程序的語法？
```SQL
/* 修改 */
ALTER PROC TWORETURN
AS 
	RETURN '2'

/* 刪除 */
DROP PROC TWORETURN
```

## 第五十三題
預存程序可以如何回傳值？
```SQL
/* 透過RETURN 回傳值 */
CREATE PROC TWORETURN 
AS
	RETURN 2

GO

DECLARE @two INT
EXEC @two = TWORETURN 

/* 透過OUTPUT參數 回傳值 */
CREATE PROC TWORETURN @TWO INT OUTPUT
AS
	SELECT @TWO = 2

GO

DECLARE @two INT
EXEC TWORETURN @two OUTPUT

```

## 第五十四題
自訂函數是什麼？

自訂函數是一種由使用者預先使用SQL敘述建立一連串指令，以供日後重複使用的方式。
與預存程序非常類似。

## 第五十五題
建立一個自訂函數，回傳日收盤20181214的資料。
```SQL
CREATE FUNCTION Get日收盤By日期
(@日期 nvarchar(8))
RETURNS TABLE

RETURN (SELECT * FROM [StockDB].[dbo].[日收盤] WHERE 日期 LIKE @日期 )

GO

SELECT * FROM Get日收盤By日期(N'20181214')
```

## 第五十六題
建立一個自訂函數，回傳日收盤最大日期(回傳NVARCHAR(8))
```SQL
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
```

## 第五十七題
修改、刪除自訂函數的語法？
```SQL
/* 修改 */
ALTER FUNCTION ....
()
RETURNS nvarchar(8)
BEGIN
DECLARE @最大日期 nvarchar(8)
 SELECT @最大日期 = MAX(日期) FROM [StockDB].[dbo].[日收盤]

RETURN @最大日期
END

/* 刪除 */
DROP FUNCTION ...
```

## 第五十八題
自訂函數與預存程序的差別

* 預存程序只能回傳氶數值；而自訂函數則能夠回傳各種類型的值（除了text, ntext, image...）
* 預存程序能使用OUTPUT來傳遞資料；自訂函數則沒有這種方式。
* 預存程序中可以修改資料庫的設定及資料表的資料(增減)；而自訂函數不允許修改資料庫的狀態或內容
* 預存程序必須以 EXEC 關鍵字來執行，因此無法用於計算式中；而自訂函數除了可以用EXEC執行外，還可以直接呼叫作為回傳值使用。
* 預存程序中可以使用TYR...CATCH；自訂函數則否。

根據上面的特性，預存程序比較適合做一些對資料庫的操作及設定，不需傳回結果；自訂函數則比較適合用於計算及擷取資料，並回傳，以利後面的運算式或子句繼續使用。

## 第五十九題
觸發程序是什麼？

觸發程序是一種針對單一資料表設定的特殊預存程序，當資料發生異動的時候會自動被觸發並執行，並根據觸發的類型分成兩種。
* DDL類型：當資料庫結構發生變化時會觸發。
* DML類型：當資料表發生變化(新增、修改、刪除等等)會觸發。

DML類型還細分成兩種
* AFTER觸發程序：當資料變動完成後，才會啟動並進行檢查或處理，若有錯誤則會使用ROLLBACK敘述回復改動。無法建立在檢視表上。
* INSTEAD OF觸發程序：此類程序會取代原有的敘述，在資料變動前執行。可以建立在檢視表上。

題目主要是討論DML類型的觸發程序。

## 第六十題
建立一個觸發程序，當有[日收盤]資料異動時修改MTIME = 0
```SQL
USE StockDB
GO
CREATE TRIGGER 日收盤異動
ON [日收盤]
AFTER INSERT, UPDATE, DELETE
AS
SELECT MTIME = 0
GO
```

## 第六十一題
修改、刪除、停用、啟用觸發程序的語法
```SQL
ENABLE TRIGGER 日收盤異動 ON [日收盤]
GO
DISABLE TRIGGER 日收盤異動 ON [日收盤]
GO
DROP TRIGGER 日收盤異動
GO
```

## 第六十二題
CTE是什麼？

一般資料表運算式 Common Table Expressions，是一個暫存的具名結果集，是從一個簡單查詢(SELECT)衍生而來。
通常用來簡化子查詢，就像是一個暫存表，但效能更佳(不會進入IO)。只存在於一個批次內。

## 第六十三題
建立一個CTE，回傳日收盤20181214的資料
```SQL
WITH 
TESTCTE AS
(
	SELECT * FROM [StockDB].[dbo].[日收盤]
	WHERE 日期 LIKE N'20181214'
)
SELECT * FROM TESTCTE
```

## 第六十四題
Temp Table 是什麼？

Temporary table分成三種
* 1 區域暫存表： 儲存在tempdb中，只有建立它的使用者能夠存取。
* 2 全域暫存表： 儲存在tempdb中，所有在資料庫中的使用者皆能存取。
* 3 資料表變數： 儲存於memory中，只有建立它的使用者能夠存取。無法解析並最佳化。

## 第六十五題
建立一個Temp Table，裡面有日收盤20181214的資料

```SQL
USE StockDB;
/* 區域暫存表 */
SELECT * INTO [#tempTable] FROM [日收盤] WHERE [日期] LIKE N'20181214';

/* 全域暫存表 */
SELECT * INTO [##tempTable] FROM [日收盤] WHERE [日期] LIKE N'20181214';

/* 資料表變數 */
SELECT * INTO [@tempTable] FROM [日收盤] WHERE [日期] LIKE N'20181214';
```

## 第六十六題
Temp Table的生命週期？
* 1 區域暫存表： 當建立它的使用者離線後，會自動DROP，但仍建議使用者自己DROP。
* 2 全域暫存表： 建立它的使用者離線後，其他使用者便無法繼續使用，待還在使用的使用者使用結束後會自動DROP。
* 3 資料表變數： 為一變數，當該次SQL指令結束後一段時間即會自動DROP。

## 第六十七題
執行計畫的用途？如何看執行計畫？

執行計畫的用途？

提供使用者觀察，該查詢陳述句的執行順序、耗費了多少系統資源及時間來取得結果。

如何查看？

在SQL Server的 GUI中點選 *顯示估計執行計畫* 即可觀察執行計畫。 

或使用指令在語句前加上 SET STATISTICS PROFILE ON

## 第六十八題
活動監視的用途？如何看活動監視？

活動監視的用途？

用來監視CPU、資料庫IO等...資源的即時運用。

如何查看？

在SQL Server的 GUI中點選 *活動監視器* 即可觀察執行計畫。

## 第六十九題
當語法執行過久時可能的原因是？如何解決？

可能的原因：

資料庫的效能瓶頸大多卡在IO這關上，當數據量大，並且沒有索引的幫助使的資料破碎，就會造成執行過久的情況。

解決方式：

遇到這樣的狀況，要先開啟執行計畫觀察語句在執行時，是在哪邊有較高的成本。接著再針對該語句進行優化或是建立索引幫助查詢。

## 第七十題
請問下列語法的執行順序為何？

```SQL
SELECT DISTINCT
MIN(日期)
,股票代號
,MAX(收盤價)
FROM 日收盤 AS a
INNER JOIN 代號表指數 AS i
ON a.股票代號 = i.代號
WHERE a.日期 BETWEEN '20170720' AND '20170727'
GROUP BY a.股票代號
HAVING MAX(收盤價) > 100
ORDER BY a.股票代號 DESC
```

SQL執行順序如下：
* from 
* on 
* join 
* where 
* group by
* avg,sum.... 
* having 
* select 
* distinct 
* order by
* limit 
  
過程中，每執行一步都會生成一張虛擬表，並作為下個步驟的輸入。

```SQL
(8)SELECT (9)DISTINCT
(6)MIN(日期)
,股票代號
,(6)MAX(收盤價)
(1)FROM 日收盤 AS a
(3)INNER JOIN 代號表指數 AS i
(2)ON a.股票代號 = i.代號
(4)WHERE a.日期 BETWEEN '20170720' AND '20170727'
(5)GROUP BY a.股票代號
(7)HAVING (6)MAX(收盤價) > 100
(10)ORDER BY a.股票代號 DESC
```