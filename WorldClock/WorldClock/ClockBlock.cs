using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xenko.Core.Mathematics;
using Xenko.Input;
using Xenko.Engine;
    using Xenko.UI;
    using Xenko.UI.Controls;
    using Xenko.UI.Panels;
    
namespace WorldClock
{

    
    public class ClockBlock : SyncScript
    {
    

        // Declared public member fields and properties will show in the game studio
        private TextBlock ClockDisplay;
        private TextBlock DateDisplay;
        private TextBlock TitleBlock;
        private UIPage page;
        private Border border;
        public string BlockName = "MainClock";
        public string Title = "Gloucester";
         private IWorldTime time;
        public override void Start()
        {
            var tp = new TimeProvider();
            time = tp.WorldTime;
            page = Entity.Get<UIComponent>().Page;
            border = page.RootElement.FindVisualChildOfType<Border>(BlockName);
            ClockDisplay = border.FindVisualChildOfType<TextBlock>("TimeBlock");
            DateDisplay = border.FindVisualChildOfType<TextBlock>("DateBlock");
            TitleBlock = border.FindVisualChildOfType<TextBlock>("Title");
            TitleBlock.Text = Title;
           
            // Initialization of the script.
        }

        public override void Update()
        {
            if(ClockDisplay != null)
            {
                ClockDisplay.Text = time.GetTime().ToString("HH:mm:ss");
                DateDisplay.Text = time.GetTime().ToString("dd:MM:yy");
            }
            // Do stuff every new frame
        }
    }
}
