using BookcaseApp.Database;
using Microsoft.Data.Sqlite;

// Intanciar base de datos y obtener la conexión a la BD
var db = new Database("./bookcase.db");
var connection = db.GetConnection();

//1. Leer los registros de la base de datos (Read)
// var selectQuery = "SELECT * FROM autor";

// using var command = new SqliteCommand(selectQuery, connection);
// using var reader = command.ExecuteReader();

// while (reader.Read()) {
//   var id = reader.GetInt32(0);
//   var nombre = reader.GetString(1);
//   var apellido = reader.GetString(2);
//   var nacionalidad = reader.GetString(3);

//   Console.WriteLine($"{id}. El autor {nombre} {apellido} es de nacionalidad {nacionalidad}");
// }

//2. Insertar un registro en la base de datos (Create)

// var insertQuery = """
//   INSERT INTO autor(nombre, apellido, nacionalidad)
//   VALUES
//     (@nombre, @apellido, @nacionalidad)
//   RETURNING id_autor;
// """;

// var nombreAutor = "Josteing";
// var apellidoAutor = "Gaarder";
// var nacionalidadAutor = "Noruega";

// using var command = new SqliteCommand(insertQuery, connection);

// command.Parameters.AddWithValue("@nombre", nombreAutor);
// command.Parameters.AddWithValue("@apellido", apellidoAutor);
// command.Parameters.AddWithValue("@nacionalidad", nacionalidadAutor);

// var insertedId = command.ExecuteScalar();

// Console.WriteLine($"El id del autor creado es {insertedId}");

//3. Eliminar un registro de la base de datos (Delete)

// var deleteQuery = "DELETE FROM autor WHERE id_autor = @id";
// var command = new SqliteCommand(deleteQuery, connection);
// command.Parameters.AddWithValue("@id", 5);

// var rowDeleted = command.ExecuteNonQuery();

// if (rowDeleted > 0) {
//   Console.WriteLine($"Se eleminaron {rowDeleted} filas.");
// }
// else {
//   Console.WriteLine("NO se eliminaron filas.");
// }

//4. Actualizar un registro de la base de datos (Update)

var updateQuery = """
  UPDATE autor SET
    nombre = @nombre,
    apellido = @apellido,
    nacionalidad = @nacionalidad
  WHERE id_autor = @id
""";

using var command = new SqliteCommand(updateQuery, connection);

command.Parameters.AddWithValue("@nombre", "José");
command.Parameters.AddWithValue("@apellido", "Saramago");
command.Parameters.AddWithValue("@nacionalidad", "Brasileño");
command.Parameters.AddWithValue("@id", 40);

var rowUpdated = command.ExecuteNonQuery();

if (rowUpdated > 0) {
  Console.WriteLine($"Se ha actualizado {rowUpdated} fila");
}
else {
  Console.WriteLine($"No se ha actualizado ninguna fila");
}



