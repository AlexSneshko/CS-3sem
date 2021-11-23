using _053506_Snetko_Lab7.Entities;
using System;
using System.Collections.Generic;

namespace _053506_Snetko_Lab7
{
    class Program
    {
        static void Main(string[] args)
        {
            var hau = new HAU();

            hau.AddClient(new Client("Alex"));
            hau.AddClient(new Client("Dima"));
            hau.AddClient(new Client("Petya"));
            hau.AddClient(new Client("Vasya"));
            hau.AddClient(new Client("Vika"));
            hau.AddClient(new Client("Katya"));
            //hau.RemoveClient(new Client("Dima"));
            hau.AddClient(new Client("Zenya"));

            var tarifs = new double[(int)Utilities.All] { 1.2, 0.3, 4.3, 5.7, 9.6, 0.8, 4.5, 8, 7.5, 0.6, 2.3, 2.7 };
            hau.SetAllTarifs(tarifs);

            hau.AddUtilityToClient("Vika", Utilities.Water);
            hau.AddUtilityToClient("Vika", Utilities.Electricity);
            hau.AddUtilityToClient("Alex", Utilities.Elevator);
            hau.AddUtilityToClient("Alex", Utilities.Gas);

            hau.ClientUsingUtility("Vika", Utilities.Water, 40);
            hau.ClientUsingUtility("Vika", Utilities.Electricity, 40);
            hau.ClientUsingUtility("Alex", Utilities.Elevator, 40);
            hau.ClientUsingUtility("Alex", Utilities.Gas, 40);

            hau.GetAllTarifs();
            hau.GetClientsBill("Vika");
            hau.journal.GetAllChanges();
            hau.utilitiesJournal.GetAllChanges();
        }
    }
}
