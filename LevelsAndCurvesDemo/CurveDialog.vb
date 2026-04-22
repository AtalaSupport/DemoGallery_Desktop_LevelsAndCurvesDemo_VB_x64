Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports Atalasoft.Imaging.ImageProcessing
Imports Atalasoft.Imaging.ImageProcessing.Effects
Imports Atalasoft.Imaging.WinControls

Namespace LevelsAndCurvesDemo
    ''' <summary>
    ''' Summary description for CurveDialog.
    ''' </summary>
    Public Class CurveDialog
        Inherits System.Windows.Forms.Form
        Private _viewer As WorkspaceViewer
        Private _needToUndo As Boolean = False
        Private _curvePen As Pen = Nothing
        Private _selectedPoints As SortedList = New SortedList()
        Private WithEvents picCurve As System.Windows.Forms.PictureBox
        Private WithEvents btnReset As System.Windows.Forms.Button
        Private label1 As System.Windows.Forms.Label
        Private cboChannels As System.Windows.Forms.ComboBox
        Private btnOK As System.Windows.Forms.Button
        Private WithEvents btnCancel As System.Windows.Forms.Button
        Private lblPosition As System.Windows.Forms.Label
        ''' <summary>
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.Container = Nothing

        Public Sub New(ByVal viewer As WorkspaceViewer, ByVal points As PointF(), ByVal channels As ChannelFlags)
            '
            ' Required for Windows Form Designer support
            '
            InitializeComponent()

            _viewer = viewer
            _curvePen = New Pen(Color.Black, 1)

            ' The points should be a 256 element array.
            If Not points Is Nothing Then
                If (Not _selectedPoints.ContainsKey(0)) Then
                    _selectedPoints.Add(0, New PointF(0, 255))
                End If

                If (Not _selectedPoints.ContainsKey(255)) Then
                    _selectedPoints.Add(255, New PointF(255, 0))
                End If

                For Each pt As PointF In points
                    If pt.X = 0 OrElse pt.X = 255 Then
                        GoTo Continue1
                    End If
                    _selectedPoints.Add(pt.X, pt)
