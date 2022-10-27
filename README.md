# C# Learning Note

以下紀錄在CMoney工程部新人訓練時期所學到的知識。

[設計模式筆記](https://github.com/yuhuan0205/CSharpLearning/blob/main/Design_Patterns.md)

[SQL筆記](https://github.com/yuhuan0205/CSharpLearning/blob/main/SQL_Note.md)

[Useful Link](https://github.com/yuhuan0205/CSharpLearning/blob/main/Useful_Link.md)

## C# Knowledge
**專案結構：**`方案 -> 專案 -> 組件 -> 命名空間 -> CS檔 -> 類別 -> 類別成員`

**POCK** ： `一個CS檔中，有多個類別，但是每個類別底下的成員只有欄位與屬性(包括getter, setter)，沒有複雜的方法。`

**欄位及屬性**：`屬性可以自訂get, set(通常用public)，欄位則直接吃存取修飾子的範圍來存取(通常用private)`

**C#輸出類型** `WindowsApp(如winform, WPF等等)，主控台應用程式(console)，類別庫(dll)`

**abstract v.s. interface** `共同的方法及成員寫在抽象裡，特別需要實現的方法則寫在interface，讓需要實作的類別去實作。`

**URL傳遞** `在傳遞URL的時候，可能會出現特殊字元，如 + / % ? 等等，這時就得使用特殊的表達方式 + --> %2B  / --> %2F 等等。`

**Json處理** https://learn.microsoft.com/zh-tw/dotnet/standard/serialization/system-text-json/how-to?pivots=dotnet-core-3-1

## Coding Style
* 所有類別成員都在建構子的地方new出來（static, const等等例外）。
* 只使用C#內建型別， int, string, double，而不是System.Int64, String....
* 類別成員命名方式為每個單字開頭都大寫如，`string ClientDataInfo;`。
* 區域變數，方法參數駝式命名，如：`clientPassword`。
* 常數命名方式為全大寫配底線分隔，如： `const int CLIENT_ID;`。
* 方法用動詞開頭，bool用 Is 或 Has 開頭如，如：`bool IsValid`。
* 發佈新版本記得改組件資訊的版本日期。
* 避免使用Magic Number 的方法：
	* 列舉(enum)
	* Const
	* Variable
* 避免複製貼上(思考如何抽取方法)
* 共用項目使用 static class 來讓全部的人都能使用
* 用`string.Empty;`來表示空字串，而不是`"";`。
* 在註解中使用`//TODO： //UNDONE： //HACK：`

## ASP.Net 

使用DI的方式將物件註冊到 Controller 中，因每一次呼叫API都會 new 新的 Controller，所以需要再 startup.cs 中 addSingleton(yourService)，之後再到Controller中注入成員。

## Other Tips
WPF 排版與HTML很接近

WPF  Datagrid 元素 用 binding 的方式連結資料，比用for loop 建立 DataTable後再傳給Datagrid 效能更好。

binding的方式，在Datagrid中設定 itemsource，binding到主程式中的 自訂物件List，須給物件中需要binding的屬性 定義 get;set;

參考自：https://www.twblogs.net/a/5ba180ff2b71771a4da8e45f

C# 中 format字串的方式為   $“{x} + {y} ” 用python 來說就是 f“{x} + {y}”

C# 中的 foreach(int item in items){ … } 用法接近 python

C# 中，計時要 using System.Diagnostics; 用其中的Stopwatch物件。


winform 元件屬性可以在右側選單快速調整

winform button 可以在 Tag 設定 隱藏的 value

時間格式利用 TimeSpan 來做，以下為formating的方式。
string.Format("{0:D2}:{1:D2}:{2:D1}:{3:D2}", t.Hours, t.Minutes, t.Seconds, t.Milliseconds)

textBox新增一行 用 TextBox.appendText( string +  Environment.NewLine ) 

textBox可以設定ReadOnly

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

單例模式：
```C#
public class Singleton
{
 //定義一個靜態變數儲存類的例項
	 private static Singleton singleton;

	 /// <summary>
	 /// 定義私有建構函式
	 /// </summary>
	 private Singleton()
	 {
	 }

	 /// <summary>
	 /// 定義公有方法提供一個全域性訪問點,同時你也可以定義公有屬性來提供全域性訪問點
	 /// </summary>
	 /// <returns></returns>
	 public static Singleton GetSingleton()
	 {
	     // 如果類的例項不存在則建立，否則直接返回
	     if (singleton==null)
	     {
		 singleton = new Singleton();
	     }
	     return singleton;
	 }
}
```
實現stable sort
```C#
public class class1:IComparable<class1>
{
	public int Value {get; set;}
	public int SortIndex {get; set;}
	public class1()
	{
	}
	public CompareTo(class1 other)
	{
		int result;
		result = this.Value.CompareTo(other.Value);
		if(result == 0)
		{
			result = this.SortIndex.CompareTo(other.SortIndex);
		}
		return resultl;
	}
}
```
BackgroundWorker使用方式
先在工具箱中把BackgroundWorker (name : BW1)設定到winform上
接著再設定BW1的事件(DoWork, RunWorkerCompleted)
```C#
 private void BtnClick(object sender, EventArgs e)
        {
	    int x = 0;
            BW1.RunWorkerAsync(x);
        }

private void BW1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
	{
		//get argument, and return output
		return DoSomething(e.Argument);
	}
	
private void BW1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            //when BW1's task done, this function will get result.
	    var result = e.Result;
	    // rendering data here.
	    text1.Text = result
        }
```
多型的使用時機及實現方式
```C#
//AbstractBtn.cs
public abstract partial class AbstractBtn : Button
    {
        public AbstractBtn()
        {
        }

        public abstract void OnClick();
        
        public string ButtonText
        {
            get { return this.Text; }
            set
            {
                this.Text = value;
            }
        }
    }
//NumbersBtn.cs
public class NumbersBtn : AbstractBtn
{
	public override void OnClick()
	{
	    Computer.Builder.Append(ButtonText);
	    Computer.Show = Computer.Builder.ToString();
	}
}
//PlausBtn
public class PlausBtn : AbstractBtn
{
	public override void OnClick()
        {
            Computer.Buffer = Computer.Buffer + Convert.ToDecimal(Computer.Show);
            Computer.Operator = "+";
            Computer.Builder.Clear();
        }
}

//main.cs
//.....
private void Button_Click(object sender, EventArgs e)
        {
            ((AbstractBtn)sender).OnClick();
            
            ResultShow.Text = $"{Computer.Buffer}{Computer.Operator}{Environment.NewLine}{Computer.Show}";
        }
//.....
```
virtual v.s. abstract
* 虛擬(virtual)方法可以實作並且允許繼承的子類別複寫。
* abstract 方法則是一定要在子類實作。
decimal.ToString("G29") 可以 format，去除小數後面的0。

