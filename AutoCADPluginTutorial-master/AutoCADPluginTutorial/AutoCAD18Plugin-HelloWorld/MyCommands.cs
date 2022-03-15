using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.EditorInput;
using System.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: CommandClass(typeof(AutoCAD18Plugin_HelloWorld.MyCommands))]
namespace AutoCAD18Plugin_HelloWorld
{
    public class MyCommands
    {
        [CommandMethod("hello")]
        public void HeloWorld()
        {
            Document doc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
            Editor ed = doc.Editor;

            ed.WriteMessage("Hello World NEO ... Knock knock!");
        }

    }
}
