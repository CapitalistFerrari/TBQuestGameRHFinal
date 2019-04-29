using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuestGameRH.Models
{
    public abstract class NPC : Character
    {
        public string Description { get; set; }
        public string Information
        {
            get
            {
                return InformationText();
            }
            set
            {

            }
        }

        public NPC()
        {

        }

        public NPC(int id, string name, string description, int locationid)
            : base(name, id, locationid)
        {
            ID = id;
            Name = name;
            Description = description;
            LocationId = locationid;

        }

        protected abstract string InformationText();
    }
}
