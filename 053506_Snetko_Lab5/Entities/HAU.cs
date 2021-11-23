﻿using _053506_Snetko_Lab5.Collections;
using System;
using System.Collections.Generic;
using System.Text;

namespace _053506_Snetko_Lab5.Entities
{
    public class HAU
    {
        private MyCustomCollection<Client> clients;
        private double[] tarifs;
        public Journal journal;
        public Journal utilitiesJournal;

        public HAU() => (clients, tarifs, journal, utilitiesJournal) = (new MyCustomCollection<Client>(), new double[(int)Utilities.All], new Journal("Clients and tarifs journal"), new Journal("Utilities journal"));

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
            tarifs[(int)utility] = price;
            journal.Changes += () => Console.WriteLine($"Tarif {utility} has been changed to price: {price}");
        }

        public double GetTarif(Utilities utility) => tarifs[(int)utility];

        public void SetAllTarifs(double[] newTarifs)
        {
            Array.Copy(newTarifs, tarifs, tarifs.Length);
            journal.Changes += () => Console.WriteLine($"All tarifs have been initialized");
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
            utilitiesJournal.Changes += () => Console.WriteLine($"{name} bought {utility} utility"); 
        }

        public void ClientUsingUtility(string name, Utilities utility, int amount) => GetClient(name).UsingUtility(utility, amount); 
    }
}
