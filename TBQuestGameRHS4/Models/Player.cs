using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace TBQuestGameRH.Models
{
    public class Player : Character, IBattle
    {
        #region ENUMS

        public new enum Status
        {
            Normal, Frenzied, Hallucinating
        }

        #endregion

        #region DAMAGE VARIABLES

        private const int DEFENDER_DAMAGE_ADJUSTMENT = 10;
        private const int MAXIMUM_RUN_AWAY_DAMAGE = 10;

        #endregion

        #region FIELDS

        protected new int _id;
        protected new string _name;
        protected new int _locationid;
        private int _hp;
        protected new bool _isAlive;
        protected new Status _status;
        protected int _level;
        private int _skillLevel;
        private Weapon _currentWeapon;
        private BattleModeName _battleMode;
        private List<Location> _locationsVisited;
        private ObservableCollection<GameItemQuantity> _inventory;
        private ObservableCollection<GameItemQuantity> _drugs;
        private ObservableCollection<GameItemQuantity> _loot;
        private ObservableCollection<GameItemQuantity> _weapons;
        
        #endregion

        #region PROPERTIES

        public new string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public new int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public new int LocationId
        {
            get { return _locationid; }
            set { _locationid = value; }
        }

        public new int HP
        {
            get { return _hp; }
            set { _hp = value; }
        }

        public new bool IsAlive
        {
            get { return _isAlive; }
            set { _isAlive = value; }
        }

        public new Status CurrentStatus
        {
            get { return _status; }
            set { _status = value; }
        }

        public int Level
        {
            get { return _level; }
            set { _level = value; }
        }

        public List<Location> LocationsVisited
        {
            get { return _locationsVisited; }
            set { _locationsVisited = value; }
        }

        public ObservableCollection<GameItemQuantity> Inventory
        {
            get { return _inventory; }
            set { _inventory = value; }
        }

        public ObservableCollection<GameItemQuantity> Weapons
        {
            get { return _weapons; }
            set { _weapons = value; }
        }

        public ObservableCollection<GameItemQuantity> Drugs
        {
            get { return _drugs; }
            set { _drugs = value; }
        }

        public ObservableCollection<GameItemQuantity> Loot
        {
            get { return _loot; }
            set { _loot = value; }
        }

        public int SkillLevel
        {
            get { return _skillLevel; }
            set { _skillLevel = value; }
        }

        public Weapon CurrentWeapon
        {
            get { return _currentWeapon; }
            set { _currentWeapon = value; }
        }

        public BattleModeName BattleMode
        {
            get { return _battleMode; }
            set { _battleMode = value; }
        }


        #endregion

        #region CONSTRUCTORS

        public Player()
        {
            _locationsVisited = new List<Location>();
            _weapons = new ObservableCollection<GameItemQuantity>();
            _loot = new ObservableCollection<GameItemQuantity>();
            _drugs = new ObservableCollection<GameItemQuantity>();
            
        }

        public override string DefaultGreeting()
        {
            return "What's the score here?";
        }

        public override string DefaultFarewell()
        {
            return "Buy the ticket, take the ride.";
        }

        #endregion

        #region METHODS

        public void UpdateInventoryCategories()
        {
            Drugs.Clear();
            Weapons.Clear();
            Loot.Clear();

            foreach (var gameItemQuantity in _inventory)
            {
                if (gameItemQuantity.GameItem is Drug) Drugs.Add(gameItemQuantity);
                if (gameItemQuantity.GameItem is Weapon) Weapons.Add(gameItemQuantity);
                if (gameItemQuantity.GameItem is Loot) Loot.Add(gameItemQuantity);
            }
        }

        public void AddGameItemQuantityToInventory(GameItemQuantity selectedGameItemQuantity)
        {
            GameItemQuantity gameItemQuantity = _inventory.FirstOrDefault(i => i.GameItem.Id == selectedGameItemQuantity.GameItem.Id);

            if (gameItemQuantity == null)
            {
                GameItemQuantity newGameItemQuantity = new GameItemQuantity();
                newGameItemQuantity.GameItem = selectedGameItemQuantity.GameItem;
                newGameItemQuantity.Quantity = 1;

                _inventory.Add(newGameItemQuantity);
            }
            else
            {
                gameItemQuantity.Quantity++;
            }

            UpdateInventoryCategories();
        }

        public void RemoveGameItemQuantityFromInventory(GameItemQuantity selectedGameItemQuantity)
        {
            GameItemQuantity gameItemQuantity = _inventory.FirstOrDefault(i => i.GameItem.Id == selectedGameItemQuantity.GameItem.Id);

            if (gameItemQuantity != null)
            {
                if (selectedGameItemQuantity.Quantity == 1)
                {
                    _inventory.Remove(gameItemQuantity);
                }
                else
                {
                    gameItemQuantity.Quantity--;
                }
            }

            UpdateInventoryCategories();
        }

        #region BATTLE METHODS

        public int Attack()
        {
            int hitPoints = random.Next(CurrentWeapon.MinimumDamage, CurrentWeapon.MaximumDamage) * _skillLevel;

            if (hitPoints <= 100)
            {
                return hitPoints;
            }
            else
            {
                return 100;
            }
        }

        public int Defend()
        {
            int hitPoints = (random.Next(CurrentWeapon.MinimumDamage, CurrentWeapon.MaximumDamage) * _skillLevel) - DEFENDER_DAMAGE_ADJUSTMENT;

            if (hitPoints >= 0 && hitPoints <= 100)
            {
                return hitPoints;
            }
            else if (hitPoints > 100)
            {
                return 100;
            }
            else
            {
                return 0;
            }
        }

        public int RunAway()
        {
            int hitPoints = _skillLevel * MAXIMUM_RUN_AWAY_DAMAGE;

            if (hitPoints <= 100)
            {
                return hitPoints;
            }
            else
            {
                return 100;
            }
        }

        #endregion

        public bool HasVisited(Location location)
        {
            return _locationsVisited.Contains(location);
        }

        #endregion
    }
}
