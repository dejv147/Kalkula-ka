using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator
{
   /// <summary>
   /// Interaction logic for MainWindow.xaml
   /// </summary>
   public partial class MainWindow : Window
   {


      Kalkulacka kalkulacka;
      ZobrazovaciPole zobrazovaciPole;
      Vypocty vypocty;

      


      public MainWindow()
      {
         InitializeComponent();


         zobrazovaciPole = new ZobrazovaciPole();
         vypocty = new Vypocty();
         kalkulacka = new Kalkulacka(vypocty, zobrazovaciPole);

         DataContext = kalkulacka;
      }




      /// <summary>
      /// Funkce pro obsluhu tlačítka s číslem. Funkce převezme číslo ze stisknutého tlačítka a vypíše jej na obrazovku.
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void Button_Click(object sender, RoutedEventArgs e)
      {

         string CisloTlacitka = ((Button)sender).Content.ToString();    // Uložení čísla dle tlačítka, které bylo stisknuto
         int Cislo = int.Parse(CisloTlacitka);                          // Uložení čísla dle tlačítka, které bylo stisknuto

         zobrazovaciPole.PridejDalsiCislo(CisloTlacitka);               //Přidání další číslice do textového řetězce zobrazeného na displeji
                        
         //kalkulacka.ReagujNaZmenu();   // Nefunguje
         ZadavaciPoleTextBlock.Text = zobrazovaciPole.ZobrazenyText;    // Zobrazení požadovaného textu na displej

      }



      /// <summary>
      /// Obsluha tlačítka funkce C pro uvedení kalkulačky do výchozího stavu
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void Funkce_C_Button_Click(object sender, RoutedEventArgs e)
      {
         kalkulacka.VychoziNastaveni();
         ZadavaciPoleTextBlock.Text = zobrazovaciPole.ZobrazenyText;    // Zobrazení požadovaného textu na displej
      }






      /// <summary>
      /// Obsluha tlačítka funkce CE pro vymazání právě napsaného čísla
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void Funkce_CE_Button_Click(object sender, RoutedEventArgs e)
      {
         try
         {
            zobrazovaciPole.ZobrazenyText = kalkulacka.SmazPosledniCislo(zobrazovaciPole.ZobrazenyText);
         }
         catch (Exception)
         {
            MessageBox.Show("Zadejte číslo!", "Chyba", MessageBoxButton.OK, MessageBoxImage.Exclamation);
         }
         ZadavaciPoleTextBlock.Text = zobrazovaciPole.ZobrazenyText;    // Zobrazení požadovaného textu na displej
      }




      /// <summary>
      /// Obslužná funkce tlačítka + pro provedení součtu
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void Soucet_Button_Click(object sender, RoutedEventArgs e)
      {
         try
         {
            zobrazovaciPole.UlozCislo();     // Uložení napsaného čísla do pomocné proměnné
            kalkulacka.aktualniStav = Kalkulacka.AktualniStav.Soucet;
         }
         catch (Exception)
         {
            MessageBox.Show("Zadejte číslo!", "Chyba", MessageBoxButton.OK, MessageBoxImage.Exclamation);
         }
         ZadavaciPoleTextBlock.Text = zobrazovaciPole.ZobrazenyText;    // Zobrazení požadovaného textu na displej
      }




      /// <summary>
      /// Obslužná funkce tlačítka - pro provedení rozdílu
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void Rozdil_Button_Click(object sender, RoutedEventArgs e)
      {
         try
         {
            zobrazovaciPole.UlozCislo();     // Uložení napsaného čísla do pomocné proměnné
            kalkulacka.aktualniStav = Kalkulacka.AktualniStav.Rozdil;
         }
         catch (Exception)
         {
            MessageBox.Show("Zadejte číslo!", "Chyba", MessageBoxButton.OK, MessageBoxImage.Exclamation);
         }
         ZadavaciPoleTextBlock.Text = zobrazovaciPole.ZobrazenyText;    // Zobrazení požadovaného textu na displej
      }




      /// <summary>
      /// Obslužná funkce tlačítka * pro provedení násobku
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void Nasobek_Button_Click(object sender, RoutedEventArgs e)
      {
         try
         {
            zobrazovaciPole.UlozCislo();     // Uložení napsaného čísla do pomocné proměnné
            kalkulacka.aktualniStav = Kalkulacka.AktualniStav.Soucin;
         }
         catch (Exception)
         {
            MessageBox.Show("Zadejte číslo!", "Chyba", MessageBoxButton.OK, MessageBoxImage.Exclamation);
         }
         ZadavaciPoleTextBlock.Text = zobrazovaciPole.ZobrazenyText;    // Zobrazení požadovaného textu na displej
      }



      /// <summary>
      /// Obslužná funkce tlačítka / pro provedení podílu
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void Podil_Button_Click(object sender, RoutedEventArgs e)
      {
         try
         {
            zobrazovaciPole.UlozCislo();     // Uložení napsaného čísla do pomocné proměnné
            kalkulacka.aktualniStav = Kalkulacka.AktualniStav.Podil;
         }
         catch (Exception)
         {
            MessageBox.Show("Zadejte číslo!", "Chyba", MessageBoxButton.OK, MessageBoxImage.Exclamation);
         }
         ZadavaciPoleTextBlock.Text = zobrazovaciPole.ZobrazenyText;    // Zobrazení požadovaného textu na displej
      }




      /// <summary>
      /// Obslužná metoda pro stisk tlačítka = pro zobrazení výsledku 
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void Vysledek_Button_Click(object sender, RoutedEventArgs e)
      {
         try
         {
            zobrazovaciPole.ZobrazenyText = kalkulacka.UkazVysledek();     // Zobrazení výsledného textového řetězce do TestBlock zobrazovacího pole
         }
         catch (Exception)
         {
            MessageBox.Show("Zadejte číslo!", "Chyba", MessageBoxButton.OK, MessageBoxImage.Exclamation);
         }
         ZadavaciPoleTextBlock.Text = zobrazovaciPole.ZobrazenyText;    // Zobrazení požadovaného textu na displej
      }



      /// <summary>
      /// Obslužná metoda pro stisk tlačítka , pro psaní desetiného čísla
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void Carka_Button_Click(object sender, RoutedEventArgs e)
      {
         zobrazovaciPole.ZobrazenyText += ",";
         ZadavaciPoleTextBlock.Text = zobrazovaciPole.ZobrazenyText;    // Zobrazení požadovaného textu na displej
      }





   }
}
