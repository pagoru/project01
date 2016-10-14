Public Class Form1

    Dim first As Point
    Dim last As Point

    Dim mouseButton As String

    Private Sub Form1_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown
        first = New Point(e.X, e.Y)
    End Sub

    Private Sub Form1_MouseUp(sender As Object, e As MouseEventArgs) Handles MyBase.MouseUp
        last = New Point(e.X, e.Y)

        Me.Text = CStr(first.X) + "-" + CStr(first.Y) + " -> " + CStr(last.X) + "-" + CStr(last.Y)
        DrawLinePoint(first, last)
    End Sub

    Public Sub DrawLinePoint(ByVal first As Point, ByVal last As Point)

        Dim myPen As New System.Drawing.Pen(System.Drawing.Color.Red)
        Dim formGraphics As System.Drawing.Graphics
        formGraphics = Me.CreateGraphics()
        formGraphics.DrawLine(myPen, first.X, first.Y, last.X, last.Y)
        myPen.Dispose()
        formGraphics.Dispose()
    End Sub

End Class

