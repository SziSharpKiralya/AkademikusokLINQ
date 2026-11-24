using System;
using System.Collections.Generic;
using System.Text;

namespace AkademikusokLINQ
{
    internal class Feladatok
    {
        private Adatbazis database;
        private List<Tagsag> lista;

        public Feladatok(string connectionString)
        {
            this.database = new Adatbazis($"{connectionString}");
            this.lista = database.Feltolt();
            Kiir();
        }

        private void Kiir()
        {
            Console.WriteLine("-----------------------------------");
            foreach (var item in lista)
            {
                Console.WriteLine(item);
            }
        }
    }
}
