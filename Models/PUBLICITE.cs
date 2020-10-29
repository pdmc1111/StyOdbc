using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleOdbc.Models
{
    public class PUBLICITE
    {
        public PUBLICITE()
        {
            //PREFIX = "";
            //CODE = "";
            //DESC_FR = "";
            //ABREV_FR = "";
            //DESC_AN = "";
            //ABREV_AN = "";
        }

        public    string    PREFIX     { get; set; }
        public    string    CODE       { get; set; }
        public    string    DESC_FR     { get; set; }
        public    string    ABREV_FR    { get; set; }
        public    string    DESC_AN     { get; set; }
        public    string    ABREV_AN    { get; set; }
    }
}
