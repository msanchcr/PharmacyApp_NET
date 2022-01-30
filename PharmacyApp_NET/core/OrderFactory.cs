using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace PharmacyApp_NET.core
{
    class OrderFactory
    {
        private static OrderFactory instance;

        public Order create (string name, MedicineType type, int amount, Distributor distributor, List<Directions> directions)
        {
            Regex rgx = new Regex("[a-zA-Z0-9]+");
            if (name == null || string.IsNullOrWhiteSpace(name) || !rgx.IsMatch(name))
            {
                throw new ArgumentException($"Expected a medicine name using the regular expression [a-zA-Z0-9]+, but got {name}.");
            }
            if (type == null )
            {
                throw new ArgumentException($"Expected type of medicine, but got {type}.");
            }
            if (amount == null || amount <= 0)
            {
                throw new ArgumentException($"Expected medicine amount>0, but got {amount}.");
            }
            if (distributor == null)
            {
                throw new ArgumentException($"Expected medicine distributor, but got {distributor}.");
            }
            if (directions == null || directions.Count <= 0 )
            {
                throw new ArgumentException("Expected at least one (1) direction where the order should be delivered.");
            }
            return new Order(name, type, amount, distributor, directions);
        }

        public static OrderFactory getInstance()
        {
            if (instance == null)
            {
                instance = new OrderFactory();
            }
            return instance;
        }
    }
}
