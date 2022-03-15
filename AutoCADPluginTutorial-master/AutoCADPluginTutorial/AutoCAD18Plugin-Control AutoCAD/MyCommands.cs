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
using Autodesk.AutoCAD.Windows;
using System.Windows;
using System.Windows.Forms;

[assembly: CommandClass(typeof(AutoCAD18Plugin_ControlAutoCAD.MyCommands))]
namespace AutoCAD18Plugin_ControlAutoCAD
{
    public class MyCommands
    {
        [CommandMethod("setWin")]
        public void setWin()
        {
            Document doc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
            Editor ed = doc.Editor;

            //position of the window
            System.Windows.Point pt = new System.Windows.Point(0, 0);
            Autodesk.AutoCAD.ApplicationServices.Application.MainWindow.DeviceIndependentLocation = pt;

            //size of window
            System.Windows.Size sizeWin = new System.Windows.Size(700, 700);
            Autodesk.AutoCAD.ApplicationServices.Application.MainWindow.DeviceIndependentSize = sizeWin;

            ed.WriteMessage("Your window is set !!");
        }

        [CommandMethod("NewDrawing", CommandFlags.Session)]
        public static void NewDrawing()
        {
            // Specify the template to use, if the template is not found
            // the default settings are used.
            string strTemplatePath = "acad.dwt";

            DocumentCollection acDocMgr = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager;
            Document acDoc = acDocMgr.Add(strTemplatePath);

            acDocMgr.MdiActiveDocument = acDoc;
        }

        [CommandMethod("SaveActiveDrawing")]
        public static void SaveActiveDrawing()
        {
            Document acDoc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
            string strDWGName = acDoc.Name;

            object obj = Autodesk.AutoCAD.ApplicationServices.Application.GetSystemVariable("DWGTITLED"); // if this value is 0 then the file has not been renamed

            // Check to see if the drawing has been named
            if (System.Convert.ToInt16(obj) == 0)
            {
                // If the drawing is using a default name (Drawing1, Drawing2, etc)
                // then provide a new name
                strDWGName = "c:\\MyDrawing.dwg";
            }

            // Save the active drawing
            acDoc.Database.SaveAs(strDWGName, true, DwgVersion.Current,
                                  acDoc.Database.SecurityParameters);
        }

        [CommandMethod("DrawingSaved")]
        public static void DrawingSaved()
        {
            object obj = Autodesk.AutoCAD.ApplicationServices.Application.GetSystemVariable("DBMOD");

            // Check the value of DBMOD, if 0 then the drawing has no unsaved changes
            if (System.Convert.ToInt16(obj) != 0)
            {
                if (System.Windows.Forms.MessageBox.Show("Do you wish to save this drawing?",
                                          "Save Drawing",
                                          System.Windows.Forms.MessageBoxButtons.YesNo,
                                          System.Windows.Forms.MessageBoxIcon.Question)
                                          == System.Windows.Forms.DialogResult.Yes)
                {
                    Document acDoc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
                    acDoc.Database.SaveAs(acDoc.Name, true, DwgVersion.Current,
                                          acDoc.Database.SecurityParameters);
                }
            }
        }

        [CommandMethod("setdocWinSize")]
        public void setdocWinSize()
        {
            Document doc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;

            // Works around what looks to be a refresh problem with the Application window
            doc.Window.WindowState = Window.State.Normal;

            // Set the position of the Document window
            System.Windows.Point ptDoc = new System.Windows.Point(0, 0);
            doc.Window.DeviceIndependentLocation = ptDoc;

            // Set the size of the Document window
            System.Windows.Size szDoc = new System.Windows.Size(400, 400);
            doc.Window.DeviceIndependentSize = szDoc;


        }

        [CommandMethod("MinMaxDocumentWindow")]
        public static void MinMaxDocumentWindow()
        {
            Document acDoc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;

            //Minimize the Document window
            acDoc.Window.WindowState = Window.State.Minimized;
            MessageBox.Show("Minimized", "MinMax");

            //Maximize the Document window
            acDoc.Window.WindowState = Window.State.Maximized;
            MessageBox.Show("Maximized", "MinMax");
        }

        [CommandMethod("CurrentDocWindowState")]
        public static void CurrentDocWindowState()
        {
            Document acDoc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;

            System.Windows.Forms.MessageBox.Show("The document window is " +
            acDoc.Window.WindowState.ToString(), "Window State");
        }

