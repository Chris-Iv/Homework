using System;

namespace _02.LaptopShop
{
    class LaptopShop
    {
        static void Main(string[] args)
        {
            Battery lion = new Battery("Li-Ion, 6-cells, 2550 mAh");
            Battery nicd = new Battery("Ni-Cd", (float)8.5);

            Laptop firstLaptop = new Laptop("Lenovo Yoga 2 Pro", (decimal)939.99, "Lenovo", "Intel Core i5-4210U (2-core, 1.70 - 2.20 GHz, 3MB cache)", 
                "12 GB", "128GB SSD", "Intel HD Graphics 4400", lion, "13.3\" (33.78 cm) – 3200 x 1800 (QHD+), IPS sensor display");
            Laptop secondLaptop = new Laptop("Aspire E3-111-C5GL", (decimal)359.55);
            Laptop thirdLaptop = new Laptop("Acer some model", (decimal)2567.50, battery: nicd, processor: "3.5 GHz", ram: "16 GB");

            Console.WriteLine(firstLaptop);
            Console.WriteLine(secondLaptop);
            Console.WriteLine(thirdLaptop);
        }
    }
}
