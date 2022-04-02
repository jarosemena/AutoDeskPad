using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Runtime;

namespace testAutocadnet
{
    public class Class1
    {
        [CommandMethod("ELEMENT")]
        public void Element()
        {
            CallToForm.Element();
        }

        [CommandMethod("getblock")]
        public void getblock()
        {
            Document acDoc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
            Editor acDocEd = acDoc.Editor;
            Database db = acDoc.Database;

            using (var tr = db.TransactionManager.StartTransaction())
            {
                var btl = (BlockTable)db.BlockTableId.GetObject(OpenMode.ForRead);
                foreach (var item in btl)
                {
                    var bk = (BlockTableRecord)tr.GetObject(item, OpenMode.ForRead);
                    if (bk.IsLayout)
                    {
                        foreach (var obj in bk)
                        {
                            Entity ent = (Entity)tr.GetObject(obj, OpenMode.ForRead);
                            if (ent != null && ent.GetType() == typeof(BlockReference))
                            {
                                BlockReference br = (BlockReference)tr.GetObject(obj, OpenMode.ForRead);
                                string Text = "";
                                foreach (DynamicBlockReferenceProperty n in br.DynamicBlockReferencePropertyCollection)
                                {
                                    Text = Text + "  " + n.PropertyName + ": " + n.Value.ToString();
                                }
                                Consolwrite("\nBlock Name: (" + br.Name + ")."+ "\nBlock Name: (" + br.BlockName + ")."+ "\nBlock addparams: (" + Text + ").");
                            }
                        }
                    }
                }
                tr.Commit();
            }
        }


[CommandMethod("MoveObject")]
    public static void MoveObject()
    {
        // Get the current document and database
        Document acDoc = Application.DocumentManager.MdiActiveDocument;
        Database acCurDb = acDoc.Database;
        // Start a transaction
        using (Transaction acTrans = acCurDb.TransactionManager.StartTransaction())
        {
            // Open the Block table for read
            BlockTable acBlkTbl;
            acBlkTbl = acTrans.GetObject(acCurDb.BlockTableId,
                                               OpenMode.ForRead) as BlockTable;
            // Open the Block table record Model space for write
            BlockTableRecord acBlkTblRec;
            acBlkTblRec = acTrans.GetObject(acBlkTbl[BlockTableRecord.ModelSpace],
                                                  OpenMode.ForWrite) as BlockTableRecord;
            // Create a circle that is at 2,2 with a radius of 0.5
            Circle acCirc = new Circle();
            acCirc.SetDatabaseDefaults();
            acCirc.Center = new Point3d(2, 2, 0);
            acCirc.Radius = 0.5;
            // Create a matrix and move the circle using a vector from (0,0,0) to (2,0,0)
            Point3d acPt3d = new Point3d(0, 0, 0);
            Vector3d acVec3d = acPt3d.GetVectorTo(new Point3d(2, 0, 0));
            acCirc.TransformBy(Matrix3d.Displacement(acVec3d));
            // Add the new object to the block table record and the transaction
            acBlkTblRec.AppendEntity(acCirc);
            acTrans.AddNewlyCreatedDBObject(acCirc, true);
            // Save the new objects to the database
            acTrans.Commit();
        }
    }


