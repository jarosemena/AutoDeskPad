using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PADesign
{
  
    public class WindModuleParameters
    {
        public static Dictionary<int, string> Codes { get; } = new Dictionary<int, string> { { 1, "ASCE 7-16" } };
        public static IEnumerable<char> ExposureCategoryCodes { get; } = new[] { 'B', 'C', 'D' };
        public static Dictionary<int, string> EnclosureClassCodes { get; } = new Dictionary<int, string> { { 1, "Open Buildings" }, { 2, "Partially Open buildings" }, { 3, "Partially Enclosed Buildings" }, { 4, "Enclosed Buildings" } };
        public static IEnumerable<string> RoofSlopeDegreeCodes { get; } = new[] { "degrees", ":12 (slope)" };
        public int Codeid { set; get; }
        public string Cod { set; get; }
        public double BasicWindSpeed { set; get; }
        public char ExpusureCategory { set; get; }
        public double FactorKzt { set; get; }
        public double DirectionalityfactorKd { set; get; }
        public double ElevationFactorKe { set; get; }
        public double RoofSlope { set; get; }
        public string RoofSlopeDegree { set; get; }
        public double MeanRoofH { set; get; }
        public Boolean ParapetLeast3 { set; get; }
        public int EnclosureClassID { set; get; }
        public string EnclosureClass { get; } 
        public CustumizeReport WindReportparam { set; get; }

        public class CustumizeReport
        {
            // static Dictionary<int, string> TribAreaCodes { get; } = new Dictionary<int, string> { { 1, "10 ft^2" }, { 2, "50 ft^2" }, { 3, "500 ft^2" } };
            static readonly string TribMasure = " ft^2";

            public Boolean ShowWallElements { set; get; }
            public Boolean IncludeParapets { set; get; }
            public Boolean ShowMaxHightOnly { set; get; }
           // public int TribAreaId { set; get; }
            public int TribArea { set; get; }
            public Boolean ASD { set; get; }
            public Boolean ShowRoofElements { set; get; }

            public CustumizeReport(int tribArea = 50,Boolean showWallElements = false, Boolean includeParapets = false, Boolean showMaxHightOnly = false, Boolean asd = false, Boolean showroofelements = false)
            {
                ShowWallElements = showWallElements;
                IncludeParapets = includeParapets;
                ShowRoofElements = showroofelements;
                TribArea = tribArea;
                ShowMaxHightOnly = showMaxHightOnly;
                ASD = asd;
             }

        }

        public WindModuleParameters(char expusureCategory,int enclousureClassID, int codeid = 1, double basicWindSpeed = 110 , double factorKzt = 1.00, double directionalityFactorKd = 0.85, double elevationFactorKe = 1.00, double roofSlope = 0, string roofSlopeDegree = "degree",  double meanRoofH =30 , Boolean parapetLeast3 = false)
        {
            Codeid = codeid;
            Cod = Codes[codeid];
            BasicWindSpeed= basicWindSpeed;
            ExpusureCategory = expusureCategory;
            FactorKzt = factorKzt;
            DirectionalityfactorKd = directionalityFactorKd;
            ElevationFactorKe = elevationFactorKe;
            EnclosureClassID = enclousureClassID;
            RoofSlope = roofSlope ;
            RoofSlopeDegree = roofSlopeDegree ;
            MeanRoofH = meanRoofH;
            ParapetLeast3 = parapetLeast3;
            EnclosureClass = EnclosureClassCodes[EnclosureClassID];

            WindReportparam = new CustumizeReport();

        }

        public WindModuleParameters(char expusureCategory, int enclousureClassID, CustumizeReport windReportparam, int codeid = 1, double basicWindSpeed = 110, double factorKzt = 1.00, double directionalityFactorKd = 0.85, double elevationFactorKe = 1.00, double roofSlope = 0, string roofSlopeDegree = "degree", double meanRoofH = 30, Boolean parapetLeast3 = false )
        {
            Codeid = codeid;
            Cod = Codes[codeid];
            BasicWindSpeed = basicWindSpeed;
            ExpusureCategory = expusureCategory;
            FactorKzt = factorKzt;
            DirectionalityfactorKd = directionalityFactorKd;
            ElevationFactorKe = elevationFactorKe;
            EnclosureClassID = enclousureClassID;
            RoofSlope = roofSlope;
            RoofSlopeDegree = roofSlopeDegree;
            MeanRoofH = meanRoofH;
            ParapetLeast3 = parapetLeast3;
            EnclosureClass = EnclosureClassCodes[EnclosureClassID];

            WindReportparam = windReportparam;

        }

        public WindModuleParameters(char expusureCategory, int enclousureClassID, int codeid = 1, double basicWindSpeed = 110, double factorKzt = 1.00, double directionalityFactorKd = 0.85, double elevationFactorKe = 1.00, double roofSlope = 0, string roofSlopeDegree = "degree", double meanRoofH = 30, Boolean parapetLeast3 = false, int tribArea = 50, Boolean showWallElements = false, Boolean includeParapets = false, Boolean showMaxHightOnly = false, Boolean asd = false, Boolean showroofelements = false)
        {
            Codeid = codeid;
            Cod = Codes[codeid];
            BasicWindSpeed = basicWindSpeed;
            ExpusureCategory = expusureCategory;
            FactorKzt = factorKzt;
            DirectionalityfactorKd = directionalityFactorKd;
            ElevationFactorKe = elevationFactorKe;
            EnclosureClassID = enclousureClassID;
            RoofSlope = roofSlope;
            RoofSlopeDegree = roofSlopeDegree;
            MeanRoofH = meanRoofH;
            ParapetLeast3 = parapetLeast3;
            EnclosureClass = EnclosureClassCodes[EnclosureClassID];

            WindReportparam = new CustumizeReport( tribArea ,  showWallElements ,  includeParapets ,  showMaxHightOnly ,  asd  ,  showroofelements );

        }

    }

   
}
