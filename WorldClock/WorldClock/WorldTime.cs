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
    public interface IWorldTime
    {
        DateTime GetTime();     
        
    }
    
    public class TimeProvider
    {
    
        public TimeProvider()
        {
            WorldTime = new WorldTime();
        }
        
        public TimeProvider(TimeSpan? offset, DateTime? date)
        {
            WorldTime = new WorldTime(offset,date );
        }
        
        public IWorldTime WorldTime
        {
            get;
            set;
        }
    }
    
    class WorldTime : IWorldTime
    {
        private DateTime? date = null;
        private TimeSpan? offset = null; 
        
        public WorldTime()
        {
            this.date = null;
            this.offset = null;
        }
        
        public WorldTime(TimeSpan? offset, DateTime? date = null)
        {
            this.date = date;
            this.offset = offset;
        }
    
        public DateTime GetTime()
        {
            var time = DateTime.UtcNow;
            if(date.HasValue)
            {
                time = date.Value + DateTime.Now.TimeOfDay;
            }
            
            if(offset.HasValue)
            {
                time = date.Value + offset.Value;
            }
            return time;
        }
    }
}
