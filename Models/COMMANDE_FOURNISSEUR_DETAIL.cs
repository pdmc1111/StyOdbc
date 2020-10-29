using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleOdbc.Models
{
    public class COMMANDE_FOURNISSEUR_DETAIL
    {
        public string          NO_COMM              { get; set; }
        public string          SEQ                  { get; set; }
        public decimal         QTE_EN_COMM          { get; set; }
        public decimal         QTE_REC              { get; set; }
        public decimal         QTE                  { get; set; }
        public decimal         COUT_REEL            { get; set; }
        public string          DT_REQUISE           { get; set; }
        //public string          TAG                  { get; set; }
        //public string          STOCK                { get; set; }
    }
}

