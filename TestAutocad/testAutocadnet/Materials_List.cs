using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FEALiTE2D.Materials;

namespace testAutocadnet
{
    static class Materials_List
    {
        public static IMaterial steel { get { return new GenericIsotropicMaterial() { E = 30E6, U = 0.2, Label = "Steel", Alpha = 0.000012, Gama = 39885, MaterialType = MaterialType.Steel }; } }
    }
}
