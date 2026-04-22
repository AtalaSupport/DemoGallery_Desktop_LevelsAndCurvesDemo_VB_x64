Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data
Imports Atalasoft.Imaging.Codec
Imports WinDemoHelperMethods.WinDemoHelperMethods

Namespace LevelsAndCurvesDemo
    ''' <summary>
    ''' Summary description for Form1.
    ''' </summary>
    Public Class Form1
        Inherits System.Windows.Forms.Form
        Private _curvePoints As PointF() = Nothing
        Private _curveChannels As Atalasoft.Imaging.ImageProcessing.ChannelFlags
        Private WithEvents workspaceViewer1 As Atalasoft.Imaging.WinControls.WorkspaceViewer
        Private WithEvents btnOpen As System.Windows.Forms.Button
        Private openFileDialog1 As System.Windows.Forms.OpenFileDialog
        Private WithEvents btnLevels As System.Windows.Forms.Button
        Private WithEvents btnCurves As System.Windows.Forms.Button
        Private WithEvents AboutBtn As System.Windows.Forms.Button
        ''' <summary>
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.Container = Nothing

        Shared Sub New()
            HelperMethods.PopulateDecoders(RegisteredDecoders.Decoders)
        End Sub

        Public Sub New()
            '
            ' Required for Windows Form Designer support
            '
            InitializeComponent()

            _curveChannels = Atalasoft.Imaging.ImageProcessing.ChannelFlags.AllChannels
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
            MyBase.Dispose(disposing)
        End Sub

#Region "Windows Form Designer generated code"
        ''' <summary>
        ''' Required method for Designer support - do not modify
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Me.workspaceViewer1 = New Atalasoft.Imaging.WinControls.WorkspaceViewer()
            Me.btnOpen = New System.Windows.Forms.Button()
            Me.openFileDialog1 = New System.Windows.Forms.OpenFileDialog()
            Me.btnLevels = New System.Windows.Forms.Button()
            Me.btnCurves = New System.Windows.Forms.Button()
            Me.AboutBtn = New System.Windows.Forms.Button()
            Me.SuspendLayout()
            ' 
            ' workspaceViewer1
            ' 
            Me.workspaceViewer1.Anchor = (CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
            Me.workspaceViewer1.DisplayProfile = Nothing
            Me.workspaceViewer1.Location = New System.Drawing.Point(0, 0)
            Me.workspaceViewer1.Magnifier.BackColor = System.Drawing.Color.White
            Me.workspaceViewer1.Magnifier.BorderColor = System.Drawing.Color.Black
            Me.workspaceViewer1.Magnifier.Size = New System.Drawing.Size(100, 100)
            Me.workspaceViewer1.Name = "workspaceViewer1"
            Me.workspaceViewer1.OutputProfile = Nothing
            Me.workspaceViewer1.Selection = Nothing
            Me.workspaceViewer1.Size = New System.Drawing.Size(644, 372)
            Me.workspaceViewer1.TabIndex = 0
            Me.workspaceViewer1.Text = "workspaceViewer1"
            Me.workspaceViewer1.UndoLevels = 1
            '			Me.workspaceViewer1.MouseMovePixel += New System.Windows.Forms.MouseEventHandler(Me.workspaceViewer1_MouseMovePixel);
            ' 
            ' btnOpen
            ' 
            Me.btnOpen.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles))
            Me.btnOpen.Location = New System.Drawing.Point(8, 380)
            Me.btnOpen.Name = "btnOpen"
            Me.btnOpen.TabIndex = 1
            Me.btnOpen.Text = "Open"
            '			Me.btnOpen.Click += New System.EventHandler(Me.btnOpen_Click);
            ' 
            ' btnLevels
            ' 
            Me.btnLevels.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles))
            Me.btnLevels.Location = New System.Drawing.Point(96, 380)
            Me.btnLevels.Name = "btnLevels"
            Me.btnLevels.TabIndex = 2
            Me.btnLevels.Text = "Levels..."
            '			Me.btnLevels.Click += New System.EventHandler(Me.btnLevels_Click);
            ' 
            ' btnCurves
            ' 
            Me.btnCurves.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles))
            Me.btnCurves.Location = New System.Drawing.Point(184, 380)
            Me.btnCurves.Name = "btnCurves"
            Me.btnCurves.TabIndex = 3
            Me.btnCurves.Text = "Curves..."
            '			Me.btnCurves.Click += New System.EventHandler(Me.btnCurves_Click);
            ' 
            ' AboutBtn
            ' 
            Me.AboutBtn.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
            Me.AboutBtn.Location = New System.Drawing.Point(552, 380)
            Me.AboutBtn.Name = "AboutBtn"
            Me.AboutBtn.Size = New System.Drawing.Size(88, 24)
            Me.AboutBtn.TabIndex = 4
            Me.AboutBtn.Text = "About ..."
            '			Me.AboutBtn.Click += New System.EventHandler(Me.AboutBtn_Click);
            ' 
            ' Form1
            ' 
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(648, 406)
            Me.Controls.Add(Me.AboutBtn)
            Me.Controls.Add(Me.btnCurves)
            Me.Controls.Add(Me.btnLevels)
            Me.Controls.Add(Me.btnOpen)
            Me.Controls.Add(Me.workspaceViewer1)
            Me.Name = "Form1"
            Me.Text = "Atalasoft Levels And Curves Demo"
            Me.ResumeLayout(False)

        End Sub
