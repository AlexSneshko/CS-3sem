using _053506_Snetko_Lab5.Collections;
using System;
using System.Collections.Generic;
using System.Text;

namespace _053506_Snetko_Lab5.Entities
{
    public class Client
    { 
        public string Name { get; }
        private MyCustomCollection<Utility> utilities;

        public Client(string name) => (Name, utilities) = (name, new MyCustomCollection<Utility>());

        public void AddUtility(Utility newUtility)
        {
            if (!utilities.Contains(newUtility)) utilities.Add(newUtility);
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

        public double GetBill(double[] tarifs)
        {
            double sum = 0;
            for (int i = 0; i < utilities.Count; i++)
                sum += utilities[i].Consumption * tarifs[(int)utilities[i].Name];

            return sum;
        }
    }

    
}
