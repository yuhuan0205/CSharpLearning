# 社群小組微服務功能概覽

## The Knowledge After Review 
```C#
// Name 僅僅只是代表該Route的名字。
// ProducesResponseType 表示回傳的資料類型，經常用於Swagger上
[HttpGet("api/{id}", Name = nameof(GetInfo))]
[ProducesResponseType(typeof(MemberBlock), StatusCodes.Status200OK)]
[ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
public async Task<Memberinfo> GetInfo(int id)
{
    try
    {
        var memberInfo = await Db.GetInfo(memberId, blockMemberId);
        return Ok(memberInfo);
    }
    catch (KeyNotFoundException)
    {
        return NotFound();
    }
}

//Redis 操作
using StackExchange.Redis;
var DataBase = ConnectionMultiplexer.Connect("IP address");

//get data from cache
var hashValues = await Database.HashGetAllAsync( key );

// add data into cache
await Database.HashSetAsync( key, ( (IEnumerable<KeyValuePair<string, JToken>>)jObject ).Select( keyValuePair => new HashEntry( keyValuePair.Key, keyValuePair.Value.ToString() ) ).ToArray() );

// set cache store time.
// if time is over, delete cache. 
await Database.KeyExpireAsync( key, DateTime.Now + TimeSpan.FromDays( 1 ) );

```
## 流程

1. 去Redis取資料 (using StackExchange.Redis)
2. 否則去MongoDB取資料

## 架構
* MemberService
* SpaceService
* ArticleService
* 待補充

## MemberService
APIs：
* Ban Controller (封鎖使用者)
* Relationship Controller(追蹤跟封鎖關係查詢)
* Serach Controller (搜尋使用者)
* Community Controller (管理社團成員) 

## Space Service
APIs：
* Space Controller (管理Space，類似 Discord 的 Server)
* Board Controller (管理Board，類似 Discord Server 裡的 Channel)
* Member Controller (管理單一會員的權限)
* Customized Auth Controller (新增權限、身分組)


# 股市爆料同學會概觀

## APIs
* Article Controller (發文、取文、刪文，跟使用者權限等商業邏輯混在一起。)
* Channel Controller
* Collection Controller
* Columnist Controller
* Comment Controller
* CommentInteractive Controller
* Group Article Controller
* Group Controller
* Group Member Controller
* Interactive Controller
* Light Finance Controller
* Member Controller
* Notify Controller
* Notify Setting Controller
* Offcial Controller
* Offcial Subscrber Controller
* Pronoted Article Controller
* Rank Controller
* Rating Controller
* Relationship Controller
* Report Controller
* Role Controller
* Stock Report Controller
* Support Controller
* Vote Controller
