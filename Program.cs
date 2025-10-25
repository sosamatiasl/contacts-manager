using MySql.Data.MySqlClient;
using System;
using System.Data;

public class ContactManager
{
    private string connectionString = "Server=localhost;Database=ContactosDB;Uid=user;Pwd=password;";

    public void GetContacts()
    {
        using (var connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            var query = "SELECT Id, Nombre, Telefono FROM Contactos";
            using (var command = new MySqlCommand(query, connection))
            using (var connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    var query = "SELECT Id, Nombre, Telefono FROM Contactos ORDER BY Id ASC";
                    using (var command = new MySqlCommand(query, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        Console.WriteLine("\n--- LISTA DE CONTACTOS ---");
                        if (!reader.HasRows)
                        {
                            Console.WriteLine("No hay contactos registrados.");
                            return;
                        }
                        while (reader.Read())
                        {
                            Console.WriteLine($"ID: {reader["Id"]} | Nombre: {reader["Nombre"]} | Teléfono: {reader["Telefono"]}");
                        }
                        Console.WriteLine("--------------------------");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\nError al obtener contactos: {ex.Message}");
                }
            }
        }
    }

    public void CreateContact(string name, string phone)
    {
        using (var connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            var query = "INSERT INTO CONTACTOS (Nombre, Telefono) VALUES (@Nombre, @Telefono)";
            using (var command = new MySqlCommand(query, connection))
            {
                try
                {
                    command.Parameters.AddWithValue("@Nombre", name);
                    command.Parameters.AddWithValue("@Telefono", phone);
                    command.ExecuteNonQuery();
                    Console.WriteLine("Contacto creado exitosamente.");
                }
                catch (Exception ex)}
                {
                    Console.WriteLine($"Error al crear contacto: {ex.Message}");
                }
            }
        }
    }

    public void UpdateContact(int id, string newName, string newPhone)
    {
        using (var connection = new MySqlConnection(connectionString))
        {
            try
            {
                connection.Open();
                var query = "UPDATE Contactos SET Nombre = @Nombre, Telefono = @Telefono WHERE Id = @Id";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", newName);
                    command.Parameters.AddWithValue("@Telefono", newPhone);
                    command.Parameters.AddWithValue("@Id", id);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        Console.WriteLine($"\nContacto con ID {id} actualizado exitosamente.");
                    }
                    else
                    {
                        Console.WriteLine($"\nNo se encontró un contacto con ID {id}.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError al actualizar contacto: {ex.Message}");
            }
        }
    }

    public void DeleteContact(int id)
    {
        using (var connection = new MySqlConnection(connectionString))
        {
            try
            {
                connection.Open();
                var query = "DELETE FROM Contactos WHERE Id = @Id";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        Console.WriteLine($"\nContacto con ID {id} eliminado exitosamente.");
                    }
                    else
                    {
                        Console.WriteLine($"\nNo se encontró un contacto con ID {id}.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError al eliminar contacto: {ex.Message}");
            }
        }
    }

}

public class Program
{
    private static ContactManager manager = new ContactManager();

    public static void Main()
    {
        DisplayWelcome();

        bool @continue = true;
        while (@continue)
        {
            ShowMenu();
            string option = Console.ReadLine();
            Console.Clear();

            try
            {
                switch (option)
                {
                    case "1":
                        HandleCreateContact();
                        break;
                    case "2":
                        manager.GetContacts();
                        break;
                    case "3":
                        HandleUpdateContact();
                        break;
                    case "4":
                        HandleDeleteContact();
                        break;
                    case "5":
                        @continue = false;
                        break;
                    default:
                        Console.WriteLine("\nOpción no válida. Por favor, selecciona un número del 1 al 5.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nERROR GENERAL DE LA APLICACIÓN: {ex.Message}");
            }

            if (@continue)
            {
                PauseConsole();
            }
        }

        MostrarDespedida();
    }

    private static void DisplayWelcome()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("==================================================");
        Console.WriteLine("         👋 Bienvenido al Gestor de Contactos     ");
        Console.WriteLine("         [CRUD C# Console con MySQL]              ");
        Console.WriteLine("==================================================");
        Console.ResetColor();
        PauseConsole();
        Console.Clear();
    }

    private static void MostrarDespedida()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("==================================================");
        Console.WriteLine("         ¡Gracias por usar la aplicación!         ");
        Console.WriteLine("         Cerrando el Gestor de Contactos...       ");
        Console.WriteLine("==================================================");
        Console.ResetColor();
        PauseConsole();
    }

    private static void ShowMenu()
    {
        Console.WriteLine("\nSelecciona una operación:");
        Console.WriteLine("1: Crear nuevo contacto");
        Console.WriteLine("2: Ver todos los contactos");
        Console.WriteLine("3: Actualizar contacto (por ID)");
        Console.WriteLine("4: Eliminar contacto (por ID)");
        Console.WriteLine("5: Salir de la aplicación");
        Console.Write("Opción: ");
    }

    private static void HandleCreateContact()
    {
        Console.Write("Nombre del nuevo contacto: ");
        string nombre = Console.ReadLine();
        Console.Write("Teléfono del nuevo contacto: ");
        string telefono = Console.ReadLine();
        manager.CreateContact(nombre, telefono);
    }

    private static void HandleUpdateContact()
    {
        manager.GetContacts();
        Console.Write("\nID del contacto a actualizar: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            Console.Write("Nuevo nombre: ");
            string nombre = Console.ReadLine();
            Console.Write("Nuevo teléfono: ");
            string telefono = Console.ReadLine();
            manager.UpdateContact(id, nombre, telefono);
        }
        else
        {
            Console.WriteLine("\nID inválido.");
        }
    }

    private static void HandleDeleteContact()
    {
        manager.GetContacts();
        Console.Write("\nID del contacto a eliminar: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            manager.DeleteContact(id);
        }
        else
        {
            Console.WriteLine("\nID inválido.");
        }
    }

    private static void PauseConsole()
    {
        Console.WriteLine("\n[Presiona cualquier tecla para continuar...] ");
        Console.ReadKey(true);
    }
}
