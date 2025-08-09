namespace SignalRChat_Server.Dtos
{
    public sealed record SendMessageDto
    (
        Guid UserId,
        Guid ToUserId,
        string Message
    );
}
