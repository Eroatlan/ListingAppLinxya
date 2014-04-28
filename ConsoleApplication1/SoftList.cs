using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListingSoftware
{
    class SoftList : List<Software>
    {
        private List<Software> list;

        //implementation of List constructor
        public SoftList() : base()
        {
            this.list = new List<Software>();
        }

        //function to tell if a value exists with the given name in the list
        public bool match (String name)
        {
            foreach (Software soft in this.list)
            {
                try
                {
                    if (soft.getName().Equals(name))
                    {
                        return true;
                    }
                }
                catch(Exception)
                {
                }
            }
            return false;
        }

        public void addSoft (Software soft)
        {
            this.list.Add(soft);
        }

        public List<Software> getList()
        {
            return this.list;
        }
        public void firstTurn()
        {
            Registre r= new Registre();
            Ways w = new Ways();

            Dictionary <String, PathValue> d = w.getDico();

            foreach(Software s in list)
            {
                if (d.ContainsKey(s.getName()))
                {
                    s.addKey(r.readValue(d[s.getName()]), 100);
                }
            }
        }
    }
}
