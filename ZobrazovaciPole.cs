using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
   /// <summary>
   /// Třída pro obsluhu zobrazovacího pole 
   /// </summary>
   public class ZobrazovaciPole
   { 

      /// <summary>
      /// Řetězec pro uložení čísla na displeji v textovém řetězci
      /// </summary>
      public string ZobrazenyText { get; set; }

      /// <summary>
      /// Uložené číslo zobrazené na displeji
      /// </summary>
      public double ZobrazeneCislo { get; set; }


      /// <summary>
      /// Konstruktor třídy
      /// </summary>
      public ZobrazovaciPole()
      {
         ZobrazenyText = "";

      }






      /// <summary>
      /// Přidá do textového řetězce další zadané číslo
      /// </summary>
      /// <param name="Cislo">Textová reprezentace zadaného čísla</param>
      public void PridejDalsiCislo(string Cislo)
      {
         ZobrazenyText += Cislo;
      }


      /// <summary>
      /// Převede celé textové pole (celé číslo) na číslo
      /// </summary>
      public void UlozCislo()
      {
         ZobrazeneCislo = double.Parse(ZobrazenyText);   // Uložení čísla do pomocné proměnné
         ZobrazenyText = ZobrazenyText.Remove(0);        // Smazání obsahu displeje
      }


      /// <summary>
      /// Funkce pro převod čísla na textový řetězec
      /// </summary>
      /// <param name="cislo">Číslo pro převod</param>
      /// <returns></returns>
      public string PrevedCisloNaText(double cislo)
      {
         return cislo.ToString();
      }






      



      public override string ToString()
      {
         return ZobrazenyText;
      }


   }
}
