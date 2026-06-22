using System;

namespace AgendaTelefonicaUEA
{
    // Struct para definir el Registro del contacto
    public struct Contacto
    {
        public string Nombre;
        public string Telefono;
        public string Email;

        public Contacto(string nombre, string telefono, string email)
        {
            Nombre = nombre;
            Telefono = telefono;
            Email = email;
        }
    }

    // Clase para gestionar la Agenda 
    public class GestorAgenda
    {
        private Contacto[] contactos = new Contacto[50];
        private int contador = 0;

        public void AgregarContacto(string nombre, string telefono, string email)
        {
            if (contador < contactos.Length)
            {
                contactos[contador] = new Contacto(nombre, telefono, email);
                contador++;
                Console.WriteLine("\nContacto agregado con exito.");
            }
            else
            {
                Console.WriteLine("\nError: La agenda esta llena.");
            }
        }

        public void ListarContactos()
        {
            Console.WriteLine("\n--- LISTA DE CONTACTOS ---");
            if (contador == 0) Console.WriteLine("La agenda esta vacia.");
            for (int i = 0; i < contador; i++)
            {
                Console.WriteLine($"{i + 1}. {contactos[i].Nombre} | Tel: {contactos[i].Telefono} | Email: {contactos[i].Email}");
            }
        }

        public void BuscarContacto(string nombre)
        {
            bool encontrado = false;
            for (int i = 0; i < contador; i++)
            {
                if (contactos[i].Nombre.ToLower().Contains(nombre.ToLower()))
                {
                    Console.WriteLine($"\nContacto encontrado: {contactos[i].Nombre} - {contactos[i].Telefono}");
                    encontrado = true;
                }
            }
            if (!encontrado) Console.WriteLine("\nContacto no encontrado.");
        }

        public void EliminarContacto(string nombre)
        {
            int indice = -1;
            for (int i = 0; i < contador; i++)
            {
                if (contactos[i].Nombre.ToLower() == nombre.ToLower())
                {
                    indice = i;
                    break;
                }
            }

            if (indice != -1)
            {
                for (int i = indice; i < contador - 1; i++)
                {
                    contactos[i] = contactos[i + 1];
                }
                contador--;
                Console.WriteLine("\nContacto eliminado con exito.");
            }
            else
            {
                Console.WriteLine("\nContacto no encontrado para eliminar.");
            }
        }
    }

    // Clase main
    class Program
    {
        static void Main(string[] args)
        {
            GestorAgenda agenda = new GestorAgenda();
            string opcion;

            do
            {
                Console.WriteLine("\n--- MENU AGENDA TELEFONICA ---");
                Console.WriteLine("1. Agregar Contacto");
                Console.WriteLine("2. Listar Contactos");
                Console.WriteLine("3. Buscar Contacto");
                Console.WriteLine("4. Eliminar Contacto");
                Console.WriteLine("5. Salir");
                Console.Write("Seleccione una opcion: ");
                opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.Write("Nombre: "); string n = Console.ReadLine();
                        Console.Write("Telefono: "); string t = Console.ReadLine();
                        Console.Write("Email: "); string e = Console.ReadLine();
                        agenda.AgregarContacto(n, t, e);
                        break;
                    case "2":
                        agenda.ListarContactos();
                        break;
                    case "3":
                        Console.Write("Nombre a buscar: "); string busqueda = Console.ReadLine();
                        agenda.BuscarContacto(busqueda);
                        break;
                    case "4":
                        Console.Write("Nombre a eliminar: "); string nombreEliminar = Console.ReadLine();
                        agenda.EliminarContacto(nombreEliminar);
                        break;
                }
            } while (opcion != "5");
        }
    }
}