        [CommandMethod("CreateModelViewport")]
        public static void CreateModelViewport()
        {
            // Get the current database
            Document acDoc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
            Database acCurDb = acDoc.Database;

            // Start a transaction
            using (Transaction acTrans = acCurDb.TransactionManager.StartTransaction())
            {
                // Open the Viewport table for read
                ViewportTable acVportTbl;
                acVportTbl = acTrans.GetObject(acCurDb.ViewportTableId,
                                                OpenMode.ForRead) as ViewportTable;

                // Check to see if the named view 'TEST_VIEWPORT' exists
                if (acVportTbl.Has("TEST_VIEWPORT") == false)
                {
                    // Open the View table for write
                    acTrans.GetObject(acCurDb.ViewportTableId, OpenMode.ForWrite);

                    // Add the new viewport to the Viewport table and the transaction
                    using (ViewportTableRecord acVportTblRecLwr = new ViewportTableRecord())
                    {
                        acVportTbl.Add(acVportTblRecLwr);
                        acTrans.AddNewlyCreatedDBObject(acVportTblRecLwr, true);

                        // Name the new viewport 'TEST_VIEWPORT' and assign it to be
                        // the lower half of the drawing window
                        acVportTblRecLwr.Name = "TEST_VIEWPORT";
                        acVportTblRecLwr.LowerLeftCorner = new Point2d(0, 0);
                        acVportTblRecLwr.UpperRightCorner = new Point2d(1, 0.5);

                        // Add the new viewport to the Viewport table and the transaction
                        using (ViewportTableRecord acVportTblRecUpr = new ViewportTableRecord())
                        {
                            acVportTbl.Add(acVportTblRecUpr);
                            acTrans.AddNewlyCreatedDBObject(acVportTblRecUpr, true);

                            // Name the new viewport 'TEST_VIEWPORT' and assign it to be
                            // the upper half of the drawing window
                            acVportTblRecUpr.Name = "TEST_VIEWPORT";
                            acVportTblRecUpr.LowerLeftCorner = new Point2d(0, 0.5);
                            acVportTblRecUpr.UpperRightCorner = new Point2d(1, 1);

                            // To assign the new viewports as the active viewports, the 
                            // viewports named '*Active' need to be removed and recreated
                            // based on 'TEST_VIEWPORT'.

                            // Step through each object in the symbol table
                            foreach (ObjectId acObjId in acVportTbl)
                            {
                                // Open the object for read
                                ViewportTableRecord acVportTblRec;
                                acVportTblRec = acTrans.GetObject(acObjId,
                                                                    OpenMode.ForRead) as ViewportTableRecord;

                                // See if it is one of the active viewports, and if so erase it
                                if (acVportTblRec.Name == "*Active")
                                {
                                    acTrans.GetObject(acObjId, OpenMode.ForWrite);
                                    acVportTblRec.Erase();
                                }
                            }

                            // Clone the new viewports as the active viewports
                            foreach (ObjectId acObjId in acVportTbl)
                            {
                                // Open the object for read
                                ViewportTableRecord acVportTblRec;
                                acVportTblRec = acTrans.GetObject(acObjId,
                                                                    OpenMode.ForRead) as ViewportTableRecord;

                                // See if it is one of the active viewports, and if so erase it
                                if (acVportTblRec.Name == "TEST_VIEWPORT")
                                {
                                    ViewportTableRecord acVportTblRecClone;
                                    acVportTblRecClone = acVportTblRec.Clone() as ViewportTableRecord;

                                    // Add the new viewport to the Viewport table and the transaction
                                    acVportTbl.Add(acVportTblRecClone);
                                    acVportTblRecClone.Name = "*Active";
                                    acTrans.AddNewlyCreatedDBObject(acVportTblRecClone, true);
                                }
                            }

                            // Update the display with the new tiled viewports arrangement
                            acDoc.Editor.UpdateTiledViewportsFromDatabase();
                        }
                    }

                    // Commit the changes
                    acTrans.Commit();
                }

                // Dispose of the transaction
            }
        }

