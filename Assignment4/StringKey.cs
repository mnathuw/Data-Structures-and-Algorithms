using System;

namespace Assignment4
{
    public class StringKey : IComparable<StringKey>
    {
        public string KeyName { get; set; }
        public StringKey(String keyName)
        {
            this.KeyName = keyName;
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
                    StringKey other = (StringKey)obj;
                    if (this.KeyName == other.KeyName)
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

        public int CompareTo(StringKey other)
        {
            return this.KeyName.CompareTo(other.KeyName);
        }

        public override int GetHashCode()
        {
            int hashCode = 0;
            for (int i = 0; i < this.KeyName.Length; i++)
            {
                hashCode += (int)this.KeyName[i] * Power(31, i);
            }
            if (hashCode > Int32.MaxValue)
            {
                return 1;
            }
            return Math.Abs(hashCode);
        }

        private int Power(int num, int pow)
        {
            if (pow == 0)
            {
                return 1;
            }
            else
            {
                return (num * Power(num, pow - 1));
            }
        }

        public override String ToString()
        {
            return String.Format("KeyName: {0} HashCode: {1}",
                this.KeyName, this.GetHashCode());
        }
    }
}