﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class LobbyType
    {
        public string id;
        public string name;
        public long minTablePrice;

        public LobbyType(string id, string name, long minTablePrice)
        {
            this.id = id;
            this.name = name;
            this.minTablePrice = minTablePrice;
        }

        public LobbyType() { }

        bool isNull()
        {
            return id == null || name == null;
        }

        public bool Equals(LobbyType other)
        {
            return this.id.Equals(other.id) &&
                this.name.Equals(other.name) &&
                this.minTablePrice.Equals(other.minTablePrice);
        }
    }
}
