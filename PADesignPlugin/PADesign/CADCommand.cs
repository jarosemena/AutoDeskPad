using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;
using System.Collections;
using System.Collections.Generic;



namespace PADesign
{
    public class CADCommand
    {

        [CommandMethod("AdskGreeting")]
        public void AdskGreeting()
        {
            try
            {
                // Get the current document and database, and start a transaction
                Document acDoc = Application.DocumentManager.MdiActiveDocument;
            
            Database acCurDb = acDoc.Database;
            List<List<string>> obj = new List<List<string>>();
            List<string> objparams = new List<string>();
               
            
            // Starts a new transaction with the Transaction Manager
            using (Transaction acTrans = acCurDb.TransactionManager.StartTransaction())
            {
                PromptSelectionResult acSSPrompt  = acDoc.Editor.SelectAll();

                if (acSSPrompt.Status == PromptStatus.OK) {
                    SelectionSet acSSet = acSSPrompt.Value;

                    foreach (SelectedObject s in acSSet)
                    {
                        //if (!IsDBnull(s))
                        //{
                            Entity acEnt = (Entity)acTrans.GetObject(s.ObjectId, OpenMode.ForRead);
                            
                                objparams.Add(acEnt.ObjectId.ToString());
                                objparams.Add((acEnt.OwnerId.ToString()));
                             //   objparams.Add(acEnt.GetField().ToString());
                            // objparams.Add(acEnt.GetField("Visibility1").ToString());
                            //   objparams.Add(acEnt.GetField("length").ToString());
                            // objparams.Add(acEnt.GetField("Flip Depth").ToString());
                            // objparams.Add(acEnt.GetField("Depth").ToString());
                            // objparams.Add(acEnt.GetField("Flip Length").ToString());

                            obj.Add(objparams);

                            
                        //}
                    }

                
                        }
                // Open the Block table record for read
                BlockTable acBlkTbl;
                acBlkTbl = acTrans.GetObject(acCurDb.BlockTableId, OpenMode.ForRead) as BlockTable;
                // Open the Block table record Model space for write
                BlockTableRecord acBlkTblRec;
                acBlkTblRec = acTrans.GetObject(acBlkTbl[BlockTableRecord.ModelSpace],
                OpenMode.ForWrite) as BlockTableRecord;
                /* Creates a new MText object and assigns it a location,
                text value and text style */
                MText objText = new MText();
                // Set the default properties for the MText object
                objText.SetDatabaseDefaults();
                // Specify the insertion point of the MText object
                objText.Location = new Autodesk.AutoCAD.Geometry.Point3d(1, 1, 0);
                    // Set the text string for the MText object
                    int c=0;
                    foreach (List<string> parm in obj)
                    {
                        c++;
                        objText.Contents = "Greetings, Welcome to the AutoCAD .NET Developer’s Guide -- " + c;
                        // Set the text style for the MText object
                        objText.TextStyleId = acCurDb.Textstyle;
                        // Appends the new MText object to model space
                        acBlkTblRec.AppendEntity(objText);
                        // Appends to new MText object to the active transaction
                        acTrans.AddNewlyCreatedDBObject(objText, true);
                        // Saves the changes to the database and closes the transaction

                        foreach (string st in parm)
                        {
                            objText.Contents = "param " + st;
                            // Set the text style for the MText object
                            objText.TextStyleId = acCurDb.Textstyle;
                            // Appends the new MText object to model space
                            acBlkTblRec.AppendEntity(objText);
                            // Appends to new MText object to the active transaction
                            acTrans.AddNewlyCreatedDBObject(objText, true);
                            // Saves the changes to the database and closes the transaction
                        }
                    }
                    

                    acTrans.Commit();
            }
            }
            catch (Autodesk.AutoCAD.Runtime.Exception ex)
            {
                Consolwrite(ex.Message);
                Application.ShowAlertDialog("The following exception was caught:\n" + ex.Message +" "+ ex.StackTrace.ToString());
            }
        }

      
        [CommandMethod("SelectObject")]
        public void SelectObjectsOnscreen()
        {

            try
            {

            
            // Get the current document and database
            Document acDoc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
            Database acCurDb = acDoc.Database;

            // Start a transaction
            using (Transaction acTrans = acCurDb.TransactionManager.StartTransaction())
            {
                // Request for objects to be selected in the drawing area
                PromptSelectionResult acSSPrompt = acDoc.Editor.GetSelection();

                // If the prompt status is OK, objects were selected
                if (acSSPrompt.Status == PromptStatus.OK)
                {
                    SelectionSet acSSet = acSSPrompt.Value;

                    // Step through the objects in the selection set
                    foreach (SelectedObject acSSObj in acSSet)
                    {
                        // Check to make sure a valid SelectedObject object was returned
                        if (acSSObj != null)
                        {
                            // Open the selected object for write
                            Entity acEnt = acTrans.GetObject(acSSObj.ObjectId,
                                                                OpenMode.ForRead) as Entity;

                            if (acEnt != null)
                            {
                                    List<string> Entitydata = new List<string>();   

                                    Entitydata.Add(acEnt.EntityColor.ToString());
                                    Entitydata.Add(acEnt.GeometricExtents.ToString());
                                    Entitydata.Add(acEnt.XData.AsArray().ToString());
                                    Entitydata.Add(acEnt.Transparency.ToString());
                                    Entitydata.Add(acEnt.Linetype.ToString());

                                    // Change the object's color to Green
                                    //acEnt.ColorIndex = 3;

                                    //consolwrite(acEnt.Layer);

                                    Consolwrite("entity " + Entitydata.ToString());
                            }
                        }
                    }

                    // Save the new object to the database
                    acTrans.Commit();
                }

                // Dispose of the transaction
            }
            } catch (Exception ex)
            {
                Consolwrite(ex.Message);
            }
        }

        [CommandMethod("PADINFO")]
        public void Padinfo()
        {
            try
            {
                Document acCurDb = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
                using (Transaction acTrans = acCurDb.TransactionManager.StartTransaction())
                {
                    LayerTableRecord acLyrTblRec;
                    acLyrTblRec = acTrans.GetObject(acCurDb.Database.LayerZero,
                                                    OpenMode.ForRead) as LayerTableRecord;

                    // consolwrite(acLyrTblRec.XData.ToString());
                    // consolwrite(acLyrTblRec.Database.Dimtxt.ToString());
                    // consolwrite(acLyrTblRec.Database.Latitude.ToString());
                    Consolwrite(acLyrTblRec.Database.Ucsname.ToString());
                    //  consolwrite(acLyrTblRec.Database.ToString());

                    Consolwrite("ejecuto padinfo**");
                    acTrans.Commit();

                   
                }
            }catch (Exception ex)
            {
                Consolwrite(ex.Message);
            }

            }
        [CommandMethod("PADWIN")]
        public void Padwin()
        {
           

                FormHome form1 = new FormHome();
                form1.ShowDialog();
          

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
