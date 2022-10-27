# SQL 練習題目及答案

primary 只能有一個，可以由多個key組成，必須為唯一不可重複的key。

foreign key 則是其他 table 的 primary key。

資料完整性：
* 實體完整性：Database會拒絕加入重複的primary key來保證實體完整性。
* 區域完整性：Database會拒絕加入資料類型超出預設範圍的資料，來確保區域完整性。
* 參考完整性：若 TableA 的 foreign key 指向的 TableB 的 primary key 將被刪除，Database會拒絕操作以確保參考完整性。

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
