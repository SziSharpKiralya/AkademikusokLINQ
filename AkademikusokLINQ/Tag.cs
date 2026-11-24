using System;
using System.Collections.Generic;
using System.Text;

namespace AkademikusokLINQ
{
    internal class Tag
    {
        private int id;
        private string nev;
        private string nem;
        private int szuletett;
        private int elhunyt;
        private string identitas;

        public Tag(int id, string nev, string nem, int szuletett, int elhunyt, string identitas)
        {
            this.id = id;
            this.nev = nev;
            this.nem = nem;
            this.szuletett = szuletett;
            this.elhunyt = elhunyt;
            this.identitas = identitas;
        }

        public int Id { get => id; }
        public string Nev { get => nev; }
        public string Nem { get => nem; }
        public int Szuletett { get => szuletett; }
        public int Elhunyt { get => elhunyt; }
        public string Identitas { get => identitas; }

        public override string ToString()
        {
            return $"{Nev}, {Nem} | {Szuletett}-{Elhunyt} | {Identitas}";
        }
    }
}
