using Microsoft.Build.Tasks.Deployment.Bootstrapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdapterDesingPattern
{
    //Client
    class CustomerRepository
    {
        private ICacheManager _cacheManager;

        public CustomerRepository(ICacheManager cacheManager)
        {
            _cacheManager = cacheManager;
        }
        public void Save()
        {
            _cacheManager.Store("cache'leme yapılıyor.");
            _cacheManager.Remove("cache silindi");
        }
    }

    //Target
    interface ICacheManager
    {

        void Remove(string key);
        void Store(string data);
    }


    //ITarget : SCache benim yazdığım bir cache 
    class SKCache : ICacheManager
    {
        //ICacheManager'ı burada implemente ettim
        public void Remove(string key)
        {
            //
            Console.WriteLine(" SKCache yöntemi ile, {0} ", key);
        }

        public void Store(string data)
        {
            Console.WriteLine(" SKCache yöntemi ile, {0} ", data);
        }
    }

    //Adaptee class : adapte edilecek class
    class CachingDecorator
    {
        //nugetten indirilen bir cache2leme olarak düşünelim. Bir firmanın yazdığı cacheleme
        public void Add(string key)
        {
            Console.WriteLine("CachingDecorator yöntemi ile, {0} ", key);
        }
    }

    //customer repo da decorator cache i nasıl çalıştırırm ? 
    //Adapter class: adaptee classını bizim sistemimize entegre edebilemmizi sağlayacak
    class CacheDecoratorAdaptor : ICacheManager
    {

        CachingDecorator cachingDecorator = new CachingDecorator();
        public void Remove(string key)
        {
            cachingDecorator.Add(key);
        }

        public void Store(string data)
        {//3.parti cacheleme 
            cachingDecorator.Add(data);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //customer repo benden bi cache istiyordu. kendi cache metodumu verirsem:
            Console.WriteLine("**Kendi kurguladığım SKCache olarak bir cache'leme kullanmak istersem :**");
            CustomerRepository customerRepo = new CustomerRepository(new SKCache());
            customerRepo.Save();


            //Eğer istenen cache'leme 3.parti türünde olursa kolayca sisteme entegre edilir
            Console.WriteLine("**3.parti olan CacheDecoratorAdaptor olarak bir cache'leme kullanmak istersem :**");
            CustomerRepository customerRepoAdapter = new CustomerRepository(new CacheDecoratorAdaptor());
            customerRepoAdapter.Save();
            Console.ReadLine();
        }
    }
}
