<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SolutionBuilderForm
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
        Me.chklistSolutions = New System.Windows.Forms.CheckedListBox()
        Me.btnAddSolution = New System.Windows.Forms.Button()
        Me.grpboxSolutions = New System.Windows.Forms.GroupBox()
        Me.btnBuildSolutions = New System.Windows.Forms.Button()
        Me.txtboxBuildOutput = New System.Windows.Forms.RichTextBox()
        Me.chkboxShowBuildOutput = New System.Windows.Forms.CheckBox()
        Me.grpboxSolutions.SuspendLayout()
        Me.SuspendLayout()
        '
        'chklistSolutions
        '
        Me.chklistSolutions.Dock = System.Windows.Forms.DockStyle.Top
        Me.chklistSolutions.FormattingEnabled = True
        Me.chklistSolutions.Location = New System.Drawing.Point(3, 16)
        Me.chklistSolutions.Name = "chklistSolutions"
        Me.chklistSolutions.Size = New System.Drawing.Size(641, 94)
        Me.chklistSolutions.TabIndex = 0
        '
        'btnAddSolution
        '
        Me.btnAddSolution.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.btnAddSolution.Location = New System.Drawing.Point(3, 116)
        Me.btnAddSolution.Name = "btnAddSolution"
        Me.btnAddSolution.Size = New System.Drawing.Size(641, 29)
        Me.btnAddSolution.TabIndex = 1
        Me.btnAddSolution.Text = "Add Solution"
        Me.btnAddSolution.UseVisualStyleBackColor = True
        '
        'grpboxSolutions
        '
        Me.grpboxSolutions.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpboxSolutions.Controls.Add(Me.chklistSolutions)
        Me.grpboxSolutions.Controls.Add(Me.btnAddSolution)
        Me.grpboxSolutions.Location = New System.Drawing.Point(12, 12)
        Me.grpboxSolutions.Name = "grpboxSolutions"
        Me.grpboxSolutions.Size = New System.Drawing.Size(647, 148)
        Me.grpboxSolutions.TabIndex = 2
        Me.grpboxSolutions.TabStop = False
        Me.grpboxSolutions.Text = "Solutions"
        '
        'btnBuildSolutions
        '
        Me.btnBuildSolutions.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.btnBuildSolutions.Enabled = False
        Me.btnBuildSolutions.Location = New System.Drawing.Point(0, 319)
        Me.btnBuildSolutions.Name = "btnBuildSolutions"
        Me.btnBuildSolutions.Size = New System.Drawing.Size(671, 42)
        Me.btnBuildSolutions.TabIndex = 3
        Me.btnBuildSolutions.Text = "Build Solutions!"
        Me.btnBuildSolutions.UseVisualStyleBackColor = True
        '
        'txtboxBuildOutput
        '
        Me.txtboxBuildOutput.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtboxBuildOutput.BackColor = System.Drawing.SystemColors.Control
        Me.txtboxBuildOutput.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtboxBuildOutput.DetectUrls = False
        Me.txtboxBuildOutput.HideSelection = False
        Me.txtboxBuildOutput.Location = New System.Drawing.Point(15, 164)
        Me.txtboxBuildOutput.Name = "txtboxBuildOutput"
        Me.txtboxBuildOutput.ReadOnly = True
        Me.txtboxBuildOutput.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical
        Me.txtboxBuildOutput.Size = New System.Drawing.Size(644, 126)
        Me.txtboxBuildOutput.TabIndex = 4
        Me.txtboxBuildOutput.Text = ""
        '
        'chkboxShowBuildOutput
        '
        Me.chkboxShowBuildOutput.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkboxShowBuildOutput.AutoSize = True
        Me.chkboxShowBuildOutput.Checked = True
        Me.chkboxShowBuildOutput.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkboxShowBuildOutput.Location = New System.Drawing.Point(12, 296)
        Me.chkboxShowBuildOutput.Name = "chkboxShowBuildOutput"
        Me.chkboxShowBuildOutput.Size = New System.Drawing.Size(114, 17)
        Me.chkboxShowBuildOutput.TabIndex = 5
        Me.chkboxShowBuildOutput.Text = "Show Build Output"
        Me.chkboxShowBuildOutput.UseVisualStyleBackColor = True
        '
        'SolutionBuilderForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(671, 361)
        Me.Controls.Add(Me.chkboxShowBuildOutput)
        Me.Controls.Add(Me.txtboxBuildOutput)
        Me.Controls.Add(Me.btnBuildSolutions)
        Me.Controls.Add(Me.grpboxSolutions)
        Me.Name = "SolutionBuilderForm"
        Me.Text = "Solution Builder"
        Me.grpboxSolutions.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents chklistSolutions As CheckedListBox
    Friend WithEvents btnAddSolution As Button
    Friend WithEvents grpboxSolutions As GroupBox
    Friend WithEvents btnBuildSolutions As Button
    Friend WithEvents txtboxBuildOutput As RichTextBox
    Friend WithEvents chkboxShowBuildOutput As CheckBox
End Class
