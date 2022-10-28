# SQL 練習題目及答案

primary 只能有一個，可以由多個key組成，必須為唯一不可重複的key。

foreign key 則是其他 table 的 primary key。

資料完整性：
* 實體完整性：Database會拒絕加入重複的primary key來保證實體完整性。
* 區域完整性：Database會拒絕加入資料類型超出預設範圍的資料，來確保區域完整性。
* 參考完整性：若 TableA 的 foreign key 指向的 TableB 的 primary key 將被刪除，Database會拒絕操作以確保參考完整性。

語法：
```SQL
USE database_name // ;
```
### 第一題
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
SELECT
```
### 第二題
以下常用的欄位型態分別是存什麼樣的資料？他的儲存大小為何？
#### 數值
* tinyint  整數，範圍從 `0 ~ 255(2^8 -1)` `1 byte(2^8)`
* (補充) smallint 整數，範圍從 `(-2^15) ~ (2^15 -1)` `2 bytes(2^16)` 前 1個 bit 存 sign，後15個 bits 存數字。
* int 整數，範圍從 `(-2^31) ~ (2^31 -1)` `4 bytes(2^32)` 前 1個 bit 存 sign，後31個 bits 存數字。
* bigint 整數，範圍從 `(-2^63) ~ (2^63 -1)` `8 bytes(2^64)` 前 1個 bit 存 sign，後63個 bits 存數字。
* float 浮點數(近似值) `(-1.79*10^308) ~ (1.79*10^308) 最多表示15位數` `8 btyes`
* real 浮點數(近似值) `(-3.40*10^38) ~ (3.40*10^38) 最多表示7位數` `4 btyes`
* numeric 精確位數，使用時須指定 (精確度, 小數點後位數)，資料範圍`-10^38 ~ 10^38 - 1`，儲存大小則視精確位數決定：
```
精確度，可指定範圍 1~38，小數位數則是最小為 0，最大不能超過指定的精確度。
1-9 : 5bytes
10-19 : 9bytes
20-28 : 13bytes
29-38 : 17bytes
```
* decimal 基本上與numeric無異，除了 `decimal會保留超出精確度的數值，numeric則完全依照指定的規範儲存。 `
#### 字串
* char(n) 資料範圍 `1-8000個字元`，每個字元 1 byte，為固定長度，未填滿的部分會填上空白字元。
* varchar(n) 資料範圍 `1-8000個字元`，每個字元 1 byte，為變動長度，儲存多少字元就佔多少空間。
* varchar(max) 資料範圍 `1 ~ (2^31 -1)` 個字元，為變動長度，儲存多少字元就佔多少空間，最多2GB
* text 資料範圍 `1 ~ (2^31 - 1)` 個字元，為變動長度，儲存多少字元就佔多少空間，最多2GB

`補充，text與varchar(max)的差異：當資料未超過8000個字元(8K byte)，varchar(max)會將資料存進row中，text則是都存進blob，row存放指向blob的索引。`
#### Unicode字串
`Unicode字串一個字元為2bytes`
* nchar(n) 資料範圍 `1-4000個字元`，每個字元 2 byte，為固定長度，未填滿的部分會填上空白字元。
* nvarchar(n) 資料範圍 `1-4000個字元`，每個字元 2 byte，為變動長度，儲存多少字元就佔多少空間。
* nvarchar(max) 資料範圍 `1 ~ (2^30 -1)` 個字元，為變動長度，儲存多少字元就佔多少空間，最多2GB
* ntext 資料範圍 `1 ~ (2^30 - 1)` 個字元，為變動長度，儲存多少字元就佔多少空間，最多2GB
#### 二元碼字串
`二元碼字串用來儲存2進制資料，可儲存各種文件如 word, excel, bmp, jpg 等`
* binary(n) 資料範圍 `1-8000 bytes`，為固定長度，未填滿的部分會填上 0x00。
* varbinary(n) 資料範圍 `1-8000 bytes`，為變動長度，儲存多少資料就佔多少空間。
* varbinary(max) 資料範圍 `1 ~ (2^31 -1) bytes` 為變動長度，儲存多少資料就佔多少空間，最多2GB
* image 資料範圍 `1 ~ (2^31 - 1) byte` 為變動長度，儲存多少資料就佔多少空間，最多2GB
`補充，SQL server 2008後可以將varbinary(max)存入檔案系統中`
#### 日期
* datetime



















