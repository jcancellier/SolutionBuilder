Imports SolutionBuilder.Utilities
Imports SolutionBuilder.Models

Public Class SolutionBuilderForm

#Region "Event Handlers"
    Private Sub SolutionBuilderForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Optimize appending build output to text box by double buffering the form
        Me.SetStyle(
            ControlStyles.AllPaintingInWmPaint _
            Or ControlStyles.UserPaint _
            Or ControlStyles.OptimizedDoubleBuffer, True
        )

        'Set current solution build index to -1
        chkListSolutions.Tag = New SolutionCheckListData() With {
            .CurrentSolutionBuildingIndex = -1
        }
    End Sub

    Private Sub btnAddSolution_Click(sender As Object, e As EventArgs) Handles btnAddSolution.Click
        'Open File Dialog
        Using openFileDialog As New OpenFileDialog()
            openFileDialog.Filter = "Solution Files | *.sln"
            If openFileDialog.ShowDialog() = DialogResult.OK Then
                chkListSolutions.Items.Add(openFileDialog.FileName)
                chkListSolutions.Items(chkListSolutions.Items.Count - 1).Checked = True
                If chkListSolutions.CheckedItems.Count > 0 Then
                    btnBuildSolutions.Enabled = True
                End If
            End If
        End Using
    End Sub

    Private Sub btnBuildSolutions_Click(sender As Object, e As EventArgs) Handles btnBuildSolutions.Click
        BuildSolutions()
    End Sub

    Private Sub chkboxShowBuildOutput_CheckedChanged(sender As Object, e As EventArgs) Handles chkboxShowBuildOutput.CheckedChanged
        If (chkboxShowBuildOutput.Checked) Then
            txtboxBuildOutput.Show()
        Else
            txtboxBuildOutput.Hide()
        End If
    End Sub
#End Region

#Region "Private Methods"
    Private Sub BuildSolutions()
        If CType(chklistSolutions.Tag, SolutionCheckListData).CurrentSolutionBuildingIndex <> -1 Then
            Exit Sub
        End If

        SetControlsEnabledStatus(False)

        ' Locate MSBuild if file path not present (this will always execute on first run of program)
        If String.IsNullOrEmpty(ApplicationData.Instance.MSBuildFileLocation) Then
            Cursor = Cursors.WaitCursor
            txtboxBuildOutput.AppendText($"Locating {Constants.MSBuildExe}")
            ApplicationData.Instance.MSBuildFileLocation = LocateMSBuildService.Execute()
            Cursor = Cursors.Default
        End If

        ' If no MSBuild file path was found then retrieve it through form
        If (String.IsNullOrEmpty(ApplicationData.Instance.MSBuildFileLocation)) Then
            Dim locateMSBuildDialog As New LocateMSBuildDialog()
            If locateMSBuildDialog.ShowDialog() = DialogResult.Cancel Or String.IsNullOrEmpty(locateMSBuildDialog.MSBuildFilePathResult) Then
                SetControlsEnabledStatus(True)
                Exit Sub
            ElseIf Not String.IsNullOrEmpty(locateMSBuildDialog.MSBuildFilePathResult) Then
                ApplicationData.Instance.MSBuildFileLocation = locateMSBuildDialog.MSBuildFilePathResult
            Else
                SetControlsEnabledStatus(True)
                Exit Sub
            End If
        End If

        'Call with dummy data since the helper also serves as an event handler for Process.Exited event
        BuildSolutionsHelper(New Object, New EventArgs())
    End Sub

    Private Sub BuildSolutionsHelper(sender As Object, e As EventArgs)
        Dim done As Boolean = False
        Invoke(New MethodInvoker(
            Sub()
                CType(chkListSolutions.Tag, SolutionCheckListData).CurrentSolutionBuildingIndex += 1
                If CType(chkListSolutions.Tag, SolutionCheckListData).CurrentSolutionBuildingIndex = chkListSolutions.CheckedItems.Count Then
                    'Terminate build process for all solutions
                    SetControlsEnabledStatus(True)
                    CType(chkListSolutions.Tag, SolutionCheckListData).CurrentSolutionBuildingIndex = -1
                    done = True
                End If
            End Sub))

        If done Then
            Exit Sub
        End If

        'Clear build output
        txtboxBuildOutput.Invoke(New MethodInvoker(
            Sub()
                txtboxBuildOutput.Clear()
            End Sub))

        Dim msbuildPath As String = $"""{ApplicationData.Instance.MSBuildFileLocation}"""
        Dim solution As String = String.Empty

        Invoke(New MethodInvoker(
            Sub()
                solution = chkListSolutions.CheckedItems(CType(chkListSolutions.Tag, SolutionCheckListData).CurrentSolutionBuildingIndex).Text
            End Sub))

        Dim buildCommand As String = $"/c ""{msbuildPath} {solution}"""

        Dim processStartInfo As New ProcessStartInfo() With {
            .FileName = "cmd.exe",
            .Arguments = buildCommand,
            .UseShellExecute = False,
            .RedirectStandardOutput = True,
            .RedirectStandardError = True,
            .CreateNoWindow = True
        }

        'Create Process for executing build
        Dim process As New Process()
        AddHandler process.OutputDataReceived, AddressOf HandleBuildOutput
        AddHandler process.ErrorDataReceived, AddressOf HandleBuildError
        process.StartInfo = processStartInfo
        process.Start()
        process.EnableRaisingEvents = True
        AddHandler process.Exited, AddressOf BuildSolutionsHelper
        process.BeginOutputReadLine()
        process.BeginErrorReadLine()
    End Sub

    Private Sub HandleBuildOutput(sender As Object, e As DataReceivedEventArgs)
        If e.Data = Nothing Then
            Exit Sub
        End If
        txtboxBuildOutput.BeginInvoke(New MethodInvoker(
            Sub()
                txtboxBuildOutput.AppendText(vbCrLf & e.Data)
            End Sub))
    End Sub

    Private Sub HandleBuildError(sender As Object, e As DataReceivedEventArgs)
        If e.Data = Nothing Then
            Exit Sub
        End If
        txtboxBuildOutput.BeginInvoke(New MethodInvoker(
            Sub()
                txtboxBuildOutput.AppendText(vbCrLf & e.Data)
            End Sub))
    End Sub


    Private Sub SetControlsEnabledStatus(enabled As Boolean)
        Invoke(New MethodInvoker(
            Sub()
                btnAddSolution.Enabled = enabled
                btnBuildSolutions.Enabled = enabled
                chkListSolutions.Enabled = enabled
            End Sub))
    End Sub

    Private Sub SolutionBuilderForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        ApplicationData.Instance.Save()
    End Sub

    Private Sub chkListSolutions_ItemChecked(sender As Object, e As ItemCheckedEventArgs) Handles chkListSolutions.ItemChecked
        Invoke(New MethodInvoker(
            Sub()
                If chkListSolutions.CheckedItems.Count > 0 Then
                    btnBuildSolutions.Enabled = True
                Else
                    btnBuildSolutions.Enabled = False
                End If
            End Sub))
    End Sub
#End Region
End Class
