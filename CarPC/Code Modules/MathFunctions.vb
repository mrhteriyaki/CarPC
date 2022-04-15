Module MathFunctions

    Function RangeCheck(ByVal value1 As Double, ByVal value2 As Double, ByVal range As Double) As Boolean
        'Range must be positive.

        'Checks if value 1 and value 2 are seperated by range value (return false) or within the value of range (true).

        'Value 1 = 1.5
        'Value 2 = 1.7
        'Range = 0.5
        'Expected return = True

        'Value 1 = 1.0
        'Value 2 = 2.0
        'Range Value 0.9
        'Expected Return = False

        'Value 1 = 1.0
        'Value 2 = - 1.0
        'Range = 0.5
        'Expected return false.

        'Value 1 = 0.5
        'Value 2= -2.0
        'Range = 3
        'Expected result true

        'Value 1 = -2.0
        'Value 2 = -3.5
        'Range = 2
        'Expected result true.

        'Calculate the lower value.
        Dim Lowest_Val As Double
        Dim Highest_Val As Double
        If value1 < value2 Then
            Lowest_Val = value1
            Highest_Val = value2
        Else
            Lowest_Val = value2
            Highest_Val = value1
        End If

        Dim Difference As Double = Highest_Val - Lowest_Val
        If Difference < 0 Then
            Difference = Difference * -1
        End If

        If Difference <= range Then
            Return True
        End If
        Return False


    End Function


End Module
