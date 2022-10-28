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
* (補充) smallint 整數，範圍從 `(-2^15) ~ (2^15 -1)` `2bytes(2^16)` 前 1個 bit 存 sign，後15個 bits 存數字。
* int 整數，範圍從 `(-2^31) ~ (2^31 -1)` `4 bytes(2^32)` 前 1個 bit 存 sign，後31個 bits 存數字。
* bigint 整數，範圍從 `(-2^63) ~ (2^63 -1)` `8 bytes(2^64)` 前 1個 bit 存 sign，後63個 bits 存數字。
* real
* float
* decimal
* numeric
#### 字串
* char
* nchar
* varchar
* nvarchar
* text
#### 日期
* datetime



















