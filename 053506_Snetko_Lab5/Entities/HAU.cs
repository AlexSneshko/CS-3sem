using _053506_Snetko_Lab5.Collections;
using System;
using System.Collections.Generic;
using System.Text;

namespace _053506_Snetko_Lab5.Entities
{
    public class HAU
    {
        private MyCustomCollection<Client> clients;
        private double[] tarifs;
        public delegate void Manager(string message);
        public event Manager Notify;

        public HAU() => (clients, tarifs) = (new MyCustomCollection<Client>(), new double[(int)Utilities.All]);

        public void AddClient(Client newClient)
        {
            clients.Add(newClient);
            Notify?.Invoke($"Client {newClient} has been added"); 
        }

        public void RemoveClient(Client client)
        {
            try
            {
                var tempClient = client;
                clients.Remove(client);
                Notify?.Invoke($"Client {tempClient} has been deleted");
            }
            catch(NoItemsException e)
            {
                Console.WriteLine(e);
            }          
        }

        public void SetTarif(Utilities utility, int price)
        {
            tarifs[(int)utility] = price;
            Notify?.Invoke($"Tarif {utility} has been changed to price: {price}");
        }

        public double GetTarif(Utilities utility) => tarifs[(int)utility];

        public void SetAllTarifs(double[] newTarifs)
        {
            Array.Copy(newTarifs, tarifs, tarifs.Length);
            Notify?.Invoke($"All tarifs have been initialized");
        }
            
        public void GetAllTarifs()
        {
            Console.WriteLine(new string('-', 30));
            for (int i = 0; i < tarifs.Length; i++)
                Console.WriteLine("{0} tarif: {1}", (Utilities)i, tarifs[i]);
            Console.WriteLine(new string('-', 30));
        }

        public void GetClientsBill(string name)
        {
            for (int i = 0; i < clients.Count; i++)
                if(clients[i].Name == name)
                {
                    Console.WriteLine("{0} bill is {1}$", name, clients[i].GetBill(tarifs));
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
            Notify?.Invoke($"{name} bought {utility} utility"); 
        }

        public void ClientUsingUtility(string name, Utilities utility, int amount) => GetClient(name).UsingUtility(utility, amount); 
    }
}
