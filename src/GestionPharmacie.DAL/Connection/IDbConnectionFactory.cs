using System.Data;

namespace GestionPharmacie.DAL.Connection;

public interface IDbConnectionFactory
{
    string ConnectionString { get; }
    string DatabasePath { get; }
    IDbConnection CreateConnection();
}
