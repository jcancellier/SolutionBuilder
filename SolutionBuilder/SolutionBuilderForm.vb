Public Class SolutionBuilderForm
    Private Sub btnAddSolution_Click(sender As Object, e As EventArgs) Handles btnAddSolution.Click
        'Open File Dialog
        Using openFileDialog As New OpenFileDialog()
            openFileDialog.Filter = "Solution Files | *.sln"
            If openFileDialog.ShowDialog() = DialogResult.OK Then
                chklistSolutions.Items.Add(openFileDialog.FileName, True)
                btnBuildSolutions.Enabled = True
            End If
        End Using
    End Sub

    Private Sub btnBuildSolutions_Click(sender As Object, e As EventArgs) Handles btnBuildSolutions.Click
        BuildSolutions()
    End Sub

    Private Sub BuildSolutions()
        If CType(chklistSolutions.Tag, SolutionCheckListData).CurrentSolutionBuildingIndex <> -1 Then
            Exit Sub
        End If

        SetControlsEnabledStatus(False)
        'Call with dummy data since the helper also serves as an event handler for Process.Exited event
        BuildSolutionsHelper(New Object, New EventArgs())
    End Sub

    Private Sub BuildSolutionsHelper(sender As Object, e As EventArgs)
        CType(chklistSolutions.Tag, SolutionCheckListData).CurrentSolutionBuildingIndex += 1
        If CType(chklistSolutions.Tag, SolutionCheckListData).CurrentSolutionBuildingIndex = chklistSolutions.CheckedItems.Count Then
            'Terminate build process for all solutions
            SetControlsEnabledStatus(True)
            CType(chklistSolutions.Tag, SolutionCheckListData).CurrentSolutionBuildingIndex = -1
            Exit Sub
        End If

        'Clear build output
        txtboxBuildOutput.BeginInvoke(New MethodInvoker(
            Sub()
                txtboxBuildOutput.Clear()
            End Sub))

        Dim msbuildPath As String = """c:\Program Files (x86)\Microsoft Visual Studio\2017\Professional\MSBuild\15.0\Bin\amd64\MSbuild.exe"""
        Dim solution As String = chklistSolutions.CheckedItems(CType(chklistSolutions.Tag, SolutionCheckListData).CurrentSolutionBuildingIndex)
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
                txtboxBuildOutput.ScrollToCaret()
            End Sub))
    End Sub

    Private Sub HandleBuildError(sender As Object, e As DataReceivedEventArgs)
        If e.Data = Nothing Then
            Exit Sub
        End If
        txtboxBuildOutput.BeginInvoke(New MethodInvoker(
            Sub()
                txtboxBuildOutput.AppendText(vbCrLf & e.Data)
                txtboxBuildOutput.ScrollToCaret()
            End Sub))
    End Sub

    Private Sub SolutionBuilderForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Set current solution build index to -1
        chklistSolutions.Tag = New SolutionCheckListData() With {
            .CurrentSolutionBuildingIndex = -1
        }
    End Sub

    Private Sub SetControlsEnabledStatus(enabled As Boolean)
        BeginInvoke(New MethodInvoker(
            Sub()
                btnAddSolution.Enabled = enabled
                btnBuildSolutions.Enabled = enabled
                chklistSolutions.Enabled = enabled
            End Sub))
    End Sub

    Private Sub chklistSolutions_ItemCheck(sender As Object, e As ItemCheckEventArgs) Handles chklistSolutions.ItemCheck
        BeginInvoke(New MethodInvoker(
            Sub()
                If chklistSolutions.CheckedItems.Count > 0 Then
                    btnBuildSolutions.Enabled = True
                Else
                    btnBuildSolutions.Enabled = False
                End If
            End Sub))

    End Sub
End Class
