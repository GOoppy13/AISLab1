using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISLab
{
    class Store
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public override string ToString()
        {
            return string.Format("Код: {0}\n" +
                "Название: {1}\n" + 
                "Адрес: {2}",
                Id, Name, Address);
        }
    }
}
