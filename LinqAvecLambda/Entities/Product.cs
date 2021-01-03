using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace LinqAvecLambda.Entities
{
    class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public Category Category { get; set; }

        public override string ToString()
        {
            return Id
                + ", "
                + Name
                + ", "
                + Price.ToString("F2", CultureInfo.InvariantCulture)
                + ", "
                + Category.Id
                + ", "
                + Category.Name;
        }
    }
}
