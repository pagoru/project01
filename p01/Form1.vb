Public Class Form1

    Dim firstX As Integer
    Dim firstY As Integer

    Dim lastX As Integer
    Dim lastY As Integer

    Private Sub Form1_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown
        firstX = e.X
        firstY = e.Y
    End Sub

    Private Sub Form1_MouseUp(sender As Object, e As MouseEventArgs) Handles MyBase.MouseUp
        lastX = e.X
        lastY = e.Y

        Me.Text = CStr(firstX) + "-" + CStr(firstY) + " -> " + CStr(lastX) + "-" + CStr(lastY)
    End Sub
End Class
