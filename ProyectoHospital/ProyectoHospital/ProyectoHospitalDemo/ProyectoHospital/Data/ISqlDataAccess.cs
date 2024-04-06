
using System.Data;

namespace Hospital.Data
{
    public interface ISqlDataAccess
    {
        IDbConnection GetConnection();
    }
}
