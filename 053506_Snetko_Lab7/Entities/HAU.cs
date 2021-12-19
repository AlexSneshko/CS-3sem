using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _053506_Snetko_Lab7.Entities
{
    public class HAU
    {
        private List<Client> clients;
        private Dictionary<Utilities, double> tarifs;
        //private double[] tarifs;
        public Journal journal;
        public Journal utilitiesJournal;

        public HAU() => (clients, tarifs, journal, utilitiesJournal) = (new List<Client>(), new Dictionary<Utilities, double>((int)Utilities.All), new Journal("Clients and tarifs journal"), new Journal("Utilities journal"));

        public void AddClient(Client newClient)
        {
            clients.Add(newClient);
            journal.Changes += () => Console.WriteLine($"Client {newClient} has been added"); 
        }

        public void RemoveClient(Client client)
        {
            try
            {
                var tempClient = client;
                clients.Remove(client);
                journal.Changes += () => Console.WriteLine($"Client {tempClient} has been deleted");
            }
            catch(NoItemsException e)
            {
                Console.WriteLine(e);
            }          
        }

        public void SetTarif(Utilities utility, int price)
        {
            tarifs[utility] = price;
            journal.Changes += () => Console.WriteLine($"Tarif {utility} has been changed to price: {price}");
        }

        public double GetTarif(Utilities utility) => tarifs[utility];

        public void SetAllTarifs(double[] newTarifs)
        {
            tarifs.Clear();
            for(int i = 0; i < (int)Utilities.All; i++)
                tarifs.Add((Utilities)i, newTarifs[i]);
            
            journal.Changes += () => Console.WriteLine($"All tarifs have been initialized");
        }
            
        public void GetAllTarifs()
        {
            Console.WriteLine(new string('-', 30));
            for (int i = 0; i < tarifs.Count; i++)
                Console.WriteLine("{0} tarif: {1}", (Utilities)i, tarifs[(Utilities)i]);
            Console.WriteLine(new string('-', 30));
        }

        public void GetClientsBill(string name)
        {
            for (int i = 0; i < clients.Count; i++)
                if(clients[i].Name == name)
                {
                    Console.WriteLine("{0}'s bill is {1}$", name, clients[i].GetBill(tarifs));
                    break;
                }  
        }

        private Client GetClient(string name)
        {
            for (int i = 0; i < clients.Count; i++)
                if (clients[i].Name == name)
                    return clients[i];

            throw new NullReferenceException();
        }

        public void AddUtilityToClient(string name, Utilities utility)
        {
            GetClient(name).AddUtility(new Utility(utility));
            utilitiesJournal.Changes += () => Console.WriteLine($"{name} bought {utility} utility"); 
        }

        public void ClientUsingUtility(string name, Utilities utility, int amount) => GetClient(name).UsingUtility(utility, amount); 

        public IEnumerable<Utilities> GetSortedUtilitiesList() => tarifs.OrderBy(_ => _.Value).Select(_ => _.Key);

        public double TotalCostOfUtilitiesSold() => clients.Select(_ => _.GetBill(tarifs)).Sum();

        public Client GetRichestClient() => clients.OrderByDescending(_ => _.GetBill(tarifs)).First();

        public int GetClentsAmountMoreRange(double range) => clients.Select(_ => _.GetBill(tarifs) > range).Count();

 

    }
}
//public int GetClentsAmountMoreMedieum(double range) => (int)clients.Select(_=>_.GetBill(tarifs)).Aggregate((a, b) => Convert.ToDouble(a > range) + Convert.ToDouble(b > range));