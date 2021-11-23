using System;
using System.Collections.Generic;
using System.Text;

namespace _053506_Snetko_Lab7.Entities
{
    public class Client
    { 
        public string Name { get; }
        private List<Utility> utilities;
        private Print utilityPurchases;
        public Print UtilityPurchases { get => (() => Console.WriteLine($"Name :{Name}")) + utilityPurchases + (() => Console.WriteLine()); }

        public Client(string name) => (Name, utilities) = (name, new List<Utility>());

        public void AddUtility(Utility newUtility)
        {
            if (!utilities.Contains(newUtility)) utilities.Add(newUtility);
            utilityPurchases += () => Console.WriteLine($"Added {newUtility.Name}");
        }

        public void RemoveUtility(Utility utility)
        {
            if (!utilities.Contains(utility)) utilities.Remove(utility);
        }

        public void UsingUtility(Utilities utility, int amount)
        {
            for (int i = 0; i < utilities.Count; i++)  
                if(utilities[i].Name == utility)
                {
                    utilities[i].Using(amount);
                    break;
                }        
        }

        public double GetBill(Dictionary<Utilities, double> tarifs)
        {
            double sum = 0;
            for (int i = 0; i < utilities.Count; i++)
                sum += utilities[i].Consumption * tarifs[(Utilities)i];

            return sum;
        }

        public override string ToString() => Name;

        public override bool Equals(object obj)
        {
            if(obj is Client client)
                return Name.Equals(client.Name);
            
            return false;
        }
    }  
}
