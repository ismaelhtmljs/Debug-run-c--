using System;
using System.Diagnostics;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // color para las letras
        Console.ForegroundColor = ConsoleColor.Magenta;      
        while (true)
        {
            Console.WriteLine(@"
                 _______   _______ .______    __    __    _______          
                |       \ |   ____||   _  \  |  |  |  |  /  _____|         
                |  .--.  ||  |__   |  |_)  | |  |  |  | |  |  __           
                |  |  |  ||   __|  |   _  <  |  |  |  | |  | |_ |          
                |  '--'  ||  |____ |  |_)  | |  `--'  | |  |__| |          
                |_______/ |_______||______/   \______/   \______|          

                .______       __    __  .__   __.      ______              
                |   _  \     |  |  |  | |  \ |  |     /      |   _     _   
                |  |_)  |    |  |  |  | |   \|  |    |  ,----' _| |_ _| |_ 
                |      /     |  |  |  | |  . `  |    |  |     |_   _|_   _|
                |  |\  \----.|  `--'  | |  |\   |    |  `----.  |_|   |_|  
                | _| `._____| \______/  |__| \__|     \______|     

                Version : Beta 3.1  By : Ismaelxd74    Github : ismaelhtmljs 
                    [-]puedes entrar a ver el repositorio en mi github
                            [*]https://github.com/ismaelhtmljs        
            ");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Para poder depurar se necesita tener instalado MinGW : https://github.com/msys2/msys2-installer/releases/download/2024-01-13/msys2-x86_64-20240113.exe\nsi sospecha del enlace, puede descargarlo en la pagina oficial de microsoft : https://code.visualstudio.com/docs/cpp/config-mingw");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n✳️Para salir del programa coloque 'exit' \n");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("[1]Depurar");
            Console.WriteLine("[2]Ver archivos");
            Console.WriteLine("[3]Moverse de escritorio");
            Console.WriteLine("[4]Abrir vscode");
            Console.WriteLine("[5]Crear proyecto");
            string respuesta = Console.ReadLine();
            
            // condicion para las opciones
            if (respuesta == "1")
            {
                Console.Clear();
                while (true)
                {
                    // mensaje 
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Para poder depurar su archivo debe convertirlo a exe y luego depurar \n");
                    Console.ForegroundColor= ConsoleColor.Yellow;
                    Console.WriteLine("⚠️Ejecute la opcion de 'Convertir a exe' y luego ejecute la opcion de 'Depurar' \n");
                    
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    // las 2 opciones 
                    Console.WriteLine("[1]Convertir a exe");
                    Console.WriteLine("[2]Depurar");
                    Console.WriteLine("[3]Volver al princio");
                    string respuesta_2 = Console.ReadLine();
                    if (respuesta_2 == "1")
                    {
                        Console.WriteLine("Coloque el nombre de su archivo : ");
                        string nombre_archivo = Console.ReadLine();
                        Console.WriteLine("Coloque el nombre para convertirlo a exe");
                        string nombre_exe = Console.ReadLine();
                        string Convertir_comand = $"g++ -o \"{nombre_exe}.exe\" \"{nombre_archivo}.cpp\"";
                        Ejecutor(Convertir_comand);
                        Limpiador();
                    }

                    else if (respuesta_2 == "2")
                    {
                        Console.WriteLine("Coloque el nombre de su archivo exe : ");
                        string nombre_ejecutar_exe = Console.ReadLine();

                        // verificar si el archivo existe
                        if (System.IO.File.Exists($"{nombre_ejecutar_exe}.exe"))
                        {
                            string depurar_comand = $"{nombre_ejecutar_exe}";
                            Ejecutor(depurar_comand);
                            Limpiador();
                        }

                        else
                        {
                            notfound_llamada();
                        }
                    }

                    else if (respuesta_2 == "3")
                    {
                        Limpiador();
                        break;
                    }

                    else
                    {
                        Error_llamada();
                    }
                }
            }

            else if(respuesta == "2")
            {
                string show_directori = Directory.GetCurrentDirectory();
                string[] show_archivos = Directory.GetFileSystemEntries(show_directori);
                foreach (var archivo in show_archivos)
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine(archivo);
                }
                Console.ForegroundColor = ConsoleColor.Magenta;
                Limpiador();
            }

            else if (respuesta == "3")
            {
                Console.ForegroundColor= ConsoleColor.Green;
                Console.WriteLine("🟢Ejemplo : C:/ruta/de/su/archivo");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Coloque la ruta en la que desea moverse : ");
                string ruta = Console.ReadLine();
                ruta = ruta.Replace("/", "\\");

                // verificar si la ruta existe
                if (Directory.Exists(ruta))
                {
                    Directory.SetCurrentDirectory(ruta);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"➡️Ahora estas en la ruta {Directory.GetCurrentDirectory()}");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Limpiador();
                }

                else
                {
                    notfound_llamada();
                }
            }

            else if (respuesta == "4")
            {
                string vscode_command = "code .";
                Ejecutor(vscode_command);
                Limpiador();
            }

            else if (respuesta == "5")
            {
                Console.WriteLine("🟢Nombre de su Carpeta a crear : ");
                string nombre_carpeta_crear = Console.ReadLine();
                Console.WriteLine("🟢Nombre de su archivo (sin extensión, por ejemplo archivo) : ");
                string nombre_archivo_crear = Console.ReadLine();
            
                // Verificar si la carpeta ya existe, si no, crearla
                string ruta_carpeta = Path.Combine(Directory.GetCurrentDirectory(), nombre_carpeta_crear);
                if (!Directory.Exists(ruta_carpeta))
                {
                    // Crear la carpeta
                    Directory.CreateDirectory(ruta_carpeta);
                    Console.WriteLine($"Carpeta {nombre_carpeta_crear} creada.");
                }
                else
                {
                    Console.WriteLine($"La carpeta {nombre_carpeta_crear} ya existe.");
                }
            
                // Crear la ruta completa para el archivo (agregar la extensión .cpp)
                string archivo_completo = Path.Combine(ruta_carpeta, $"{nombre_archivo_crear}.cpp");
            
                // Verificar si el archivo ya existe
                if (!File.Exists(archivo_completo))
                {
                    // Crear el archivo y cerrarlo inmediatamente
                    File.Create(archivo_completo).Close();
                    Console.WriteLine($"Se ha creado el archivo {archivo_completo} dentro de la carpeta {nombre_carpeta_crear}.");
                }
                else
                {
                    Console.WriteLine("El archivo ya existe en esa ubicación.");
                }
            }


            else if (respuesta == "exit")
            {
                Environment.Exit(0);
            }

            else
            {
                Error_llamada();
            }
        }
    }
    static void Ejecutor(string comando)
    {
        ProcessStartInfo processStartInfo = new ProcessStartInfo()
        {
            FileName = "cmd.exe",
            Arguments = $"/C {comando}",
            UseShellExecute = true,
            CreateNoWindow = false,
        };
        Process.Start(processStartInfo);
    }

    static void Limpiador()
    {
        Console.WriteLine("Presione cualquier tecla para continuar...");
        Console.ReadKey();
        Console.Clear();
    }

    static void Error_llamada()
    {
        Error_Mensaje error_Mensaje= new Error_Mensaje();
        error_Mensaje.Mensaje();
    }

    static void notfound_llamada()
    {
        Error_Mensaje error_Mensaje= new Error_Mensaje();
        error_Mensaje.notFound();
    }
}

class Error_Mensaje
{
    public void Mensaje()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("❗ERROR : No se encuentra la opcion que coloco");
        Console.WriteLine("presione cualquier tecla para continuar...");
        Console.ReadLine();
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.Clear();
    }
    public void notFound()
    {
        Console.ForegroundColor= ConsoleColor.Red;
        Console.WriteLine("❗ERROR : No se pudo encontrar el archivo");
        Console.ReadLine();
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.Clear();
    }
}