using Microsoft.Data.Sqlite;
namespace BookcaseApp.Database;


public class Database(string dbPath) {
  // Construyo la cadena de conexión
  private readonly string _stringConnection = $"Data Source={dbPath}";

  // Obtener la conexión abierta
  public SqliteConnection GetConnection() {
    var connection = new SqliteConnection(_stringConnection);
    connection.Open();

    return connection;
  }
}