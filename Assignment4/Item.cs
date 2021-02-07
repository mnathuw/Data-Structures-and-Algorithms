using System;

namespace Assignment4
{
    public class Item : IComparable<Item>
    {
        public string Name { get; set; }
        public int GoldPieces { get; set; }
        public double Weight { get; set; }

        public Item(string name, int goldPieces, double weight)
        {
            this.Name = name;
            this.GoldPieces = goldPieces;
            this.Weight = weight;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            else
            {
                if (this.GetType().Equals(obj.GetType()))
                {
                    Item other = (Item)obj;
                    if (this.Name == other.Name && this.GoldPieces == other.GoldPieces
                        && this.Weight == other.Weight)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
        }

        public int CompareTo(Item other)
        {
            return this.Name.CompareTo(other.Name);
        }

        public override String ToString()
        {
            return String.Format("{0} is worth {1}gp and weighs {2}kg",
                this.Name, this.GoldPieces, this.Weight);
        }
    }
}