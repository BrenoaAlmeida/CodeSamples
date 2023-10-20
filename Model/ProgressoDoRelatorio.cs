using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSamples.Model
{
    public class ProgressoDoRelatorio
    {
        public int PorcemtagemCompleta { get; set; } = 0;
        public List<Website> SitesBaixados { get; set; } = new List<Website>();
    }
}
