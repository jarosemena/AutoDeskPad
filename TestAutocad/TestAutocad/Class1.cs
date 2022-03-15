using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;

namespace TestAutocad
{
    public class Class1
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
                    PromptSelectionResult acSSPrompt = acDoc.Editor.SelectAll();

                    if (acSSPrompt.Status == PromptStatus.OK)
                    {
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
                    int c = 0;
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
                Application.ShowAlertDialog("The following exception was caught:\n" + ex.Message + " " + ex.StackTrace.ToString());
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