Continue1:
                Next pt
            Else
                btnReset_Click(Nothing, Nothing)
            End If

            Select Case channels
                Case ChannelFlags.AllChannels
                    cboChannels.SelectedIndex = 0
                Case ChannelFlags.Channel1
                    cboChannels.SelectedIndex = 1
                Case ChannelFlags.Channel2
                    cboChannels.SelectedIndex = 2
                Case ChannelFlags.Channel3
                    cboChannels.SelectedIndex = 3
                Case ChannelFlags.Channel4
                    cboChannels.SelectedIndex = 4
            End Select

        End Sub

        ''' <summary>
        ''' Clean up any resources being used.
        ''' </summary>
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If Not components Is Nothing Then
                    components.Dispose()
                End If
            End If

            _curvePen.Dispose()
            MyBase.Dispose(disposing)
        End Sub

#Region "Windows Form Designer generated code"
        ''' <summary>
        ''' Required method for Designer support - do not modify
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Me.picCurve = New System.Windows.Forms.PictureBox()
            Me.btnReset = New System.Windows.Forms.Button()
            Me.label1 = New System.Windows.Forms.Label()
            Me.cboChannels = New System.Windows.Forms.ComboBox()
            Me.btnOK = New System.Windows.Forms.Button()
            Me.btnCancel = New System.Windows.Forms.Button()
            Me.lblPosition = New System.Windows.Forms.Label()
            Me.SuspendLayout()
            ' 
            ' picCurve
            ' 
            Me.picCurve.BackColor = System.Drawing.Color.White
            Me.picCurve.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.picCurve.Location = New System.Drawing.Point(17, 46)
            Me.picCurve.Name = "picCurve"
            Me.picCurve.Size = New System.Drawing.Size(259, 259)
            Me.picCurve.TabIndex = 0
            Me.picCurve.TabStop = False
            '			Me.picCurve.Paint += New System.Windows.Forms.PaintEventHandler(Me.picCurve_Paint);
            '			Me.picCurve.MouseMove += New System.Windows.Forms.MouseEventHandler(Me.picCurve_MouseMove);
            '			Me.picCurve.MouseDown += New System.Windows.Forms.MouseEventHandler(Me.picCurve_MouseDown);
            ' 
            ' btnReset
            ' 
            Me.btnReset.Location = New System.Drawing.Point(14, 336)
            Me.btnReset.Name = "btnReset"
            Me.btnReset.Size = New System.Drawing.Size(68, 29)
            Me.btnReset.TabIndex = 1
            Me.btnReset.Text = "&Reset"
            '			Me.btnReset.Click += New System.EventHandler(Me.btnReset_Click);
            ' 
            ' label1
            ' 
            Me.label1.Location = New System.Drawing.Point(34, 15)
            Me.label1.Name = "label1"
            Me.label1.Size = New System.Drawing.Size(57, 18)
            Me.label1.TabIndex = 2
            Me.label1.Text = "Channels:"
            ' 
            ' cboChannels
            ' 
            Me.cboChannels.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboChannels.Items.AddRange(New Object() {"All Channels", "Channel 1", "Channel 2", "Channel 3", "Channel 4"})
            Me.cboChannels.Location = New System.Drawing.Point(100, 13)
            Me.cboChannels.Name = "cboChannels"
            Me.cboChannels.Size = New System.Drawing.Size(158, 21)
            Me.cboChannels.TabIndex = 3
            ' 
            ' btnOK
            ' 
            Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.btnOK.Location = New System.Drawing.Point(112, 336)
            Me.btnOK.Name = "btnOK"
            Me.btnOK.Size = New System.Drawing.Size(68, 29)
            Me.btnOK.TabIndex = 4
            Me.btnOK.Text = "&OK"
            ' 
            ' btnCancel
            ' 
            Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.btnCancel.Location = New System.Drawing.Point(210, 336)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.Size = New System.Drawing.Size(68, 29)
            Me.btnCancel.TabIndex = 5
            Me.btnCancel.Text = "&Cancel"
            '			Me.btnCancel.Click += New System.EventHandler(Me.btnCancel_Click);
            ' 
            ' lblPosition
            ' 
            Me.lblPosition.Location = New System.Drawing.Point(88, 306)
            Me.lblPosition.Name = "lblPosition"
            Me.lblPosition.Size = New System.Drawing.Size(117, 15)
            Me.lblPosition.TabIndex = 6
            Me.lblPosition.TextAlign = System.Drawing.ContentAlignment.TopCenter
            ' 
            ' CurveDialog
            ' 
            Me.AcceptButton = Me.btnOK
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.CancelButton = Me.btnCancel
            Me.ClientSize = New System.Drawing.Size(293, 374)
            Me.Controls.Add(Me.lblPosition)
            Me.Controls.Add(Me.btnCancel)
            Me.Controls.Add(Me.btnOK)
            Me.Controls.Add(Me.cboChannels)
            Me.Controls.Add(Me.label1)
            Me.Controls.Add(Me.btnReset)
            Me.Controls.Add(Me.picCurve)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
            Me.Name = "CurveDialog"
            Me.ShowInTaskbar = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Curve Options"
            Me.ResumeLayout(False)

        End Sub
#End Region

        Public Function GetPoints() As PointF()
            ' The points should be values from 0 to 1.
            Dim pts As PointF() = New PointF(_selectedPoints.Count - 1) {}
            Dim i As Integer = 0

            For Each pt As PointF In _selectedPoints.Values
                pts(i) = New PointF(pt.X / 255.0F, (255 - pt.Y) / 255.0F)
                i += 1
            Next pt

            Return pts
        End Function

        Public Function GetChannels() As ChannelFlags
            Select Case Me.cboChannels.SelectedIndex
                Case 1
                    Return ChannelFlags.Channel1
                Case 2
                    Return ChannelFlags.Channel2
                Case 3
                    Return ChannelFlags.Channel3
                Case 4
                    Return ChannelFlags.Channel4
                Case Else
                    Return ChannelFlags.AllChannels
            End Select
        End Function

        Private Sub btnReset_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReset.Click
            _selectedPoints.Clear()
            _selectedPoints.Add(0, New PointF(0, 255))
            _selectedPoints.Add(255, New PointF(255, 0))

            Me.picCurve.Refresh()

            If _needToUndo Then
                _viewer.Undos.Undo()
                _needToUndo = False
            End If
        End Sub

        Private Sub picCurve_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles picCurve.Paint
            ' Draw the curve lines.
            Dim items As PointF() = New PointF(_selectedPoints.Count - 1) {}
            _selectedPoints.Values.CopyTo(items, 0)

            e.Graphics.DrawCurve(_curvePen, items)
        End Sub

        Private Sub picCurve_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picCurve.MouseDown
            ' Leave the 0, 0 and 255, 255 items.
            If e.X = 0 OrElse e.X = 255 Then
                Return
            End If

            ' Move the correct point to this position and redraw.
            If _selectedPoints.ContainsKey(e.X) Then
                _selectedPoints.Remove(e.X)
            End If
            _selectedPoints.Add(e.X, New PointF(e.X, e.Y))

            Me.picCurve.Refresh()

            ' Show a preview.
            If _needToUndo Then
                Me._viewer.Undos.Undo()
            End If

            Dim cmd As Atalasoft.Imaging.ImageProcessing.Effects.CurvesCommand = New Atalasoft.Imaging.ImageProcessing.Effects.CurvesCommand(GetPoints(), GetChannels())
            Me._viewer.ApplyCommand(cmd, "Curves Command")
            _needToUndo = True
        End Sub

        Private Sub picCurve_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picCurve.MouseMove
            lblPosition.Text = e.X.ToString() & ", " & (CInt(Fix(255 - e.Y))).ToString()
        End Sub

        Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
            If _needToUndo Then
                _viewer.Undos.Undo()
            End If
        End Sub

    End Class

End Namespace
