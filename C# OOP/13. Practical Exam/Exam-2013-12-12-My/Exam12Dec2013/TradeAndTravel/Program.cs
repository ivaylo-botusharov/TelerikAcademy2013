﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeAndTravel
{
    class Program
    {
        static void Main(string[] args)
        {
            var extendedEngine = new ExtendedEngine(new ExtendedInteractionManager());
            extendedEngine.Start();

            //var engine = new Engine(new InteractionManager());
            //engine.Start();
        }
    }
}
