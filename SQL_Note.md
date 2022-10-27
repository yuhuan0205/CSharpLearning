# SQL 練習題目及答案

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
