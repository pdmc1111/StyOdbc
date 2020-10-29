using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleOdbc.Models
{
    public class CD_FINI
    {
        public  string  FOURN         { get; set; }
        public  string  MODELE        { get; set; }
        public  string  CODE          { get; set; }
        public  string  DESC1         { get; set; }
        public  string  DESC2         { get; set; }
        public  string  CD_ACT        { get; set; }
        public  string  PROMO         { get; set; }
        public  string  PTR           { get; set; }
        public  string  CATEG         { get; set; }
        public  string  STR_SERV      { get; set; }
        public  string  MARQUE        { get; set; }
        public  string  DEPT          { get; set; }
        public  string  CD_DIV        { get; set; }
        public decimal  COUT_LISTE    { get; set; }
        public decimal  COUT_FOURN    { get; set; }
        public decimal  COUT_REEL     { get; set; }
        public decimal  COUT_VEND     { get; set; }
        public decimal  QTE_MIN_ENT   { get; set; }
        public decimal  QTE_MIN_GLO   { get; set; } //19
    }
}


