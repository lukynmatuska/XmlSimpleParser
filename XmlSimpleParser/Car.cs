using System;
using System.Collections.Generic;
using System.Text;

namespace XmlSimpleParser
{
    public class Car
    {
        public string Regno { get; set; }
        public string Manufacturer { get; set; }
        public string Type { get; set; }
        public Car() {
            ;
        }
        public Car(string regno, string manufacturer, string type)
        {
            this.Regno = regno;
            this.Manufacturer = manufacturer;
            this.Type = type;
        }
    }
}
