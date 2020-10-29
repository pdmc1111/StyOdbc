using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleOdbc.Models
{
    public class MAGASIN
    {
        public MAGASIN()
        {
            PREFIX = "";
            CODE = "";
            NOM = "";
            ABREV = "";
            ABREV3L = "";
            ADR1 = "";
            VILLE = "";
            PROVINCE = "";
            CD_POST = "";
            TELEPHONE = "";
            FAX = "";
            NO_TPS = "";
            NO_TVQ = "";
        }

        public      string       PREFIX          { get; set; }
        public      string       CODE            { get; set; }
        public      string       NOM             { get; set; }
        public      string       ABREV           { get; set; }
        public      string       ABREV3L         { get; set; }
        public      string       ADR1            { get; set; }
        public      string       VILLE           { get; set; }
        public      string       PROVINCE        { get; set; }
        public      string       CD_POST         { get; set; }
        public      string       TELEPHONE       { get; set; }
        public      string       FAX             { get; set; }
        public      string       NO_TPS           { get; set; }
        public      string       NO_TVQ           { get; set; }

    }
}
