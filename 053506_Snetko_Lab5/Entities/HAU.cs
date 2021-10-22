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

        public HAU() => (clients, tarifs) = (new MyCustomCollection<Client>(), new double[(int)Utilities.All]);

        public void AddClient(Client newClient) => clients.Add(newClient);
        public void RemoveClient(Client client) => clients.Remove(client);

        public void SetTarif(Utilities utility, int price) => tarifs[(int)utility] = price;
        public double GetTarif(Utilities utility) => tarifs[(int)utility];

        public void SetAllTarifs(double[] newTarifs) => Array.Copy(newTarifs, tarifs, tarifs.Length);

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

        public Client GetClient(string name)
        {
            for (int i = 0; i < clients.Count; i++)
                if (clients[i].Name == name)
                    return clients[i];

            throw new NullReferenceException();
        }
    }
}
