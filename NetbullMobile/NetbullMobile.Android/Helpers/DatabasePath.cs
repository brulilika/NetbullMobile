using NetbullMobile.Dependencie;
using System.IO;

namespace NetbullMobile.Droid.Helpers
{
    public class DatabasePath : IDbPath
    {
        public string GetDbPath()
        {
            return Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "netbull.db3");
        }
    }
}