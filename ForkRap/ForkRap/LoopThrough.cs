using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForkRap
{
    class LoopThrough
    {
        private String url = null;
        private int times = 1;
        private String destination = "./output";

        public LoopThrough(String url, int times, String destination)
        {
            this.url = url;
            this.times = times;
            this.destination = destination;
        }
    }
}
