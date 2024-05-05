class Tests {
    public static bool TestSongController()
    {
        SongController songController = new();
        // Test all methods for songController:
        
       
    }

    public static bool TestAlbumController()
    {
        AlbumController albumController = new();

        // Test all methods for albumController
       

    }

    public static bool TestUserController()
    {
        UserController userController = new();

        // Test all methods for userController
        userController.CreateNewUser("joey", "1234");
        userController.GetUser("joey");
        userController.DeleteUser("joey");
    }

    public static bool TestPlaylistController()
    {
        PlaylistController playlistController = new();

    }
}
    
    