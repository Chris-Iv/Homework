using System;
using System.Collections.Generic;
using System.Linq;
using FurnitureManufacturer.Interfaces;
using System.Text;

namespace FurnitureManufacturer.Models
{
    public class Company : ICompany
    {
        private string name;
        private string registrationNumber;
        private ICollection<IFurniture> furnitures;

        public Company(string name, string registrationNumber)
        {
            this.Name = name;
            this.RegistrationNumber = registrationNumber;
            this.Furnitures = new List<IFurniture>();
        }

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
                    throw new ArgumentNullException("Company name cannot be empty!");
                }

                if (value.Length < 5)
                {
                    throw new ArgumentOutOfRangeException("Company name should be at least 5 letters!");
                }

                this.name = value;
            }
        }

        public string RegistrationNumber
        {
            get
            {
                return this.registrationNumber;
            }
            set
            {
                if (value.Length < 10 || value.Length > 10)
                {
                    throw new ArgumentOutOfRangeException("Registration number must be 10 digits long!");
                }

                if (value.Any(ch => !char.IsDigit(ch)))
                {
                    throw new ArgumentException("Registration number must be only digits!");
                }

                this.registrationNumber = value;
            }
        }

        public ICollection<IFurniture> Furnitures
        {
            get
            {
                return this.furnitures;
            }
            set
            {
                this.furnitures = value;
            }
        }

        public void Add(IFurniture furniture)
        {
            this.Furnitures.Add(furniture);
        }

        public void Remove(IFurniture furniture)
        {
            this.Furnitures.Remove(furniture);
        }

        public IFurniture Find(string model)
        {
            return this.Furnitures.FirstOrDefault(f => f.Model.ToLower() == model.ToLower());
        }

        public string Catalog()
        {
            //var result = new StringBuilder();

            //result.AppendLine(string.Format(
            //    ToStringFormat,
            //    this.Name,
            //    this.RegistrationNumber,
            //    this.Furnitures.Count != ZeroFurnitures ? this.Furnitures.Count.ToString() : NoFurnitures,
            //    this.Furnitures.Count != OneFurniture ? ManyFurnitures : SingleFurniture));

            var result = new StringBuilder();
            result.AppendLine(string.Format("{0} - {1} - {2} {3}",
            this.Name, this.RegistrationNumber, this.Furnitures.Count != 0 ? this.Furnitures.Count.ToString() : "no", this.Furnitures.Count != 1 ? "furnitures" : "furniture"));

            var sortedFurnitures = this.Furnitures.OrderBy(f => f.Price).ThenBy(f => f.Model);
            foreach (var furniture in sortedFurnitures)
            {
                result.AppendLine(furniture.ToString());
            }

            return result.ToString().Trim();

            //return string.Format("{0} - {1} - {2} {3}", 
            //this.Name, this.RegistrationNumber, this.Furnitures.Count != 0 ? this.Furnitures.Count.ToString() : "no", this.Furnitures.Count != 1 ? "furnitures" : "furniture")
        }
    }
}
