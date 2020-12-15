using System;
using System.Collections.Generic;
using System.Text;

namespace XmlSimpleParser
{
    public class CarDatabase
    {
        public List<Car> Cars { get; set; }
        public CarDatabase()
        {
            this.Cars = new List<Car>();
        }
    }
}
