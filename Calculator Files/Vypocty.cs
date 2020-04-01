using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
   public class Vypocty
   {
      public double Cislo_1 { get; set; }
      public double Cislo_2 { get; set; }
      public double Vysledek { get; set; }



      public void Soucet()
      {
         Vysledek = Cislo_1 + Cislo_2;
      }



      public void Rozdil()
      {
         Vysledek = Cislo_1 - Cislo_2;
      }




      public void Soucin()
      {
         Vysledek = Cislo_1 * Cislo_2;
      }



      public void Podil()
      {
         Vysledek = Cislo_1 / Cislo_2;
      }






   }
}
