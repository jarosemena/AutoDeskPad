

using System;
using System.Collections.Generic;

namespace PADesign
{
    public class FFDModule
    {
        static Dictionary<int, string> TypeCodes { get; } = new Dictionary<int, string> { { 1, "Wind Module" } };


        public string ModuleName { set; get; }
        public string Name { set; get; }
        public string Type { set; get; }
        public int Typeid { set; get; }
        
        public WindModuleParameters Windparams { set; get; }

        public FFDModule(string moduleName, WindModuleParameters windparams , int typeid = 1, string name = null )
        {
            if (string.IsNullOrEmpty(moduleName))
            {
                throw new ArgumentException($"'{nameof(moduleName)}' cannot be null or empty.", nameof(moduleName));
            }

            ModuleName = moduleName;
            if (name == null || name.Length == 0) { Name = moduleName; } else { Name = name; }
            
            Type = TypeCodes[typeid];
            Typeid = typeid;
            
            Windparams = windparams;


        }
        public FFDModule(string moduleName, int typeid,  char expusureCategory, int enclousureClassID, int codeid = 1, double basicWindSpeed = 110, double factorKzt = 1.00, double directionalityFactorKd = 0.85, double elevationFactorKe = 1.00, double roofSlope = 0, string roofSlopeDegree = "degree", double meanRoofH = 30, Boolean parapetLeast3 = false, string name = null )
        {
            ModuleName = moduleName;
            if (name == null || name.Length == 0) { Name = moduleName; } else { Name = name; }

            Type = TypeCodes[typeid];
            Typeid = typeid;

            Windparams = new WindModuleParameters(expusureCategory, enclousureClassID,codeid , basicWindSpeed,  factorKzt ,  directionalityFactorKd ,  elevationFactorKe ,  roofSlope,  roofSlopeDegree ,  meanRoofH ,  parapetLeast3 );



        }
    }
}