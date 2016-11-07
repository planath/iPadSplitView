using System;

namespace iPadSplitView.Core.Model
{
    public class Person
    {
        private int _id;
        private string _firstName;
        private string _lastName;
        private string _email;
        private Color _color;

        public Person()
        {
        }

        public Person(int id, string firstName, string lastName, string email, Color color)
        {
            if (id == null) throw new ArgumentNullException(nameof(id));
            if (firstName == null) throw new ArgumentNullException(nameof(firstName));
            if (lastName == null) throw new ArgumentNullException(nameof(lastName));
            if (email == null) throw new ArgumentNullException(nameof(email));

            _firstName = firstName;
            _lastName = lastName;
            _email = email;
            _color = color;
            _id = id;
        }
            
        public Person(string firstName, string lastName, string email)
        {
            if (firstName == null) throw new ArgumentNullException(nameof(firstName));
            if (lastName == null) throw new ArgumentNullException(nameof(lastName));
            if (email == null) throw new ArgumentNullException(nameof(email));

            _firstName = firstName;
            _lastName = lastName;
            _email = email;
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        public Color Color
        {
            get { return _color; }
            set { _color = value; }
        }

        public Person Clone()
        {
            return (Person) this.MemberwiseClone();
        }

        protected bool Equals(Person other)
        {
            return _id == other._id && string.Equals(_firstName, other._firstName) &&
                    string.Equals(_lastName, other._lastName) && string.Equals(_email, other._email);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Person) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = _id.GetHashCode();
                hashCode = (hashCode*397) ^ (_firstName != null ? _firstName.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_lastName != null ? _lastName.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_email != null ? _email.GetHashCode() : 0);
                return hashCode;
            }
        }

        public bool IsEmpty
        {
            get
            {
                return string.IsNullOrEmpty(FirstName) ||
                        string.IsNullOrEmpty(LastName) ||
                        string.IsNullOrEmpty(Email);
            }
        }
    }
}
