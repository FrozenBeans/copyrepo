using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public class ResLocation
    {
        private string _City;
        private string _State;
        private string _ResName;

        public int locationID { get; set; }
        public int? Zipcode { get; set; }

        public string State
        {
            get=> _State; set
            { 
                if (value.Length > 2)
            {
                    throw new ArgumentException("State cannot be more than 2 characters");
            }
            _State = value;
            }
        }
        public string City
        {
            get => _City; set
            {
                if (value.Length > 20)
                    throw new ArgumentException("City cannot be more than 20 characters");
                _City = value;
            }
        }

        public string ResName
        {
            get => _ResName;
            set {
                if (value.Length > 30)
                    throw new ArgumentException("Restaurant name cannot be more than 30 characters");
                _ResName = value;
            }
        }
    }
}
