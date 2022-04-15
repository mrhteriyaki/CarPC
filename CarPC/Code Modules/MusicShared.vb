Module MusicShared
    Public Artist As String = ""
    Public Album As String = ""
    Public Title As String = ""

    Public MusicArr(0) As String
    Public MusicCount As Integer = -1

    Public MusicRandom As Boolean = False
    Public RandomHistory(0) As String
    Public RandomHistoryCount As Integer = -1

    Public VideoMode As Boolean = False

    Public NoPicture As Boolean = False

    Public MediaFileTypes() As String = {"mp4", "mp3", "flac", "wma", "mkv", "m4a", "wmv", "mpeg", "wav", "flv", "xm", "mod", "it"}
    Public VideoFileTypes() As String = {"mp4", "mkv", "wmv", "mpeg", "flv"}


    Public SoundCloudLoaded As Boolean = False
    Public SpotifyLoaded As Boolean = False
    Public YoutubeLoaded As Boolean = False
    Public FacebookLoaded As Boolean = False

    Function getFileName(ByVal FileName As String)
        Dim Index As Integer = FileName.LastIndexOf("\")
        Return FileName.Substring(Index + 1)
    End Function


End Module
