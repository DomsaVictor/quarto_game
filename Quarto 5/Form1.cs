using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quarto_5
{
    public partial class Form1 : Form
    {
        public bool turn = false;  // true = P1    false = P2
        public int turn1 = 0;
        public char dleimiter = '_';
        public String[] BA1, BA2, BA3, BA4,
                 BB1, BB2, BB3, BB4,
                 BC1, BC2, BC3, BC4,
                BD1, BD2, BD3, BD4;
        bool won = false;
        private void btnReset_Click(object sender, EventArgs e)
        {
            reset();
        }

        string a = "___";
        public Form1()
        {
            InitializeComponent();
            label1.Text = "1";
            BA1 = a.Split('_');
            BA2 = a.Split('_');
            BA3 = a.Split('_');
            BA4 = a.Split('_');

            BB1 = a.Split('_');
            BB2 = a.Split('_');
            BB3 = a.Split('_');
            BB4 = a.Split('_');

            BC1 = a.Split('_');
            BC2 = a.Split('_');
            BC3 = a.Split('_');
            BC4 = a.Split('_');

            BD1 = a.Split('_');
            BD2 = a.Split('_');
            BD3 = a.Split('_');
            BD4 = a.Split('_');

            B1.Tag = "2_2_2_1";
            B2.Tag = "2_2_2_2";
            B3.Tag = "1_2_2_2";
            B4.Tag = "1_1_2_2";
            B5.Tag = "2_1_1_1";
            B6.Tag = "2_1_2_1";
            B7.Tag = "2_1_1_2";
            B8.Tag = "2_2_1_1";
            B9.Tag = "1_2_1_2";
            B10.Tag = "1_1_1_2";
            B11.Tag = "1_1_2_1";
            B12.Tag = "2_2_1_2";
            B13.Tag = "2_1_2_2";
            B14.Tag = "1_1_1_1";
            B15.Tag = "1_2_2_1";
            B16.Tag = "1_2_1_1";
            Random R = new Random();

            B1.BackgroundImage =Image.FromFile(@"D:\Quarto 5\Quarto 5\Resources\2221.gif");
            B2.BackgroundImage = Image.FromFile(@"D:\Quarto 5\Quarto 5\Resources\2222.gif");
            B3.BackgroundImage = Image.FromFile(@"D:\Quarto 5\Quarto 5\Resources\1222.gif");
            B4.BackgroundImage = Image.FromFile(@"D:\Quarto 5\Quarto 5\Resources\1122.gif");
            B5.BackgroundImage = Image.FromFile(@"D:\Quarto 5\Quarto 5\Resources\2111.gif");
            B6.BackgroundImage = Image.FromFile(@"D:\Quarto 5\Quarto 5\Resources\2121.gif");
            B7.BackgroundImage = Image.FromFile(@"D:\Quarto 5\Quarto 5\Resources\2112.gif");
            B8.BackgroundImage = Image.FromFile(@"D:\Quarto 5\Quarto 5\Resources\2211.gif");
            B9.BackgroundImage = Image.FromFile(@"D:\Quarto 5\Quarto 5\Resources\1212.gif");
            B10.BackgroundImage = Image.FromFile(@"D:\Quarto 5\Quarto 5\Resources\1112.gif");
            B11.BackgroundImage = Image.FromFile(@"D:\Quarto 5\Quarto 5\Resources\1121.gif");
            B12.BackgroundImage = Image.FromFile(@"D:\Quarto 5\Quarto 5\Resources\2212.gif");
            B13.BackgroundImage = Image.FromFile(@"D:\Quarto 5\Quarto 5\Resources\2122.gif");
            B14.BackgroundImage = Image.FromFile(@"D:\Quarto 5\Quarto 5\Resources\1111.gif");
            B15.BackgroundImage = Image.FromFile(@"D:\Quarto 5\Quarto 5\Resources\1221.gif");
            B16.BackgroundImage = Image.FromFile(@"D:\Quarto 5\Quarto 5\Resources\1211.gif");
        }

        private void choose_button(object sender, EventArgs e)
        {
            if (btnChoose.BackgroundImage == btnBase.BackgroundImage)
            {
                Button b = (Button)sender;
                btnChoose.BackgroundImage = b.BackgroundImage;
                btnChoose.Tag = b.Tag;
                b.Enabled = false;
                //b.Text = "";

                turn = !turn;
                btnChoose.Tag = b.Tag;
                b.BackgroundImage = btnBase.BackgroundImage;
            }
            if (turn == true)
                label1.Text = "1";
            else label1.Text = "2";

            
        }

        private void chosen_button(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.BackgroundImage ==btnBase.BackgroundImage  && btnChoose.BackgroundImage!= btnBase.BackgroundImage)
            {
                b.BackgroundImage = btnChoose.BackgroundImage;
                b.Tag= btnChoose.Tag;
                btnChoose.Tag = "";
                btnChoose.BackgroundImage = btnBase.BackgroundImage;             
                if (b.Name == "A11") BA1 = b.Tag.ToString().Split('_');
                 else if(b.Name == "A12") BA2 = b.Tag.ToString().Split('_');
                 else if(b.Name == "A13") BA3 = b.Tag.ToString().Split('_');
                 else if(b.Name == "A14") BA4 = b.Tag.ToString().Split('_');
                 else if(b.Name == "A21") BB1 = b.Tag.ToString().Split('_');
                 else if(b.Name == "A22") BB2 = b.Tag.ToString().Split('_');
                 else if(b.Name == "A23") BB3 = b.Tag.ToString().Split('_');
                 else if(b.Name == "A24") BB4 = b.Tag.ToString().Split('_');
                 else if(b.Name == "A31") BC1 = b.Tag.ToString().Split('_');
                 else if(b.Name == "A32") BC2 = b.Tag.ToString().Split('_');
                 else if(b.Name == "A33") BC3 = b.Tag.ToString().Split('_');
                 else if(b.Name == "A34") BC4 = b.Tag.ToString().Split('_');
                 else if(b.Name == "A41") BD1 = b.Tag.ToString().Split('_');
                 else if(b.Name == "A42") BD2 = b.Tag.ToString().Split('_');
                 else if(b.Name == "A43") BD3 = b.Tag.ToString().Split('_');
                 else if(b.Name == "A44") BD4 = b.Tag.ToString().Split('_');

            }
            check_win();
        }
        private void check_win()
        {
            if(won==false)
                foreach (Button b in panel1.Controls)
                {
                        if (BA1[0]!="" && BA1[0] == BA2[0] && BA2[0] == BA3[0] && BA3[0] == BA4[0]) { MessageBox.Show("Player " + label1.Text + " wins"); end_game();break; }
                        else if (BA1[1] != "" && BA1[1] == BA2[1] && BA2[1] == BA3[1] && BA3[1] == BA4[1]) { MessageBox.Show("Player " + label1.Text + " wins"); end_game();break; }
                        else if (BA1[2] != "" && BA1[2] == BA2[2] && BA2[2] == BA3[2] && BA3[2] == BA4[2]) { MessageBox.Show("Player " + label1.Text + " wins"); end_game(); break; }
                        else if (BA1[3] != "" && BA1[3] == BA2[3] && BA2[3] == BA3[3] && BA3[3] == BA4[3]) { MessageBox.Show("Player " + label1.Text + " wins"); end_game(); break; }

                        else if (BB1[0] != "" && BB1[0] == BB2[0] && BB2[0] == BB3[0] && BB3[0] == BB4[0]) { MessageBox.Show("Player " + label1.Text + " wins"); end_game(); break; }
                        else if (BB1[1] != "" && BB1[1] == BB2[1] && BB2[1] == BB3[1] && BB3[1] == BB4[1]) { MessageBox.Show("Player " + label1.Text + " wins"); end_game(); break; }
                        else if (BB1[2] != "" && BB1[2] == BB2[2] && BB2[2] == BB3[2] && BB3[2] == BB4[2]) { MessageBox.Show("Player " + label1.Text + " wins"); end_game(); break; }
                        else if (BB1[3] != "" && BB1[3] == BB2[3] && BB2[3] == BB3[3] && BB3[3] == BB4[3]) { MessageBox.Show("Player " + label1.Text + " wins"); end_game(); break; }

                        else if (BC1[0] != "" && BC1[0] == BC2[0] && BC2[0] == BC3[0] && BC3[0] == BC4[0]) { MessageBox.Show("Player " + label1.Text + " wins"); end_game(); break; }
                        else if (BC1[1] != "" && BC1[1] == BC2[1] && BC2[1] == BC3[1] && BC3[1] == BC4[1]) { MessageBox.Show("Player " + label1.Text + " wins"); end_game(); break; }
                        else if (BC1[2] != "" && BC1[2] == BC2[2] && BC2[2] == BC3[2] && BC3[2] == BC4[2]) { MessageBox.Show("Player " + label1.Text + " wins"); end_game(); break; }
                        else if (BC1[3] != "" && BC1[3] == BC2[3] && BC2[3] == BC3[3] && BC3[3] == BC4[3]) { MessageBox.Show("Player " + label1.Text + " wins"); end_game(); break; }

                        else if (BD1[0] != "" && BD1[0] == BD2[0] && BD2[0] == BD3[0] && BD3[0] == BD4[0]) { MessageBox.Show("Player " + label1.Text + " wins"); end_game(); break; }
                        else if (BD1[1] != "" && BD1[1] == BD2[1] && BD2[1] == BD3[1] && BD3[1] == BD4[1]) { MessageBox.Show("Player " + label1.Text + " wins"); end_game(); break; }
                        else if (BD1[2] != "" && BD1[2] == BD2[2] && BD2[2] == BD3[2] && BD3[2] == BD4[2]) { MessageBox.Show("Player " + label1.Text + " wins"); end_game(); break; }
                        else if (BD1[3] != "" && BD1[3] == BD2[3] && BD2[3] == BD3[3] && BD3[3] == BD4[3]) { MessageBox.Show("Player " + label1.Text + " wins"); end_game(); break; }


                        if (BA1[0] != "" && BA1[0] == BB1[0] && BB1[0] == BC1[0] && BC1[0] == BD1[0]) { MessageBox.Show("Player " + label1.Text + " wins"); end_game(); break; }
                        else if (BA1[1] != "" && BA1[1] == BB1[1] && BB1[1] == BC1[1] && BC1[1] == BD1[1]) { MessageBox.Show("Player " + label1.Text + " wins"); end_game(); break; }
                        else if (BA1[2] != "" && BA1[2] == BB1[2] && BB1[2] == BC1[2] && BC1[2] == BD1[2]) { MessageBox.Show("Player " + label1.Text + " wins"); end_game(); break; }
                        else if (BA1[3] != "" && BA1[3] == BB1[3] && BB1[3] == BC1[3] && BC1[3] == BD1[3]) { MessageBox.Show("Player " + label1.Text + " wins"); end_game(); break; }

                        else if (BB2[0] != "" && BA2[0] == BB2[0] && BB2[0] == BC2[0] && BC2[0] == BD2[0]) { MessageBox.Show("Player " + label1.Text + " wins"); end_game(); break; }
                        else if (BB2[1] != "" && BA2[1] == BB2[1] && BB2[1] == BC2[1] && BC2[1] == BD2[1]) { MessageBox.Show("Player " + label1.Text + " wins"); end_game(); break; }
                        else if (BB2[2] != "" && BA2[2] == BB2[2] && BB2[2] == BC2[2] && BC2[2] == BD2[2]) { MessageBox.Show("Player " + label1.Text + " wins"); end_game(); break; }
                        else if (BB2[3] != "" && BA2[3] == BB2[3] && BB2[3] == BC2[3] && BC2[3] == BD2[3]) { MessageBox.Show("Player " + label1.Text + " wins"); end_game(); break; }

                        else if (BC3[0] != "" && BA3[0] == BC3[0] && BB3[0] == BC3[0] && BD3[0] == BC3[0]) { MessageBox.Show("Player " + label1.Text + " wins"); end_game(); break; }
                        else if (BC3[1] != "" && BA3[1] == BC3[1] && BB3[1] == BC3[1] && BD3[1] == BC3[1]) { MessageBox.Show("Player " + label1.Text + " wins"); end_game(); break; }
                        else if (BC3[2] != "" && BA3[2] == BC3[2] && BB3[2] == BC3[2] && BD3[2] == BC3[2]) { MessageBox.Show("Player " + label1.Text + " wins"); end_game(); break; }
                        else if (BC3[3] != "" && BA3[3] == BC3[3] && BB3[3] == BC3[3] && BD3[3] == BC3[3]) { MessageBox.Show("Player " + label1.Text + " wins"); end_game(); break; }

                        else if (BB4[0] != "" && BA4[0] == BB4[0] && BB4[0] == BC4[0] && BC4[0] == BD4[0]) { MessageBox.Show("Player " + label1.Text + " wins"); end_game(); break; }
                        else if (BB4[1] != "" && BA4[1] == BB4[1] && BB4[1] == BC4[1] && BC4[1] == BD4[1]) { MessageBox.Show("Player " + label1.Text + " wins"); end_game(); break; }
                        else if (BB4[2] != "" && BA4[2] == BB4[2] && BB4[2] == BC4[2] && BC4[2] == BD4[2]) { MessageBox.Show("Player " + label1.Text + " wins"); end_game(); break; }
                        else if (BB4[3] != "" && BA4[3] == BB4[3] && BB4[3] == BC4[3] && BC4[3] == BD4[3]) { MessageBox.Show("Player " + label1.Text + " wins"); end_game(); break; }


                        if (BA1[0] != "" && BA1[0] == BB2[0] && BB2[0] == BC3[0] && BC3[0] == BD4[0]) { MessageBox.Show("Player " + label1.Text + " wins"); end_game(); break; }
                        else if (BA1[1] != "" && BA1[1] == BB2[1] && BB2[1] == BC3[1] && BC3[1] == BD4[1]) { MessageBox.Show("Player " + label1.Text + " wins"); end_game(); break; }
                        else if (BA1[2] != "" && BA1[2] == BB2[2] && BB2[2] == BC3[2] && BC3[2] == BD4[2]) { MessageBox.Show("Player " + label1.Text + " wins"); end_game(); break; }
                        else if (BA1[3] != "" && BA1[3] == BB2[3] && BB2[3] == BC3[3] && BC3[3] == BD4[3]) { MessageBox.Show("Player " + label1.Text + " wins"); end_game(); break; }


                        if (BA4[0] != "" && BA4[0] == BB3[0] && BB3[0] == BC2[0] && BC2[0] == BD1[0]) { MessageBox.Show("Player " + label1.Text + " wins"); end_game(); break; }
                        else if (BA4[1] != "" && BA4[1] == BB3[1] && BB3[1] == BC2[1] && BC2[1] == BD1[1]) { MessageBox.Show("Player " + label1.Text + " wins"); end_game(); break; }
                        else if (BA4[2] != "" && BA4[2] == BB3[2] && BB3[2] == BC2[2] && BC2[2] == BD1[2]) { MessageBox.Show("Player " + label1.Text + " wins"); end_game(); break; }
                        else if (BA4[3] != "" && BA4[3] == BB3[3] && BB3[3] == BC2[3] && BC2[3] == BD1[3]) { MessageBox.Show("Player " + label1.Text + " wins"); end_game(); break; }

                }

        }
        public void end_game()
        {
            won = true;
            foreach (Button b in this.Controls.OfType<Button>())
            {
                b.Enabled = false;
            }
            btnReset.Enabled = true;
            turn = false;
        }
        public void reset()
        {
            btnChoose.Enabled = true;

            B1.BackgroundImage = Image.FromFile(@"D:\Quarto 5\Quarto 5\Resources\2221.gif");
            B2.BackgroundImage = Image.FromFile(@"D:\Quarto 5\Quarto 5\Resources\2222.gif");
            B3.BackgroundImage = Image.FromFile(@"D:\Quarto 5\Quarto 5\Resources\1222.gif");
            B4.BackgroundImage = Image.FromFile(@"D:\Quarto 5\Quarto 5\Resources\1122.gif");
            B5.BackgroundImage = Image.FromFile(@"D:\Quarto 5\Quarto 5\Resources\2111.gif");
            B6.BackgroundImage = Image.FromFile(@"D:\Quarto 5\Quarto 5\Resources\2121.gif");
            B7.BackgroundImage = Image.FromFile(@"D:\Quarto 5\Quarto 5\Resources\2112.gif");
            B8.BackgroundImage = Image.FromFile(@"D:\Quarto 5\Quarto 5\Resources\2211.gif");
            B9.BackgroundImage = Image.FromFile(@"D:\Quarto 5\Quarto 5\Resources\1212.gif");
            B10.BackgroundImage = Image.FromFile(@"D:\Quarto 5\Quarto 5\Resources\1112.gif");
            B11.BackgroundImage = Image.FromFile(@"D:\Quarto 5\Quarto 5\Resources\1121.gif");
            B12.BackgroundImage = Image.FromFile(@"D:\Quarto 5\Quarto 5\Resources\2212.gif");
            B13.BackgroundImage = Image.FromFile(@"D:\Quarto 5\Quarto 5\Resources\2122.gif");
            B14.BackgroundImage = Image.FromFile(@"D:\Quarto 5\Quarto 5\Resources\1111.gif");
            B15.BackgroundImage = Image.FromFile(@"D:\Quarto 5\Quarto 5\Resources\1221.gif");
            B16.BackgroundImage = Image.FromFile(@"D:\Quarto 5\Quarto 5\Resources\1211.gif");

            BA1 = a.Split('_');
            BA2 = a.Split('_');
            BA3 = a.Split('_');
            BA4 = a.Split('_');

            BB1 = a.Split('_');
            BB2 = a.Split('_');
            BB3 = a.Split('_');
            BB4 = a.Split('_');

            BC1 = a.Split('_');
            BC2 = a.Split('_');
            BC3 = a.Split('_');
            BC4 = a.Split('_');

            BD1 = a.Split('_');
            BD2 = a.Split('_');
            BD3 = a.Split('_');
            BD4 = a.Split('_');

            foreach (Button b in this.Controls.OfType<Button>())
            {
                if (b.Name.ToString()[0] == 'B') b.Enabled = true;

            }
            foreach (Button b in panel1.Controls)
            {
                b.Enabled = true;
                b.BackgroundImage = btnBase.BackgroundImage;
            }
            btnChoose.BackgroundImage = btnBase.BackgroundImage;
            btnChoose.Tag = "";
            turn = false;
            label1.Text = "1";
        }

    }
}
