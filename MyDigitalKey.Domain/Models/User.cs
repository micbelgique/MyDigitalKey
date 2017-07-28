using System;
using MyDigitalKey.Domain.Interfaces;

namespace MyDigitalKey.Domain.Models
{
    public class User : IAggregateRoot
    {
        private User(string lastName, string firstName)
        {
            Id = Guid.NewGuid();
            LastName = lastName;
            FirstName = firstName;
        }

        public Guid Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public DigitalKey Key { get; private set; }

        public static User Create(string lastName, string firstName)
        {
            if (string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentNullException(nameof(lastName));
            if (string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentNullException(nameof(firstName));

            return new User(lastName, firstName);
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