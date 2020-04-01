using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Calculator
{
   /// <summary>
   /// Třída pro řízení kalkulačky s implementací rozhraní pro možnost reagování na změnu vlastností této třídy
   /// </summary>
   public class Kalkulacka: INotifyPropertyChanged
   {

      /// <summary>
      /// Událost z rozhraní INotifyPropertyChanged
      /// </summary>
      public event PropertyChangedEventHandler PropertyChanged;

   
      Vypocty vypocty;
      ZobrazovaciPole zobrazovaciPole;

      



      /// <summary>
      /// Výčtový typ pro snadnější orientaci jaký typ výpočtu je právě požadován
      /// </summary>
      public enum AktualniStav { Soucet, Rozdil, Soucin, Podil, Vychozi, Vysledek }
      public AktualniStav aktualniStav;





      /// <summary>
      /// Konstruktor třídy pro úvodní inicializaci potřebných funkcí a vlastností
      /// </summary>
      /// <param name="vypocty">Instance třídy pro výpočty</param>
      /// <param name="zobrazovaciPole">Instance třídy pro zobrazovací pole</param>
      public Kalkulacka(Vypocty vypocty, ZobrazovaciPole zobrazovaciPole)
      {
         this.vypocty = vypocty;
         this.zobrazovaciPole = zobrazovaciPole;
         aktualniStav = AktualniStav.Vychozi;
      }

      /// <summary>
      /// Uvede kalkulačku do výchozího nastavení
      /// </summary>
      public void VychoziNastaveni()
      {
         zobrazovaciPole.ZobrazenyText = "";
         zobrazovaciPole.ZobrazeneCislo = 0;
         vypocty.Cislo_1 = 0;
         vypocty.Cislo_2 = 0;
         vypocty.Vysledek = 0;
         aktualniStav = AktualniStav.Vychozi;
      }



      /// <summary>
      /// Metoda smaže poslední číslici v textovém řetězci
      /// </summary>
      /// <param name="cislo">Textová reprezentace čísla</param>
      /// <returns></returns>
      public string SmazPosledniCislo(string cislo)
      {
         string TextoveCislo = cislo;
         TextoveCislo = TextoveCislo.Remove(TextoveCislo.Length - 1);   // Odstranění posledního znaku z textového řetězce

         return TextoveCislo;
      }




      /// <summary>
      /// Metoda pro provedení výpočtu
      /// </summary>
      /// <returns>Výsledek výpočtu</returns>
      public string UkazVysledek()
      {
         string vysledek = "";
         
         vypocty.Cislo_1 = zobrazovaciPole.ZobrazeneCislo;     // Uložení prvního čísla do pomocné proměnné pro výpočet
         zobrazovaciPole.UlozCislo();                          // Uložení čísla na displeji do pomocné proměnné
         vypocty.Cislo_2 = zobrazovaciPole.ZobrazeneCislo;     // Uložení druhého čísla do pomocné proměnné pro výpočet
         ProvedVypocet();                                      // Provedení výpočtu
         

         vysledek = zobrazovaciPole.PrevedCisloNaText(vypocty.Vysledek);   // Textová forma výsledku výpočtu
         aktualniStav = AktualniStav.Vysledek;
         return vysledek;
      }

      


      /// <summary>
      /// Metoda provede výpočet uvnitř třídy Vypocty a výsledek uchová v interní proměnné třídy Vypocty
      /// </summary>
      private void ProvedVypocet()
      {
         if (aktualniStav == AktualniStav.Soucet)
            vypocty.Soucet();
         if (aktualniStav == AktualniStav.Rozdil)
            vypocty.Rozdil();
         if (aktualniStav == AktualniStav.Soucin)
            vypocty.Soucin();
         if (aktualniStav == AktualniStav.Podil)
            vypocty.Podil();

      }









      /// <summary>
      /// Pomocná metoda pro vyvolání změny na displeji při změně parametrů
      /// </summary>
      public void ReagujNaZmenu()
      {
         VyvolejZmenu(nameof(zobrazovaciPole));     // Pomocná metoda pro vyvolání změny v okením formuláři při změně nejbližší osoby
      }




      /// <summary>
      /// Pomocná metoda pro vyvolání události, které předá jméno změněné vlastnosti (převzato v parametru).
      /// Metoda je volána vždy s názvem vlastnosti tam, kde je potřeba reagovat na změnu. 
      /// </summary>
      /// <param name="vlastnost"></param>
      protected void VyvolejZmenu(string vlastnost)
      {
         if (PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(vlastnost));
      }



   }
}