    [CommandMethod("RotateObject")]
        public static void RotateObject()
        {
            // Get the current document and database
            Document acDoc = Application.DocumentManager.MdiActiveDocument;
            Database acCurDb = acDoc.Database;
            // Start a transaction
            using (Transaction acTrans = acCurDb.TransactionManager.StartTransaction())
            {
                // Open the Block table for read
                BlockTable acBlkTbl;
                acBlkTbl = acTrans.GetObject(acCurDb.BlockTableId,
                                                   OpenMode.ForRead) as BlockTable;
                // Open the Block table record Model space for write
                BlockTableRecord acBlkTblRec;
                acBlkTblRec = acTrans.GetObject(acBlkTbl[BlockTableRecord.ModelSpace],
                                                      OpenMode.ForWrite) as BlockTableRecord;
                // Create a lightweight polyline
                Polyline acPoly = new Polyline();
                acPoly.SetDatabaseDefaults();
                acPoly.AddVertexAt(0, new Point2d(1, 2), 0, 0, 0);
                acPoly.AddVertexAt(1, new Point2d(1, 3), 0, 0, 0);
                acPoly.AddVertexAt(2, new Point2d(2, 3), 0, 0, 0);
                acPoly.AddVertexAt(3, new Point2d(3, 3), 0, 0, 0);
                acPoly.AddVertexAt(4, new Point2d(4, 4), 0, 0, 0);
                acPoly.AddVertexAt(5, new Point2d(4, 2), 0, 0, 0);
                // Close the polyline
                acPoly.Closed = true;
                Matrix3d curUCSMatrix = acDoc.Editor.CurrentUserCoordinateSystem;
                CoordinateSystem3d curUCS = curUCSMatrix.CoordinateSystem3d;
                // Rotate the polyline 45 degrees, around the Z-axis of the current UCS
                // using a base point of (4,4.25,0)
                acPoly.TransformBy(Matrix3d.Rotation(0.7854,
                                                           curUCS.Zaxis,
                                                           new Point3d(4, 4.25, 0)));
                // Add the new object to the block table record and the transaction
                acBlkTblRec.AppendEntity(acPoly);
                acTrans.AddNewlyCreatedDBObject(acPoly, true);
                // Save the new objects to the database
                acTrans.Commit();
            }
        }

        [CommandMethod("changeABlock")]
        public void RedefiningABlock()
        {
            // Get the current database and start a transaction
            Database acCurDb;
            acCurDb = Application.DocumentManager.MdiActiveDocument.Database;

            using (Transaction acTrans = acCurDb.TransactionManager.StartTransaction())
            {
                // Open the Block table for read
                BlockTable acBlkTbl;
                acBlkTbl = acTrans.GetObject(acCurDb.BlockTableId, OpenMode.ForRead) as BlockTable;

                if (!acBlkTbl.Has("CircleBlock"))
                {
                    Consolwrite("No hay nada que actualizar");
                }
                else
                {
                    // Redefine the block if it exists
                    BlockTableRecord acBlkTblRec =
                        acTrans.GetObject(acBlkTbl["CircleBlock"] , OpenMode.ForWrite) as BlockTableRecord;

                    // Step through each object in the block table record
                    foreach (ObjectId objID in acBlkTblRec)
                    {
                        DBObject dbObj = acTrans.GetObject(objID, OpenMode.ForRead) as DBObject;

                        // Revise the circle in the block
                        if (dbObj is Polyline)
                        {
                            Polyline acPol = dbObj as Polyline;

                            acPol.UpgradeOpen();
                            acPol.EndPoint = new Point3d(0,0,0);
                            acPol.StartPoint = new Point3d(0, 0, 0);
                          
                            
                        }
                    }

                    // Update existing block references
                    foreach (ObjectId objID in acBlkTblRec.GetBlockReferenceIds(false, true))
                    {
                        BlockReference acBlkRef = acTrans.GetObject(objID, OpenMode.ForWrite) as BlockReference;
                        acBlkRef.RecordGraphicsModified(true);
                    }

                    Application.ShowAlertDialog("CircleBlock has been revised.");
                }

                // Save the new object to the database
                acTrans.Commit();

                // Dispose of the transaction
            }
        }

