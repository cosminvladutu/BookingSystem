using System;

namespace Booking.Models
{
    public class Identity
    {
        public Guid Id { get; private set; }

        internal static Identity Create(Guid id)
        {
            Validate();
            return new Identity(id);
        }

        private static void Validate()
        {
            throw new NotImplementedException();
        }

        private Identity(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException("Identifier is empty");
            }
        }
    }
}