using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Timers;
using System.Threading.Tasks;

namespace HW2205_SpaceGame_Events
{
    class Program
    {
        static void Main(string[] args)
        {
            SpaceQuestGameManager sqGm = new SpaceQuestGameManager(100, 350, 630, 85, 0);
            GameViewer gV = new GameViewer();

            //inserting functions into the SpaceQuestGameManager events:
            sqGm.BadShipsExploded += gV.BadShipExplodedEventHandler;
            sqGm.GoodSpaceShipDestroyed += gV.GoodSpaceShipDestroyedEventHandler;
            sqGm.GoodSpaceShipHPChanged += gV.GoodSpaceShipHPChangedEventHandler;
            sqGm.GoodSpaceShipLocationChanged += gV.GoodSpaceShipLocationChangedEventHandler;
            sqGm.LevelUpReached += gV.LevelUpReachedChangedEventHandler;
            Console.WriteLine("===Status: ===");
            sqGm.ToString();

            do
            {
                sqGm.MoveSpaceShip(280, 690);
                Thread.Sleep(500);
                sqGm.OnGoodSpaceShipDestroyed();
                Thread.Sleep(500);
                sqGm.OnLevelUpReached();
                Thread.Sleep(500);
                sqGm.OnBadShipsExploded();
                Thread.Sleep(500);
                sqGm.OnGoodSpaceShipHPChanged();
                Thread.Sleep(500);
                sqGm.OnGoodSpaceShipLocationChanged();

                Console.WriteLine("===Status: ===");
                sqGm.ToString();
            }
            while (sqGm._currentLevel <= 3);

            System.Timers.Timer t = new System.Timers.Timer(500);
            t.Elapsed += ElapsedEventHandler;
            t.Start();

            while (true) { }

            Console.ReadKey();
        }
        public static void ElapsedEventHandler(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine(e.SignalTime);
        }
    }
}
