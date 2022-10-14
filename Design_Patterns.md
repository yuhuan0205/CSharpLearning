# [Home Page](https://github.com/yuhuan0205/CSharpLearning)
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
