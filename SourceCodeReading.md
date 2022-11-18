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
```

## 架構
* MemberService
* SpaceService
* ArticleService
* 待補充

## MemberService
summary：
* Ban Service (封鎖使用者)
* Relationship Service(追蹤跟封鎖關係查詢)
* Serach Service (搜尋使用者)
* Community Service (管理社團成員) 

## Space Service
summary：
* Space Service (管理Space，類似 Discord 的 Server)
* Board Service (管理Board，類似 Discord Server 裡的 Channel)
* Member Service (管理單一會員的權限)
* Customized Auth Service (新增權限、身分組)
