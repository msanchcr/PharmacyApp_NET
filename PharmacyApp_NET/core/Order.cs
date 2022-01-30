using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyApp_NET.core
{
    public enum MedicineType { PAINKILLER, ANALEPTIC, ANESTHETIC, ANTACID, ANTIDEPRESSANT, ANTIBIOTIC }
    public enum Distributor { COFARMA, EMPSEPHAR, CEMEFAR }
    public enum Directions { ROSA, ALCAZABILLA }
    public class Order
    {
        private string name;
        private MedicineType type;
        private int amount;
        private Distributor distributor;
        private List<Directions> directions;

        public Order(string name, MedicineType type, int amount, Distributor distributor, List<Directions> directions)
        {
            this.name = name;
            this.type = type;
            this.amount = amount;
            this.distributor = distributor;
            this.directions = directions;
        }

        public string getName()
        {
            return this.name;
        }

        public MedicineType getType()
        {
            return this.type;
        }

        public int getAmount()
        {
            return this.amount;
        }

        public Distributor getDistributor()
        {
            return this.distributor;
        }

        public List<Directions> getDirections ()
        {
            return this.directions;
        }

        public void setName(string name)
        {
            this.name = name;
        }

        public void setType(MedicineType type)
        {
            this.type = type;
        }

        public void setAmount(int amount)
        {
            this.amount = amount;
        }

        public void setDistributor(Distributor distributor)
        {
            this.distributor = distributor;
        }

        public void setDirections(List<Directions> directions)
        {
            this.directions = directions;
        }

        public string toString()
        {
            return $"[name: {this.getName()}, type: {this.getType()}, amount: {this.getAmount()}, distributor: {this.getDistributor()}, directions: {String.Join(", ", this.getDirections().ToArray())}]";
        }
    }
}
