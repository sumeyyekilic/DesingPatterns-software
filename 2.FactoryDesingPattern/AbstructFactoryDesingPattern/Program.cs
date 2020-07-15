using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstructFactoryDesingPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Factory factory = new Factory(new FabrikaAFactory());
            factory.basla();

            Console.WriteLine("*******");

            Factory factory2 = new Factory(new FabrikaBFactory());
            factory2.basla();

            Console.ReadLine();
        }
    }

    //
    public abstract class BisikletUret
    {
        //bisiklet üret'in yapması gereken görevler
        //soyut ürün sınıflarımız
        public abstract bool TasarımIs();
        public abstract bool MekanikIs();
        
        //üretimin durumunu geriye döndüren bir değer olsun dersek 
        public abstract string bisikletDurum
        { get; }

    }
    //ürün sınıfı
    public abstract class BisikletSiparis
    {
        public abstract void Execute(string siparis);
    }
    //asıl ürünlerimizin tasarımı(concrete sınıflar)
    public class FabrikaAUret : BisikletUret
    {
        //kalııtm verşnce
        //abstruct ürünün tipleri aşağıdaki gibi otomatik gelir.
        //abstruct tiplerde , abstruct olarak tanımlanmış üyeleri 
        //türeyen sınıflarında uygulaması zorunluluğu vardır.(interface için de geçerli)
        public override string bisikletDurum
        {
            get { return "Bisiklet Üretim Durumu Başladı"; }
        }

        public override bool MekanikIs()
        {
            Console.WriteLine("A Fabrikası Mekanik işler yapılacak .. !");
            return true;
        }

        public override bool TasarımIs()
        {
            Console.WriteLine("A Fabrikası Tasarım işler yapılacak .. !");
            return true;
        }
    }
    public class FabrikaBUret : BisikletUret
    {
        public override string bisikletDurum
        {
            get { return "Bisiklet Üretim Durumu Başladı"; }
        }


        public override bool MekanikIs()
        {
            Console.WriteLine("B Fabrikası Mekanik işler yapılacak .. !");
            return true;
        }

        public override bool TasarımIs()
        {
            Console.WriteLine("B Fabrikası Tasarım işler yapılacak .. !");
            return true;
        }
    }
    //YUKARIDA ÜRETİMİ HEM A FABRİKASI HEMDE B FABRİKASI İÇİN TANIMLADIM

    //Birde bu üretimin siparişi için "BisikletSiparis" türevli ürünler olmalı

    public class FabrikaASiparis : BisikletSiparis
    {
        public override void Execute(string siparis)
        {
            Console.WriteLine("A Fabrikası Siparişi verilir ..!");
        }
    }
    public class FabrikaBSiparis : BisikletSiparis
    {
        public override void Execute(string siparis)
        {
            Console.WriteLine("B Fabrikası Siparişi verilir ..!");
        }
    }

    //bu aşamaya kadar ürünleimizi tanımladık 
    //ürünlerin soyut sınıfları tasarlandı.

    //bir fabrikaya  ihtiyacımız var..  
    public abstract class BisikletFactory
    {
        //fabrika sınıfımız için model olacak soyut fabrika tipini tanımlama 
        public abstract BisikletUret BisikletUret();
        public abstract BisikletSiparis BisikletSiparis();
    }

    //abstruct yerine interface de kullanılabilir

    //**** asıl fabrikalarımızın tasarımı ***
    public class FabrikaAFactory : BisikletFactory
    {
        //BisikletSiparis ve BisikletUret ürünlerini geriye döndüren 
        public override BisikletSiparis BisikletSiparis()
        {
            //fabrika kendisiyle alakalı tiplerle çalışır
            return new FabrikaASiparis();
        }

        public override BisikletUret BisikletUret()
        {
            return new FabrikaAUret();
        }      
    }

    //B ürünü için Fabrika tanımı
    public class FabrikaBFactory : BisikletFactory
    {
        public override BisikletSiparis BisikletSiparis()
        {
            return new FabrikaBSiparis();
        }

        public override BisikletUret BisikletUret()
        {
            return new FabrikaBUret();
        }
    }

    //artık istemcinin fabrika seçimini gerçekleştirecek sınıfı olmalı
    public class Factory
    {
        //hangi tipte ürünlerle çalılacaksa bu ürünler için kullanılacak nesne ürünlerini burada ele alınır
        private BisikletFactory _bisikletFactory;
        private BisikletSiparis _bisikletSiparis;
        private BisikletUret _bisikletUret;
        public Factory (BisikletFactory bisikletFactory)
        {
            _bisikletFactory = bisikletFactory;

            //seçilen fabrikaya göre nesnelerin üretimi gerçekleştirlecek
            _bisikletSiparis = bisikletFactory.BisikletSiparis();
            //bisiklet üretimi için biiskletFactory üzerinden BisikletUret 'i kullanabilicez.
            _bisikletUret = bisikletFactory.BisikletUret();
        }
        public void basla()
        {
           

            
            if (_bisikletUret.bisikletDurum == "Bisiklet Üretim Durumu Başladı")
                _bisikletSiparis.Execute("SELECT..");
                _bisikletUret.MekanikIs();
                _bisikletUret.TasarımIs();

        }

    }
}