        [CommandMethod("SplitAndIterateModelViewports")]
        public static void SplitAndIterateModelViewports()
        {
            // Get the current database
            Document acDoc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
            Database acCurDb = acDoc.Database;

            // Start a transaction
            using (Transaction acTrans = acCurDb.TransactionManager.StartTransaction())
            {
                // Open the Viewport table for write
                ViewportTable acVportTbl;
                acVportTbl = acTrans.GetObject(acCurDb.ViewportTableId,
                                                OpenMode.ForWrite) as ViewportTable;

                // Open the active viewport for write
                ViewportTableRecord acVportTblRec;
                acVportTblRec = acTrans.GetObject(acDoc.Editor.ActiveViewportId,
                                                    OpenMode.ForWrite) as ViewportTableRecord;

                using (ViewportTableRecord acVportTblRecNew = new ViewportTableRecord())
                {
                    // Add the new viewport to the Viewport table and the transaction
                    acVportTbl.Add(acVportTblRecNew);
                    acTrans.AddNewlyCreatedDBObject(acVportTblRecNew, true);

                    // Assign the name '*Active' to the new Viewport
                    acVportTblRecNew.Name = "*Active";

                    // Use the existing lower left corner for the new viewport
                    acVportTblRecNew.LowerLeftCorner = acVportTblRec.LowerLeftCorner;

                    // Get half the X of the existing upper corner
                    acVportTblRecNew.UpperRightCorner = new Point2d(acVportTblRec.UpperRightCorner.X,
                                                                    acVportTblRec.LowerLeftCorner.Y +
                                                                    ((acVportTblRec.UpperRightCorner.Y -
                                                                        acVportTblRec.LowerLeftCorner.Y) / 2));

                    // Recalculate the corner of the active viewport
                    acVportTblRec.LowerLeftCorner = new Point2d(acVportTblRec.LowerLeftCorner.X,
                                                                acVportTblRecNew.UpperRightCorner.Y);

                    // Update the display with the new tiled viewports arrangement
                    acDoc.Editor.UpdateTiledViewportsFromDatabase();

                    // Step through each object in the symbol table
                    foreach (ObjectId acObjId in acVportTbl)
                    {
                        // Open the object for read
                        ViewportTableRecord acVportTblRecCur;
                        acVportTblRecCur = acTrans.GetObject(acObjId,
                                                                OpenMode.ForRead) as ViewportTableRecord;

                        if (acVportTblRecCur.Name == "*Active")
                        {
                            Autodesk.AutoCAD.ApplicationServices.Application.SetSystemVariable("CVPORT", acVportTblRecCur.Number);

                            Autodesk.AutoCAD.ApplicationServices.Application.ShowAlertDialog("Viewport: " + acVportTblRecCur.Number +
                                                        " is now active." +
                                                        "\nLower left corner: " +
                                                        acVportTblRecCur.LowerLeftCorner.X + ", " +
                                                        acVportTblRecCur.LowerLeftCorner.Y +
                                                        "\nUpper right corner: " +
                                                        acVportTblRecCur.UpperRightCorner.X + ", " +
                                                        acVportTblRecCur.UpperRightCorner.Y);
                        }
                    }
                }

                // Commit the changes and dispose of the transaction
                acTrans.Commit();
            }
        }

        [CommandMethod("ZoomCenter")]
        static public void ZoomCenter()
        {
            // Center the view at 5,5,0
            Zoom(new Point3d(), new Point3d(), new Point3d(5, 5, 0), 1);
        }

        [CommandMethod("ZoomExtents")]
        static public void ZoomExtents()
        {
            // Zoom to the extents of the current space
            Zoom(new Point3d(), new Point3d(), new Point3d(), 1.01075);
        }

        [CommandMethod("ZoomLimits")]
        static public void ZoomLimits()
        {
            Document acDoc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
            Database acCurDb = acDoc.Database;

            // Zoom to the limits of Model space
            Zoom(new Point3d(acCurDb.Limmin.X, acCurDb.Limmin.Y, 0),
                 new Point3d(acCurDb.Limmax.X, acCurDb.Limmax.Y, 0),
                 new Point3d(), 1);
        }

        [CommandMethod("ZoomScale")]
        static public void ZoomScale()
        {
            // Get the current document
            Document acDoc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;

            // Get the current view
            using (ViewTableRecord acView = acDoc.Editor.GetCurrentView())
            {
                // Get the center of the current view
                Point3d pCenter = new Point3d(acView.CenterPoint.X,
                                              acView.CenterPoint.Y, 0);

                // Set the scale factor to use
                double dScale = 0.5;

                // Scale the view using the center of the current view
                Zoom(new Point3d(), new Point3d(), pCenter, 1 / dScale);
            }
        }

        [CommandMethod("Zoomto")]
        static public void Zoomto()
        {
            // Zoom to a window boundary defined by 1.3,7.8 and 13.7,-2.6
            Point3d pMin = new Point3d(1.3, 7.8, 0);
            Point3d pMax = new Point3d(13.7, -2.6, 0);

            Zoom(pMin, pMax, new Point3d(), 1);
        }

