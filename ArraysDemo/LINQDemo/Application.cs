using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQDemo
{
    internal class Application
    {
        public List<Pony> AllPonies { get; set; }
        public void Run()
        {
            //Create list of ponies to demo the linq
            List<Pony> ponies = new List<Pony>()
            {
                new Pony("Lavender", "Purple", "Flowers")
            }


        }
    }
}
