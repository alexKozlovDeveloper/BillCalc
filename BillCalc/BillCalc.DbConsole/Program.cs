using BillCalc.DAL.EF;
using System;

namespace BillCalc.DbConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new BillCalcContext(""))
            {
                //var players = db.Players.ToList();
                //foreach (var p in players)
                //    Console.WriteLine($"{p.Name} - {p.Team.Name}");

                //var teams = db.Teams.ToList();
                //foreach (var t in teams)
                //{
                //    Console.WriteLine($"{t.Name}");
                //    foreach (var p in t.Players)
                //        Console.WriteLine($"{p.Name}");
                //}
            }
        }
    }
}
