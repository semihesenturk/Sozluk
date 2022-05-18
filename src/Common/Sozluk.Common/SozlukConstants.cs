namespace Sozluk.Common;
public class SozlukConstants
{
    public const string RabbitMQHost = "localhost";
    public const string DefaultExchangeType = "direct";


    public const string UserEmailExchangeName = "UserExchange";
    public const string UserEmailChangedQueueName = "UserEmailChangedQueue";

    public const string FavExchangeName = "FavExchange";
    public const string CreateEntryCommentFavQueueName = "CreateEntryCommentQueue";
}
