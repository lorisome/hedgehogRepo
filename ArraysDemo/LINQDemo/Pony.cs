using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQDemo
{
    public class Pony
    {
        public string Name { get; set; }
        public string HairColor { get; set; }
        public string SkinColor { get; set; }
        public string CutieMark { get; set; }
        public string CutieColor { get; set; }

        public Pony(string name, string hairColor, string skinColor, string cutieMark, string cutieColor)
        {
            Name= name;
            HairColor=hairColor;
            SkinColor = skinColor;
            CutieMark=cutieMark;
            CutieColor=cutieColor;
        }

}
