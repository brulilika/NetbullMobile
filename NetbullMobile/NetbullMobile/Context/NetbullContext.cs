using NetbullMobile.Dependencie;
using NetbullMobile.Model;
using SQLite;
using Xamarin.Forms;

namespace NetbullMobile.Context
{
    public class NetbullContext
    {
        private static SQLiteConnection _sqLiteConnection;
        public static NetbullContext _lazy;

        public static NetbullContext Current
        {
            get
            {
                if (_lazy == null)
                    _lazy = new NetbullContext();
                return _lazy;
            }
        }
        private NetbullContext()
        {
            _sqLiteConnection = new SQLiteConnection(DependencyService.Get<IDbPath>().GetDbPath());

            //Instanciação das Tabelas

            _sqLiteConnection.CreateTable<Pessoa>();
            _sqLiteConnection.CreateTable<Endereco>();
            _sqLiteConnection.CreateTable<Telefone>();
        }

        public SQLiteConnection Conexao
        {
            get { return _sqLiteConnection; }
            set { _sqLiteConnection = value; }
        }
    }
}
