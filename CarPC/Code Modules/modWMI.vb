Option Explicit On
Option Strict Off
Imports System.Management
Module modWMI
    Public Function WMI_Display_GetBrightnessPct(Optional ByVal monitorPNPdeviceName As String = "") As Double

        Dim objSwbemServices As Object
        Dim colInstances As Object
        Dim objInstance As Object
        objSwbemServices = GetObject("winmgmts:\\.\root\wmi")

        Dim retPct As Double = -1

        Dim strSSID As String
        strSSID = ""

        colInstances = objSwbemServices.ExecQuery("Select * From WmiMonitorBrightness")
        For Each objInstance In colInstances

            'MsgBox("Active:" & objInstance.Active)
            'MsgBox("CurrentBrightness:" & objInstance.CurrentBrightness)
            'MsgBox("InstanceName:" & objInstance.InstanceName)
            'MsgBox("Level:" & Join(objInstance.Level))
            'MsgBox("Levels:" & objInstance.Levels)

            If monitorPNPdeviceName = "" Then
                retPct = Val(objInstance.CurrentBrightness)
                Exit For
            End If

            If objInstance.InstanceName = monitorPNPdeviceName Then
                retPct = Val(objInstance.CurrentBrightness)
                Exit For
            End If




        Next


        Return retPct

    End Function

    Public Function WMI_Display_IsBrightnessAvailableForAllScreens() As Boolean



        Dim objSwbemServices As Object
        Dim colInstances As Object
        Dim objInstance As Object
        objSwbemServices = GetObject("winmgmts:\\.\root\wmi")

        Dim retPct As Double = -1

        Dim strSSID As String
        strSSID = ""

        colInstances = objSwbemServices.ExecQuery("Select * From WmiMonitorBrightness")

        Dim wmiScrCount As Integer = 0

        For Each objInstance In colInstances


            Try
                retPct = Val(objInstance.CurrentBrightness)
                wmiScrCount = wmiScrCount + 1

            Catch

            End Try

        Next


        Return (wmiScrCount = Screen.AllScreens.Length)

    End Function

    Public Function WMI_Display_SetBrightnessPct(ByVal targetBrightness As Double) As Boolean


        'define scope (namespace)
        Dim wmiScope As New System.Management.ManagementScope("root\WMI")

        'define query
        Dim wmiQuery As New System.Management.SelectQuery("WmiMonitorBrightnessMethods")

        'output current brightness
        Dim wmiSearcher As New System.Management.ManagementObjectSearcher(wmiScope, wmiQuery)

        Dim wmiCollection As System.Management.ManagementObjectCollection = wmiSearcher.[Get]()

        Dim retBool As Boolean = False

        Dim tempByte As Byte = CByte(targetBrightness)


        ' Try
        ' wmiObject.InvokeMethod("WmiRevertToPolicyBrightness")
        ' Catch ex As Exception
        '
        '        End Try

        Try
            For Each wmiObject As System.Management.ManagementObject In wmiCollection

                wmiObject.InvokeMethod("WmiSetBrightness", New [Object]() {UInt32.MaxValue, tempByte})
                'note the reversed order - won't work otherwise!
                'only work on the first object

                retBool = True
                'Exit For
            Next

        Catch

        End Try


        wmiSearcher.Dispose()
        wmiCollection.Dispose()


        Return retBool

    End Function

End Module
