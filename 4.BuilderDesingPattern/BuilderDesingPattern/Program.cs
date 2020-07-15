using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderDesingPattern
{
    public class MainApp

    {
        public static void Main()

        {
            BisikletBuilder uret;
            
            // BisikletBuilder ile bayi oluşturuldu
            Bayi bayi = new Bayi();
            
            // bisiklet türlerinin oluşturulup, sergilenmesi
            uret = new YarisBuilder();
            bayi.Construct(uret);
            Console.WriteLine(uret.Bisiklet.basla());

            uret = new DagBuilder();
            bayi.Construct(uret);
            Console.WriteLine(uret.Bisiklet.basla());

            uret = new GeziBuilder();
            bayi.Construct(uret);
            Console.WriteLine(uret.Bisiklet.basla());
            
            Console.ReadKey();
        }
    }
    //Bayi Director sınıf
    class Bayi
    {
        // Builder karmaşık bir dizi adım kullanıyo
        public void Construct(BisikletBuilder bisikletBuilder)
        {
            bisikletBuilder.BuilKadro();
            bisikletBuilder.BuildVites();
            bisikletBuilder.BuildMarka();
        }
    }

    //'Builder' abstract classı
    abstract class BisikletBuilder
    {
        protected Bisiklet bisiklet;
        // Olşturulan bisikletlerin örneği getirilir
        public Bisiklet Bisiklet
        {
            get { return bisiklet; }
        }
        // Abstract build methodlarıtüretildi
        public abstract void BuilKadro();
        public abstract void BuildVites();
        public abstract void BuildMarka();
    }
    //Dağ bisikleti 'ConcreteBuilder1' class
    class DagBuilder : BisikletBuilder
    {
        public DagBuilder()
        {
            bisiklet = new Bisiklet("Dağ bisikleti siparişidir");
        }
        public override void BuilKadro()
        {
            bisiklet["kadro"] = "Karbon";
        }
        public override void BuildVites()
        {
            bisiklet["vites"] = "28";
        }
        public override void BuildMarka()
        {
            bisiklet["marka"] = "SALCANO";
        }
    }

    //Yarış bisikleti 'ConcreteBuilder2' sınıf
    class YarisBuilder : BisikletBuilder
    {
        public YarisBuilder()
        {
            bisiklet = new Bisiklet("Yarış Bisikleti şiparişidir");
        }
        public override void BuilKadro()
        {
            bisiklet["kadro"] = "Aliminyum";
        }
        public override void BuildVites()
        {
            bisiklet["vites"] = "25";
        }
        public override void BuildMarka()
        {
            bisiklet["marka"] = "BIANCHI";
        }

    }
    // Gezi bisikleti 'ConcreteBuilder3' class
    class GeziBuilder : BisikletBuilder
    {
        public GeziBuilder()
        {
            bisiklet = new Bisiklet("Gezi Bisikleti şiparişidir");
        }
        public override void BuilKadro()
        {
            bisiklet["kadro"] = "Çelik";
        }
        public override void BuildVites()
        {
            bisiklet["vites"] = "21";
        }
        public override void BuildMarka()
        {
            bisiklet["marka"] = "SCOTT";
        }
    }

    //'Product' classı
    class Bisiklet
    {
        private string _bisikletTuru;
        private Dictionary<string, string> _bisikletOzellik= new Dictionary<string, string>();
        // Constructor
        public Bisiklet(string bisikletTuru)
        {
            //sayut bisiklet sınfım ile kalıtım verdiğim 
            //bisiklet türlerini burdan çağırmak için:
            this._bisikletTuru = bisikletTuru;
        }
        // bisklet özelliklerini sözlükten al
        public string this[string index]
        {
            get { return _bisikletOzellik[index]; }
            set { _bisikletOzellik[index] = value; }
        }
        public string basla()
        {
            return string.Format ("BİSİKLET TÜRÜ: {0} ," +
                "\n - Kadro : {1}" +
                "\n - Vites: {2}" +
                "\n - Marka: {3}" +
                "\n******************************",
                _bisikletTuru, _bisikletOzellik["kadro"], _bisikletOzellik["vites"], _bisikletOzellik["marka"]);
        }
    }
}