        //[CommandMethod("Matrix_ScaleRotationMovement")]
        //public static void Matrix_ScaleRotationMovement()
        //{
        //    Editor ed = MgdAcApplication.DocumentManager.MdiActiveDocument.Editor;
        //    Database db = HostApplicationServices.WorkingDatabase;
        //    try
        //    {
        //        ObjectId faceId = CreateFaceOnXYPlaneOfWCS();
        //
        //        Transaction trans = faceId.Database.TransactionManager.StartTransaction();
        //        using (trans)
        //        {
        //            DBObject obj = (DBObject)trans.GetObject(faceId, OpenMode.ForWrite);
        //            if (obj is Face)
        //            {
        //                Face castObj = (Face)obj;
        //
        //                //Modify the object below ...
        //                Matrix3d scaleMat = Matrix3d.Scaling(2, Point3d.Origin);
        //                Matrix3d rotationMat = Matrix3d.Rotation(Math.PI / 4, Vector3d.ZAxis, Point3d.Origin);
        //                Matrix3d movementMat = Matrix3d.Displacement(new Vector3d(3, 3, 0));
        //                castObj.TransformBy(scaleMat.PreMultiplyBy(rotationMat).PreMultiplyBy(movementMat));
        //            }
        //
        //            trans.Commit();
        //        }
        //    }
        //    catch (System.Exception ex)
        //    {
        //        ed.WriteMessage(ex.ToString());
        //    }
        //}
        public ElementModel UpdateElement( ElementModel Element)
        {
            ElementModel NewElement = new ElementModel();
            NewElement.Name = Element.Name;
            NewElement.Blockname = Element.Blockname;
            NewElement.Depth = Element.Depth;
            NewElement.Length = Element.Length;
            NewElement.Rotation = Element.Rotation;
            NewElement.Matirial = Element.Matirial;
            NewElement.EndPoint = Element.EndPoint;
            NewElement.InitialPoint = Element.InitialPoint;
            NewElement.ID = Element.ID;
            NewElement.ObjID =  Element.ObjID;

            Document acDoc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
            Editor acDocEd = acDoc.Editor;
            Database db = acDoc.Database;
            using (Transaction acTrans = acDoc.TransactionManager.StartTransaction())
            {

                using (BlockReference Block = (BlockReference)acTrans.GetObject(NewElement.ObjID, OpenMode.ForRead, false, true))
                {
                    Block.UpgradeOpen();
                    Point3d po = new Point3d(NewElement.InitialPoint.Y, NewElement.InitialPoint.X, 0);
                    Block.Position = po;
                    Block.Rotation = NewElement.Rotation;
                    Block.Material = NewElement.Matirial;

                    foreach (DynamicBlockReferenceProperty n in Block.DynamicBlockReferencePropertyCollection)
                    {
                        if (n.PropertyName == "Depth")
                        {
                            n.Value = NewElement.Depth;
                        }
                        if (n.PropertyName == "length")
                        {
                            n.Value = NewElement.Length;
                        }

                    }

                };
 
                    
                    acTrans.Commit();
                

            }

                return NewElement;
        }

