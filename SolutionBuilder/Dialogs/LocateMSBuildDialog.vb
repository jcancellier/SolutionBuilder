Imports System.Windows.Forms
Imports SolutionBuilder.Utilities

Public Class LocateMSBuildDialog
    Public Property MSBuildFilePathResult As String = String.Empty

#Region "Event Handlers"
    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnAutoDetect_Click(sender As Object, e As EventArgs) Handles btnAutoDetect.Click
        lblResults.ForeColor = DefaultForeColor
        lblResults.ResetText()
        lblResults.Text = $"Locating {Constants.MSBuildExe}..."
        Cursor = Cursors.WaitCursor
        MSBuildFilePathResult = LocateMSBuildService.Execute()
        If String.IsNullOrEmpty(MSBuildFilePathResult) Then
            lblResults.Text = $"Unable to auto-detect MSBuild.exe. Please try manually opening MSBuild.exe with the option below"
            lblResults.ForeColor = Color.Red
            'Focus Open File button
            btnOpenFile.Select()
        Else
            lblResults.Text = "MSBuild found successfully: " & vbCrLf & MSBuildFilePathResult & vbCrLf & "Click Confirm to continue"
            lblResults.ForeColor = DefaultForeColor
            btnConfirm.Enabled = True
            btnConfirm.Select()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub LocateMSBuildDialog_Load(sender As Object, e As EventArgs) Handles Me.Load
        btnAutoDetect.Select()
    End Sub

    Private Sub BtnOpenFile_Click(sender As Object, e As EventArgs) Handles btnOpenFile.Click
        Dim openFileDialog As New OpenFileDialog()
        openFileDialog.Filter = "MSBuild (MSBuild.exe) | MSBuild.exe"

        If openFileDialog.ShowDialog() = DialogResult.OK Then
            MSBuildFilePathResult = openFileDialog.FileName
            lblResults.Text = "MSBuild file selected: " & vbCrLf & MSBuildFilePathResult & vbCrLf & "Click Confirm to continue"
            lblResults.ForeColor = DefaultForeColor
            btnConfirm.Enabled = True
            btnConfirm.Select()
        End If
    End Sub
#End Region
End Class
