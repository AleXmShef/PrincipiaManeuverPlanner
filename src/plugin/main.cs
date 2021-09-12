using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace PrincipiaManeuverPlanner
{
    [KSPAddon(KSPAddon.Startup.Flight, false)]
    public class HelloKerbinMod : MonoBehavior
    {
        public override void OnStart(StartState state)
        {
            print("Hello, Kerbin!");
        }
    }
}