namespace Booking.Persistence
{
    public interface IConnectionStringProvider
    {
        /// <summary>
        /// Retrieves the connection string by it's name.
        /// </summary>
        /// <param name="name">The name of the connection string.</param>
        /// <returns>The connection string.</returns>
        string GetByName(string name);
    }
}