         public List<ElementModel> LoadElements()
        {
            List<ElementModel> obj = new List<ElementModel>();
            try
            {
                // Get the current document and database, and start a transaction
                Document acDoc = Application.DocumentManager.MdiActiveDocument;

                Database acCurDb = acDoc.Database;
 
                // Starts a new transaction with the Transaction Manager
                using (Transaction acTrans = acDoc.TransactionManager.StartTransaction())
                {
                    TypedValue[] acTypValAr = new TypedValue[1];
                    acTypValAr[0] = new TypedValue(0, "INSERT");
                    SelectionFilter acSelFtr = new SelectionFilter(acTypValAr);
                    PromptSelectionResult acSSPrompt = acDoc.Editor.SelectAll(acSelFtr);

                   // PromptSelectionResult acSSPrompt = acDoc.Editor.GetSelection();

                    if (acSSPrompt.Status == PromptStatus.OK)
                    {
                        SelectionSet acSSet = acSSPrompt.Value;
                        List<ObjectId> listaobj = acSSet.GetObjectIds().ToList<ObjectId>();

                        foreach (ObjectId s in listaobj)
                        {
                            // Dictionary<string, string> objparams = new Dictionary<string, string>();
                            ElementModel objparams = new ElementModel();
                            using (Entity acEnt = (Entity)acTrans.GetObject(s, OpenMode.ForRead))
                            {
                                if (acEnt is BlockReference && acEnt.Layer == "0" && acEnt.BlockName== "*MODEL_SPACE")
                                {
                                  
                                    BlockReference Block = (BlockReference)acTrans.GetObject(acEnt.Id,OpenMode.ForRead );
                                    objparams.ID = Block.ObjectId.ToString();
                                    objparams.ObjID = Block.ObjectId;
                                    objparams.Name = (Block.Name.ToString());
                                    objparams.Blockname = (Block.BlockName.ToString());
                                   // objparams["BlockId"] = (Block.BlockId.ToString());
                                    objparams.InitialPoint = new ElementModel.Point( Block.Position.Y, Block.Position.X);
                                    objparams.Rotation = Block.Rotation;
                                    objparams.Matirial = Block.Material.ToString();
                                    objparams.EndPoint = new ElementModel.Point(0,0);

                                   bool FlagProperty = false;
                                    Dictionary<string,string> Text = new Dictionary<string, string>();
                                    List<string> properties = new List<string>();
                                    foreach (DynamicBlockReferenceProperty n in Block.DynamicBlockReferencePropertyCollection)
                                    {
                                        if( n.PropertyName == "Depth") { FlagProperty = true; }
                                        if (properties.Contains( n.PropertyName))
                                            {
                                            Text[n.PropertyName] = n.Value.ToString();
                                        }
                                            else{
                                            Text.Add(n.PropertyName, n.Value.ToString());
                                            properties.Add(n.PropertyName);
                                        }
                                    }
                                  
                                    if (FlagProperty)
                                    {
                                        objparams.Depth = Convert.ToDouble(Text["Depth"]);
                                        objparams.Length = Convert.ToDouble(Text["length"]);
                                    }

                                    obj.Add(objparams);

                                }

                            } ;
                           

                        }


                    }

                    acTrans.Commit();
                    return obj;
                    
                }
            }
            catch (Autodesk.AutoCAD.Runtime.Exception ex)
            {
                Consolwrite(ex.Message);
                Application.ShowAlertDialog("The following exception was caught:\n" + ex.Message + " " + ex.StackTrace.ToString());
                return obj;
            }
        }

        public void PrintObj( List<Dictionary<string, string>>  obj)
        {
            // Get the current document and database, and start a transaction
            Document acDoc = Application.DocumentManager.MdiActiveDocument;

            Database acCurDb = acDoc.Database;

            // Starts a new transaction with the Transaction Manager
            using (Transaction acTrans = acDoc.TransactionManager.StartTransaction())
            {
                // Open the Block table record for read
                BlockTable acBlkTbl;
                acBlkTbl = acTrans.GetObject(acCurDb.BlockTableId, OpenMode.ForRead) as BlockTable;



                // Open the Block table record Model space for write
                BlockTableRecord acBlkTblRec;
                acBlkTblRec = acTrans.GetObject(acBlkTbl[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;
                /* Creates a new MText object and assigns it a location,
                text value and text style */
                MText objText = new MText();
                // Set the default properties for the MText object
                objText.SetDatabaseDefaults();
                // Specify the insertion point of the MText object
                objText.Location = new Autodesk.AutoCAD.Geometry.Point3d(0, 0, 0);
                // Set the text string for the MText object
                int c = 0;
                foreach (Dictionary<string, string> parm in obj)
                {
                    c++;
                    objText.Contents = objText.Contents + "Number of Objetc -- " + c + "\n";


                    foreach (string st in parm.Keys)
                    {
                        objText.Contents = objText.Contents + "param " + st + ": " + parm[st] + "\n";

                    }
                }
                // Set the text style for the MText object
                objText.TextStyleId = acCurDb.Textstyle;
                // Appends the new MText object to model space
                acBlkTblRec.AppendEntity(objText);
                // Appends to new MText object to the active transaction
                acTrans.AddNewlyCreatedDBObject(objText, true);
                // Saves the changes to the database and closes the transaction

                acTrans.Commit();
            }
           

        }

        public void Consolwrite(string message)
        {

            Document doc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
            Editor ed = doc.Editor;
            ed.WriteMessage(message);
        }

        [CommandMethod("Hello")]
        public void Hello()
        {
            Document doc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
            Editor ed = doc.Editor;
            ed.WriteMessage("Hello World ...");
        }
    }
}
