namespace Felice.Core.Data
{
    using System;
    using System.Data;
    using NHibernate.Dialect;
    using NHibernate.SqlTypes;
    using NHibernate.Type;
    using Types;

    public class MonthType : PrimitiveType
    {
        public MonthType() : base(new AnsiStringFixedLengthSqlType(7))
        {
        }

        public override string Name
        {
            get { return "MonthType"; }
        }

        public override Type ReturnedClass
        {
            get { return typeof(Month); }
        }

        public override void Set(IDbCommand cmd, object value, int index)
        {
            var parameter = (IDataParameter)cmd.Parameters[index];
            var val = (Month) value;
            parameter.Value = val.ToString();
        }

        public override object Get(IDataReader rs, int index)
        {
            var column = (string) rs[index];
            var value = new Month(column);
            return value;
        }

        public override object Get(IDataReader rs, string name)
        {
            var ordinal = rs.GetOrdinal(name);
            return this.Get(rs, ordinal);
        }

        public override object FromStringValue(string xml)
        {
            return xml;
        }

        public override string ObjectToSQLString(object value, Dialect dialect)
        {
            return value.ToString();
        }

        public override Type PrimitiveClass
        {
            get { return typeof(string); }
        }

        public override object DefaultValue
        {
            get { return Month.Default; }
        }
    }
}
