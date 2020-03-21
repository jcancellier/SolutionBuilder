<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SolutionBuilderForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SolutionBuilderForm))
        Me.btnAddSolution = New System.Windows.Forms.Button()
        Me.grpboxSolutions = New System.Windows.Forms.GroupBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnMoveSolutionUp = New System.Windows.Forms.ToolStripButton()
        Me.btnMoveSolutionDown = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnRemoveSolution = New System.Windows.Forms.ToolStripButton()
        Me.chkListSolutions = New System.Windows.Forms.ListView()
        Me.clmHeaderSolution = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.clmHeaderBranch = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnBuildSolutions = New System.Windows.Forms.Button()
        Me.txtboxBuildOutput = New System.Windows.Forms.RichTextBox()
        Me.chkboxShowBuildOutput = New System.Windows.Forms.CheckBox()
        Me.grpboxSolutions.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnAddSolution
        '
        Me.btnAddSolution.Location = New System.Drawing.Point(3, 153)
        Me.btnAddSolution.Name = "btnAddSolution"
        Me.btnAddSolution.Size = New System.Drawing.Size(641, 32)
        Me.btnAddSolution.TabIndex = 1
        Me.btnAddSolution.Text = "Add Solution"
        Me.btnAddSolution.UseVisualStyleBackColor = True
        '
        'grpboxSolutions
        '
        Me.grpboxSolutions.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpboxSolutions.Controls.Add(Me.ToolStrip1)
        Me.grpboxSolutions.Controls.Add(Me.chkListSolutions)
        Me.grpboxSolutions.Controls.Add(Me.btnAddSolution)
        Me.grpboxSolutions.Location = New System.Drawing.Point(12, 12)
        Me.grpboxSolutions.Name = "grpboxSolutions"
        Me.grpboxSolutions.Size = New System.Drawing.Size(647, 191)
        Me.grpboxSolutions.TabIndex = 2
        Me.grpboxSolutions.TabStop = False
        Me.grpboxSolutions.Text = "Solutions"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnMoveSolutionUp, Me.btnMoveSolutionDown, Me.ToolStripSeparator1, Me.btnRemoveSolution})
        Me.ToolStrip1.Location = New System.Drawing.Point(3, 125)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolStrip1.Size = New System.Drawing.Size(109, 25)
        Me.ToolStrip1.TabIndex = 6
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnMoveSolutionUp
        '
        Me.btnMoveSolutionUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnMoveSolutionUp.Image = CType(resources.GetObject("btnMoveSolutionUp.Image"), System.Drawing.Image)
        Me.btnMoveSolutionUp.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnMoveSolutionUp.Name = "btnMoveSolutionUp"
        Me.btnMoveSolutionUp.Size = New System.Drawing.Size(23, 22)
        Me.btnMoveSolutionUp.Text = "ToolStripButton1"
        Me.btnMoveSolutionUp.ToolTipText = "Move solution up"
        '
        'btnMoveSolutionDown
        '
        Me.btnMoveSolutionDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnMoveSolutionDown.Image = CType(resources.GetObject("btnMoveSolutionDown.Image"), System.Drawing.Image)
        Me.btnMoveSolutionDown.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnMoveSolutionDown.Name = "btnMoveSolutionDown"
        Me.btnMoveSolutionDown.Size = New System.Drawing.Size(23, 22)
        Me.btnMoveSolutionDown.Text = "ToolStripButton1"
        Me.btnMoveSolutionDown.ToolTipText = "Move solution down"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'btnRemoveSolution
        '
        Me.btnRemoveSolution.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnRemoveSolution.Image = CType(resources.GetObject("btnRemoveSolution.Image"), System.Drawing.Image)
        Me.btnRemoveSolution.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnRemoveSolution.Name = "btnRemoveSolution"
        Me.btnRemoveSolution.Size = New System.Drawing.Size(23, 22)
        Me.btnRemoveSolution.Text = "ToolStripButton1"
        Me.btnRemoveSolution.ToolTipText = "Remove solution from list"
        '
        'chkListSolutions
        '
        Me.chkListSolutions.Alignment = System.Windows.Forms.ListViewAlignment.Left
        Me.chkListSolutions.CheckBoxes = True
        Me.chkListSolutions.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.clmHeaderSolution, Me.clmHeaderBranch})
        Me.chkListSolutions.Dock = System.Windows.Forms.DockStyle.Top
        Me.chkListSolutions.HideSelection = False
        Me.chkListSolutions.LabelWrap = False
        Me.chkListSolutions.Location = New System.Drawing.Point(3, 16)
        Me.chkListSolutions.MultiSelect = False
        Me.chkListSolutions.Name = "chkListSolutions"
        Me.chkListSolutions.Size = New System.Drawing.Size(641, 106)
        Me.chkListSolutions.TabIndex = 2
        Me.chkListSolutions.UseCompatibleStateImageBehavior = False
        Me.chkListSolutions.View = System.Windows.Forms.View.Details
        '
        'clmHeaderSolution
        '
        Me.clmHeaderSolution.Text = "Solution"
        Me.clmHeaderSolution.Width = 0
        '
        'clmHeaderBranch
        '
        Me.clmHeaderBranch.Text = "Branch"
        Me.clmHeaderBranch.Width = 0
        '
        'btnBuildSolutions
        '
        Me.btnBuildSolutions.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.btnBuildSolutions.Enabled = False
        Me.btnBuildSolutions.Location = New System.Drawing.Point(0, 390)
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
        Me.txtboxBuildOutput.Location = New System.Drawing.Point(15, 209)
        Me.txtboxBuildOutput.Name = "txtboxBuildOutput"
        Me.txtboxBuildOutput.ReadOnly = True
        Me.txtboxBuildOutput.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical
        Me.txtboxBuildOutput.Size = New System.Drawing.Size(644, 152)
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
        Me.chkboxShowBuildOutput.Location = New System.Drawing.Point(12, 367)
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
        Me.ClientSize = New System.Drawing.Size(671, 432)
        Me.Controls.Add(Me.chkboxShowBuildOutput)
        Me.Controls.Add(Me.txtboxBuildOutput)
        Me.Controls.Add(Me.btnBuildSolutions)
        Me.Controls.Add(Me.grpboxSolutions)
        Me.Name = "SolutionBuilderForm"
        Me.Text = "Solution Builder"
        Me.grpboxSolutions.ResumeLayout(False)
        Me.grpboxSolutions.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnAddSolution As Button
    Friend WithEvents grpboxSolutions As GroupBox
    Friend WithEvents btnBuildSolutions As Button
    Friend WithEvents txtboxBuildOutput As RichTextBox
    Friend WithEvents chkboxShowBuildOutput As CheckBox
    Friend WithEvents chkListSolutions As ListView
    Friend WithEvents clmHeaderSolution As ColumnHeader
    Friend WithEvents clmHeaderBranch As ColumnHeader
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents btnMoveSolutionUp As ToolStripButton
    Friend WithEvents btnMoveSolutionDown As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents btnRemoveSolution As ToolStripButton
End Class
