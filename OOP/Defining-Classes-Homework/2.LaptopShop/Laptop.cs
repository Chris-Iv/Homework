using System;
using System.Text;

namespace _02.LaptopShop
{
    class Laptop
    {
        private string model;
        private string manufacturer;
        private string processor;
        private string ram;
        private string graphicsCard;
        private string hdd;
        private string screen;
        private Battery battery;
        private decimal price;

        public string Model
        {
            get
            {
                return this.model;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Invalid model");
                }
                else
                {
                    this.model = value;
                }
            }
        }

        public string Manufacturer
        {
            get
            {
                return this.manufacturer;
            }
            set
            {
                if (value != null && value.Length < 1)
                {
                    throw new ArgumentException("Invalid manufacturer");
                }
                else
                {
                    this.manufacturer = value;
                }
            }
        }

        public string Processor
        {
            get
            {
                return this.processor;
            }
            set
            {
                if (value != null && value.Length < 1)
                {
                    throw new ArgumentException("Invalid processor");
                }
                else
                {
                    this.processor = value;
                }
            }
        }

        public string Ram
        {
            get
            {
                return this.ram;
            }
            set
            {
                if (value != null && value.Length < 1)
                {
                    throw new ArgumentException("Invalid ram");
                }
                else
                {
                    this.ram = value;
                }
            }
        }

        public string GraphicsCard
        {
            get
            {
                return this.graphicsCard;
            }
            set
            {
                if (value != null && value.Length < 1)
                {
                    throw new ArgumentException("Invalid graphicsCard");
                }
                else
                {
                    this.graphicsCard = value;
                }
            }
        }

        public string Hdd
        {
            get
            {
                return this.hdd;
            }
            set
            {
                if (value != null && value.Length < 1)
                {
                    throw new ArgumentException("Invalid hdd");
                }
                else
                {
                    this.hdd = value;
                }
            }
        }

        public string Screen
        {
            get
            {
                return this.screen;
            }
            set
            {
                if (value != null && value.Length < 1)
                {
                    throw new ArgumentException("Invalid screen");
                }
                else
                {
                    this.screen = value;
                }
            }
        }

        public Battery Battery
        {
            get
            {
                return this.battery;
            }
            set
            {
                this.battery = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Invalid price");
                }
                else
                {
                    this.price = value;
                }
            }
        }

        public Laptop(string model, decimal price)
        {
            this.Model = model;
            this.Price = price;
        }

        public Laptop(string model, decimal price, string manufacturer = null, string processor = null, string ram = null, 
            string hdd = null, string graphicsCard = null, Battery battery = null, string screen = null) 
            : this(model, price)
        {
            this.Manufacturer = manufacturer;
            this.Processor = processor;
            this.Ram = ram;
            this.Hdd = hdd;
            this.GraphicsCard = graphicsCard;
            this.Battery = battery;
            this.Screen = screen;
        }

        public override string ToString()
        {
            StringBuilder laptopStr = new StringBuilder();
            laptopStr.AppendLine("model: " + this.Model);

            if (Manufacturer != null)
            {
                laptopStr.AppendLine("manufacturer: " + this.Manufacturer);
            }
            if (Processor != null)
            {
                laptopStr.AppendLine("processor: " + this.Processor);
            }
            if (Ram != null)
            {
                laptopStr.AppendLine("RAM: " + this.Ram);
            }
            if (Hdd != null)
            {
                laptopStr.AppendLine("HDD: " + this.Hdd);
            }
            if (GraphicsCard != null)
            {
                laptopStr.AppendLine("graphics Card: " + this.GraphicsCard);
            }
            if (Battery != null)
            {
                laptopStr.Append(this.Battery.ToString());
            }
            if (Screen != null)
            {
                laptopStr.AppendLine("screen: " + this.Screen);
            }

            laptopStr.AppendLine("price: " + this.Price + " lv.");
            return laptopStr.ToString();
        }

    }
}
