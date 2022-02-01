Public Class Form1   
    Private myGraphics As Graphics
    Private grid(3, 3) As String
    Private goal(3, 3) As String
    Private list As ArrayList
    Dim indexOf9 As Array
    Dim Moves As Integer
    Dim state As Boolean
    Dim seconde As Integer
    Dim minute As Integer

    Sub drawCase()
        For i As Integer = 0 To 2
            For j As Integer = 0 To 2
                Select Case i
                    Case 0
                        Select Case j
                            Case 0
                                PictureBox11.Image = Image.FromFile("C:\Users\RHJA\Documents\visual studio 2012\Projects\TaquinVbnet\TaquinVbnet\images\" & grid(i, j) & ".png")
                            Case 1
                                PictureBox12.Image = Image.FromFile("C:\Users\RHJA\Documents\visual studio 2012\Projects\TaquinVbnet\TaquinVbnet\images\" & grid(i, j) & ".png")
                            Case 2
                                PictureBox13.Image = Image.FromFile("C:\Users\RHJA\Documents\visual studio 2012\Projects\TaquinVbnet\TaquinVbnet\images\" & grid(i, j) & ".png")
                        End Select
                    Case 1
                        Select Case j
                            Case 0
                                PictureBox21.Image = Image.FromFile("C:\Users\RHJA\Documents\visual studio 2012\Projects\TaquinVbnet\TaquinVbnet\images\" & grid(i, j) & ".png")
                            Case 1
                                PictureBox22.Image = Image.FromFile("C:\Users\RHJA\Documents\visual studio 2012\Projects\TaquinVbnet\TaquinVbnet\images\" & grid(i, j) & ".png")
                            Case 2
                                PictureBox23.Image = Image.FromFile("C:\Users\RHJA\Documents\visual studio 2012\Projects\TaquinVbnet\TaquinVbnet\images\" & grid(i, j) & ".png")
                        End Select
                    Case 2
                        Select Case j
                            Case 0
                                PictureBox31.Image = Image.FromFile("C:\Users\RHJA\Documents\visual studio 2012\Projects\TaquinVbnet\TaquinVbnet\images\" & grid(i, j) & ".png")
                            Case 1
                                PictureBox32.Image = Image.FromFile("C:\Users\RHJA\Documents\visual studio 2012\Projects\TaquinVbnet\TaquinVbnet\images\" & grid(i, j) & ".png")
                            Case 2
                                PictureBox33.Image = Image.FromFile("C:\Users\RHJA\Documents\visual studio 2012\Projects\TaquinVbnet\TaquinVbnet\images\" & grid(i, j) & ".png")
                        End Select
                End Select
            Next
        Next
        If state Then
            Moves += 1
            moves_label.Text = Moves
        End If
        If Win() Then
            Timer1.Enabled = False

            Dim val As String = "You Win!!!  Moves : " & Moves & " , Times : " & time_label.Text & " , To restart, Click on Yes"
            If MessageBox.Show(val, "Success", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                NewGame()
            Else
                Application.Exit()
            End If
        End If
    End Sub

    Function IsSolvable(ByVal liste As ArrayList) As Boolean
        Dim total As Integer = 0
        Dim count As Integer
        For i As Integer = 0 To liste.Count - 1
            count = 0
            For j As Integer = (i + 1) To liste.Count - 1
                If liste(j) < liste(i) Then
                    count += 1
                End If
            Next
            total += count
        Next
        Dim bool As Boolean
        If (total Mod 2) = 0 Then
            bool = True
        Else
            bool = False
        End If
        Return bool
    End Function


    Sub NewGame()
        Do
            list = Randomlist()
        Loop While IsSolvable(list) = False
        list.Add(9)
        Dim count As Integer = 0
        For i As Integer = 0 To 2
            For j As Integer = 0 To 2
                grid(i, j) = list(count)
                count += 1
            Next
        Next
        goal = setGoal()
        Moves = -1
        seconde = 0
        minute = 0
        Timer1.Enabled = True
        drawCase()
        state = True
    End Sub

    Function Win() As Boolean
        Dim bool As Boolean = False
        If grid(0, 0) = goal(0, 0) And grid(0, 1) = goal(0, 1) And grid(0, 2) = goal(0, 2) And grid(1, 0) = goal(1, 0) And grid(1, 1) = goal(1, 1) And grid(1, 2) = goal(1, 2) And grid(2, 0) = goal(2, 0) And grid(2, 1) = goal(2, 1) And grid(2, 2) = goal(2, 2) Then
            bool = True
        End If
        Return bool
    End Function

    Function Randomlist() As ArrayList
        Dim list As ArrayList = New ArrayList()
        Dim randomnumber As Integer
        Dim random As Random = New Random()
        For i As Integer = 1 To 8
            Do
                randomnumber = random.Next(1, 9)
            Loop While list.Contains(randomnumber)
            list.Add(randomnumber)
        Next
        Return list
    End Function

    Function SwapGrid(ByVal i1 As Integer, ByVal j1 As Integer, ByVal i2 As Integer, ByVal j2 As Integer) As Array
        Dim temp As String = grid(i1, j1)
        grid(i1, j1) = grid(i2, j2)
        grid(i2, j2) = temp
        Return grid
    End Function

    Function GetIndexOf9() As Array
        Dim ci As Integer
        Dim cj As Integer
        For i As Integer = 0 To 2
            For j As Integer = 0 To 2
                If grid(i, j) = "9" Then
                    ci = i
                    cj = j
                End If
            Next
        Next
        Dim tab(2) As Integer
        tab(0) = ci
        tab(1) = cj
        Return tab
    End Function

    Function setGoal() As Array
        Dim list_goal As ArrayList = New ArrayList()
        For i As Integer = 1 To 9
            list_goal.Add(i.ToString())
        Next
        Dim count As Integer = 0
        Dim _goal(3, 3) As String
        For i As Integer = 0 To 2
            For j As Integer = 0 To 2
                _goal(i, j) = list_goal(count)
                count += 1
            Next
        Next
        Return _goal
    End Function

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PictureBox11.Visible = False
        PictureBox12.Visible = False
        PictureBox13.Visible = False
        PictureBox21.Visible = False
        PictureBox22.Visible = False
        PictureBox23.Visible = False
        PictureBox31.Visible = False
        PictureBox32.Visible = False
        PictureBox33.Visible = False
    End Sub


    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        PictureBox11.Visible = True
        PictureBox12.Visible = True
        PictureBox13.Visible = True
        PictureBox21.Visible = True
        PictureBox22.Visible = True
        PictureBox23.Visible = True
        PictureBox31.Visible = True
        PictureBox32.Visible = True
        PictureBox33.Visible = True

        NewGame()

        Button3.Enabled = False
        Button4.Visible = True
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Application.Exit()
    End Sub

    Private Sub PictureBox11_Click(sender As Object, e As EventArgs) Handles PictureBox11.Click
        indexOf9 = GetIndexOf9()
        If indexOf9(0) = 1 And indexOf9(1) = 0 Then
            grid = SwapGrid(0, 0, 1, 0)
            drawCase()
        ElseIf indexOf9(0) = 0 And indexOf9(1) = 1 Then
            grid = SwapGrid(0, 0, 0, 1)
            drawCase()
        End If
    End Sub

    Private Sub PictureBox12_Click(sender As Object, e As EventArgs) Handles PictureBox12.Click
        indexOf9 = GetIndexOf9()
        If indexOf9(0) = 0 And indexOf9(1) = 0 Then
            grid = SwapGrid(0, 1, 0, 0)
            drawCase()
        ElseIf indexOf9(0) = 0 And indexOf9(1) = 2 Then
            grid = SwapGrid(0, 1, 0, 2)
            drawCase()
        ElseIf indexOf9(0) = 1 And indexOf9(1) = 1 Then
            grid = SwapGrid(0, 1, 1, 1)
            drawCase()
        End If
    End Sub

    Private Sub PictureBox13_Click(sender As Object, e As EventArgs) Handles PictureBox13.Click
        indexOf9 = GetIndexOf9()
        If indexOf9(0) = 0 And indexOf9(1) = 1 Then
            grid = SwapGrid(0, 2, 0, 1)
            drawCase()
        ElseIf indexOf9(0) = 1 And indexOf9(1) = 2 Then
            grid = SwapGrid(0, 2, 1, 2)
            drawCase()
        End If
    End Sub

    Private Sub PictureBox21_Click(sender As Object, e As EventArgs) Handles PictureBox21.Click
        indexOf9 = GetIndexOf9()
        If indexOf9(0) = 0 And indexOf9(1) = 0 Then
            grid = SwapGrid(1, 0, 0, 0)
            drawCase()
        ElseIf indexOf9(0) = 1 And indexOf9(1) = 1 Then
            grid = SwapGrid(1, 0, 1, 1)
            drawCase()
        ElseIf indexOf9(0) = 2 And indexOf9(1) = 0 Then
            grid = SwapGrid(1, 0, 2, 0)
            drawCase()
        End If
    End Sub

    Private Sub PictureBox22_Click(sender As Object, e As EventArgs) Handles PictureBox22.Click
        indexOf9 = GetIndexOf9()
        If indexOf9(0) = 1 And indexOf9(1) = 0 Then
            grid = SwapGrid(1, 1, 1, 0)
            drawCase()
        ElseIf indexOf9(0) = 0 And indexOf9(1) = 1 Then
            grid = SwapGrid(1, 1, 0, 1)
            drawCase()
        ElseIf indexOf9(0) = 1 And indexOf9(1) = 2 Then
            grid = SwapGrid(1, 1, 1, 2)
            drawCase()
        ElseIf indexOf9(0) = 2 And indexOf9(1) = 1 Then
            grid = SwapGrid(1, 1, 2, 1)
            drawCase()
        End If
    End Sub

    Private Sub PictureBox23_Click(sender As Object, e As EventArgs) Handles PictureBox23.Click
        indexOf9 = GetIndexOf9()
        If indexOf9(0) = 0 And indexOf9(1) = 2 Then
            grid = SwapGrid(1, 2, 0, 2)
            drawCase()
        ElseIf indexOf9(0) = 1 And indexOf9(1) = 1 Then
            grid = SwapGrid(1, 2, 1, 1)
            drawCase()
        ElseIf indexOf9(0) = 2 And indexOf9(1) = 2 Then
            grid = SwapGrid(1, 2, 2, 2)
            drawCase()
        End If
    End Sub

    Private Sub PictureBox31_Click(sender As Object, e As EventArgs) Handles PictureBox31.Click
        indexOf9 = GetIndexOf9()
        If indexOf9(0) = 1 And indexOf9(1) = 0 Then
            grid = SwapGrid(2, 0, 1, 0)
            drawCase()
        ElseIf indexOf9(0) = 2 And indexOf9(1) = 1 Then
            grid = SwapGrid(2, 0, 2, 1)
            drawCase()
        End If
    End Sub

    Private Sub PictureBox32_Click(sender As Object, e As EventArgs) Handles PictureBox32.Click
        indexOf9 = GetIndexOf9()
        If indexOf9(0) = 2 And indexOf9(1) = 0 Then
            grid = SwapGrid(2, 1, 2, 0)
            drawCase()
        ElseIf indexOf9(0) = 1 And indexOf9(1) = 1 Then
            grid = SwapGrid(2, 1, 1, 1)
            drawCase()
        ElseIf indexOf9(0) = 2 And indexOf9(1) = 2 Then
            grid = SwapGrid(2, 1, 2, 2)
            drawCase()
        End If
    End Sub

    Private Sub PictureBox33_Click(sender As Object, e As EventArgs) Handles PictureBox33.Click
        indexOf9 = GetIndexOf9()
        If indexOf9(0) = 2 And indexOf9(1) = 1 Then
            grid = SwapGrid(2, 2, 2, 1)
            drawCase()
        ElseIf indexOf9(0) = 1 And indexOf9(1) = 2 Then
            grid = SwapGrid(2, 2, 1, 2)
            drawCase()
        End If
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub moves_label_Click(sender As Object, e As EventArgs) Handles moves_label.Click

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        seconde += 1
        If seconde = 60 Then
            minute += 1
            seconde = 0
        End If
        If minute > 60 Then
            MessageBox.Show("Too long", "Message")
            Application.Exit()
        End If
        time_label.Text = minute & " : " & seconde
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Timer1.Enabled = False
        Button3.Enabled = True
        Button4.Visible = False
        PictureBox11.Visible = False
        PictureBox12.Visible = False
        PictureBox13.Visible = False
        PictureBox21.Visible = False
        PictureBox22.Visible = False
        PictureBox23.Visible = False
        PictureBox31.Visible = False
        PictureBox32.Visible = False
        PictureBox33.Visible = False
        time_label.Text = "0 : 0"
        moves_label.Text = "0"
    End Sub
End Class
