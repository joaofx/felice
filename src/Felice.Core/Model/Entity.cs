namespace Felice.Core.Model
{
    public abstract class Entity
    { 
        /// <summary>
        ///     To help ensure hashcode uniqueness, a carefully selected random number multiplier 
        ///     is used within the calculation.  Goodrich and Tamassia's Data Structures and
        ///     Algorithms in Java asserts that 31, 33, 37, 39 and 41 will produce the fewest number
        ///     of collissions.  See http://computinglife.wordpress.com/2008/11/20/why-do-hash-functions-use-prime-numbers/
        ///     for more information.
        /// </summary>
        private const int HashMultiplier = 31;

        private int? cachedHashCode;

        public virtual long Id
        {
            get; 
            set;
        }

        public static bool operator ==(Entity x, Entity y)
        {
            return object.Equals(x, y);
        }

        public static bool operator !=(Entity x, Entity y)
        {
            return (x == y) == false;
        }

        public virtual bool IsNew
        {
            get { return this.Id.Equals(default(long)); }
        }

        public override bool Equals(object obj)
        {
            if (this.IsNew == false)
            {
                var entity = obj as Entity;
                return (entity != null) && (this.IdsAreEqual(entity));
            }

            return ReferenceEquals(this, obj);
        }

        protected bool IdsAreEqual(Entity entity)
        {
            return Equals(this.Id, entity.Id);
        }

        public override int GetHashCode()
        {
            if (this.cachedHashCode.HasValue)
            {
                return this.cachedHashCode.Value;
            }

            if (this.IsNew)
            {
                this.cachedHashCode = base.GetHashCode();
            }
            else
            {
                unchecked
                {
                    // It's possible for two objects to return the same hash code based on 
                    // identically valued properties, even if they're of two different types, 
                    // so we include the object's type in the hash calculation
                    var hashCode = this.GetType().GetHashCode();
                    this.cachedHashCode = (hashCode * HashMultiplier) ^ this.Id.GetHashCode();
                }
            }

            return this.cachedHashCode.Value;
        }

        public override string ToString()
        {
            if (this.IsNew)
            {
                return string.Format("{0}@{1}",
                    base.ToString(),
                    this.GetHashCode());
            }

            return string.Format("{0}#{1}",
                base.ToString(),
                this.Id);
        }
    }
}