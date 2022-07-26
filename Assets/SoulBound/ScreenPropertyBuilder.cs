using System.Collections.Generic;

namespace SoulBound
{
    class ScreenPropertyBuilder
    {
        private string name;
        public ScreenPropertyBuilder SetName(string name)
        {
            this.name = name;
            return this;
        }

        public Dictionary<string, object> Build()
        {
            if (name == null)
            {
                throw new Exception("Key \"name\" is required in properties");
            }
            Dictionary<string, object> property = new Dictionary<string, object>();
            property.Add("name", name);
            return property;
        }
    }
}