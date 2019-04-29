using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuestGameRH.Models
{
    public class Drug : GameItem
    {
        public int HPChange { get; set; }
        public int LevelChange { get; set; }

        public Drug(int id, string name, int value, int hpChange, string description, int levelChange, int level)
            : base(id, name, value, description, level)
        {
            HPChange = hpChange;
            LevelChange = levelChange;
        }

        public override string InformationString()
        {
            if (HPChange != 0 && LevelChange != 0)
            {
                return $"{Name}: {Description}\nHP: {HPChange}\nLevelUp {LevelChange}";
            }
            else if (LevelChange != 0 && HPChange == 0)
            {
                return $"{Name}: {Description}\nLevelUp: {LevelChange}";
            }
            else if (HPChange != 0 && LevelChange == 0)
            {
                return $"{Name}: {Description}\nHP: {HPChange}";
            }
            else
            {
                return $"{Name}: {Description}";
            }
        }
    }
}
