<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LocateMSBuildDialog
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.btnAutoDetect = New System.Windows.Forms.Button()
        Me.btnOpenFile = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblMSBuildInfo = New System.Windows.Forms.Label()
        Me.lblResults = New System.Windows.Forms.Label()
        Me.btnConfirm = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(358, 145)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(86, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancel"
        '
        'btnAutoDetect
        '
        Me.btnAutoDetect.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnAutoDetect.Location = New System.Drawing.Point(13, 145)
        Me.btnAutoDetect.Name = "btnAutoDetect"
        Me.btnAutoDetect.Size = New System.Drawing.Size(86, 23)
        Me.btnAutoDetect.TabIndex = 2
        Me.btnAutoDetect.Text = "Auto Detect"
        '
        'btnOpenFile
        '
        Me.btnOpenFile.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnOpenFile.Location = New System.Drawing.Point(105, 145)
        Me.btnOpenFile.Name = "btnOpenFile"
        Me.btnOpenFile.Size = New System.Drawing.Size(86, 23)
        Me.btnOpenFile.TabIndex = 3
        Me.btnOpenFile.Text = "Open File..."
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.TableLayoutPanel1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(456, 129)
        Me.Panel1.TabIndex = 4
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.lblResults, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblMSBuildInfo, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(456, 129)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'lblMSBuildInfo
        '
        Me.lblMSBuildInfo.AutoSize = True
        Me.lblMSBuildInfo.Location = New System.Drawing.Point(10, 10)
        Me.lblMSBuildInfo.Margin = New System.Windows.Forms.Padding(10, 10, 3, 0)
        Me.lblMSBuildInfo.Name = "lblMSBuildInfo"
        Me.lblMSBuildInfo.Size = New System.Drawing.Size(418, 26)
        Me.lblMSBuildInfo.TabIndex = 0
        Me.lblMSBuildInfo.Text = "MSBuild is used to build Visual Studio Solutions. You may allow Solution Builder " &
    "to auto-detect MSBuild, or you may manually locate the file. Select from the opt" &
    "ions below."
        '
        'lblResults
        '
        Me.lblResults.AutoSize = True
        Me.lblResults.Location = New System.Drawing.Point(10, 74)
        Me.lblResults.Margin = New System.Windows.Forms.Padding(10, 10, 3, 0)
        Me.lblResults.Name = "lblResults"
        Me.lblResults.Size = New System.Drawing.Size(0, 13)
        Me.lblResults.TabIndex = 1
        '
        'btnConfirm
        '
        Me.btnConfirm.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnConfirm.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnConfirm.Enabled = False
        Me.btnConfirm.Location = New System.Drawing.Point(266, 145)
        Me.btnConfirm.Name = "btnConfirm"
        Me.btnConfirm.Size = New System.Drawing.Size(86, 23)
        Me.btnConfirm.TabIndex = 5
        Me.btnConfirm.Text = "Confirm"
        '
        'LocateMSBuildDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(456, 180)
        Me.Controls.Add(Me.btnConfirm)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnOpenFile)
        Me.Controls.Add(Me.btnAutoDetect)
        Me.Controls.Add(Me.Cancel_Button)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "LocateMSBuildDialog"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Locate MSBuild"
        Me.Panel1.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Cancel_Button As Button
    Friend WithEvents btnAutoDetect As Button
    Friend WithEvents btnOpenFile As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents lblMSBuildInfo As Label
    Friend WithEvents lblResults As Label
    Friend WithEvents btnConfirm As Button
End Class
