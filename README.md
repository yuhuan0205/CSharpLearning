# C# Learning Note

## C# Knowledge
**專案結構：**`方案 -> 專案 -> 組件 -> 命名空間 -> CS檔 -> 類別 -> 類別成員`

**POCK** ： `一個CS檔中，有多個類別，但是每個類別底下的成員只有欄位與屬性(包括getter, setter)，沒有複雜的方法。`

**欄位及屬性**：`屬性可以自訂get, set(通常用public)，欄位則直接吃存取修飾子的範圍來存取(通常用private)`

**C#輸出類型** `WindowsApp(如winform, WPF等等)，主控台應用程式(console)，類別庫(dll)`

## Coding Style
* 所有類別成員都在建構子的地方new出來（static, const等等例外）。
* 只使用C#內建型別， int, string, double，而不是System.Int64, String....
* 類別成員命名方式為每個單字開頭都大寫如，string ClientDataInfo。
* 常數命名方式為全大寫，如： `const int CONST;`
* 發佈新版本記得改組件資訊的版本日期。
* 避免使用Magic Number 的方法：
	* 列舉(enum)
	* Const
	* Variable
* 避免複製貼上(思考如何抽取方法)
* 共用項目使用 static class 來讓全部的人都能使用

## Other Tips
WPF 排版與HTML很接近

WPF  Datagrid 元素 用 binding 的方式連結資料，比用for loop 建立 DataTable後再傳給Datagrid 效能更好。

binding的方式，在Datagrid中設定 itemsource，binding到主程式中的 自訂物件List，須給物件中需要binding的屬性 定義 get;set;

參考自：https://www.twblogs.net/a/5ba180ff2b71771a4da8e45f

C# 中 format字串的方式為   $“{x} + {y} ” 用python 來說就是 f“{x} + {y}”

C# 中的 foreach(int item in items){ … } 用法接近 python

C# 中，計時要 using System.Diagnostics; 用其中的Stopwatch物件。


winform 元件屬性可以在右側選單快速調整

時間格式利用 TimeSpan 來做，以下為formating的方式。
string.Format("{0:D2}:{1:D2}:{2:D1}:{3:D2}", t.Hours, t.Minutes, t.Seconds, t.Milliseconds)

textBox新增一行 用 TextBox.appendText( string +  Environment.NewLine ) 

C# async 邏輯 (非常重要！)
```C#
public async void fun(){
	T result = await DoSomeThings(); 
}
public Task<T> DoSomeThings(){
	return Task.Run(() =>
            {
	      T t = someThingsDoReallyLongTime();	
                  return t;
            });

}
```
Hashtable vs Dictionary
https://dotblogs.com.tw/sunnylearning/2018/05/17/144428

datatable可以使用select
datatable.DefaultView.Sort = “Column_1 ASC”

enum用法
```C#
private enum IndexOfField:int
{
    DealDate = 0,
    StockId = 1,
    StockName = 2,
    SecBrokerId = 3,
    SecBrokerName = 4,
    Price = 5,
    BuyQty = 6,
    CellQty = 7
}
int x  = (int)IndexOfField.StockId;
// x == 1;
```
