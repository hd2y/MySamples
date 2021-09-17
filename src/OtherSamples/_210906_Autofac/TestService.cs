namespace _210906_Autofac
{
    public class TestService
    {
        public IFreeSql Db { get; set; }
        public IFreeSql<Db1> Db1 { get; set; }
        public IFreeSql<Db2> Db2 { get; set; }
    }
}