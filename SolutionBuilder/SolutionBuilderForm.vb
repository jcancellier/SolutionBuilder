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

        ' Disable Toolstrip buttons if no solutions are present
        btnMoveSolutionDown.Enabled = False
        btnMoveSolutionUp.Enabled = False
        btnRemoveSolution.Enabled = False
    End Sub

    Private Sub btnAddSolution_Click(sender As Object, e As EventArgs) Handles btnAddSolution.Click
        'Open File Dialog
        Using openFileDialog As New OpenFileDialog()
            openFileDialog.Filter = "Solution Files | *.sln"
            If openFileDialog.ShowDialog() = DialogResult.OK Then
                Dim solutionFilePath As String = openFileDialog.FileName
                Dim solutionSafeFilePath As String = openFileDialog.SafeFileName
                Dim solutionDirectoryPath As String = System.IO.Path.GetDirectoryName(solutionFilePath)
                Dim currentBranch As String = GitServices.RetrieveCurrentGitBranchService.Execute(solutionDirectoryPath)
                Dim solutionDataItem As New ListViewItem(New String() {solutionSafeFilePath, currentBranch})
                chkListSolutions.Items.Add(solutionDataItem)
                chkListSolutions.Items(chkListSolutions.Items.Count - 1).Tag = solutionFilePath
                chkListSolutions.Items(chkListSolutions.Items.Count - 1).Checked = True

                'Enable controls when a solution exists in list
                If chkListSolutions.CheckedItems.Count > 0 Then
                    btnBuildSolutions.Enabled = True
                End If
                ResizeSolutionListColumns()
                CheckSolutionListSelectedIndex()
            End If
        End Using
    End Sub

    Private Sub CheckSolutionListSelectedIndex()
        chkListSolutions_SelectedIndexChanged(Nothing, Nothing)
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
                solution = chkListSolutions.CheckedItems(CType(chkListSolutions.Tag, SolutionCheckListData).CurrentSolutionBuildingIndex).Tag
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

    Private Sub ResizeSolutionListColumns()
        chkListSolutions.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)
        chkListSolutions.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
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

    Private Sub btnMoveSolutionDown_Click(sender As Object, e As EventArgs) Handles btnMoveSolutionDown.Click
        Dim indexUnderSelected As Integer = chkListSolutions.SelectedIndices(0) + 1
        Dim itemUnderSelected As ListViewItem = chkListSolutions.Items(indexUnderSelected)
        chkListSolutions.Items.RemoveAt(indexUnderSelected)
        chkListSolutions.Items.Insert(indexUnderSelected - 1, itemUnderSelected)
        CheckSolutionListSelectedIndex()
    End Sub

    Private Sub btnMoveSolutionUp_Click(sender As Object, e As EventArgs) Handles btnMoveSolutionUp.Click
        Dim indexAboveSelected As Integer = chkListSolutions.SelectedIndices(0) - 1
        Dim itemAboveSelected As ListViewItem = chkListSolutions.Items(indexAboveSelected)
        chkListSolutions.Items.RemoveAt(indexAboveSelected)
        chkListSolutions.Items.Insert(indexAboveSelected + 1, itemAboveSelected)
        CheckSolutionListSelectedIndex()
    End Sub
    Private Sub btnRemoveSolution_Click(sender As Object, e As EventArgs) Handles btnRemoveSolution.Click
        Dim currentIndex As Integer = chkListSolutions.SelectedIndices(0)
        chkListSolutions.Items.RemoveAt(currentIndex)
    End Sub

    Private Sub chkListSolutions_SelectedIndexChanged(sender As Object, e As EventArgs) Handles chkListSolutions.SelectedIndexChanged
        Dim selectedItemsCount As Integer = chkListSolutions.SelectedItems.Count

        'Enable remove button if a solution is selected
        If selectedItemsCount > 0 Then
            btnRemoveSolution.Enabled = True
        Else
            btnRemoveSolution.Enabled = False
        End If

        'Enable/Disable MoveUp and MoveDown Buttons
        If selectedItemsCount > 0 AndAlso chkListSolutions.Items.Count > 1 Then
            ' Enable Toolstrip buttons if no solutions are present
            Dim isBottomItem As Boolean = (chkListSolutions.SelectedIndices(0) = chkListSolutions.Items.Count - 1)
            If Not isBottomItem Then
                btnMoveSolutionDown.Enabled = True
            Else
                btnMoveSolutionDown.Enabled = False
            End If

            Dim isTopItem As Boolean = (chkListSolutions.SelectedIndices(0) = 0)
            If Not isTopItem Then
                btnMoveSolutionUp.Enabled = True
            Else
                btnMoveSolutionUp.Enabled = False
            End If
        Else
            btnMoveSolutionDown.Enabled = False
            btnMoveSolutionUp.Enabled = False
        End If
    End Sub


#End Region
End Class
