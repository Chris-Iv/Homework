using System;
using System.Text;

namespace _02.LaptopShop
{
    class Battery
    {
        private string type;
        private float hours;

        public string Type
        {
            get
            {
                return this.type;
            }
            set
            {
                if (value != null && value.Length < 1)
                {
                    throw new ArgumentException("Invalid battery type");
                }
                else
                {
                    this.type = value;
                }
            }
        }

        public float Hours
        {
            get
            {
                return this.hours;
            }
            set
            {
                if (value != null && value < 0)
                {
                    throw new ArgumentException("Invalid battery life");
                }
                else
                {
                    this.hours = value;
                }
            }
        }

        public Battery(string type)
        {
            this.Type = type;
        }

        public Battery(string type, float hours)
            : this(type)
        {
            this.Hours = hours;
        }

        public override string ToString()
        {
            StringBuilder resultStr = new StringBuilder();

            if (this.Type != null)
            {
                resultStr.AppendLine("battery: " + this.Type);
            }

            if (this.Hours > 0)
            {
                resultStr.AppendLine("battery life: " + this.Hours + "hours");
            }

            return resultStr.ToString();
        }

    }
}
