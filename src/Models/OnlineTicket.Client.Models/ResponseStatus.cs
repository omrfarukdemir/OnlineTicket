namespace OnlineTicket.Models.Clients.OBilet
{
    public static class ResponseStatus
    {
        public const string Success = nameof(Success);
        public const string InvalidDepartureDate = nameof(InvalidDepartureDate);
        public const string InvalidRoute = nameof(InvalidRoute);
        public const string InvalidLocation = nameof(InvalidLocation);
        public const string Timeout = nameof(Timeout);
    }
}