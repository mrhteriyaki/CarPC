Module CANBUS


    Public SendHSCAN As Boolean = False
    Public SendLSCAN As Boolean = False

    Enum LightState
        LightsOn
        LightsOff
    End Enum
    'HVAC Variables
    Public FanSpeed As Integer = 0
    Public OutsideTemp As Double = 0
    Public AirConOn As Boolean = False
    Public HVACTemp As Double = 0
    Public HVACVENTCode As Integer = 0
    Public FanSpeedMode As String = ""
    Public FeetVents As Boolean = False
    Public FaceVents As Boolean = False
    Public WindowVents As Boolean = False
    Public ACStateString As String = "AC Status: Auto"
    'GPS Auto-close cabin
    Public BadSmellZoneString As String = ""

    'Cabin Air Close / Open
    Public CloseOpenState As Boolean = True
    Public CloseOpenCodes As String = ""


    'Lock / Unlocked
    Public LockState As Integer = -1

    'Doors
    Public DriverDoor As Boolean = False
    Public PassengerDoor As Boolean = False
    Public RearLeftDoor As Boolean = False
    Public RearRightDoor As Boolean = False
    Public RearDemister As Boolean = False

    'Interior Lights
    Public CabinLights As LightState = LightState.LightsOff

    'Indicators
    Public Indicators As String = ""

    'Headlights
    Public Headlights As LightState = LightState.LightsOff
    Public FogLights As LightState = LightState.LightsOff
    Public AutoHeadLights As LightState = LightState.LightsOff
    Public HighBeams As LightState = LightState.LightsOff

    'Car Ignition
    Public IgnitionStatus As Integer = 0



    'Engine Information
    Public EngineCoolantTemp As Integer = 60

    'Wheel Information
    Public FrontLeftWheelSpeed As Double = 0
    Public FrontRightWheelSpeed As Double = 0
    Public RearLeftWheelSpeed As Double = 0
    Public RearRightWheelSpeed As Double = 0



End Module
