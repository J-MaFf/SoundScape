namespace SoundScape;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        searchBar = new TextBox();
        searchItem = new ComboBox();
        sortBy = new ComboBox();
        filterBy = new ComboBox();
        label1 = new Label();
        label2 = new Label();
        label3 = new Label();
        label4 = new Label();
        dataGridView1 = new DataGridView();
        button1 = new Button();
        label5 = new Label();
        progressBar1 = new ProgressBar();
        button2 = new Button();
        label6 = new Label();
        panel1 = new Panel();
        button8 = new Button();
        button7 = new Button();
        button6 = new Button();
        label10 = new Label();
        button5 = new Button();
        button4 = new Button();
        button3 = new Button();
        textBox2 = new TextBox();
        textBox1 = new TextBox();
        label9 = new Label();
        label8 = new Label();
        label7 = new Label();
        textBox3 = new TextBox();
        ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
        panel1.SuspendLayout();
        SuspendLayout();
        // 
        // searchBar
        // 
        searchBar.AcceptsTab = true;
        searchBar.ForeColor = SystemColors.WindowText;
        searchBar.Location = new Point(12, 63);
        searchBar.Name = "searchBar";
        searchBar.Size = new Size(756, 23);
        searchBar.TabIndex = 0;
        searchBar.Text = "Search";
        searchBar.Enter += searchBar_Enter;
        searchBar.KeyUp += searchBar_KeyUp;
        searchBar.Leave += searchBar_Leave;
        // 
        // searchItem
        // 
        searchItem.DropDownStyle = ComboBoxStyle.DropDownList;
        searchItem.FormattingEnabled = true;
        searchItem.Items.AddRange(new object[] { "Song", "Album", "Playlist", "User" });
        searchItem.Location = new Point(806, 62);
        searchItem.Name = "searchItem";
        searchItem.Size = new Size(85, 23);
        searchItem.TabIndex = 2;
        searchItem.SelectedIndexChanged += searchItem_SelectedIndexChanged;
        // 
        // sortBy
        // 
        sortBy.DropDownStyle = ComboBoxStyle.DropDownList;
        sortBy.FormattingEnabled = true;
        sortBy.Items.AddRange(new object[] { "None" });
        sortBy.Location = new Point(895, 62);
        sortBy.Name = "sortBy";
        sortBy.Size = new Size(85, 23);
        sortBy.TabIndex = 3;
        sortBy.Enter += sortBy_Enter;
        // 
        // filterBy
        // 
        filterBy.DropDownStyle = ComboBoxStyle.DropDownList;
        filterBy.FormattingEnabled = true;
        filterBy.Items.AddRange(new object[] { "None", "Profanity" });
        filterBy.Location = new Point(983, 62);
        filterBy.Name = "filterBy";
        filterBy.Size = new Size(85, 23);
        filterBy.TabIndex = 4;
        filterBy.Visible = false;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(806, 44);
        label1.Name = "label1";
        label1.Size = new Size(69, 15);
        label1.TabIndex = 5;
        label1.Text = "Search Item";
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(895, 44);
        label2.Name = "label2";
        label2.Size = new Size(44, 15);
        label2.TabIndex = 6;
        label2.Text = "Sort By";
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Location = new Point(983, 44);
        label3.Name = "label3";
        label3.Size = new Size(49, 15);
        label3.TabIndex = 7;
        label3.Text = "Filter By";
        // 
        // label4
        // 
        label4.AutoSize = true;
        label4.Location = new Point(12, 44);
        label4.Name = "label4";
        label4.Size = new Size(71, 15);
        label4.TabIndex = 8;
        label4.Text = "Search Term";
        // 
        // dataGridView1
        // 
        dataGridView1.AllowUserToAddRows = false;
        dataGridView1.AllowUserToDeleteRows = false;
        dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridView1.Location = new Point(12, 113);
        dataGridView1.Name = "dataGridView1";
        dataGridView1.ReadOnly = true;
        dataGridView1.Size = new Size(1056, 595);
        dataGridView1.TabIndex = 9;
        dataGridView1.CellClick += dataGridView1_CellClick;
        // 
        // button1
        // 
        button1.Location = new Point(774, 62);
        button1.Name = "button1";
        button1.Size = new Size(26, 23);
        button1.TabIndex = 10;
        button1.Text = "🔍";
        button1.UseVisualStyleBackColor = true;
        button1.MouseClick += button1_MouseClick;
        // 
        // label5
        // 
        label5.AutoSize = true;
        label5.Location = new Point(12, 92);
        label5.Name = "label5";
        label5.Size = new Size(88, 15);
        label5.TabIndex = 11;
        label5.Text = "No results yet...";
        // 
        // progressBar1
        // 
        progressBar1.Location = new Point(143, 92);
        progressBar1.MarqueeAnimationSpeed = 50;
        progressBar1.Name = "progressBar1";
        progressBar1.Size = new Size(925, 15);
        progressBar1.TabIndex = 12;
        // 
        // button2
        // 
        button2.Location = new Point(12, 5);
        button2.Name = "button2";
        button2.Size = new Size(75, 23);
        button2.TabIndex = 13;
        button2.Text = "Login";
        button2.UseVisualStyleBackColor = true;
        button2.Click += button2_Click;
        // 
        // label6
        // 
        label6.AutoSize = true;
        label6.Font = new Font("Cascadia Code", 32F, FontStyle.Bold);
        label6.Location = new Point(355, 2);
        label6.Name = "label6";
        label6.Size = new Size(360, 57);
        label6.TabIndex = 14;
        label6.Text = "SoundScape 🎶";
        // 
        // panel1
        // 
        panel1.Controls.Add(button8);
        panel1.Controls.Add(button7);
        panel1.Controls.Add(button6);
        panel1.Controls.Add(label10);
        panel1.Controls.Add(button5);
        panel1.Controls.Add(button4);
        panel1.Controls.Add(button3);
        panel1.Controls.Add(textBox2);
        panel1.Controls.Add(textBox1);
        panel1.Controls.Add(label9);
        panel1.Controls.Add(label8);
        panel1.Controls.Add(label7);
        panel1.Location = new Point(316, 218);
        panel1.Name = "panel1";
        panel1.Size = new Size(419, 210);
        panel1.TabIndex = 15;
        // 
        // button8
        // 
        button8.ForeColor = Color.Red;
        button8.Location = new Point(394, 3);
        button8.Name = "button8";
        button8.Size = new Size(22, 23);
        button8.TabIndex = 11;
        button8.Text = "❌";
        button8.UseVisualStyleBackColor = true;
        button8.Click += button8_Click;
        // 
        // button7
        // 
        button7.ForeColor = Color.Red;
        button7.Location = new Point(219, 89);
        button7.Name = "button7";
        button7.Size = new Size(100, 23);
        button7.TabIndex = 10;
        button7.Text = "Delete";
        button7.UseVisualStyleBackColor = true;
        button7.Click += button7_Click;
        // 
        // button6
        // 
        button6.Location = new Point(109, 89);
        button6.Name = "button6";
        button6.Size = new Size(104, 23);
        button6.TabIndex = 9;
        button6.Text = "Logout";
        button6.UseVisualStyleBackColor = true;
        button6.Click += button6_Click;
        // 
        // label10
        // 
        label10.AutoSize = true;
        label10.ForeColor = Color.Red;
        label10.Location = new Point(14, 184);
        label10.Name = "label10";
        label10.Size = new Size(53, 15);
        label10.TabIndex = 8;
        label10.Text = "Message";
        // 
        // button5
        // 
        button5.BackColor = Color.Transparent;
        button5.Location = new Point(316, 106);
        button5.Name = "button5";
        button5.Size = new Size(22, 23);
        button5.TabIndex = 7;
        button5.Text = "👁️";
        button5.UseVisualStyleBackColor = false;
        button5.Click += button5_Click;
        // 
        // button4
        // 
        button4.Location = new Point(109, 146);
        button4.Name = "button4";
        button4.Size = new Size(104, 23);
        button4.TabIndex = 6;
        button4.Text = "Login";
        button4.UseVisualStyleBackColor = true;
        button4.Click += button4_Click;
        // 
        // button3
        // 
        button3.Location = new Point(215, 146);
        button3.Name = "button3";
        button3.Size = new Size(104, 23);
        button3.TabIndex = 5;
        button3.Text = "Create Account";
        button3.UseVisualStyleBackColor = true;
        button3.Click += button3_Click;
        // 
        // textBox2
        // 
        textBox2.Location = new Point(109, 106);
        textBox2.Name = "textBox2";
        textBox2.PasswordChar = '*';
        textBox2.Size = new Size(210, 23);
        textBox2.TabIndex = 4;
        // 
        // textBox1
        // 
        textBox1.Location = new Point(109, 77);
        textBox1.Name = "textBox1";
        textBox1.Size = new Size(210, 23);
        textBox1.TabIndex = 3;
        // 
        // label9
        // 
        label9.AutoSize = true;
        label9.Font = new Font("Segoe UI", 32F);
        label9.Location = new Point(145, 0);
        label9.Name = "label9";
        label9.Size = new Size(129, 59);
        label9.TabIndex = 2;
        label9.Text = "Login";
        // 
        // label8
        // 
        label8.AutoSize = true;
        label8.Location = new Point(52, 109);
        label8.Name = "label8";
        label8.Size = new Size(57, 15);
        label8.TabIndex = 1;
        label8.Text = "Password";
        // 
        // label7
        // 
        label7.AutoSize = true;
        label7.Location = new Point(49, 80);
        label7.Name = "label7";
        label7.Size = new Size(60, 15);
        label7.TabIndex = 0;
        label7.Text = "Username";
        // 
        // textBox3
        // 
        textBox3.Location = new Point(872, 123);
        textBox3.Name = "textBox3";
        textBox3.Size = new Size(185, 23);
        textBox3.TabIndex = 16;
        textBox3.Enter += textBox3_Enter;
        textBox3.KeyUp += textBox3_KeyUp;
        textBox3.Leave += textBox3_Leave;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1080, 720);
        Controls.Add(textBox3);
        Controls.Add(panel1);
        Controls.Add(label6);
        Controls.Add(button2);
        Controls.Add(progressBar1);
        Controls.Add(label5);
        Controls.Add(button1);
        Controls.Add(dataGridView1);
        Controls.Add(label4);
        Controls.Add(label3);
        Controls.Add(label2);
        Controls.Add(label1);
        Controls.Add(filterBy);
        Controls.Add(sortBy);
        Controls.Add(searchItem);
        Controls.Add(searchBar);
        Name = "Form1";
        Text = "Form1";
        Load += Form1_Load;
        ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
        panel1.ResumeLayout(false);
        panel1.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private TextBox searchBar;
    private ComboBox searchItem;
    private ComboBox sortBy;
    private ComboBox filterBy;
    private Label label1;
    private Label label2;
    private Label label3;
    private Label label4;
    private DataGridView dataGridView1;
    private Button button1;
    private Label label5;
    private ProgressBar progressBar1;
    private Button button2;
    private Label label6;
    private Panel panel1;
    private Button button4;
    private Button button3;
    private TextBox textBox2;
    private TextBox textBox1;
    private Label label9;
    private Label label8;
    private Label label7;
    private Button button5;
    private Label label10;
    private Button button7;
    private Button button6;
    private Button button8;
    private TextBox textBox3;
}
