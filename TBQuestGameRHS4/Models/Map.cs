using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace TBQuestGameRH.Models
{
    public class Map
    {
        #region FIELDS

        private Location[,] _mapLocations;
        private int _maxRows, _maxColumns;
        private GameMapCoordinates _currentLocationCoordinates;
        private List<GameItem> _standardGameItems;

        #endregion

        #region PROPERTIES

        public Location[,] MapLocations
        {
            get { return _mapLocations; }
            set { _mapLocations = value; }
        }

        public GameMapCoordinates CurrentLocationCoordinates
        {
            get { return _currentLocationCoordinates; }
            set { _currentLocationCoordinates = value; }
        }

        public Location CurrentLocation
        {
            get { return _mapLocations[_currentLocationCoordinates.Row, _currentLocationCoordinates.Column]; }
        }

        public List<GameItem> StandardGameItems
        {
            get { return _standardGameItems; }
            set { _standardGameItems = value; }
        }

        #endregion

        #region CONSTRUCTORS

        public Map(int rows, int columns)
        {
            _maxRows = rows;
            _maxColumns = columns;
            _mapLocations = new Location[rows, columns];
        }

        #endregion

        #region METHODS

        public void MoveNorth()
        {
            if (_currentLocationCoordinates.Row > 0)
            {
                _currentLocationCoordinates.Row -= 1;
            }
        }

        public void MoveEast()
        {
            if (_currentLocationCoordinates.Column < _maxColumns - 1)
            {
                _currentLocationCoordinates.Column += 1;
            }
        }

        public void MoveSouth()
        {
            if (_currentLocationCoordinates.Row < _maxRows - 1)
            {
                _currentLocationCoordinates.Row += 1;
            }
        }

        public void MoveWest()
        {
            if (_currentLocationCoordinates.Column > 0)
            {
                _currentLocationCoordinates.Column -= 1;
            }
        }

        public Location NorthLocation(Player player)
        {
            Location northLocation = null;

            if (_currentLocationCoordinates.Row > 0)
            {
                Location nextNorthLocation = _mapLocations[_currentLocationCoordinates.Row - 1, _currentLocationCoordinates.Column];

                if (nextNorthLocation != null &&
                    (nextNorthLocation.Accessible == true || nextNorthLocation.IsAccessibleByLevel(player.Level)))
                {
                    northLocation = nextNorthLocation;
                }
            }

            return northLocation;
        }

        public Location EastLocation(Player player)
        {
            Location eastLocation = null;

            if (_currentLocationCoordinates.Column < _maxColumns - 1)
            {
                Location nextEastLocation = _mapLocations[_currentLocationCoordinates.Row, _currentLocationCoordinates.Column + 1];

                if (nextEastLocation != null &&
                    (nextEastLocation.Accessible == true || nextEastLocation.IsAccessibleByLevel(player.Level)))
                {
                    eastLocation = nextEastLocation;
                }
            }

            return eastLocation;
        }

        public Location SouthLocation(Player player)
        {
            Location southLocation = null;

            if (_currentLocationCoordinates.Row < _maxRows - 1)
            {
                Location nextSouthLocation = _mapLocations[_currentLocationCoordinates.Row + 1, _currentLocationCoordinates.Column];

                if (nextSouthLocation != null &&
                    (nextSouthLocation.Accessible == true || nextSouthLocation.IsAccessibleByLevel(player.Level)))
                {
                    southLocation = nextSouthLocation;
                }
            }

            return southLocation;
        }

        public Location WestLocation(Player player)
        {
            Location westLocation = null;

            if (_currentLocationCoordinates.Column > 0)
            {
                Location nextWestLocation = _mapLocations[_currentLocationCoordinates.Row, _currentLocationCoordinates.Column - 1];

                if (nextWestLocation != null &&
                    (nextWestLocation.Accessible == true || nextWestLocation.IsAccessibleByLevel(player.Level)))
                {
                    westLocation = nextWestLocation;
                }
            }

            return westLocation;
        }

        #endregion


    }
}
