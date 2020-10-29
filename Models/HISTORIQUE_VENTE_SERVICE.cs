using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleOdbc.Models
{
    public class HISTORIQUE_VENTE_SERVICE
    {
        public      string          TYPE          { get; set; }
        public      string          NO_CTR        { get; set; }
        public      string          NO_LIG        { get; set; }
        public      string          DT_SYST       { get; set; }
        public      string          HR_SYST       { get; set; }
        public      string          CD_SERV       { get; set; }
        public      decimal         QTE_SERV      { get; set; }
        public      decimal         VTE_SERV      { get; set; }
        public      decimal         QTE_POT       { get; set; }
        public      decimal         VTE_POT       { get; set; }
    }
}