        static void Zoom(Point3d pMin, Point3d pMax, Point3d pCenter, double dFactor)
        {
            // Get the current document and database
            Document acDoc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
            Database acCurDb = acDoc.Database;

            int nCurVport = System.Convert.ToInt32(Autodesk.AutoCAD.ApplicationServices.Application.GetSystemVariable("CVPORT"));

            // Get the extents of the current space when no points 
            // or only a center point is provided
            // Check to see if Model space is current
            if (acCurDb.TileMode == true)
            {
                if (pMin.Equals(new Point3d()) == true &&
                    pMax.Equals(new Point3d()) == true)
                {
                    pMin = acCurDb.Extmin;
                    pMax = acCurDb.Extmax;
                }
            }
            else
            {
                // Check to see if Paper space is current
                if (nCurVport == 1)
                {
                    // Get the extents of Paper space
                    if (pMin.Equals(new Point3d()) == true &&
                        pMax.Equals(new Point3d()) == true)
                    {
                        pMin = acCurDb.Pextmin;
                        pMax = acCurDb.Pextmax;
                    }
                }
                else
                {
                    // Get the extents of Model space
                    if (pMin.Equals(new Point3d()) == true &&
                        pMax.Equals(new Point3d()) == true)
                    {
                        pMin = acCurDb.Extmin;
                        pMax = acCurDb.Extmax;
                    }
                }
            }

            // Start a transaction
            using (Transaction acTrans = acCurDb.TransactionManager.StartTransaction())
            {
                // Get the current view
                using (ViewTableRecord acView = acDoc.Editor.GetCurrentView())
                {
                    Extents3d eExtents;

                    // Translate WCS coordinates to DCS
                    Matrix3d matWCS2DCS;
                    matWCS2DCS = Matrix3d.PlaneToWorld(acView.ViewDirection);
                    matWCS2DCS = Matrix3d.Displacement(acView.Target - Point3d.Origin) * matWCS2DCS;
                    matWCS2DCS = Matrix3d.Rotation(-acView.ViewTwist,
                                                    acView.ViewDirection,
                                                    acView.Target) * matWCS2DCS;

                    // If a center point is specified, define the min and max 
                    // point of the extents
                    // for Center and Scale modes
                    if (pCenter.DistanceTo(Point3d.Origin) != 0)
                    {
                        pMin = new Point3d(pCenter.X - (acView.Width / 2),
                                            pCenter.Y - (acView.Height / 2), 0);

                        pMax = new Point3d((acView.Width / 2) + pCenter.X,
                                            (acView.Height / 2) + pCenter.Y, 0);
                    }

                    // Create an extents object using a line
                    using (Line acLine = new Line(pMin, pMax))
                    {
                        eExtents = new Extents3d(acLine.Bounds.Value.MinPoint,
                                                    acLine.Bounds.Value.MaxPoint);
                    }

                    // Calculate the ratio between the width and height of the current view
                    double dViewRatio;
                    dViewRatio = (acView.Width / acView.Height);

                    // Tranform the extents of the view
                    matWCS2DCS = matWCS2DCS.Inverse();
                    eExtents.TransformBy(matWCS2DCS);

                    double dWidth;
                    double dHeight;
                    Point2d pNewCentPt;

                    // Check to see if a center point was provided (Center and Scale modes)
                    if (pCenter.DistanceTo(Point3d.Origin) != 0)
                    {
                        dWidth = acView.Width;
                        dHeight = acView.Height;

                        if (dFactor == 0)
                        {
                            pCenter = pCenter.TransformBy(matWCS2DCS);
                        }

                        pNewCentPt = new Point2d(pCenter.X, pCenter.Y);
                    }
                    else // Working in Window, Extents and Limits mode
                    {
                        // Calculate the new width and height of the current view
                        dWidth = eExtents.MaxPoint.X - eExtents.MinPoint.X;
                        dHeight = eExtents.MaxPoint.Y - eExtents.MinPoint.Y;

                        // Get the center of the view
                        pNewCentPt = new Point2d(((eExtents.MaxPoint.X + eExtents.MinPoint.X) * 0.5),
                                                    ((eExtents.MaxPoint.Y + eExtents.MinPoint.Y) * 0.5));
                    }

                    // Check to see if the new width fits in current window
                    if (dWidth > (dHeight * dViewRatio)) dHeight = dWidth / dViewRatio;

                    // Resize and scale the view
                    if (dFactor != 0)
                    {
                        acView.Height = dHeight * dFactor;
                        acView.Width = dWidth * dFactor;
                    }

                    // Set the center of the view
                    acView.CenterPoint = pNewCentPt;

                    // Set the current view
                    acDoc.Editor.SetCurrentView(acView);
                }

                // Commit the changes
                acTrans.Commit();
            }
        }

        [CommandMethod("REGME")]
        public void ReGme()
        {
            // Redraw the drawing
            Autodesk.AutoCAD.ApplicationServices.Application.UpdateScreen();
            Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor.UpdateScreen();

            // Regenerate the drawing
            Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor.Regen();
        }

    }
}
