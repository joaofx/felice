namespace Felice.Core.Model
{
    public abstract class Entity
    {
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
            return this.IsNew == false ? this.Id.GetHashCode() : base.GetHashCode();
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