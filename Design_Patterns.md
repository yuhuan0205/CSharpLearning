# [Home Page](https://github.com/yuhuan0205/CSharpLearning)

# 介面與抽象
繼承一個抽象類別，代表的是「該物件是甚麼」。

而一個介面則是表示「該物件能做什麼」。

```C#
public interface IProgrammer
{
    void WriteCSharp();
    void WriteSQL();
    void WriteVB();
}

public class Hua : IProgrammer
{
    // Error: Hua 未實作 IProgrammer.WriteCSharp()

    public void WriteSQL() { /* Work */ }
    public void WriteVB() { /* Work */ }
}

public class Ming : IProgrammer
{
    public void WriteCSharp() { /* Work */ }
    public void WriteSQL() { /* Work */ }
    public void WriteVB() { /* Work */ }
    public Tea MakeTea() { return new Tea(teaName: "MilkTea"); }
}

public void Work()
{
    IProgrammer programmer = new Ming();
    programmer.WriteCSharp();
    programmer.WriteCSharp();
    programmer.WriteCSharp();
    programmer.MakeTea(); // Error: IProgrammer 未包含 MakeTea 的定義
}
```

# SOLID
## SRP 單一職責原則
若發生多於一個原因使我們想要去改變一個類別，那麼該類別就有多於一個以上的職責。

## OCP 開放封閉原則
對擴充開放，對修改封閉。

不變更模組原始程式碼的情況下，改變其行為：`使用抽象類別`

## LSP 里氏替換原則
若子類無法替換父類，則違反LSP。

抽取共同的部分作為抽象類，讓A、B類別繼承它們的共同類。

Line, LineSegment and Ray 共同繼承自 LineObject.

## ISP 介面隔離原則
不應該強迫客戶程式依賴他們未使用的方法。

## DIP 依賴反向原則
抽象化底層的模組 => 使其成為一個interface，讓高層的模組可以使用。任何在底層模組的更動，只要符合interface，就不會改動到高層模組。

Lamp物件實作interface IButtonService, 物件 Button 的成員是一個抽象的 IButtonService 介面，任何實作 IButtonService 的物件都能成為 Button的成員

```C#
public interface IButtonService
{
  public void TurnOn();
  public void TurnOff();
} 

public class Lamp: IButtonService
{
  public TurnOn()
  {
    //light up
  }
  ...
}

public class Button
{
  public IButtonService IB;
  public Button(IButtonService i)
  {
    IB = i;
  }
}
```
## Command Pattern
建立一個Command介面，替每個類似的物件實作一個Execute方法。

類似於在LittleComputer中做的按鈕，與不同Operators的Operation方法。

好處：
* 根據不同物件來決定他該採用的方法(多型)。
* 跟時間解藕，可以保存物件與他所執行的方法，不一定要在呼叫後馬上執行。
* 可以輕易的做到Undo功能，只要回復上一個物件的Execute方法就好。

## 變體：Active Object Pattern
適用時機，在單執行序下模擬多執行序。

只需要把所有Executeable 的物件放進佇列中，根據各自的實做展現不同功能。

例如，在佇列中加入Sleep物件，在時間未達設定時間，可以將自己重新放回佇列尾，達到Sleep的功能，卻又不阻斷程式進行。

## Templeate Pattern
把重複的程式碼提出到父類，在用子類去繼承。

## Strategy Pattern
使用一個具體的實例打包重複的程式碼，其功能由傳入的介面實作。已經實作介面的物件透過DI傳給策略物件。

`Templeate vs Strategy`
* Templeate 相對來說比較不占空間、也比較有效率，但不靈活
* Strategy 相對來說容易擴充，適合日後需要抽換介面實作的系統。

## Singleton Pattern
限制使用者只能建立一個實例。透過靜態方法與私有建構子來實現Singleton。

好處：
* 跨平台
* 適用任何類別
* 延遲建立，若未使用則不會建立實例

壞處：
* 未定義解構子
* 不能繼承－－繼承後的子類別沒有Singleton的效果
* 每次建立實例都要判斷，稍嫌沒有效率

可以透過.Net的語法來避免多次使用if
```C#
public class Singleton
{
  private static Instance = new Singleton();
  public static Create { get { return Instance; } }
  private Singleton {}
}
```