namespace SoundScape;

public partial class Form1 : Form
{
    public Form1()
    {
        // Testing query controller
        QueryController queryController = new QueryController();
        queryController.ListSongsByArtist();

        InitializeComponent();

    }
}
