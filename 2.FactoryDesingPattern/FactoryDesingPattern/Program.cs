using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryDesingPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            //creator sınıfından örnek türet
            CreatorFactory creator = new CreatorFactory();
            
            IBisiklet bisikletDag = creator.BisikletFactory(BisikletModel.Dag);
            bisikletDag.Uret();

            IBisiklet bisikletYaris= creator.BisikletFactory(BisikletModel.Yaris);
            bisikletYaris.Uret();

            IBisiklet bisikletGezi = creator.BisikletFactory(BisikletModel.Gezi);
            bisikletGezi.Uret();
            
            Console.ReadLine();
        }
    }

    //***Product Class****
    //interface olarak da tanımlanabilir
    interface IBisiklet
    {
        //Bisiklet Sınıfım Concrrate productlar için base class görevi üstlenir 
        //ve factory metodun geriye döndüreceği referanstır.
        void Uret();
        //bisiklet için sür metodu
    }
    
    //ConcreteaProduct
    public class DagBisikleti : IBisiklet
    {
        //Sedonabike marka bisikleti bke sınıfından türeteceğiz bu ürünü
        public void Uret()
        {
            Console.WriteLine("Üretilecek bisiklet, Dağ Bisikleti türüdür..!");
        }
    }


    //ConcreteaProduct
    //Bir product daha üretirsek 
    public class YarisBisikleti : IBisiklet
    {
        public void Uret()
        {
            Console.WriteLine("Üretilecek bisiklet, Yarış Bisikleti türüdür..!");
        }
    }
    //ConcreteaProduct
    public class GeziBisikleti : IBisiklet
    {
        //Sedonabike marka bisikleti bke sınıfından türeteceğiz bu ürünü
        public void Uret()
        {
            Console.WriteLine("Üretilecek bisiklet, Gezi Bisikleti türüdür..!");
        }
    }

    //Yeni bir class
    //Factory Metodunu içinde taşıyacak bir class üret

    //hangi bisiklet türünden istediğini Creator sınıfı için türetildi
    enum BisikletModel
    {
        Dag,
        Yaris,
        Gezi
    }

    //CreatorClass
    class CreatorFactory
    {
        //Burada bisiklet türüne göre uygun olan asıl ürünün (concrete product on üretimi) üretimi gerçekleştirilir
        //FactıryMethod
        

        public IBisiklet BisikletFactory(BisikletModel bisikletModel)
        {
            IBisiklet bisiklet=null;
            //bisiklet model ise bisiklet tipidir.
            switch(bisikletModel)
            {
                case BisikletModel.Dag:
                    bisiklet = new DagBisikleti();
                    break;
                case BisikletModel.Yaris:
                    bisiklet = new YarisBisikleti();
                    break;
                case BisikletModel.Gezi:
                    bisiklet = new GeziBisikleti();
                    break;
               default:
                    break;
            }
            //Asıl ürünü taşıyan referans
            return bisiklet;
        }
    }

}
