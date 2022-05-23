namespace Sozluk.Common.Models.Page;

public class BasePagedQuery
{
    #region Constructor
    public BasePagedQuery(int page, int pageSize)
    {
        Page = page;
        PageSize = pageSize;
    }
    #endregion

    public int Page { get; set; }
    public int PageSize { get; set; }
}
