using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xenko.Core.Mathematics;
using Xenko.Input;
using Xenko.Engine;

namespace WorldClock
{
    public class SunSpin : SyncScript
    {
        // Declared public member fields and properties will show in the game studio
        public float CurrentAngle;
        private IWorldTime time;
        public override void Start()
        {
            var tp = new TimeProvider();
            time = tp.WorldTime;
            // Initialization of the script.
        }

        public override void Update()
        {
            CurrentAngle = (float)((360f / 31557600 )* (((31557600 / 365) * time.GetTime().DayOfYear  ) + time.GetTime().TimeOfDay.TotalSeconds));
            
            //Log.Info("Current sun angle " + CurrentAngle);
            Entity.Transform.Rotation = Quaternion.RotationY(CurrentAngle);
        }
    }
}
