using _053506_Snetko_Lab5.Collections;
using _053506_Snetko_Lab5.Entities;
using System;
using System.Collections.Generic;

namespace _053506_Snetko_Lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            var hau = new HAU();
            var journal = new Journal();
            hau.Notify += journal.Add;

            hau.AddClient(new Client("Alex"));
            hau.AddClient(new Client("Dima"));
            hau.AddClient(new Client("Petya"));
            hau.AddClient(new Client("Vasya"));
            hau.AddClient(new Client("Vika"));
            hau.AddClient(new Client("Katya"));
            hau.RemoveClient(new Client("Oxxxymiron"));
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


            journal.GetAllChanges();
        }
    }
}
/*
             hau.GetClient("Vika").AddUtility(new Utility(Utilities.Water));
            hau.GetClient("Vika").AddUtility(new Utility(Utilities.Electricity));
            hau.GetClient("Alex").AddUtility(new Utility(Utilities.Elevator));
            hau.GetClient("Alex").AddUtility(new Utility(Utilities.Gas));

            hau.GetClient("Vika").UsingUtility(Utilities.Water, 40);
            hau.GetClient("Vika").UsingUtility(Utilities.Electricity, 150);
            hau.GetClient("Alex").UsingUtility(Utilities.Elevator, 40);
            hau.GetClient("Alex").UsingUtility(Utilities.Gas, 150);

            Print GetPeopleUtilities = hau.GetClient("Alex").UtilityPurchases;
            GetPeopleUtilities += hau.GetClient("Dima").UtilityPurchases;
            GetPeopleUtilities += hau.GetClient("Petya").UtilityPurchases;
            GetPeopleUtilities += hau.GetClient("Vasya").UtilityPurchases;
            GetPeopleUtilities += hau.GetClient("Vika").UtilityPurchases;
            GetPeopleUtilities += hau.GetClient("Katya").UtilityPurchases;*/
