using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeDesingPattern
{
    class Program
    {
        class MainApp
        {
            static void Main()
            {
                Console.WriteLine("Mevsimlere göre çiçekler----> X ve Y türünü klonlayıp ekrana yazdırma ");

                // X ve Y adında 2 örnek oluşturdum
                //her birini klonladım
                ConcretePrototypeCicek1 X = new ConcretePrototypeCicek1();
                X._cicekAdi = "BEYAZ GÜL";
                X.sicaklık = "20 derece";
                X.familya = "Rosaceae ";
                ConcretePrototypeCicek1 X1 = (ConcretePrototypeCicek1)X.Clone();
                Console.WriteLine("*** Klonlanan 1. X çiçek türü : ***");
                GorunumTanımları(X1);
                //X türünden 2.bir çiçek klonladım
                ConcretePrototypeCicek1 X2 = (ConcretePrototypeCicek1)X.Clone();
                X2._cicekAdi = "KIRMIZI GÜL";
                X2.sicaklık = "20-32 derece";
                X2.familya = "Rosaceae ";
                Console.WriteLine("*** Klonlanan 2. X çiçek türü : ***");
                GorunumTanımları(X2);

                //Y türünden örnek oluşturma ve klonlama
                ConcretePrototypeCicek12 Y = new ConcretePrototypeCicek12();
                Y._cicekAdi = "KARANFİL";
                Y.sicaklık = "-3 İLE 34 derece arası";
                Y.familya = "Dianthus";
                ConcretePrototypeCicek12 Y1 = (ConcretePrototypeCicek12)Y.Clone();
                Console.WriteLine("*** Klonlanan 1. Y çiçek türü : ***");
                GorunumTanımları(Y1);

                Console.ReadKey();
            }
            //çiçek türü ve istediğim özellikleri skrayla görüntüleme standardı oluşturdum : 
            public static void GorunumTanımları(CicekPrototype p)
            {
                Console.WriteLine("     İsmi = {0:d}," +
                    " \n     Familya = {1:d} ," +
                    " \n     Sıcaklık = {2:d}: ",
                     p._cicekAdi, p.familya, p.sicaklık);
            }
        }
        //'Prototype' abstract classı
        abstract class CicekPrototype
        {
            public abstract CicekPrototype Clone();
            public string _cicekAdi;
            public string sicaklık;
            public string familya;
        }

        // Çiçek1 türü için 'ConcretePrototype' classı
        class ConcretePrototypeCicek1 : CicekPrototype
        {
            // Constructor
            public ConcretePrototypeCicek1() : base()
            {
            }
            //bir kopya döndürmesi için:
            public override CicekPrototype Clone()
            {
                return (CicekPrototype)this.MemberwiseClone();
            }
        }
        // Çiçek1 türü için 'ConcretePrototype' class 
        class ConcretePrototypeCicek12 : CicekPrototype
        {
            // Constructor
            public ConcretePrototypeCicek12() : base()
            {
            }
            //bir kopya döndürmesi için:
            public override CicekPrototype Clone()
            {
                return (CicekPrototype)this.MemberwiseClone();
            }
        }
    }
}