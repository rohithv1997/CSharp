using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTypes;
using EnumTypes;

namespace EntityFactory
{
    public class Attribute
    {
        public string Name { get; set; }
        public DataTypeValues dataType { get; set; }
        public string Label { get; set; }
    }

    public class Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        List<Attribute> x = new List<Attribute>();
        public List<Attribute> Attributes
        {
            get { return x; }
            set { x = value; }
        }

    }

    public class EntityCollections
    {
        List<Entity> ec = new List<Entity>();
        public List<Entity> Entities
        {
            get { return ec; }
            set { ec = value; }
        }
    }

}
