using COMPSCI366.Models;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic.ApplicationServices;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Reflection.Metadata.Ecma335;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace SoundScape;

public partial class Form1 : Form
{
    static string? username = null;
    static string? password = null;
    bool modifyPL = false;
    int row = -1;
    string page = "";
    public Form1()
    {

        InitializeComponent();

        panel1.Visible = false;
        label7.Visible = false;
        label8.Visible = false;
        label9.Visible = false;
        textBox1.Visible = false;
        textBox2.Visible = false;
        button3.Visible = false;
        button4.Visible = false;
        button5.Visible = false;
        label10.Visible = false;
        label10.Text = "";
        button6.Visible = false;
        button7.Visible = false;
        button8.Visible = false;
        textBox3.Visible = false;

    }

    private void Form1_Load(object sender, EventArgs e)
    {
        searchBar.ForeColor = Color.Gray;
        searchItem.SelectedItem = "Song";
        sortBy.SelectedItem = "None";
        filterBy.SelectedItem = "None";
    }

    private void searchBar_KeyUp(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            Logic();
        }
    }

    private void sortBy_Enter(object sender, EventArgs e)
    {
        switch (searchItem.SelectedItem)
        {
            case "Song":
                sortBy.Items.Clear();
                sortBy.Items.AddRange(["None", "Duration", "Danceability", "Genre"]);
                break;
            case "Album":
                sortBy.Items.Clear();
                sortBy.Items.AddRange(["None", "Total Songs", "Duration"]);
                break;
            case "Playlist":
                sortBy.Items.Clear();
                sortBy.Items.AddRange(["None", "Creation Date"]);
                break;
            case "User":
                sortBy.Items.Clear();
                sortBy.Items.AddRange(["None", "Minutes Listened"]);
                break;
            default:
                sortBy.Items.Clear();
                sortBy.Items.AddRange(["None"]);
                break;
        }
        sortBy.SelectedItem = "None";
    }

    private void searchItem_SelectedIndexChanged(object sender, EventArgs e)
    {
        sortBy.SelectedItem = "None";
        filterBy.SelectedItem = "None";
        if (searchItem.SelectedItem != "Song")
        { filterBy.Visible = false; label3.Visible = false; }
        else
        { filterBy.Visible = true; label3.Visible = true; }
    }

    private void searchBar_Click(object sender, EventArgs e)
    {
        searchBar.SelectionStart = 0;
    }

    private void searchBar_Enter(object sender, EventArgs e)
    {
        if (searchBar.Text == "Search")
            searchBar.Text = "";
        searchBar.ForeColor = Color.Black;
    }

    private void searchBar_Leave(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(searchBar.Text))
        {
            searchBar.Text = "Search";
            searchBar.ForeColor = Color.Gray;
        }
    }

    private void button1_MouseClick(object sender, MouseEventArgs e)
    {
        Logic();
    }

    private void Logic()
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        progressBar1.Value = 0;

        string searchTerm = searchBar.Text.Trim();
        if (searchTerm == "Search") { searchTerm = ""; }

        if (searchItem.SelectedItem == "Song")
        {
            DataTable dt = new DataTable();
            page = "Song";
            dt.Columns.Add("Title", typeof(string));
            dt.Columns.Add("Artists", typeof(string));
            dt.Columns.Add("Album", typeof(string));
            dt.Columns.Add("Genre", typeof(string));
            dt.Columns.Add("Duration", typeof(string));
            dt.Columns.Add("Danceability", typeof(string));
            dt.Columns.Add("Profanity", typeof(bool));
            dt.Columns.Add("Track ID", typeof(string));
            dt.Columns.Add("Add", typeof(string));
            dt.Columns.Add("Remove", typeof(string));


            SongController sC = new SongController();
            var songs = sC.SearchString(searchTerm);
            progressBar1.Value += 25;

            if (sortBy.SelectedItem == "Duration")
                songs = sC.SortByDuration(songs);
            else if (sortBy.SelectedItem == "Danceability")
                songs = sC.SortByDanceability(songs);
            else if (sortBy.SelectedItem == "Genre")
                songs = sC.SortByGenre(songs);
            progressBar1.Value += 25;
            if (filterBy.SelectedItem == "Profanity")
                songs = sC.FilterByProfanity(songs);
            progressBar1.Value += 25;

            foreach (var song in songs)
            {
                dt.Rows.Add([$"{song.Trackname}", $"{song.Artists}", $"{song.Albumname}", $"{song.Genre}", $"{TimeSpan.FromMilliseconds((double)song.Duration).ToString(@"mm\:ss")}", $"{song.Danceability * 100:0.}%", $"{song.Profanity}", song.TrackId, "➕", "➖",]);
            }
            progressBar1.Value += 25;
            dataGridView1.DataSource = dt;
        }
        if (searchItem.SelectedItem == "Album")
        {
            DataTable dt = new DataTable();
            page = "Album";
            dt.Columns.Add("Title", typeof(string));
            dt.Columns.Add("Artists", typeof(string));
            dt.Columns.Add("Total Songs", typeof(int));
            dt.Columns.Add("Duration", typeof(string));

            AlbumController aC = new();
            var albums = aC.SearchString(searchTerm);
            progressBar1.Value += 33;

            if (sortBy.SelectedItem == "Duration")
                albums = aC.SortByDuration(albums);
            else if (sortBy.SelectedItem == "Total Songs")
                albums = aC.SortByTotalSongs(albums);

            progressBar1.Value += 33;

            foreach (var album in albums)
            {
                List<string> artists = [];
                foreach (var song in album.Songs)
                {
                    Console.WriteLine("song");
                    artists.Add(song.Artists);
                }
                string artistsStr = string.Join(", ", artists.Distinct().ToList());
                dt.Rows.Add([$"{album.Name}", $"{artistsStr}", $"{album.Totalsongs}", $"{TimeSpan.FromMilliseconds((double)album.Duration).ToString(@"hh\:mm\:ss")}"]);
            }
            progressBar1.Value += 34;
            dataGridView1.DataSource = dt;
        }
        if (searchItem.SelectedItem == "Playlist")
        {
            DataTable dt = new DataTable();
            page = "Playlist";
            dt.Columns.Add("Title", typeof(string));
            dt.Columns.Add("Description", typeof(string));
            dt.Columns.Add("Total Songs", typeof(int));
            dt.Columns.Add("Creation Date", typeof(DateTime));
            dt.Columns.Add("Created By", typeof(string));
            dt.Columns.Add("Playlist ID", typeof(string));
            dt.Columns.Add("Delete", typeof(string));

            PlaylistController pC = new();
            var playlists = pC.SearchString(searchTerm);
            progressBar1.Value += 33;
            if (sortBy.SelectedItem == "Creation Date")
                playlists = pC.SortByCreationDate(playlists);
            progressBar1.Value += 33;

            foreach (var playlist in playlists)
            {
                dt.Rows.Add([$"{playlist.PlaylistName}", $"{playlist.Description}", playlist.PlaylistSongs.Count, playlist.CreationDate, playlist.Username, playlist.PlaylistId, "❌"]);
            }
            progressBar1.Value += 34;
            dataGridView1.DataSource = dt;
        }

        if (searchItem.SelectedItem == "User")
        {
            DataTable dt = new DataTable();
            page = "User";
            dt.Columns.Add("Username", typeof(string));
            dt.Columns.Add("Time Listened", typeof(string));
            dt.Columns.Add("Playlists", typeof(int));

            UserController uC = new();
            var users = uC.SearchString(searchTerm);
            progressBar1.Value += 33;

            if (sortBy.SelectedItem == "Minutes Listened")
                users = uC.SortByMinutes(users);
            progressBar1.Value += 33;

            foreach (var user in users)
            {
                dt.Rows.Add([$"{user.Username}", $"{TimeSpan.FromMinutes((double)user.MinutesListened).ToString(@"hh\:mm\:ss")}", user.Playlists.Count]);
            }
            progressBar1.Value += 34;
            dataGridView1.DataSource = dt;
        }




        /////// TIMER
        stopwatch.Stop();
        TimeSpan ts = stopwatch.Elapsed;
        string elapsedTime = String.Format("{0:0}.{1:000}", ts.Seconds, ts.Milliseconds);
        label5.Text = $"{dataGridView1.Rows.Count} results in {elapsedTime}s";
    }

    // Profile
    private void button2_Click(object sender, EventArgs e)
    {
        if (button2.Text == "Login")
        {
            panel1.Visible = true;
            label7.Visible = true;
            label8.Visible = true;
            label9.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
            button5.Visible = true;
            label10.Visible = true;
            button8.Visible = true;
        }
        if (button2.Text == username)
        {
            panel1.Visible = true;
            button6.Visible = true;
            button7.Visible = true;
            label10.Visible = true;
            button8.Visible = true;
        }

    }

    // Password visibility
    private void button5_Click(object sender, EventArgs e)
    {
        if (textBox2.PasswordChar == (char)0)
            textBox2.PasswordChar = '*';
        else
            textBox2.PasswordChar = (char)0;
    }

    // Login
    private void button4_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text))
        {
            label10.Text = "Username and Password must have a value";
            label10.ForeColor = Color.Red;
            return;
        }
        UserController uC = new();
        var user = uC.GetUser(textBox1.Text);
        if (user == null)
        {
            label10.Text = "Username/Password incorrect";
            label10.ForeColor = Color.Red;
            return;
        }
        if (user.Password != textBox2.Text)
        {
            label10.Text = "Username/Password incorrect";
            label10.ForeColor = Color.Red;
            return;
        }
        label10.Text = "Login successful";
        label10.ForeColor = Color.Green;
        textBox1.Visible = false;
        textBox2.Visible = false;
        label7.Visible = false;
        label8.Visible = false;
        button4.Visible = false;
        button3.Visible = false;
        button5.Visible = false;

        username = user.Username;
        password = user.Password;
        button2.Text = username;
        button6.Visible = true;
        button7.Visible = true;
    }

    // Create account
    private void button3_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text))
        {
            label10.Text = "Username and Password must have a value";
            label10.ForeColor = Color.Red;
            return;
        }
        UserController uC = new();
        var user = uC.GetUser(textBox1.Text);
        if (user != null)
        {
            label10.Text = "User already exists";
            label10.ForeColor = Color.Red;
            return;
        }
        uC.CreateNewUser(textBox1.Text, textBox2.Text);
        label10.Text = "User created successfully";
        label10.ForeColor = Color.Green;
        username = textBox1.Text;
        password = textBox2.Text;
        button2.Text = username;
        textBox1.Visible = false;
        textBox2.Visible = false;
        label7.Visible = false;
        label8.Visible = false;
        button4.Visible = false;
        button3.Visible = false;
        button5.Visible = false;
        button6.Visible = true;
        button7.Visible = true;
    }

    // Logout
    private void button6_Click(object sender, EventArgs e)
    {
        username = password = null;
        button2.Text = "Login";
        label10.Text = "Logged out";
        label10.ForeColor = Color.Green;
        button6.Visible = false;
        button7.Visible = false;
    }

    // X button
    private void button8_Click(object sender, EventArgs e)
    {
        panel1.Visible = false;
        label7.Visible = false;
        label8.Visible = false;
        label9.Visible = false;
        textBox1.Visible = false;
        textBox2.Visible = false;
        button3.Visible = false;
        button4.Visible = false;
        button5.Visible = false;
        label10.Visible = false;
        label10.Text = "";
        button6.Visible = false;
        button7.Visible = false;
        button8.Visible = false;
    }

    private void button7_Click(object sender, EventArgs e)
    {
        UserController uC = new();
        uC.DeleteUser(username);

        username = password = null;
        button2.Text = "Login";
        label10.Text = "User deleted";
        label10.ForeColor = Color.Red;
        button6.Visible = false;
        button7.Visible = false;
    }

    // Click add/remove
    private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        textBox3.ForeColor = Color.Black;
        if (e.ColumnIndex == 8)
        {
            textBox3.Visible = true;
            textBox3.Location = new Point(1080 / 2, 720 / 2);
            textBox3.Text = "Add to playlist";
            modifyPL = true;
            row = e.RowIndex;
        }
        else if (e.ColumnIndex == 9)
        {
            Console.WriteLine("remove");
            textBox3.Text = "Remove from playlist";
            modifyPL = false;
            row = e.RowIndex;
        }
        else if (e.ColumnIndex == 6 && page == "Playlist")
        {
            PlaylistController pC = new();
            var pl = pC.GetPlaylist(username, (string)dataGridView1[0, e.RowIndex].Value);
            if (pl != null)
            {
                pC.DeletePlaylist(pl.PlaylistId);
                Logic();
            }
        }

    }

    private void textBox3_Enter(object sender, EventArgs e)
    {
        textBox3.Text = "";
    }

    private void textBox3_KeyUp(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            PlaylistController pC = new();
            SongController sC = new();
            if (username == null)
            {
                textBox3.Text = $"Must be signed in";
                textBox3.ForeColor = Color.Red;
                return;
            }
            if (modifyPL)
            {
                string playlist = textBox3.Text;
                var pl = pC.GetPlaylist(username, playlist);
                if (pl == null)
                {
                    pC.CreatePlaylist(username, playlist, "This is my new playlist!");
                }
                pl = pC.GetPlaylist(username, playlist);
                string trackID = (string)dataGridView1[7, row].Value;

                pC.AddSongToPlaylist(pl.PlaylistId, trackID);
                textBox3.Text = $"Song added to {playlist}";
                textBox3.ForeColor = Color.Green;
            }
            else
            {
                string playlist = textBox3.Text;
                var pl = pC.GetPlaylist(username, playlist);
                string trackID = (string)dataGridView1[7, row].Value;

                pC.RemoveSongFromPlaylist(pl.PlaylistId, trackID);
                textBox3.Text = $"Song removed from {playlist}";
                textBox3.ForeColor = Color.Red;
            }
        }
    }

    private void textBox3_Leave(object sender, EventArgs e)
    {
        textBox3.Visible = false;
    }
}
