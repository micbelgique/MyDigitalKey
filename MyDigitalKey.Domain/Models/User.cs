using System;
using MyDigitalKey.Domain.Interfaces;

namespace MyDigitalKey.Domain.Models
{
    public class User : IAggregateRoot
    {
        private User(Guid id, string lastName, string firstName)
        {
            Id = id;
            LastName = lastName;
            FirstName = firstName;
        }

        public string FirstName { get; }
        public string LastName { get; }
        public DigitalKey Key { get; private set; }

        public Guid Id { get; }

        public static User Create(Guid id, string lastName, string firstName)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException(nameof(id));
            }
            if (string.IsNullOrWhiteSpace(lastName))
            {
                throw new ArgumentNullException(nameof(lastName));
            }
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new ArgumentNullException(nameof(firstName));
            }

            return new User(id, lastName, firstName);
        }

        public void SetKey(DigitalKey key)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }
            if (key.Id == Guid.Empty)
            {
                throw new ArgumentException();
            }

            Key = key;
        }
    }
}