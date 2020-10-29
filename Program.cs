/*
 PhD: To Read appsettings.json config file
  get these NUGET packages.
Microsoft.Extensions.Configuration
Microsoft.Extensions.Configuration.FileExtensions
Microsoft.Extensions.Configuration.Json 
 
 
 */

using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using ConsoleOdbc.Models;

namespace ConsoleOdbc
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            var cfgDsnName = configuration["dsnName"];
            var cfgTableName = configuration["tableName"];

            var connectionString = configuration["ConnectionStrings:LocalDbConnection"];
            var toSqlServer = new ToSqlServer(connectionString);
            var meublex = new OdbcMeublex(cfgDsnName, toSqlServer);


            //var columnNames = "CODE_COMP, STATUT, RAISON_SOCIALE,  NOM,    ADR1,    ADR2,  VILLE, PROVINCE, CD_POST, TELEPHONE,   FAX,   PROPRIO, DT_OUV,   NO_CHARTE, DIV_CONS, NO_TPS,    NO_TVQ,  DT_PER_DEBUT, DT_PER_FIN, COMMENTAIRE__001, COMMENTAIRE__002, COMMENTAIRE__003, COMMENTAIRE__004";
            //var columnValues = "'0011',     '1',     '1',         'DESC',  'ABREV',  'P',   'H',     'D',    'B',     '123',     '123',  'QWER',  '222222', '2222',     1,        '123',     '123',   '121273',      '121273',   'NOTE1',          'NOTE2',           'NOTE3',         'NOTE4'";
            //meublex.InsertIntoTable("GL_COMPAGNIE", columnNames, columnValues);

            var cm = ",";
            var setCriteria = 
            " STATUT='0'" + cm +
            " RAISON_SOCIALE='testTestTEST'" + cm +
            " NOM='Test Name'" + cm + 
            " ADR1='12345 Rue Fake'" + cm +
            " ADR2='54321 Rue NomFaker'" + cm +
            " VILLE='Montreal'" + cm +
            " PROVINCE='Quebec'" + cm +
            " CD_POST='H3E 1A2'" + cm +
            " TELEPHONE='5145551212'" + cm +
            " FAX='5145552121'" + cm +
            " PROPRIO='Propio'" + cm +
            " DT_OUV='20191028'" + cm +
            " NO_CHARTE='4'" + cm +
            " DIV_CONS='2'" + cm +
            " NO_TPS='123'" + cm +
            " NO_TVQ='321'" + cm +
            " DT_PER_DEBUT='20191028'" + cm +
            " DT_PER_FIN='20191028'" + cm +
            " COMMENTAIRE__001='COMMENTAIRE__001'" + cm +
            " COMMENTAIRE__002='COMMENTAIRE__002'" + cm +
            " COMMENTAIRE__003='COMMENTAIRE__003'" + cm +
            " COMMENTAIRE__004='COMMENTAIRE__004'"
            ;

            var whereCriteria = "CODE_COMP='0011'";
            meublex.UpdateTable("GL_COMPAGNIE", setCriteria, whereCriteria);



            //meublex.DeleteFromTable("GL_COMPAGNIE", "CODE_COMP='PhD'");




            return;

            var tables = new string[] 
            {"CATEGORIE",
            "CD_ACTIVITE",
            "CD_FINI",
            "CD_MODELE",
            "CD_SERVICE",
            "CLIENT",
            "DEPARTEMENT",
            "DIVISION",
            "FOURNISSEUR",
            "HISTORIQUE_VENTE",
            "HISTORIQUE_VENTE_SERVICE",
            "MAGASIN",
            "PUBLICITE",
            "REGION",
            "TERME_PAIEMENT",
            "VENDEUR",
            "COMMANDE_FOURNISSEUR_DETAIL"};



            meublex.GetMeublexDbData<CATEGORIE>(tables[0]);
            meublex.GetMeublexDbData<CD_ACTIVITE>(tables[1]);
            meublex.GetMeublexDbData<CD_FINI>(tables[2]);
            meublex.GetMeublexDbData<CD_MODELE>(tables[3]);
            meublex.GetMeublexDbData<CD_SERVICE>(tables[4]);
            meublex.GetMeublexDbData<CLIENT>(tables[5]);
            meublex.GetMeublexDbData<DEPARTEMENT>(tables[6]);
            meublex.GetMeublexDbData<DIVISION>(tables[7]);
            meublex.GetMeublexDbData<FOURNISSEUR>(tables[8]);
            meublex.GetMeublexDbData<HISTORIQUE_VENTE>(tables[9]);
            meublex.GetMeublexDbData<HISTORIQUE_VENTE_SERVICE>(tables[10]);
            meublex.GetMeublexDbData<MAGASIN>(tables[11]);
            meublex.GetMeublexDbData<PUBLICITE>(tables[12]);
            meublex.GetMeublexDbData<REGION>(tables[13]);
            meublex.GetMeublexDbData<TERME_PAIEMENT>(tables[14]);
            meublex.GetMeublexDbData<VENDEUR>(tables[15]);
            meublex.GetMeublexDbData<COMMANDE_FOURNISSEUR_DETAIL>(tables[16]);

            Console.WriteLine(Environment.NewLine + Environment.NewLine + "Program Complete!");
        }
    }
}
