using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISLab
{
    class Program
    {
        static void Main(string[] args)
        {
        }
        public static void GetInfoLaptopsByCPU(string CPU, Laptop[] laptops)
        {
            Console.WriteLine("1. Данные по всем ноутбукам с процессором {0}", CPU);
            IEnumerable<Laptop> selectedLaptops = from laptop in laptops
                                       where laptop.CPU == CPU
                                       select laptop;
            foreach(Laptop laptop in selectedLaptops)
            {
                Console.WriteLine(laptop.ToString() + "\n");
            }
        }
        public static void GetModelsLaptopByCompany(string company, Laptop[] laptops)
        {
            Console.WriteLine("\n2. Модели ноутбуков фирмы {0}", company);
            IEnumerable<Laptop> selectedLaptops = from laptop in laptops
                                                  where laptop.Company == company
                                                  select laptop;
            foreach (Laptop laptop in selectedLaptops)
            {
                Console.WriteLine(laptop.ToString() + "\n");
            }
        }
        public static void GetModelsInRangePrice(double start, double end, Laptop[] laptops)
        {
            Console.WriteLine("\n3. Число моделей с ценой от {0} до {1}", start, end);
            IEnumerable<Laptop> selectedLaptops = from laptop in laptops
                                                  where laptop.Price >= start &&
                                                        laptop.Price < end
                                                  select laptop;
            foreach (Laptop laptop in selectedLaptops)
            {
                Console.WriteLine(laptop.ToString() + "\n");
            }
        }
        public static void GetModelsWithRamMore(int ram, Laptop[] laptops)
        {
            Console.WriteLine("\n4. Модель и производитель ноутбуков с объемом памяти более {0}", ram);
            var result = from laptop in laptops
                         where laptop.RAM > ram
                         select new
                         {
                             Model = laptop.Model,
                             Company = laptop.Company
                         };
            foreach (var laptop in result)
            {
                Console.WriteLine("Модель: {0}\nКомпания: {1}", laptop.Model, laptop.Company);
            }
        }
        public static void AveragePriceByCompany(string company, Laptop[] laptops)
        {
            var result = from laptop in laptops
                         where laptop.Company == company
                         select laptop.Price;
            Console.WriteLine("\n4. 5. Средняя цена ноутбуков фирмы {0}: {1}", company, result.Average());
        }
        public static void GroupingByStore(Laptop[] laptops)
        {
            Console.WriteLine("\n6. Все ноутбуки, сгруппированные по коду магазина (group)");
            var groups = from laptop in laptops
                         group laptop by laptop.StoreId;
            foreach(var group in groups)
            {
                Console.WriteLine("Код магазина: {0}", group.Key);
                foreach (var laptop in group)
                {
                    Console.WriteLine(laptop.ToString() + "\n");
                }
            }
        }
        public static void GetLaptopsInfoWithStoreInfo(Laptop[] laptops)
        {
            Console.WriteLine("\n7. Модель и цена ноутбуков с указанием названия и адреса магазина(join)");
            Store[] stores = new Store[]
            {

            };
            var result = from laptop in laptops
                         join store in stores on laptop.StoreId equals store.Id
                         select new
                         {
                             Model = laptop.Model,
                             Price = laptop.Price, 
                             StoreName = store.Name,
                             StoreAddress = store.Address
                         };
            foreach (var info in result)
            {
                Console.WriteLine("Модель: {0}\nЦена: {1}\nМагазин: {2}\n Адрес: {3}", info.Model, info.Price, info.StoreName, info.StoreAddress);
            }
        }
    }
}
