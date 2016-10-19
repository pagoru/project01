Public Class Form1

    Dim first As Point
    Dim last As Point

    Dim mouseButton As String
    Dim stringboton As String

    Dim altP As Boolean = False
    Private Sub Form1_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown
        first = New Point(e.X, e.Y)

        If e.Button = MouseButtons.Left Then
            stringboton = "Left"
        ElseIf e.Button = MouseButtons.Right Then
            stringboton = "Right"
        ElseIf e.Button = MouseButtons.Middle Then
            stringboton = "Middle"
        End If
    End Sub

    Private Sub Form1_MouseUp(sender As Object, e As MouseEventArgs) Handles MyBase.MouseUp
        last = New Point(e.X, e.Y)

        Me.Text = "(" + CStr(first.X) + "," + CStr(first.Y) + ") - (" + CStr(last.X) + "," + CStr(last.Y) + ") [" + stringboton + "]"

        If My.Computer.Keyboard.AltKeyDown Then
            DarwSsquare(first.X, first.Y, last.X, last.Y)
        ElseIf My.Computer.Keyboard.CtrlKeyDown Then
            DrawEllipse(first.X, first.Y, last.X, last.Y)
        Else
            DrawLinePoint(first, last)
        End If

    End Sub

    Public Sub DrawEllipse(ByVal x As Integer, ByVal y As Integer, ByVal w As Integer, ByVal h As Integer)
        Dim myPen As New System.Drawing.Pen(System.Drawing.Color.Blue)
        Dim formGraphics As System.Drawing.Graphics
        formGraphics = Me.CreateGraphics()

        Dim nX = x
        Dim nY = y
        Dim nW = w - x
        If (nW < 0) Then
            nX = w
            nW = x - nX
        End If
        Dim nH = h - y
        If (nH < 0) Then
            nY = h
            nH = y - nY
        End If

        Dim rectan As New Rectangle(nX, nY, nW, nH)
        formGraphics.DrawEllipse(myPen, rectan)
        myPen.Dispose()
        formGraphics.Dispose()
    End Sub

    Public Sub DarwSsquare(ByVal x As Integer, ByVal y As Integer, ByVal w As Integer, ByVal h As Integer)
        Dim myPen As New System.Drawing.Pen(System.Drawing.Color.Red)
        Dim formGraphics As System.Drawing.Graphics
        formGraphics = Me.CreateGraphics()

        Dim nX = x
        Dim nY = y
        Dim nW = w - x
        If (nW < 0) Then
            nX = w
            nW = x - nX
        End If
        Dim nH = h - y
        If (nH < 0) Then
            nY = h
            nH = y - nY
        End If

        Dim rectan As New Rectangle(nX, nY, nW, nH)
        formGraphics.DrawRectangle(myPen, rectan)
        myPen.Dispose()
        formGraphics.Dispose()
    End Sub

    Public Sub DrawLinePoint(ByVal first As Point, ByVal last As Point)
        Dim myPen As New System.Drawing.Pen(System.Drawing.Color.Black)
        Dim formGraphics As System.Drawing.Graphics
        formGraphics = Me.CreateGraphics()
        formGraphics.DrawLine(myPen, first.X, first.Y, last.X, last.Y)
        myPen.Dispose()
        formGraphics.Dispose()
    End Sub

    Private Sub Frm_main_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp

        If e.KeyCode = Keys.Back Then
            If Me.Text.Length > 0 Then
                Me.Text = Me.Text.Substring(0, Me.Text.Length - 1)
            End If
        ElseIf e.KeyCode = Keys.Escape Then
            Me.Text = ""
        ElseIf e.KeyCode = Keys.Return Or e.KeyCode = Keys.I Then
            Me.Text = StrReverse(Me.Text)
        Else
            Me.Text += Convert.ToChar(e.KeyCode)
        End If

    End Sub

    Private Sub Form1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDoubleClick

        If Me.WindowState = FormWindowState.Normal Then
            Me.WindowState = FormWindowState.Maximized
        Else
            Me.WindowState = FormWindowState.Normal
        End If

    End Sub

    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        Me.Text = "Mida [" + Convert.ToString(Me.Size.Width) + ", " + Convert.ToString(Me.Size.Height) + "]"
    End Sub

End Class

