﻿using MandatoryAssignment.Interfaces;
using MandatoryAssignment.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryAssignment.AbstractModels
{
    public abstract class AttackItem : IWorldItem
    {
        protected AttackItem(string name)
        {
            Name = name;
        }
        public string Name { get; set; }

        public abstract PositiveInt Hit();

        public abstract PositiveInt Range();

        public void Use(IWorldEntity user)
        {
            // nothing
        }

        public virtual void UseOn(IWorldEntity user, IWorldEntity target)
        {
            Coordinate diff = user.Position.XYDiffrence(target.Position);
            if(Math.Max(diff.x, diff.y) <= Range())
            {
                target.ReceiveHit(Hit());
            }          
        }

        public void UseOn(IWorldEntity user, IWorldObject target)
        {
            // nothing
        }
    }
}
