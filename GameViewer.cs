using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2205_SpaceGame_Events
{
    class GameViewer : IGameViewer
    {
        public void BadShipExplodedEventHandler(object sender, BadShipsExplodedEventArgs e)
        {
            Console.WriteLine(sender);
            Console.WriteLine($"Number of Bad Ship Exploded {e.NumberOfExplodedBadShips}");
        }

        public void GoodSpaceShipDestroyedEventHandler(object sender, LocationEventArgs e)
        {
            Console.WriteLine(sender);
            Console.WriteLine($"Good SpaceShip Destroyed Location X:{e.X} Y: {e.Y}");
        }

        public void GoodSpaceShipHPChangedEventHandler(object sender, PointsEventArgs e)
        {
            Console.WriteLine(sender);
            Console.WriteLine($"Number of Good SpaceShip hits {e.HitPoints}");
        }

        public void GoodSpaceShipLocationChangedEventHandler(object sender, LocationEventArgs e)
        {
            Console.WriteLine(sender);
            Console.WriteLine($"Good SpaceShip Location Changed new location is: X- {e.X}, Y- {e.Y}");
        }

        public void LevelUpReachedChangedEventHandler(object sender, LevelEventArgs e)
        {
            Console.WriteLine(sender);
            Console.WriteLine($"Level Up Reached Changed. Current level is: {e.CurrentLevel}");
        }
    }
}
