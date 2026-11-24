using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Xml;

namespace AkademikusokLINQ
{
    internal class Adatbazis
    {
        private readonly string connectionString;

        public Adatbazis(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Tagsag> Feltolt()
        {
            List<Tagsag> lista = new List<Tagsag>();
            Dictionary<int, Tag> tagok = new Dictionary<int, Tag>();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    Console.WriteLine("Adatbáziskapcsolat felvive!");
                    string tagQuery = "SELECT * FROM tag";
                    using (MySqlCommand command = new MySqlCommand(tagQuery, conn))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = reader.GetInt32("id");
                                Tag t = new Tag(
                                    id,
                                    reader.GetString("nev"),
                                    reader.GetString("nem"),
                                    reader.GetInt32("szuletett"),
                                    reader.GetInt32("elhunyt"),
                                    reader.GetString("identitas")
                                    );
                                tagok[id] = t;
                            }
                        }
                    }

                    string tagsagQuery = "SELECT * FROM tagsag";
                    using (MySqlCommand command = new MySqlCommand(tagsagQuery, conn))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = reader.GetInt32("id");
                                Tag t = tagok[reader.GetInt32("tagid")];
                                string tipus = reader.GetString("tipus");
                                int ev = reader.GetInt32("ev");
                                lista.Add(new Tagsag(id, t, tipus, ev));
                            }
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Hiba az adatbázishoz való kapcsolódás során: ");
                Console.WriteLine(ex);
                Console.ResetColor();
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e);
                Console.ResetColor();
            }

            return lista;
        }
    }
}
