using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleOdbc.Models
{
    public class HISTORIQUE_VENTE
    {
        public HISTORIQUE_VENTE()
        {
            TYPE = "";
            NO_CTR = "";
            NO_FACT = "";
            NO_CLIENT = "";
            DT_SYST = "";
            HR_SYS = "";
            DT_VTE = "";
            DT_FACT = "";
            NO_VEND = "";
            MAG = "";
            TERME_PAIEMENT = "";
            PUB = "";
            REGION = "";
            CD_POST = "";
            NO_LIGNE = "";
            FOURN = "";
            MODELE = "";
            FINI = "";
            PTR = "";
            CATEG = "";
            DEPT = "";
            CD_DIV = "";
            TDP = "";
            ACT = "";
            MARQUE = "";
            DESC_MODELE = "";
            QTE_VNL = 0;
            PRIX_UNIT = 0;
            RABAIS_FOURN = 0;
            TAXE1 = 0;
            TAXE2 = 0;
            TAXE3 = 0;
            PRIX_SUGG = 0;
            ESC_SUGG = 0;
            COUT_REEL = 0;
            COUT_REEL_FIFO = 0;
            COUT_VEND = 0;
            SELL_THRU = 0;
            QTE_CTR = 0;
            TYPE_LIVR = "";
            DT_REQUISE = "";
            REMARQUE = "";
            PTR_ENS = "";
            FACT_VEND = 0;
        }

        public     string     TYPE              { get; set; }
        public     string     NO_CTR            { get; set; }
        public     string     NO_FACT           { get; set; }
        public     string     NO_CLIENT         { get; set; }
        public     string     DT_SYST           { get; set; }
        public     string     HR_SYS            { get; set; }
        public     string     DT_VTE            { get; set; }
        public     string     DT_FACT           { get; set; }
        public     string     NO_VEND           { get; set; }
        public     string     MAG               { get; set; }
        public     string     TERME_PAIEMENT    { get; set; }
        public     string     PUB               { get; set; }
        public     string     REGION            { get; set; }
        public     string     CD_POST           { get; set; }
        public     string     NO_LIGNE          { get; set; }
        public     string     FOURN             { get; set; }
        public     string     MODELE            { get; set; }
        public     string     FINI              { get; set; }
        public     string     PTR               { get; set; }
        public     string     CATEG             { get; set; }
        public     string     DEPT              { get; set; }
        public     string     CD_DIV            { get; set; }
        public     string     TDP               { get; set; }
        public     string     ACT               { get; set; }
        public     string     MARQUE            { get; set; }
        public     string     DESC_MODELE       { get; set; }
        public     decimal    QTE_VNL           { get; set; }
        public     decimal    PRIX_UNIT         { get; set; }
        public     decimal    RABAIS_FOURN      { get; set; }
        public     decimal    TAXE1             { get; set; }
        public     decimal    TAXE2             { get; set; }
        public     decimal    TAXE3             { get; set; }
        public     decimal    PRIX_SUGG         { get; set; }
        public     decimal    ESC_SUGG          { get; set; }
        public     decimal    COUT_REEL         { get; set; }
        public     decimal    COUT_REEL_FIFO    { get; set; }
        public     decimal    COUT_VEND         { get; set; }
        public     decimal    SELL_THRU          { get; set; }
        public     decimal    QTE_CTR           { get; set; }
        public     string     TYPE_LIVR         { get; set; }
        public     string     DT_REQUISE        { get; set; }
        public     string     REMARQUE          { get; set; }
        public     string     PTR_ENS           { get; set; }
        public     decimal    FACT_VEND         { get; set; }

    }
}
