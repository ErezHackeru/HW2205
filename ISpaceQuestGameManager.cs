using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2205_SpaceGame_Events
{
    interface ISpaceQuestGameManager
    {        
        event EventHandler<PointsEventArgs> GoodSpaceShipHPChanged;
        event EventHandler<LocationEventArgs> GoodSpaceShipLocationChanged;
        event EventHandler<LocationEventArgs> GoodSpaceShipDestroyed;
        event EventHandler<BadShipsExplodedEventArgs> BadShipsExploded;
        event EventHandler<LevelEventArgs> LevelUpReached;
        
        void MoveSpaceShip(int newX, int newY);
        void GoodSpaceShipGotDamaged(int damage);
        void GoodSpaceShipGotExtraHP(int extra);
        void EnemyShipsDestroyed(int numberOfBadShipsDestroyed);

        void OnGoodSpaceShipHPChanged();
        void OnGoodSpaceShipLocationChanged();
        void OnGoodSpaceShipDestroyed();
        void OnBadShipsExploded();
        void OnLevelUpReached();
    }
}
