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

            hau.AddClient(new Client("Alex"));
            hau.AddClient(new Client("Dima"));
            hau.AddClient(new Client("Petya"));
            hau.AddClient(new Client("Vasya"));
            hau.AddClient(new Client("Vika"));
            hau.AddClient(new Client("Katya"));

            var tarifs = new double[(int)Utilities.All] { 1.2, 0.3, 4.3, 5.7, 9.6, 0.8, 4.5, 8, 7.5, 0.6, 2.3, 2.7 };
            hau.SetAllTarifs(tarifs);

            hau.GetClient("Vika").AddUtility(new Utility(Utilities.Water));
            hau.GetClient("Vika").AddUtility(new Utility(Utilities.Electricity));
            hau.GetClient("Alex").AddUtility(new Utility(Utilities.Elevator));
            hau.GetClient("Alex").AddUtility(new Utility(Utilities.Gas));

            hau.GetClient("Vika").UsingUtility(Utilities.Water, 40);
            hau.GetClient("Vika").UsingUtility(Utilities.Electricity, 150);
            hau.GetClient("Alex").UsingUtility(Utilities.Elevator, 40);
            hau.GetClient("Alex").UsingUtility(Utilities.Gas, 150);

            hau.GetClientsBill("Vika");
            hau.GetClientsBill("Alex");
            hau.GetAllTarifs();
        }
    }
}
