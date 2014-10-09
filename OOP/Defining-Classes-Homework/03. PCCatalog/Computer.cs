using System;
using System.Collections.Generic;

namespace _03.PCCatalog
{
    class Computer
    {
        private string name;
        private List<Component> components = new List<Component>();
        private decimal price;
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Invalid name!");
                }
                else
                {
                    this.name = value;
                }
            }
        }
        public decimal Price
        {
            get
            {
                return this.price;
            }
        }
        public Computer(string name, Component boxPC, Component motherboard, Component hdd, Component procesor, Component graficsCard, Component ram)
        {
            this.Name = name;
            this.components.Add(boxPC);
            this.components.Add(motherboard);
            this.components.Add(hdd);
            this.components.Add(procesor);
            this.components.Add(graficsCard);
            this.components.Add(ram);
            foreach (Component componet in this.components)
            {
                this.price += componet.Price;
            }
        }
        public Computer(string name, Component boxPC, Component motherboard, Component hdd, Component procesor, Component graficsCard, Component ram, params Component[] componets) :
            this(name, boxPC, motherboard, hdd, procesor, graficsCard, ram)
        {
            this.components.AddRange(components);
            foreach (Component componet in components)
            {
                this.price += componet.Price;
            }
        }
        public void writeToConsole()
        {
            Console.WriteLine("{0} - {1:f2} lv.", this.Name, this.price);
            foreach (var component in this.components)
            {
                Console.WriteLine(" - {0} - {1:f2} lv.", component.Name, component.Price);
            }
        }
    }
}
