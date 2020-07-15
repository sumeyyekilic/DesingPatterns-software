using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonDesingPattern
{
    class Program
    {
        static void Main()
        {
            //aşağıda oluş _singleton nesnesine iht duyduğumda kullanmak için
            //new ile ürettirmiyor!!BUNA DİKKAT
            //bir kere şu şekikde üretince emin şekilde üretmiş oluruz.
            var singleton = Singleton.CreateSingleton();
            //oluşt delete metodunu buradan çağırdım
            singleton.Delete();

            Console.ReadLine();
        }
    }

    class Singleton
    {
        //yönetilecek nesne tanımlanır
        private static Singleton _singleton;

        //burada amaç dış erişimi engellemek Singleton nesnesinin
        private Singleton()
        {

        }
        //Singleton örneğini oluşturacak bir metot ytanımlıycam.
        //Singleton kendisini döndürsün:
        public static Singleton CreateSingleton()
        {
            //eğer customer man nesnesinden daha önce oluşturulmuş varsa aynısını ver
            //eğer yoksa bir tane oluşturup onu döndürücüez.
            if (_singleton == null)
            {
                //new'leme yapılır.
                _singleton = new Singleton();
            }
            //eğer null değilse sing döndür.
            return _singleton;
        }

        public void Delete()
        {
            Console.WriteLine("Silme işlemin başarılı..");
        }
    }
}
