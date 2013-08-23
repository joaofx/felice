namespace Felice.Core.Types
{
    using System;

    public struct Month
    {
        private readonly string value;
        public static Month Default = new Month("00/0000");

        public Month(string value) : this()
        {
            //// TODO: fazer parse de data 01/+value
            //// TODO: value guardar yyyy/MM
            this.value = value;
        }

        public Month(DateTime value) : this(value.ToString("yyyy/MM"))
        {
        }

        public static bool operator ==(Month lhs, Month rhs)
        {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(Month lhs, Month rhs)
        {
            return (lhs == rhs) == false;
        }

        public static Month Current
        {
            get
            {
                return new Month(DateTime.Today);
            }
        }

        public new string ToString()
        {
            return this.value;
        }

        public bool Equals(Month other)
        {
            return Equals(other.value, this.value);
        }

        public override int GetHashCode()
        {
            return (this.value != null ? this.value.GetHashCode() : 0);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (obj.GetType() != typeof (Month))
            {
                return false;
            }

            return this.Equals((Month) obj);
        }
    }
}