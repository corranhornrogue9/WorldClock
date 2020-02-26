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
    public class SiteSpawner : SyncScript
    {
        // Declared public member fields and properties will show in the game studio
        public List<Site> Sites = new List<Site>();
        public Prefab sitePrefab;
        public float Radius = 75;

        public override void Start()
        {
            Sites.Add(new Site() {DegreesLat = 42, DegreesLong = 2});
            foreach(var site in Sites)
            {
                var instance = sitePrefab.Instantiate();
                var siteInstance = instance[0];
                Log.Info("adding site");
                // Change the X coordinate
                //siteInstance.Transform.Position.X = Radius;
                SceneSystem.SceneInstance.RootScene.Entities.Add(siteInstance);
            }
            // Initialization of the script.
        }

        public override void Update()
        {
            // Do stuff every new frame
        }
    }
}
