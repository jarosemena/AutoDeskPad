Imports System.Runtime
Imports Autodesk.AutoCAD.Runtime
Imports Autodesk.AutoCAD.ApplicationServices
Imports Autodesk.AutoCAD.DatabaseServices
Imports Autodesk.AutoCAD.EditorInput

Public Class CFSrelease

    'ensure single instance of app
    Friend Shared m_ps As Autodesk.AutoCAD.Windows.PaletteSet = Nothing

    'define command
    <CommandMethod("TestPalette")>
    Public Sub DoIt()
        'check to see if palette is created
        If m_ps Is Nothing Then
            'no so create it
            m_ps = New Autodesk.AutoCAD.Windows.PaletteSet("My First Palette")
            Dim myPalette As Container1 = New Container1()
            m_ps.Add("My First Palette", myPalette)
        End If
        m_ps.Visible = True
    End Sub


    Private Shared Sub GetXData()
        Dim doc As Document = Application.DocumentManager.MdiActiveDocument
        Dim ed As Editor = doc.Editor

        ' Ask the user to select an entity
        ' for which to retrieve XData
        Dim opt As New PromptEntityOptions(vbLf & "Select entity: ")
        Dim res As PromptEntityResult = ed.GetEntity(opt)

        If res.Status = PromptStatus.OK Then
            Dim tr As Transaction = doc.TransactionManager.StartTransaction()
            Using tr
                Dim obj As DBObject = tr.GetObject(res.ObjectId, OpenMode.ForRead)
                Dim rb As ResultBuffer = obj.XData
                If rb Is Nothing Then
                    ed.WriteMessage(vbLf & "Entity does not have XData attached.")
                Else
                    Dim n As Integer = 0
                    For Each tv As TypedValue In rb
                        ed.WriteMessage(vbLf & "TypedValue {0} - type: {1}, value: {2}", System.Math.Max(System.Threading.Interlocked.Increment(n), n - 1), tv.TypeCode, tv.Value)
                    Next
                    rb.Dispose()
                End If
            End Using
        End If
    End Sub

    Private Shared Sub SetXData()
        Dim doc As Document = Application.DocumentManager.MdiActiveDocument
        Dim ed As Editor = doc.Editor

        ' Ask the user to select an entity
        ' for which to set XData
        Dim opt As New PromptEntityOptions(vbLf & "Select entity: ")
        Dim res As PromptEntityResult = ed.GetEntity(opt)

        If res.Status = PromptStatus.OK Then
            Dim tr As Transaction = doc.TransactionManager.StartTransaction()
            Using tr
                Dim obj As DBObject = tr.GetObject(res.ObjectId, OpenMode.ForWrite)
                'use REL1 - start, and REL2 - end
                'use UVW or local axis release
                AddRegAppTableRecord("PDAL")
                Dim rb As New ResultBuffer(New TypedValue(1001, "PDAL"), New TypedValue(1000, "XY"))
                obj.XData = rb
                rb.Dispose()
                tr.Commit()
            End Using
        End If
    End Sub

    Private Shared Sub RemoveXdata()
        Dim doc As Document = Application.DocumentManager.MdiActiveDocument
        Dim db As Database = doc.Database
        Dim iCounter As Integer

        Dim tr As Transaction = db.TransactionManager.StartTransaction()
        Using tr
            Dim ed As Editor = Application.DocumentManager.MdiActiveDocument.Editor
            Try
                ' Prompt the user to select an entity
                Dim ers As PromptEntityResult = ed.GetEntity("Pick entity ")
                ' Open the selected entity
                Dim ent As Entity = DirectCast(tr.GetObject(ers.ObjectId, OpenMode.ForRead), Entity)

                For iCounter = 1 To 2
                    Dim buffer As ResultBuffer = ent.GetXDataForApplication("REL" & iCounter)
                    'This call ensures that the Xdata of our releases will be removed
                    If buffer IsNot Nothing Then
                        ent.UpgradeOpen()
                        ent.XData = New ResultBuffer(New TypedValue(1001, "REL" & iCounter))
                        buffer.Dispose()
                    End If
                    tr.Commit()
                Next iCounter
            Catch
                tr.Abort()
            End Try
        End Using
    End Sub


    Private Shared Sub AddRegAppTableRecord(regAppName As String)
        Dim doc As Document = Application.DocumentManager.MdiActiveDocument
        Dim ed As Editor = doc.Editor
        Dim db As Database = doc.Database

        Dim tr As Transaction = doc.TransactionManager.StartTransaction()
        Using tr
            Dim rat As RegAppTable = DirectCast(tr.GetObject(db.RegAppTableId, OpenMode.ForRead, False), RegAppTable)
            If Not rat.Has(regAppName) Then
                rat.UpgradeOpen()
                Dim ratr As New RegAppTableRecord()
                ratr.Name = regAppName
                rat.Add(ratr)
                tr.AddNewlyCreatedDBObject(ratr, True)
            End If
            tr.Commit()
        End Using
    End Sub
   
End Class
