using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListingSoftware
{
    class RegGuess
    {
        private String name;
        private List<String> values;

        public RegGuess(String name)
        {
            this.name = name;
            this.values = new List<String>();
        }

        public void addValue(String val)
        {
            this.values.Add(val);
        }

        public void addValueRange(List<String> val)
        {
            this.values.AddRange(val);
        }

        public List<String> getValues()
        { return this.values; }

        public String getName()
        { return this.name; }

        public String toString()
        {
            String result = ("Reg entry ==> Name : " + this.name + " - Values : " + this.values);
            return result;
        }
    }
}
