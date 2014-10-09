using System;

namespace _03.PCCatalog
{
    class Component
    {
        private string name;
        private decimal price;
        private string details;

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
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Invalid price!");
                }
                else
                {
                    this.price = value;
                }
            }
        }

        public string Details
        {
            get
            {
                return this.details;
            }
            set
            {
                if (value != null && value.Length < 1)
                {
                    throw new ArgumentException("Invalid details!");
                }
                else
                {
                    this.details = value;
                }
            }
        }

        public Component(string name, decimal price, string details = null)
        {
            this.Name = name;
            this.Price = price;
            this.Details = details;
        }

    }
}
