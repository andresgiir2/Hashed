using System;
using System.Security.Cryptography;
using System.Text;

class Program
{
    static void Main()
    {
        Console.Write("Ingrese su contraseña: ");
        string password = Console.ReadLine();
        string hashedPassword = HashPassword(password);
        Console.WriteLine($"Contraseña encriptada: {hashedPassword}");

        string storedHash = hashedPassword;

        Console.Write("Verifique su contraseña: ");
        string verifyPassword = Console.ReadLine();
        string verifyHashedPassword = HashPassword(verifyPassword);
        if (verifyHashedPassword == storedHash)
        {
            Console.WriteLine("Contraseña correcta.");
        }
        else
        {
            Console.WriteLine("Contraseña incorrecta.");
        }
    }

    static string HashPassword(string password)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            StringBuilder builder = new StringBuilder();
            foreach (byte b in bytes)
            {
                builder.Append(b.ToString("x2"));
            }
            return builder.ToString();
        }
    }
}
