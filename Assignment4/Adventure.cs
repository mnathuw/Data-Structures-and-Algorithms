using System;
using System.IO;

namespace Assignment4
{
    public class Adventure
    {
        private HashMap<StringKey, Item> map;

        public Adventure(string filename)
        {
            if (filename == null)
            {
                throw new ArgumentNullException();
            }
            if (File.Exists(@filename))
            {
                this.map = new HashMap<StringKey, Item>();
                StreamReader file = new StreamReader(@filename);
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    string[] words = line.Split(',');
                    for (int i = 0; i < words.Length; i++)
                    {
                        words[i] = words[i].Trim();
                    }
                    StringKey key = new StringKey(words[0]);
                    Item item = new Item(words[0], Convert.ToInt32(words[1]), Convert.ToDouble(words[2]));
                    this.map.Put(key, item);
                }
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public HashMap<StringKey, Item> GetMap()
        {
            return this.map;
        }

        public String PrintLootMap()
        {
            int valueNumber = this.map.Table.Length;
            String lootMap  = "";
            for (int i = 0; i < valueNumber; i++)
            {
                if (this.map.Table[i] == null || this.map.Table[i].Value.GoldPieces == 0)
                {
                    Entry<StringKey, Item> temp = this.map.Table[i];
                    this.map.Table[i] = this.map.Table[valueNumber - 1];
                    this.map.Table[valueNumber - 1] = temp;
                    valueNumber--;
                    i--;
                }
            }
            for (int i = valueNumber - 1; i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (this.map.Table[j].Key.KeyName.CompareTo(this.map.Table[j + 1].Key.KeyName) > 0)
                    {
                       
                        Entry<StringKey, Item> temp = this.map.Table[j];
                        this.map.Table[j] = this.map.Table[j + 1];
                        this.map.Table[j + 1] = temp;
                    }
                }
            }

            for (int i = 0; i < valueNumber; i++)
            {
                lootMap += this.map.Table[i].Value.ToString() + "\n";
            }
            return lootMap;
        }
    }
}