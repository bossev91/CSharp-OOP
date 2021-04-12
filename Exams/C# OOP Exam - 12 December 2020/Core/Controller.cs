using Bakery.Core.Contracts;
using Bakery.Models.BakedFoods;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Enums;
using Bakery.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Core
{
    class Controller : IController
    {
        private List<IBakedFood> bakedFoods;
        private List<IDrink> drinks;
        private List<ITable> tables;
        private decimal totalBill = 0;

        public Controller()
        {
            bakedFoods = new List<IBakedFood>();
            drinks = new List<IDrink>();
            tables = new List<ITable>();
        }

        public string AddDrink(string type, string name, int portion, string brand)
        {
            IDrink drink = null;
            if(type == "Tea")
            {
                drink = new Tea(name, portion, brand);
            }
            if(type == "Water")
            {
                drink = new Water(name, portion, brand);
            }

            drinks.Add(drink);
            return $"Added {name} ({brand}) to the drink menu";
            
        }

        public string AddFood(string type, string name, decimal price)
        {

            IBakedFood food = null;
            if (type == "Bread")
            {
                food = new Bread(name, price);
            }
            if (type == "Cake")
            {
                food = new Cake(name, price);
            }

            bakedFoods.Add(food);
            return $"Added {name} ({type}) to the menu";
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            ITable table = null;
            if(type == "InsideTable")
            {
                table = new InsideTable(tableNumber, capacity);
            }
            if(type == "OutsideTable")
            {
                table = new OutsideTable(tableNumber, capacity);
            }

            tables.Add(table);
            return $"Added table number {tableNumber} in the bakery";
        }

        public string GetFreeTablesInfo()
        {
            foreach (var item in tables.Where(x => x.IsReserved == false))
            {
                return $"{item.GetFreeTableInfo()}";
            }

            return "";            // TODO: ???????????
        }

        public string GetTotalIncome()
        {
            return $"Total income: {totalBill:f2}lv";
        }

        public string LeaveTable(int tableNumber)
        {
            ITable table = tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            decimal tableBill = table.GetBill();            
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Table: {tableNumber}");
            sb.AppendLine($"Bill: {tableBill:f2}");
            totalBill += tableBill;
            table.Clear();           
            return sb.ToString().TrimEnd();

        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            ITable table = tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            IDrink drink = drinks.FirstOrDefault(d => d.Name == drinkName && d.Brand == drinkBrand);

            if (table == null)
            {
                return $"Could not find table {tableNumber}";
            }
            else
            {
                if (drink == null)
                {
                    return $"There is no {drinkName} {drinkBrand} available";
                }
                else
                {
                    table.OrderDrink(drink);
                    //totalBill += drink.Price;
                    return $"Table {tableNumber} ordered {drinkName} {drinkBrand}";
                    
                }
            }
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            ITable table = tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            IBakedFood food = bakedFoods.FirstOrDefault(x => x.Name == foodName);

            if(table == null)
            {
                return $"Could not find table {tableNumber}";
            }
            else
            {
                if(food == null)
                {
                    return $"No {foodName} in the menu";
                }
                else
                {
                    table.OrderFood(food);
                    //totalBill += food.Price;
                    return $"Table {tableNumber} ordered {foodName}";
                    
                }
            }
        }

        public string ReserveTable(int numberOfPeople)
        {
            ITable table = tables.FirstOrDefault(t => t.IsReserved == false);
            if(table == null)
            {
                return $"No available table for {numberOfPeople} people";
            }
            else
            {
                table.Reserve(numberOfPeople);
                //totalBill += table.Price;
                return $"Table {table.TableNumber} has been reserved for {numberOfPeople} people";
            }
        }
    }
}
