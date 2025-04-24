using MandatoryAssignment.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleFrameworkUse.Abstract
{
    public abstract class FlyItem : IWorldItem
    {
        protected FlyItem(string name)
        {
            Name = name;
        }
        public string Name { get; set; }

        public void Use(IWorldEntity user)
        {
            throw new NotImplementedException();
        }
    }
}
