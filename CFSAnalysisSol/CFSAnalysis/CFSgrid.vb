Imports System.Data
Imports System.Data.OleDb

Public Class CFSgrid

    Private Sub SubNodes() 'takes end points of line, adds subpoints to nodes table
        Dim objDB As New DBAccess.DAOObject
        Dim reader As OleDbDataReader
        Dim gridSize As Double
        Dim firstTime As Boolean = True

        'find the next node number to use
        Dim NextAvailNode As Integer = objDB.RunSPReturnDataSet("NodesMax").Tables(0).Rows(0)(0) + 1

        'clear out the old data in SubElements table
        objDB.RunActionQuery("DELETE * From SubElements")

        'get element information
        reader = objDB.RunSPReturnRS("MemberCoords") 'for column headers, see membercoords query
        If reader.HasRows Then
            Do While reader.Read()
                'find the distance between the start and end points
                Dim distance As Double
                distance = Math.Sqrt((reader(3) - reader(6)) ^ 2 + _
                                     (reader(4) - reader(7)) ^ 2 + _
                                     (reader(5) - reader(8)) ^ 2)
                Select Case distance
                    Case Is > 25 'split element into 6" elements
                        gridSize = 1 / distance / 6
                    Case Is > 13 'split element into 4 pieces
                        gridSize = 1 / 4
                    Case Is > 5 'split element into 3 pieces
                        gridSize = 1 / 3
                    Case Else 'dont split element
                        gridSize = 1
                End Select
                Dim increment As Double = gridSize

                Do While increment < 0.999
                    'create node entry for new points - add to node table
                    objDB.RunActionQuery("INSERT INTO Nodes " & _
                               "(nID,nParent,nCoordX,nCoordY,nCoordZ) VALUES (" & _
                                NextAvailNode & "," & NextAvailNode & "," & _
                                reader(3) + (reader(6) - reader(3)) * increment & "," & _
                                reader(4) + (reader(7) - reader(4)) * increment & "," & _
                                reader(5) + (reader(8) - reader(5)) * increment & ")")

                    'create new subelements - add to subelements table
                    If firstTime Then
                        objDB.RunActionQuery("INSERT INTO SubElements " & _
                                  "(sParent,sNode1,sNode2,sRotU1,sRotV1,sRotW1) VALUES ('" & _
                                    reader(0) & "'," & reader(1) & "," & NextAvailNode & "," & _
                                   reader(9) & "," & reader(10) & "," & reader(11) & ")")
                        firstTime = False
                    Else
                        objDB.RunActionQuery("INSERT INTO SubElements " & _
                                  "(sParent,sNode1,sNode2) VALUES (" & _
                                   reader(0) & "," & NextAvailNode - 1 & "," & NextAvailNode & ")")
                    End If

                    increment = increment + gridSize
                    NextAvailNode = NextAvailNode + 1
                Loop

                If Not firstTime Then
                    objDB.RunActionQuery("INSERT INTO SubElements " & _
                                 "(sParent,sNode1,sNode2,sRotU2,sRotV2,sRotW2) VALUES ('" & _
                                   reader(0) & "'," & NextAvailNode - 1 & "," & reader(2) & "," & _
                                  reader(12) & "," & reader(13) & "," & reader(14) & ")")
                End If

            Loop

        End If

    End Sub

End Class

