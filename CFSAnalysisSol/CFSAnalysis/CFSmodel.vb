Imports Autodesk.AutoCAD.Runtime
Imports Autodesk.AutoCAD.DatabaseServices
Imports Autodesk.AutoCAD.Geometry
Imports Autodesk.AutoCAD.ApplicationServices
Imports Autodesk.AutoCAD.EditorInput
Imports System.Data
Imports System.Data.OleDb


Public Class CFSmodel
    'class to read all the lines in the drawing and write to the nodes and elements database. 
    'database is currently in same directory as drawing, may be moved later
    Dim doc As Document = Application.DocumentManager.MdiActiveDocument
    Dim ed As Editor = doc.Editor
    Dim IDcounter As Integer

    <CommandMethod("CFSModel")>
    Public Sub CFSmain()

        'create the filter to select the restraint blocks
        Dim TypValAr(1) As TypedValue
        TypValAr.SetValue(New TypedValue(DxfCode.Start, "Insert"), 0)
        TypValAr.SetValue(New TypedValue(DxfCode.LayerName, "Restraint"), 1)
        'assign the filter
        Dim RestraintSelFtr As SelectionFilter = New SelectionFilter(TypValAr)
        'select all the restraints
        Dim ResSelRes As PromptSelectionResult = ed.SelectAll(RestraintSelFtr)

        'create the filters to select only member centerlines
        TypValAr.SetValue(New TypedValue(DxfCode.Start, "Line"), 0)
        TypValAr.SetValue(New TypedValue(DxfCode.LinetypeName, "CENTER"), 1)
        'assign the filter
        Dim MemberSelFtr As SelectionFilter = New SelectionFilter(TypValAr)
        'select all the members
        Dim MemSelRes As PromptSelectionResult = ed.SelectAll(MemberSelFtr)

        'error handling - make sure we have some selections
        Try

            If MemSelRes.Status = PromptStatus.OK Then
                'we have a lines selection set
                Dim objMemArray() As ObjectId = MemSelRes.Value.GetObjectIds()
                'start by creating the nodes table using the lines selected
                WriteNodes(objMemArray)

                If ResSelRes.Status = PromptStatus.OK Then
                    'we have restraint selection set
                    Dim objResArray() = ResSelRes.Value.GetObjectIds()
                    'continue to add nodes or update them depending on restraint location
                    WriteRestraints(objResArray)
                End If
                'add the members to the database
                WriteMembers(objMemArray)
            End If

        Catch ex As Exception
            ed.WriteMessage(ex.ToString())
        End Try
    End Sub

    Private Sub WriteNodes(ByRef myObjs() As ObjectId) 'uses the Nodes table
        Dim db As Database = doc.Database
        Dim dbObj As DBObject
        Dim ds As DataSet

        'clear out the old data
        Dim objDB As New DBAccess.DAOObject
        objDB.RunActionQuery("DELETE * From Nodes")
        IDcounter = 1

        Using tr As Transaction = db.TransactionManager.StartTransaction
            For Each objId As ObjectId In myObjs
                dbObj = tr.GetObject(objId, OpenMode.ForRead)
                Dim line_obj As Line = TryCast(dbObj, Line)

                Dim x As Double, y As Double, z As Double
                Dim k As Integer

                For k = 1 To 2
                    If k = 1 Then
                        x = Math.Round(line_obj.StartPoint(0), 2)
                        y = Math.Round(line_obj.StartPoint(1), 2)
                        z = Math.Round(line_obj.StartPoint(2), 2)
                    Else
                        x = Math.Round(line_obj.EndPoint(0), 2)
                        y = Math.Round(line_obj.EndPoint(1), 2)
                        z = Math.Round(line_obj.EndPoint(2), 2)
                    End If

                    'first we check if the point is in the node table
                    ds = New DataSet
                    ds = objDB.RunSPReturnDataSet("NodesExist", New OleDbParameter("CoordX", x), _
                        New OleDbParameter("CoordY", y), New OleDbParameter("CoordZ", z))

                    'then we add the point to the node table
                    objDB.RunActionQuery("INSERT INTO Nodes " _
                            & "(nID,nParent,nCoordx,nCoordY,nCoordZ) VALUES (" _
                            & IDcounter & "," & IDcounter & "," & x & "," & y & "," & z & ")")

                    'if the point was already there, update the parent value
                    If ds.Tables(0).Rows.Count <> 0 Then
                        objDB.RunActionQuery("UPDATE Nodes SET nParent = " _
                                & ds.Tables(0).Rows(0)(0) _
                                & " WHERE nID = " & IDcounter & ";")
                    End If

                    IDcounter = IDcounter + 1 'increment the ID counter
                Next k
            Next objId
            tr.Commit()
        End Using
    End Sub

    Private Sub WriteRestraints(ByRef myObjs() As ObjectId) 'uses the nodes table
        Dim db As Database = doc.Database
        Dim blk As BlockReference
        Dim objDB As New DBAccess.DAOObject
        Dim x As Double, y As Double, z As Double
        Dim ds As New DataSet


        Using tr As Transaction = db.TransactionManager.StartTransaction
            For Each objId As ObjectId In myObjs
                blk = DirectCast(tr.GetObject(objId, OpenMode.ForRead), BlockReference)

                'get the block insertion point
                x = Math.Round(blk.Position(0), 2)
                y = Math.Round(blk.Position(1), 2)
                z = Math.Round(blk.Position(2), 2)

                'check if the block insertion point is in the node table
                ds = New DataSet
                ds = objDB.RunSPReturnDataSet("NodesExist", New OleDbParameter("CoordX", x), _
                    New OleDbParameter("CoordY", y), New OleDbParameter("CoordZ", z))

                If ds.Tables(0).Rows.Count <> 0 Then
                    'the restraint insertion point is already there
                    objDB.RunActionQuery("UPDATE Nodes SET nRestraint =yes, n" & blk.Name & "= 0 " _
                            & " WHERE nID =" & ds.Tables(0).Rows(0)(0) & ";")
                Else
                    'the restraint is creating a new point
                    objDB.RunActionQuery("INSERT INTO Nodes " _
                           & "(nID,nParent,nCoordx,nCoordY,nCoordZ, nRestraint, n" & blk.Name & ") VALUES (" _
                           & IDcounter & "," & IDcounter & "," & x & "," & y & "," & z & ",yes,0)")

                    IDcounter = IDcounter + 1 'increment the ID counter
                End If

            Next objId
            tr.Commit()
        End Using
    End Sub

    Private Sub WriteMembers(ByRef myObjs() As ObjectId) 'uses the members table
        Dim db As Database = doc.Database
        Dim dbObj As DBObject
        Dim MemCounter As String = String.Empty
        Dim ptDist As Double
        Dim points As New Dictionary(Of Integer, Double)
        Dim VertLine As String
        IDcounter = 1 'start the id counter loop back at 1

        'clear out the old data
        Dim objDB As New DBAccess.DAOObject
        objDB.RunActionQuery("DELETE * From Elements")

        'create the list of nodes in a datatable
        Dim ds As DataSet = objDB.RunSPReturnDataSet("NodesUnique")
        Dim PointsToCheck As System.Data.DataTable = ds.Tables(0)
        Dim pointRow As DataRow

        'step through each line
        Using tr As Transaction = db.TransactionManager.StartTransaction
            For Each objId As ObjectId In myObjs
                dbObj = tr.GetObject(objId, OpenMode.ForRead)
                Dim line_obj As Line = TryCast(dbObj, Line)
                'check if the line is vertical
                If line_obj.Angle = 0 Then
                    VertLine = "True"
                Else
                    VertLine = "Null"
                End If

                MemCounter = IncrementString(MemCounter)
                'insert the parent memberS into the database
                objDB.RunActionQuery("INSERT INTO Elements " _
                           & "(eID,eHandle,eShape,eNode1,eNode2,eVertical) VALUES ('" _
                           & MemCounter & "','" & line_obj.Handle.ToString & "','" & line_obj.Layer _
                           & "'," & IDcounter & "," & IDcounter + 1 & "," & VertLine & ")")

                'insert the child members
                For Each pointRow In PointsToCheck.Rows
                    Dim pt As New Point3d(pointRow(0), pointRow(1), pointRow(2))
                    ptDist = PointOnLine(line_obj, pt) 'check to see if any points are on the line
                    If ptDist > 0 Then 'if any values are returned > 0 then a point is on the line
                        points.Add(pointRow(3), ptDist)
                    End If
                Next pointRow
                Dim childStart As Integer = IDcounter
                'need to make child entity for all members
                Dim sortedPoints = (From entry In points Order By entry.Value Ascending).ToDictionary(Function(pair) pair.Key, Function(pair) pair.Value)
                Dim i As Integer = 1
                'if we had points on line, need to step through each point on the line
                For Each entry As KeyValuePair(Of Integer, Double) In sortedPoints
                    Dim childEnd As Integer = entry.Key 'need to end at new point
                    objDB.RunActionQuery("INSERT INTO Elements " _
                       & "(eID,eNode1,eNode2,eParent) VALUES ('" _
                       & MemCounter & i & "'," & childStart & "," & childEnd & ",'" & MemCounter & "')")
                    i = i + 1
                    childStart = childEnd 'set start equal to old end
                Next
                'when we are done, have to add last child line
                objDB.RunActionQuery("INSERT INTO Elements " _
                       & "(eID,eNode1,eNode2,eParent) VALUES ('" _
                       & MemCounter & i & "'," & childStart & "," & IDcounter + 1 & ",'" & MemCounter & "')")

                IDcounter = IDcounter + 2 'increment the ID counter for both nodes
                points.Clear() 'clear out the point table for the next line
            Next objId
            tr.Commit()
        End Using
    End Sub

    Private Function IncrementString(ByVal Input As String) As String
        Dim curChar As Char = Nothing
        Dim nextChar As Char = Nothing
        Dim Output As String = String.Empty
        Dim i As Integer = 0

        If String.IsNullOrEmpty(Input) Then
            Output = "A"
        Else
            curChar = Input.Substring(0, 1)
            If curChar = "Z" Then
                Output = Input.Replace("Z", "A") & "A"
            Else
                nextChar = Chr(Asc(curChar) + 1)
                Output = Input.Replace(curChar, nextChar)
            End If
        End If
        Return Output
    End Function


    Private Function PointOnLine(ByVal memline As Line, ByVal point As Point3d) As Double
        Dim x1 As Double = Math.Round(memline.StartPoint(0), 2)
        Dim y1 As Double = Math.Round(memline.StartPoint(1), 2)
        Dim z1 As Double = Math.Round(memline.StartPoint(2), 2)
        Dim x2 As Double = Math.Round(memline.EndPoint(0), 2)
        Dim y2 As Double = Math.Round(memline.EndPoint(1), 2)
        Dim z2 As Double = Math.Round(memline.EndPoint(2), 2)
        Dim v As New Vector3d(x2 - x1, y2 - y1, z2 - z1) 'line vector, start pt to end pt
        Dim w As New Vector3d(point(0) - x1, point(1) - y1, point(2) - z1) 'start pt to new pt vector
        Dim c1 As Double = w.Length
        If v.IsParallelTo(w) And c1 > 0 And c1 < v.Length Then 'vectors are parallel and point is not an end point
            Return c1
        Else
            Return -1.0
        End If
    End Function

End Class
