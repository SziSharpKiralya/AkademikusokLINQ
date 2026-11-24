using System;
using System.Collections.Generic;
using System.Text;

namespace AkademikusokLINQ
{
    internal class Tagsag
    {
        private int id;
        private Tag tag;
        private string tipus;
        private int ev;

        public Tagsag(int id, Tag tag, string tipus, int ev)
        {
            this.id = id;
            this.tag = tag;
            this.tipus = tipus;
            this.ev = ev;
        }

        public int Id { get => id; }
        public string Tipus { get => tipus; }
        public int Ev { get => ev; }
        internal Tag Tag { get => tag; }

        public override string ToString()
        {
            return $"{Tag.Nev} | {Tipus} | {Ev}";
        }
    }
}
