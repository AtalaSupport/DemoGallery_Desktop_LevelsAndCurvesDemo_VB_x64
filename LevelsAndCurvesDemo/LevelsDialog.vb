Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports Atalasoft.Imaging
Imports Atalasoft.Imaging.ImageProcessing
Imports Atalasoft.Imaging.ImageProcessing.Effects
Imports Atalasoft.Imaging.WinControls

Namespace LevelsAndCurvesDemo
    ''' <summary>
    ''' Summary description for LevelsDialog.
    ''' </summary>
    Public Class LevelsDialog
        Inherits System.Windows.Forms.Form
        Private groupBox1 As System.Windows.Forms.GroupBox
        Private WithEvents btnOK As System.Windows.Forms.Button
        Private WithEvents btnCancel As System.Windows.Forms.Button
        Private WithEvents btnAuto As System.Windows.Forms.Button
        Private WithEvents btnBlackPoint As System.Windows.Forms.Button
        Private WithEvents btnGrayPoint As System.Windows.Forms.Button
        Private WithEvents btnWhitePoint As System.Windows.Forms.Button
        Private label1 As System.Windows.Forms.Label
        Private WithEvents txtGamma As System.Windows.Forms.TextBox
        Private WithEvents txtInputClipMin As System.Windows.Forms.TextBox
        Private WithEvents txtInputClipMax As System.Windows.Forms.TextBox
        Private label2 As System.Windows.Forms.Label
        Private WithEvents txtOutputMin As System.Windows.Forms.TextBox
        Private WithEvents txtOutputMax As System.Windows.Forms.TextBox
        ''' <summary>
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.Container = Nothing
        Private WithEvents picHistogram As System.Windows.Forms.PictureBox
        Private _redHistogram As Integer()
        Private _greenHistogram As Integer()
        Private _blueHistogram As Integer()
        Private _combinedHistogram As Integer()
        Private _mouseColor As Color
        Private _eyeDropper As EyeDropperStyle = EyeDropperStyle.None
        Private _levels As LevelsCommand = New LevelsCommand()
        Private _loading As Boolean = True
        Private WithEvents cmbChannels As System.Windows.Forms.ComboBox

        Private _viewer As WorkspaceViewer
        Public Sub New(ByVal viewer As WorkspaceViewer)

            InitializeComponent()
            Me.cmbChannels.SelectedIndex = 0
            _viewer = viewer
            AddHandler _viewer.MouseMovePixel, AddressOf viewer_MouseMovePixel
            AddHandler _viewer.MouseDown, AddressOf viewer_MouseDown
            GetHistograms()
            SetTextFields()
            _loading = False

        End Sub

        Private Sub GetHistograms()
            '// FB 7282 - avoiding exceptions for no image
            If _viewer.Image IsNot Nothing Then
                Dim hist As Histogram = New Histogram(_viewer.Image)
                _redHistogram = hist.GetChannelHistogram(2)
                _greenHistogram = hist.GetChannelHistogram(1)
                _blueHistogram = hist.GetChannelHistogram(0)
                _combinedHistogram = New Integer(255) {}
                For i As Integer = 0 To 255
                    _combinedHistogram(i) = _redHistogram(i) + _greenHistogram(i) + _blueHistogram(i)
                Next i
                picHistogram.Invalidate()
            End If
        End Sub

        Public Property Viewer() As WorkspaceViewer
            Get
                Return _viewer
            End Get
            Set(ByVal value As WorkspaceViewer)
                _viewer = Value
            End Set
        End Property


        ''' <summary>
        ''' Clean up any resources being used.
        ''' </summary>
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If Not components Is Nothing Then
                    components.Dispose()
                End If
            End If
            RemoveHandler _viewer.MouseMovePixel, AddressOf viewer_MouseMovePixel
            RemoveHandler _viewer.MouseDown, AddressOf viewer_MouseDown
            MyBase.Dispose(disposing)
        End Sub

#Region "Windows Form Designer generated code"
        ''' <summary>
        ''' Required method for Designer support - do not modify
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Me.groupBox1 = New System.Windows.Forms.GroupBox()
            Me.txtOutputMax = New System.Windows.Forms.TextBox()
            Me.txtOutputMin = New System.Windows.Forms.TextBox()
            Me.label2 = New System.Windows.Forms.Label()
            Me.txtInputClipMax = New System.Windows.Forms.TextBox()
            Me.txtGamma = New System.Windows.Forms.TextBox()
            Me.label1 = New System.Windows.Forms.Label()
            Me.txtInputClipMin = New System.Windows.Forms.TextBox()
            Me.picHistogram = New System.Windows.Forms.PictureBox()
            Me.cmbChannels = New System.Windows.Forms.ComboBox()
            Me.btnOK = New System.Windows.Forms.Button()
            Me.btnCancel = New System.Windows.Forms.Button()
            Me.btnAuto = New System.Windows.Forms.Button()
            Me.btnBlackPoint = New System.Windows.Forms.Button()
            Me.btnGrayPoint = New System.Windows.Forms.Button()
            Me.btnWhitePoint = New System.Windows.Forms.Button()
            Me.groupBox1.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' groupBox1
            ' 
            Me.groupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtOutputMax, Me.txtOutputMin, Me.label2, Me.txtInputClipMax, Me.txtGamma, Me.label1, Me.txtInputClipMin, Me.picHistogram})
            Me.groupBox1.Location = New System.Drawing.Point(8, 16)
            Me.groupBox1.Name = "groupBox1"
            Me.groupBox1.Size = New System.Drawing.Size(280, 200)
            Me.groupBox1.TabIndex = 0
            Me.groupBox1.TabStop = False
            Me.groupBox1.Text = "Channel                                        "
            ' 
            ' txtOutputMax
            ' 
            Me.txtOutputMax.Location = New System.Drawing.Point(184, 168)
            Me.txtOutputMax.Name = "txtOutputMax"
            Me.txtOutputMax.Size = New System.Drawing.Size(40, 20)
            Me.txtOutputMax.TabIndex = 7
            Me.txtOutputMax.Text = "255"
            '			Me.txtOutputMax.TextChanged += New System.EventHandler(Me.txtOutputMax_TextChanged);
            ' 
            ' txtOutputMin
            ' 
            Me.txtOutputMin.Location = New System.Drawing.Point(136, 168)
            Me.txtOutputMin.Name = "txtOutputMin"
            Me.txtOutputMin.Size = New System.Drawing.Size(40, 20)
            Me.txtOutputMin.TabIndex = 6
            Me.txtOutputMin.Text = "0"
            '			Me.txtOutputMin.TextChanged += New System.EventHandler(Me.txtOutputMin_TextChanged);
            ' 
            ' label2
            ' 
            Me.label2.AutoSize = True
            Me.label2.Location = New System.Drawing.Point(48, 171)
            Me.label2.Name = "label2"
            Me.label2.Size = New System.Drawing.Size(77, 13)
            Me.label2.TabIndex = 5
            Me.label2.Text = "Output Levels:"
            ' 
            ' txtInputClipMax
            ' 
            Me.txtInputClipMax.Location = New System.Drawing.Point(192, 32)
            Me.txtInputClipMax.Name = "txtInputClipMax"
            Me.txtInputClipMax.Size = New System.Drawing.Size(40, 20)
            Me.txtInputClipMax.TabIndex = 4
            Me.txtInputClipMax.Text = "255"
            '			Me.txtInputClipMax.TextChanged += New System.EventHandler(Me.txtInputClipMax_TextChanged);
            ' 
            ' txtGamma
            ' 
            Me.txtGamma.Location = New System.Drawing.Point(144, 32)
            Me.txtGamma.Name = "txtGamma"
            Me.txtGamma.Size = New System.Drawing.Size(40, 20)
            Me.txtGamma.TabIndex = 3
            Me.txtGamma.Text = "1.00"
            '			Me.txtGamma.TextChanged += New System.EventHandler(Me.txtGamma_TextChanged);
            ' 
            ' label1
            ' 
            Me.label1.AutoSize = True
            Me.label1.Location = New System.Drawing.Point(16, 36)
            Me.label1.Name = "label1"
            Me.label1.Size = New System.Drawing.Size(68, 13)
            Me.label1.TabIndex = 2
            Me.label1.Text = "Input Levels:"
            ' 
            ' txtInputClipMin
            ' 
            Me.txtInputClipMin.Location = New System.Drawing.Point(96, 32)
            Me.txtInputClipMin.Name = "txtInputClipMin"
            Me.txtInputClipMin.Size = New System.Drawing.Size(40, 20)
            Me.txtInputClipMin.TabIndex = 1
            Me.txtInputClipMin.Text = "0"
            '			Me.txtInputClipMin.TextChanged += New System.EventHandler(Me.txtInputClipMin_TextChanged);
            ' 
            ' picHistogram
            ' 
            Me.picHistogram.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.picHistogram.Location = New System.Drawing.Point(12, 64)
            Me.picHistogram.Name = "picHistogram"
            Me.picHistogram.Size = New System.Drawing.Size(265, 96)
            Me.picHistogram.TabIndex = 0
            Me.picHistogram.TabStop = False
            '			Me.picHistogram.Paint += New System.Windows.Forms.PaintEventHandler(Me.picHistogram_Paint);
            ' 
            ' cmbChannels
            ' 
            Me.cmbChannels.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbChannels.Items.AddRange(New Object() {"RGB", "Red", "Green", "Blue"})
            Me.cmbChannels.Location = New System.Drawing.Point(72, 10)
            Me.cmbChannels.Name = "cmbChannels"
            Me.cmbChannels.Size = New System.Drawing.Size(96, 21)
            Me.cmbChannels.TabIndex = 8
            '			Me.cmbChannels.SelectedIndexChanged += New System.EventHandler(Me.cmbChannels_SelectedIndexChanged);
            ' 
            ' btnOK
            ' 
            Me.btnOK.Location = New System.Drawing.Point(296, 24)
            Me.btnOK.Name = "btnOK"
            Me.btnOK.Size = New System.Drawing.Size(72, 24)
            Me.btnOK.TabIndex = 0
            Me.btnOK.Text = "OK"
            '			Me.btnOK.Click += New System.EventHandler(Me.btnOK_Click);
            ' 
            ' btnCancel
            ' 
            Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.btnCancel.Location = New System.Drawing.Point(296, 56)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.Size = New System.Drawing.Size(72, 24)
            Me.btnCancel.TabIndex = 1
            Me.btnCancel.Text = "Cancel"
            '			Me.btnCancel.Click += New System.EventHandler(Me.btnCancel_Click);
            ' 
            ' btnAuto
            ' 
            Me.btnAuto.Location = New System.Drawing.Point(296, 104)
            Me.btnAuto.Name = "btnAuto"
            Me.btnAuto.Size = New System.Drawing.Size(72, 24)
            Me.btnAuto.TabIndex = 2
            Me.btnAuto.Text = "Auto"
            '			Me.btnAuto.Click += New System.EventHandler(Me.btnAuto_Click);
            ' 
            ' btnBlackPoint
            ' 
            Me.btnBlackPoint.FlatStyle = System.Windows.Forms.FlatStyle.Popup
            Me.btnBlackPoint.Location = New System.Drawing.Point(296, 168)
            Me.btnBlackPoint.Name = "btnBlackPoint"
            Me.btnBlackPoint.Size = New System.Drawing.Size(24, 23)
            Me.btnBlackPoint.TabIndex = 3
            '			Me.btnBlackPoint.Click += New System.EventHandler(Me.btnBlackPoint_Click);
            ' 
            ' btnGrayPoint
            ' 
            Me.btnGrayPoint.FlatStyle = System.Windows.Forms.FlatStyle.Popup
            Me.btnGrayPoint.Location = New System.Drawing.Point(320, 168)
            Me.btnGrayPoint.Name = "btnGrayPoint"
            Me.btnGrayPoint.Size = New System.Drawing.Size(24, 23)
            Me.btnGrayPoint.TabIndex = 4
            '			Me.btnGrayPoint.Click += New System.EventHandler(Me.btnGrayPoint_Click);
            ' 
            ' btnWhitePoint
            ' 
            Me.btnWhitePoint.FlatStyle = System.Windows.Forms.FlatStyle.Popup
            Me.btnWhitePoint.Location = New System.Drawing.Point(344, 168)
            Me.btnWhitePoint.Name = "btnWhitePoint"
            Me.btnWhitePoint.Size = New System.Drawing.Size(24, 23)
            Me.btnWhitePoint.TabIndex = 5
            '			Me.btnWhitePoint.Click += New System.EventHandler(Me.btnWhitePoint_Click);
            ' 
            ' LevelsDialog
            ' 
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(378, 224)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmbChannels, Me.btnWhitePoint, Me.btnGrayPoint, Me.btnBlackPoint, Me.btnAuto, Me.btnCancel, Me.groupBox1, Me.btnOK})
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "LevelsDialog"
            Me.Text = "Levels"
            Me.groupBox1.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
#End Region

        Private Sub picHistogram_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles picHistogram.Paint

            Dim histogram As Integer() = Nothing
            Select Case Me.cmbChannels.SelectedIndex
                Case 0
                    histogram = _combinedHistogram
                Case 1
                    histogram = _redHistogram
                Case 2
                    histogram = _greenHistogram
                Case 3
                    histogram = _blueHistogram
            End Select

            'maximum histogram value
            Dim maxValue As Integer = 0
            For i As Integer = 0 To 255
                If histogram(i) > maxValue Then
                    maxValue = histogram(i)
                End If
            Next i

            'draw it
            For i As Integer = 0 To 255
                e.Graphics.DrawLine(New Pen(Color.Black, 1), New Point(i, picHistogram.ClientSize.Height), New Point(i, CInt(Fix(picHistogram.ClientSize.Height - CDbl(histogram(i)) / maxValue * picHistogram.ClientSize.Height))))
            Next i
        End Sub

        Private Sub cmbChannels_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbChannels.SelectedIndexChanged
            picHistogram.Invalidate()
            SetTextFields()
        End Sub

        Private Sub btnAuto_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAuto.Click
            Me._viewer.Undos.Undo()
            Me._viewer.ApplyCommand(New AutoLevelsCommand(), "Auto Levels")
            GetHistograms()
        End Sub

        Private Sub btnBlackPoint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBlackPoint.Click
            _eyeDropper = EyeDropperStyle.BlackPoint
        End Sub

        Private Sub viewer_MouseMovePixel(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
            _mouseColor = _viewer.Image.GetPixelColor(e.X, e.Y)
            System.Diagnostics.Debug.WriteLine("Mouse Move Viewer " & _viewer.Image.GetPixelColor(e.X, e.Y).ToString())
        End Sub

        Private Sub viewer_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)

            System.Diagnostics.Debug.WriteLine("MouseDown " & e.X & " " & e.Y)
            Select Case _eyeDropper
                Case EyeDropperStyle.BlackPoint
                    _levels.ShadowColor = _mouseColor
                Case EyeDropperStyle.GrayPoint
                    _levels.MidtoneColor = _mouseColor
                Case EyeDropperStyle.WhitePoint
                    _levels.HighlightColor = _mouseColor
            End Select
            ApplyLevels()
            SetTextFields()

        End Sub

        Private Sub ApplyLevels()
            If (Not _loading) Then
                Me._viewer.Undos.Undo()
                _viewer.ApplyCommand(_levels, "Levels")
                GetHistograms()
            End If
        End Sub

        Private Sub SetTextFields()
            _loading = True
            Select Case Me.cmbChannels.SelectedIndex
                Case 0
                    Me.txtInputClipMin.Text = ((_levels.ShadowColor.R + _levels.ShadowColor.G + _levels.ShadowColor.B) / 3).ToString()
                    Me.txtInputClipMax.Text = ((CLng(Fix(_levels.HighlightColor.R)) + CLng(Fix(_levels.HighlightColor.G)) + CLng(Fix(_levels.HighlightColor.B))) / 3).ToString()
                    Me.txtOutputMin.Text = ((_levels.OutputRangeLow.R + _levels.OutputRangeLow.G + _levels.OutputRangeLow.B) / 3).ToString()
                    Me.txtOutputMax.Text = ((CLng(Fix(_levels.OutputRangeHigh.R)) + CLng(Fix(_levels.OutputRangeHigh.G)) + CLng(Fix(_levels.OutputRangeHigh.B))) / 3).ToString()
                    Me.txtGamma.Text = ((_levels.Gamma.R + _levels.Gamma.G + _levels.Gamma.B) / 3).ToString()
                Case 1
                    Me.txtInputClipMin.Text = _levels.ShadowColor.R.ToString()
                    Me.txtInputClipMax.Text = _levels.HighlightColor.R.ToString()
                    Me.txtOutputMin.Text = _levels.OutputRangeLow.R.ToString()
                    Me.txtOutputMax.Text = _levels.OutputRangeHigh.R.ToString()
                    Me.txtGamma.Text = _levels.Gamma.R.ToString()
                Case 2
                    Me.txtInputClipMin.Text = _levels.ShadowColor.G.ToString()
                    Me.txtInputClipMax.Text = _levels.HighlightColor.G.ToString()
                    Me.txtOutputMin.Text = _levels.OutputRangeLow.G.ToString()
                    Me.txtOutputMax.Text = _levels.OutputRangeHigh.G.ToString()
                    Me.txtGamma.Text = _levels.Gamma.G.ToString()
                Case 3
                    Me.txtInputClipMin.Text = _levels.ShadowColor.B.ToString()
                    Me.txtInputClipMax.Text = _levels.HighlightColor.B.ToString()
                    Me.txtOutputMin.Text = _levels.OutputRangeLow.B.ToString()
                    Me.txtOutputMax.Text = _levels.OutputRangeHigh.B.ToString()
                    Me.txtGamma.Text = _levels.Gamma.B.ToString()
            End Select
            _loading = False

        End Sub

        Private Sub btnGrayPoint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGrayPoint.Click
            _eyeDropper = EyeDropperStyle.GrayPoint
        End Sub

        Private Sub btnWhitePoint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnWhitePoint.Click
            _eyeDropper = EyeDropperStyle.WhitePoint
        End Sub

        Private Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOK.Click
            Me.Close()
        End Sub

        Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
            _viewer.Undos.Undo()
            Me.Close()
        End Sub

        Private Sub txtOutputMin_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOutputMin.TextChanged
            ' FB 7283 - Do a little bounds checking to avoid exceptions
            Dim clr As Byte
            If Not Byte.TryParse(txtOutputMin.Text, clr) Then
                txtOutputMin.Text = "0"
                clr = Byte.Parse("0")
            End If
            Select Case Me.cmbChannels.SelectedIndex
                Case 0
                    _levels.OutputRangeLow = Color.FromArgb(clr, clr, clr)
                Case 1
                    _levels.OutputRangeLow = Color.FromArgb(clr, _levels.OutputRangeLow.G, _levels.OutputRangeLow.B)
                Case 2
                    _levels.OutputRangeLow = Color.FromArgb(_levels.OutputRangeLow.R, clr, _levels.OutputRangeLow.B)
                Case 3
                    _levels.OutputRangeLow = Color.FromArgb(_levels.OutputRangeLow.R, _levels.OutputRangeLow.G, clr)
            End Select
            ApplyLevels()

        End Sub

        Private Sub txtOutputMax_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOutputMax.TextChanged
            ' FB 7283 - Do a little bounds checking to avoid exceptions
            Dim clr As Byte
            If Not Byte.TryParse(txtOutputMax.Text, clr) Then
                txtOutputMax.Text = "0"
                clr = Byte.Parse("0")
            End If
            Select Case Me.cmbChannels.SelectedIndex
                Case 0
                    _levels.OutputRangeHigh = Color.FromArgb(clr, clr, clr)
                Case 1
                    _levels.OutputRangeHigh = Color.FromArgb(clr, _levels.OutputRangeLow.G, _levels.OutputRangeLow.B)
                Case 2
                    _levels.OutputRangeHigh = Color.FromArgb(_levels.OutputRangeLow.R, clr, _levels.OutputRangeLow.B)
                Case 3
                    _levels.OutputRangeHigh = Color.FromArgb(_levels.OutputRangeLow.R, _levels.OutputRangeLow.G, clr)
            End Select
            ApplyLevels()
        End Sub

        Private Sub txtInputClipMin_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtInputClipMin.TextChanged
            ' FB 7283 - Do a little bounds checking to avoid exceptions
            Dim clr As Byte
            If Not Byte.TryParse(txtInputClipMin.Text, clr) Then
                txtInputClipMin.Text = "0"
                clr = Byte.Parse("0")
            End If
            Select Case Me.cmbChannels.SelectedIndex
                Case 0
                    _levels.ShadowColor = Color.FromArgb(clr, clr, clr)
                Case 1
                    _levels.ShadowColor = Color.FromArgb(clr, _levels.ShadowColor.G, _levels.ShadowColor.B)
                Case 2
                    _levels.ShadowColor = Color.FromArgb(_levels.ShadowColor.R, clr, _levels.ShadowColor.B)
                Case 3
                    _levels.ShadowColor = Color.FromArgb(_levels.ShadowColor.R, _levels.ShadowColor.G, clr)
            End Select
            ApplyLevels()
        End Sub

        Private Sub txtInputClipMax_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtInputClipMax.TextChanged
            ' FB 7283 - Do a little bounds checking to avoid exceptions
            Dim clr As Byte
            If Not Byte.TryParse(txtInputClipMax.Text, clr) Then
                txtInputClipMax.Text = "0"
                clr = Byte.Parse("0")
            End If
            Select Case Me.cmbChannels.SelectedIndex
                Case 0
                    _levels.HighlightColor = Color.FromArgb(clr, clr, clr)
                Case 1
                    _levels.HighlightColor = Color.FromArgb(clr, _levels.HighlightColor.G, _levels.HighlightColor.B)
                Case 2
                    _levels.HighlightColor = Color.FromArgb(_levels.HighlightColor.R, clr, _levels.HighlightColor.B)
                Case 3
                    _levels.HighlightColor = Color.FromArgb(_levels.HighlightColor.R, _levels.HighlightColor.G, clr)
            End Select
            ApplyLevels()
        End Sub

        Private Sub txtGamma_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtGamma.TextChanged
            ' FB 7283 - Do a little bounds checking to avoid exceptions
            Dim clr As Double
            If Not Double.TryParse(txtGamma.Text, clr) Then
                txtGamma.Text = "0"
                clr = Byte.Parse("0")
            End If
            Select Case Me.cmbChannels.SelectedIndex
                Case 0
                    _levels.Gamma = New GammaColor(clr, clr, clr)
                Case 1
                    _levels.Gamma = New GammaColor(_levels.Gamma.B, _levels.Gamma.G, clr)
                Case 2
                    _levels.Gamma = New GammaColor(_levels.Gamma.B, clr, _levels.Gamma.B)
                Case 3
                    _levels.Gamma = New GammaColor(clr, _levels.Gamma.G, _levels.Gamma.B)
            End Select
            ApplyLevels()
        End Sub
    End Class

    Friend Enum EyeDropperStyle
        None
        BlackPoint
        GrayPoint
        WhitePoint
    End Enum
End Namespace
