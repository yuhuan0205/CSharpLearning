# C# Learning Note

## Coding Style


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
