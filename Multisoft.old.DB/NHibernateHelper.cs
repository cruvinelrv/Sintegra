using NHibernate;
using NHibernate.Cfg;

namespace Thiago
{
    public class NHibernateHelper
    {
        private static ISessionFactory _sf;

        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sf == null)
                    _sf =
                        new Configuration()
                        .Configure(@"hibernate/hibernate.cfg.xml")
                        .BuildSessionFactory();
                return _sf;
            }
        }

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
            //ISession ss;
            //ss.FlushMode = FlushMode.Never;//for Read-Only Apps
        }
    }
}
