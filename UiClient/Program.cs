using System;
using System.Threading;

namespace UiClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Client cliente = new Client();


            string Menu = "                ********Bienvenido******** \n Selecciona una opción \n 1) Consulta todos los generos musicales \n 2) Consulta artistas por genero         \n 3) Consulta albums por artista          \n 4) Consulta canciones por album         \n 5) Consulta artistas por nombre de una canción";

            Console.WriteLine(Menu);

            switch (Console.Read())
            {
                case '1':
                    Console.Write("\n           Todos los generos \n");
                    Console.Write("\n           Procesando . . . \n");
                    ShowSpinner();
                    foreach (var i in cliente.GetAllGenre())
                    {
                        Console.WriteLine("                                     ---------" + i.NameGenere + "---------");
                        foreach (var j in i.lstSubGeneres)
                        {
                            Console.WriteLine(string.Concat("                   ", j.NombreSubGenero));
                        }
                        Console.WriteLine("                                     ------------------");
                    }
                    break;
                case '2':
                    Console.WriteLine("escribe un genero musical");
                    Console.ReadLine();
                    string gen;                                     
                    gen = Console.ReadLine();
                    Console.Write("\n           Procesando . . . \n \n \n");
                    ShowSpinner();
                    foreach (var i in cliente.GetAlbumByArtist(gen))
                    {
                        Console.WriteLine("---------" + i.NameAlbum + "---------");
                    }

                    break;
                case '3':
                    Console.WriteLine("escribe el nombre de un artista");
                    Console.ReadLine();
                    string artista;
                    artista = Console.ReadLine();
                    Console.Write("\n           Procesando . . . \n \n \n");
                    ShowSpinner();
                    foreach (var i in cliente.GetArtistByGenre(artista))
                    {
                        Console.WriteLine("---------" + i.NameArtist + "---------");
                    }
                    break;
                case '4':
                    Console.Write("Escribe un album ");
                    Console.ReadLine();
                    string album;
                    album = Console.ReadLine();
                    Console.Write("\n           Procesando . . . \n \n \n");
                    ShowSpinner();
                    foreach (var i in cliente.GetSongsByAlbum(album))
                    {
                        Console.WriteLine("---------" + i.nameSong + "---------");
                    }
                    break;
                case '5':
                    Console.Write("Escribe el nombre de un canción");
                    Console.ReadLine();
                    string Artist;
                    Artist = Console.ReadLine();
                    Console.Write("\n           Procesando . . . \n \n \n");
                    ShowSpinner();
                    foreach (var i in cliente.GetArtistBySong(Artist))
                    {
                        Console.WriteLine("---------" + i.NameArtist + "---------");
                    }
                    break;
            }
        }
        static void ShowSpinner()
        {
            var counter = 0;
            for (int i = 0; i < 50; i++)
            {
                switch (counter % 4)
                {
                    case 0: Console.Write("/"); break;
                    case 1: Console.Write("-"); break;
                    case 2: Console.Write("\\"); break;
                    case 3: Console.Write("|"); break;
                }
                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                counter++;
                Thread.Sleep(100);
            }
        }

    }
}
