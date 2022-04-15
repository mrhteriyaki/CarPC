Public Class WebPortalPrompt

    Private Sub btnSoundCloud_Click(sender As Object, e As EventArgs) Handles btnSoundCloud.Click
        WebsiteShow = Websites.SoundCloud
        CarPCfrm.LoadWebPanel()
        Me.Close()
    End Sub

    Private Sub btnSpotify_Click(sender As Object, e As EventArgs) Handles btnSpotify.Click
        WebsiteShow = Websites.Spotify
        CarPCfrm.LoadWebPanel()
        Me.Close()
    End Sub

    Private Sub btnYoutube_Click(sender As Object, e As EventArgs) Handles btnYoutube.Click
        WebsiteShow = Websites.Youtube
        CarPCfrm.LoadWebPanel()
        Me.Close()
    End Sub

    Private Sub btnFacebook_Click(sender As Object, e As EventArgs) Handles btnFacebook.Click
        WebsiteShow = Websites.Facebook
        CarPCfrm.LoadWebPanel()
        Me.Close()
    End Sub


    Private Sub WebPortalPrompt_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Location = New Point(164, 628)
    End Sub
End Class