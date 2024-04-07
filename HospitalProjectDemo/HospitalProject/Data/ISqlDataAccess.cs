using System.Data;

namespace HospitalProject.Data
{
    public interface ISqlDataAccess
    {
        IDbConnection GetConnection();
    }
}
