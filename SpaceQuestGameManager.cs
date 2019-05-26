using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2205_SpaceGame_Events
{
    class SpaceQuestGameManager : ISpaceQuestGameManager
    {
        int _goodSpaceShipHitPoints;
        int _shipXLocation;
        int _shipYLocation;
        int _numberOfBadShips;
        public int _currentLevel;

        public event EventHandler<PointsEventArgs> GoodSpaceShipHPChanged;
        public event EventHandler<LocationEventArgs> GoodSpaceShipLocationChanged;
        public event EventHandler<LocationEventArgs> GoodSpaceShipDestroyed;
        public event EventHandler<BadShipsExplodedEventArgs> BadShipsExploded;
        public event EventHandler<LevelEventArgs> LevelUpReached;

        public SpaceQuestGameManager(int goodSpaceShipHitPoints, int shipXLocation, 
            int shipYLocation, int numberOfBadShips, int currentLevel)
        {
            _goodSpaceShipHitPoints = goodSpaceShipHitPoints;
            _shipXLocation = shipXLocation;
            _shipYLocation = shipYLocation;
            _numberOfBadShips = numberOfBadShips;
            _currentLevel = currentLevel;
        }

        public void EnemyShipsDestroyed(int numberOfBadShipsDestroyed)
        {
            if (BadShipsExploded != null)
            {
                BadShipsExploded.Invoke(this, 
                    new BadShipsExplodedEventArgs() { NumberOfExplodedBadShips = numberOfBadShipsDestroyed });
            }
        }

        public void GoodSpaceShipGotDamaged(int damage)
        {
            if (GoodSpaceShipHPChanged != null)
            {
                GoodSpaceShipHPChanged.Invoke(this, new PointsEventArgs() { HitPoints = damage});
            }
        }

        public void GoodSpaceShipGotExtraHP(int extra)
        {
            if (GoodSpaceShipHPChanged != null)
            {
                GoodSpaceShipHPChanged.Invoke(this, 
                    new PointsEventArgs() { HitPoints = _goodSpaceShipHitPoints + extra });
            }
        }

        public void MoveSpaceShip(int newX, int newY)
        {
            if (GoodSpaceShipLocationChanged != null)
            {
                GoodSpaceShipLocationChanged.Invoke(this,
                    new LocationEventArgs() { X = newX, Y = newY });
            }
        }

        public void OnBadShipsExploded()
        {
            if (BadShipsExploded != null)
            {
                BadShipsExploded.Invoke(this,
                    new BadShipsExplodedEventArgs() { NumberOfExplodedBadShips  =_numberOfBadShips-- });
            }
        }

        public void OnGoodSpaceShipDestroyed()
        {
            if (GoodSpaceShipDestroyed != null)
            {
                GoodSpaceShipDestroyed.Invoke(this,
                    new LocationEventArgs() { X=0,Y=0 }); // what is the new location ?
            }
        }

        public void OnGoodSpaceShipHPChanged()
        {
            if (GoodSpaceShipHPChanged != null)
            {
                GoodSpaceShipHPChanged.Invoke(this,
                    new PointsEventArgs() { HitPoints = _goodSpaceShipHitPoints }); 
            }
        }

        public void OnGoodSpaceShipLocationChanged()
        {
            if (GoodSpaceShipLocationChanged != null)
            {
                GoodSpaceShipLocationChanged.Invoke(this,
                    new LocationEventArgs() {X=_shipXLocation, Y=_shipYLocation });
            }
        }

        public void OnLevelUpReached()
        {
            if (LevelUpReached != null)
            {
                LevelUpReached.Invoke(this,
                    new LevelEventArgs() { CurrentLevel = _currentLevel++ });
            }            
        }

        public override string ToString()
        {
            return $"_goodSpaceShipHitPoints {_goodSpaceShipHitPoints} _shipXLocation "+
                $"{_shipXLocation} _shipYLocation {_shipYLocation} _numberOfBadShips {_numberOfBadShips}"+
                $"_currentLevel {_currentLevel}";
        }
    }
}
