using MediatR;

namespace Sozluk.Common.Models.Queries;

public class SearchEntryQuery : IRequest<List<SearchEntryViewModel>>
{
    #region Constructor
    public SearchEntryQuery()
    {

    }
    public SearchEntryQuery(string searchText)
    {
        SearchText = searchText;
    }
    #endregion

    public string SearchText { get; set; }
}
