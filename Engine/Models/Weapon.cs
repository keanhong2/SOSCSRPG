using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    public class Weapon : GameItem
    {
        public int MinimunDamaged { get; set; }
        public int MaximumDamaged { get; set; }

        public Weapon(int itemTypeID, string name, int price, int maximumDamaged , int minimumDamaged)
            : base(itemTypeID, name, price)
        {
            MinimunDamaged = MinimunDamaged;
            MaximumDamaged = maximumDamaged;
        }

        public new Weapon Clone()
        {
            return new Weapon(ItemTypeID, Name, Price, MinimunDamaged, MaximumDamaged);
        }
    }
}
