Console.Write("Ingresa ruta de almacenamiento: ");
string usb = Console.ReadLine();

if (Directory.Exists(usb))
{
    Console.WriteLine("Contenido del almacenamiento:");
    try
    {
        ContenidoRuta(usb);
    }
    catch (UnauthorizedAccessException)
    {
        Console.WriteLine("No tienes acceso a uno o más elementos en la memoria USB.");
    }
}
else
{
    Console.WriteLine("La ruta no es válida.");
}
static void ContenidoRuta(string direcion)
{
    Console.WriteLine($"Contenido de {direcion}:");

    try
    {
        string[] directories = Directory.GetDirectories(direcion);
        foreach (string directory in directories)
        {
            Console.WriteLine($"[Directorio] {Path.GetFileName(directory)}");
            ContenidoRuta(directory);
        }
        string[] archivos = Directory.GetFiles(direcion);
        foreach (string file in archivos)
        {
            Console.WriteLine($"[Archivo] {Path.GetFileName(file)}");
        }
    }
    catch (UnauthorizedAccessException)
    {
        Console.WriteLine($"No tienes acceso a {direcion}.");
    }
}