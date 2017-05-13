using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForkRap
{
    class LoopThrough
    {
        private String api = null;
        private int times = 1;
        private String destination = "./output";

        public LoopThrough(String api, int times, String destination)
        {
            this.api = api;
            this.times = times;
            this.destination = destination;
        }
    }
}