#End Region

        ''' <summary>
        ''' The main entry point for the application.
        ''' </summary>
        <STAThread()> _
        Shared Sub Main()
            Application.Run(New Form1())
        End Sub

        Private Sub btnOpen_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOpen.Click
            Me.openFileDialog1.Filter = HelperMethods.CreateDialogFilter(True)
            If Me.openFileDialog1.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
                'FB 7281 - adding try/catch to prevent unrecognized Image Format Exceptions
                Try
                    Me.workspaceViewer1.Open(Me.openFileDialog1.FileName)
                    ' FB 7327 - clearing the undo buffer prevents unwanted behavior
                    Me.workspaceViewer1.Undos.Clear()
                Catch ex As Exception
                    MessageBox.Show("Image format is not supported.")
                End Try

            End If
        End Sub

        Private Sub btnLevels_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLevels.Click
            ' FB 7282 - preventing unhandled exception when no image loaded
            If Me.workspaceViewer1.Image Is Nothing Then
                MessageBox.Show("Please open an image before attempting to adjust levels.")
            Else
                Dim levels As New LevelsDialog(Me.workspaceViewer1)
                levels.TopMost = True
                levels.Show()
            End If
        End Sub

        Private Sub workspaceViewer1_MouseMovePixel(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles workspaceViewer1.MouseMovePixel
            System.Diagnostics.Debug.WriteLine("Mouse Move Viewer " & workspaceViewer1.Image.GetPixelColor(e.X, e.Y).ToString())
        End Sub

        Private Sub btnCurves_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCurves.Click
            ' FB 7282 - preventing unhandled exception when no image loaded
            If Me.workspaceViewer1.Image Is Nothing Then
                MessageBox.Show("Please open an image before attempting to adjust levels.")
            Else
                Dim dlg As CurveDialog = New CurveDialog(Me.workspaceViewer1, _curvePoints, _curveChannels)
                dlg.ShowDialog(Me)
                dlg.Dispose()
            End If

        End Sub

        Private Sub AboutBtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles AboutBtn.Click
            Dim aboutBox As AtalaDemos.AboutBox.About = New AtalaDemos.AboutBox.About("About Atalasoft DotImage Levels and Curves Demo", "DotImage Levels and Curves Demo")
            aboutBox.Description = "Demonstrates how DotImage's Levels and Curves commands will work on an a photographic image as well as a demonstration of AutoLevels.  These features require a license of DotImage Photo Pro."
            aboutBox.ShowDialog()

        End Sub
    End Class
End Namespace
