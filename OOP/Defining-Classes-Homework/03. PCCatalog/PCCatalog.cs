using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.PCCatalog
{
    class PCCatalog
    {
        static void Main(string[] args)
        {
            Component boxPC = new Component(name: "Box Shenha V6", price: 55.20m, details: "Size: 475 x 185 x 465 cm");
            Component motherboard = new Component(name: "Motherboard ASROCK FM2A88X Extreme6+", price: 188.40m);
            Component hdd = new Component(name: "Hard drive SEAGATE 2T, ES.3, SATA III", price: 330m, details: "Capacity: 2 TB");
            Component processor = new Component(name: "Processor Intel Core I3-4340", price: 316.80m);
            Component graphicsCard = new Component(name: "Graphics card PALIT GeForce GT 610", price: 80.40m, details: "Graphics memory размер: 1 GB");
            Component ram = new Component(name: "Memory ADATA 2X4GB", price: 171.60m, details: "Description: 2X4G DDR3");
            Component discSSD = new Component(name: "SSD Drive A-DATA 128GB SSD", price: 127.20m, details: "Description: Multi-Level Cell (MLC) NAND Flash Memory, 2.5 inch");
            Component fan = new Component(name: "Fan COOLERMASTER Blade Master 80", price: 16.80m);
            Component power = new Component(name: "PSU FD 750W INTEGRA BLACK", price: 157.20m, details: "Description: Multi-Level Cell (MLC) NAND Flash Memory, 2.5 inch");
            Computer computer1 = new Computer(
            name: "Good pc",
            boxPC: boxPC,
            motherboard: motherboard,
            hdd: hdd,
            procesor: processor,
            graficsCard: graphicsCard,
            ram: ram
            );
            Computer computer2 = new Computer("Awesome pc", boxPC, motherboard, hdd, processor, graphicsCard, ram, discSSD, fan, power);
            Computer computer3 = new Computer("Great pc", boxPC, motherboard, hdd, processor, graphicsCard, ram, discSSD);
            List<Computer> computers = new List<Computer>() { computer2, computer1, computer3, computer1 };
            computers = computers.OrderBy(computer => computer.Price).ToList();
            foreach (var computer in computers)
            {
                computer.writeToConsole();
                Console.WriteLine();
            }

        }
    }
}
