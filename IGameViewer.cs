using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2205_SpaceGame_Events
{
    interface IGameViewer
    {
        void GoodSpaceShipHPChangedEventHandler(object sender, PointsEventArgs e);
        void GoodSpaceShipLocationChangedEventHandler(object sender, LocationEventArgs e);
        void GoodSpaceShipDestroyedEventHandler(object sender, LocationEventArgs e);
        void BadShipExplodedEventHandler(object sender, BadShipsExplodedEventArgs e);
        void LevelUpReachedChangedEventHandler(object sender, LevelEventArgs e);
    }
}
