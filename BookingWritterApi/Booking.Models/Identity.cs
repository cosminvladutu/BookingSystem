using System;

namespace Booking.Models
{
    public class Identity
    {
        public Guid Id { get; private set; }

        internal static Identity Create(Guid id)
        {
            Validate(id);
            return new Identity(id);
        }

        private static void Validate(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException("Identifier is empty");
            }
        }

        private Identity(Guid id)
        {
            Id = id;
        }
    }
}