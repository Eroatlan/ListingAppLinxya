using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListingSoftware
{
    class Software
    {
        private String identifyingNumber;
        private String name;
        private String vendor;
        private String installLocation;
        private String productID;
        private String version;
        private List<WeightedKey> keys;

        public Software (String idN, String name, String vend, String instLoc, String prodID, String ver)
        {
            this.identifyingNumber = idN;
            this.name = name;
            this.vendor = vend;
            this.installLocation = instLoc;
            this.productID = prodID;
            this.version = ver;
            this.keys = new List<WeightedKey>();
        }


        public String getIdentifyingNumber()
        { return this.identifyingNumber; }
        public String getName()
        { return this.name; }
        public String getVendor ()
        { return this.vendor; }
        public String getInstallLocation ()
        { return this.installLocation; }
        public String getProductID()
        { return this.productID; }
        public String getVersion()
        { return this.version; }


        //Functions to manipulate weighted keys
        public void addKey (String val, int weight)
        { this.keys.Add(new WeightedKey(val, weight)); }
        public List<WeightedKey> getKeys ()
        { return this.keys; }


        //to adapt Console => Appli
        public String toString()
        {
            String ret;
            ret = "Entry ==> Name : " + this.name; //+ " - Vendor : " + this.vendor;
            return ret;
        }
    }
}
