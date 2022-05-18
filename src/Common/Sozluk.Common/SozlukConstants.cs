namespace Sozluk.Common;
public class SozlukConstants
{
    public const string RabbitMQHost = "localhost";
    public const string DefaultExchangeType = "direct";

    public const string UserEmailExchangeName = "UserExchange";
    public const string UserEmailChangedQueueName = "UserEmailChangedQueue";

    public const string FavExchangeName = "FavExchange";
    public const string CreateEntryCommentFavQueueName = "CreateEntryCommentQueue";
    public const string DeleteEntryCommentFavQueueName = "DeleteEntryCommentFavQueue";

    public const string VoteExchangeName = "VoteExchange";
    public const string CreateEntryVoteQueueName = "CreateEntryVoteQueue";
    public const string DeleteEntryVoteQueueName = "DeleteEntryCoteQueue";
    public const string CreateEntryFavQueueName = "CreateEntryFavQueue";
    public const string DeleteEntryFavQueeueName = "DeleteEntryFavQueeue";
    public const string CreateEntryCommentVoteQueueName = "CreateEntryCommentVoteQueue";
    public const string DeleteEntryCommentVoteQueueName = "DeleteEntryCommentVoteQueue";
}
