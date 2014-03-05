namespace FurnitureManufacturer.Models
{
    using FurnitureManufacturer.Interfaces;

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Company : ICompany
    {
        private const int CompanyNameMinimumNumberOfSymbols = 5;
        private const int CompanyRegistrationNumberMandatorySymbolsCount = 10;

        private string name;
        private string registrationNumber;
        private ICollection<IFurniture> furnitures;

        public Company(string name, string registrationNumber)
        {
            this.Name = name;
            this.RegistrationNumber = registrationNumber;
            this.furnitures = new List<IFurniture>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Company name cannot be null or empty!");
                }

                if (value.Length < CompanyNameMinimumNumberOfSymbols)
                {
                    throw new ArgumentOutOfRangeException("Too short company name. Name should be at least 5 symbols!");
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
            private set
            {

                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Company registration number cannot be null or empty!");
                }

                if (value.Length == CompanyRegistrationNumberMandatorySymbolsCount)
                {
                    foreach (var symbol in value)
                    {
                        if (!char.IsDigit(symbol))
                        {
                            throw new ArgumentException("Invalid symbol type! Registration number must contain only digits!");
                        }
                    }

                    this.registrationNumber = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Company registration number must be exactly 10 symbols!");
                }
            }
        }

        public ICollection<IFurniture> Furnitures
        {
            get
            {
                return new List<IFurniture>(this.furnitures);
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Furnitures cannot have null value!");
                }

                this.furnitures = value;
            }
        }

        public void Add(IFurniture furniture)
        {
            if (furniture == null)
            {
                throw new ArgumentOutOfRangeException("Furnite value cannot be null! Cannot add furniture with null value!");
            }

            this.furnitures.Add(furniture);
        }

        public void Remove(IFurniture furniture)
        {
            if (furniture == null)
            {
                throw new ArgumentOutOfRangeException("Furnite value cannot be null! Cannot remove furniture with null value!");
            }

            foreach (var furn in this.Furnitures)
            {
                if (ReferenceEquals(furn, furniture))
                {
                    this.furnitures.Remove(furn);
                    break;
                }
            }
        }

        public IFurniture Find(string model)
        {
            //if (string.IsNullOrEmpty(model))
            //{
            //    throw new ArgumentNullException("Cannot give a null or empty furniture to be found!");
            //}

            foreach (var furniture in this.Furnitures)
            {
                if (furniture.Model.ToLower() == model.ToLower())
                {
                    return furniture;
                }
            }

            return null;
        }

        public string Catalog()
        {
            StringBuilder result = new StringBuilder();

            string furnituresCountAsString = this.Furnitures.Count != 0 ? this.Furnitures.Count.ToString() : "no";
            string furnituresNameAsString = this.Furnitures.Count != 1 ? "furnitures" : "furniture";

            result.Append(string.Format("{0} - {1} - {2} {3}", this.Name, this.RegistrationNumber, furnituresCountAsString, furnituresNameAsString));
            result.AppendLine();

            var orderedFurnitures = this.Furnitures.OrderBy(f => f.Price).ThenBy(f => f.Model);

            foreach (var furniture in orderedFurnitures)
            {
                result.AppendLine(furniture.ToString());
            }

            return result.ToString().TrimEnd();
        }
    }
}
