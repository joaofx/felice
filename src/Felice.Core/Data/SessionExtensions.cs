namespace Felice.Core.Data
{
    using Logs;
    using Model;
    using NHibernate;

    public static class SessionExtensions
    {
        public static void DeleteFrom(this ISession session, string tableName)
        {
            session.CreateSQLQuery("delete from " + tableName).ExecuteUpdate();
        }

        public static void DeleteAll<T>(this ISession session) where T : Entity
        {
            session.DeleteFrom(GetTableName<T>());
        }

        public static void DeleteById<TEntity>(this ISession session, object id)
        {
            var hql = string.Format("delete {0} where id = :id", typeof(TEntity));

            session.CreateQuery(hql)
                .SetParameter("id", id)
                .ExecuteUpdate();
        }

        private static string GetTableName<T>()
        {
            //// TODO: create a class for this
            var classMaping = HibernateConfiguration.BuiltConfiguration.GetClassMapping(typeof(T));

            if (classMaping == null)
            {
                Log.Framework.InfoFormat(
                    "Was not possible get table name of entity {0}. Check if exist a mapping for this entity.",
                    typeof(T).FullName);

                return string.Empty;
            }

            return classMaping.Table.Name;
        }
    }
}
