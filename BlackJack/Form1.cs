using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

namespace BlackJack
{
    public partial class MainWindow : Form
    {
        private List<PictureBox> croupier_boxes = new List<PictureBox>(6);
        private List<PictureBox> player_boxes = new List<PictureBox>(6);
        private Game game = Game.Instance;
        
        public MainWindow()
        {
            InitializeComponent();
            game.Parent = this;
            game.start();
            visualizeStartCards();
            if (game.getPoints(Game.Person.Player) == 21) stand_btn_Click(stand_btn, new EventArgs());
        }

        private void visualizeStartCards()
        {
            /*for (int i=0; i<Controls.Count; i++)
            {
                if (Controls[i] is PictureBox)
                {
                    Controls[i].Hide();
                    Controls[i].Dispose();
                    //Controls.RemoveAt(i);
                }
            }*/

            RemoveControls(this, typeof(PictureBox));

            //int a = 0;

            foreach(Card card in game.PlayerCards)
            {
                PictureBox pbox = new PictureBox();
                pbox.Image = card.Image;
                pbox.SizeMode = PictureBoxSizeMode.StretchImage;
                pbox.Location = new Point((player_boxes.Count() * 125), 206);
                pbox.Size = new Size(125, 181);
                pbox.Visible = true;
                //pbox.Show();
                if (!player_boxes.Contains(pbox)) player_boxes.Add(pbox);
                if (!Controls.Contains(pbox)) Controls.Add(pbox);
            }

            foreach(Card card in game.CroupierCards)
            {
                PictureBox pbox = new PictureBox();
                pbox.Image = card.Image; // Image.Location
                pbox.SizeMode = PictureBoxSizeMode.StretchImage;
                pbox.Location = new Point((croupier_boxes.Count() * 125), 0);
                pbox.Size = new Size(125, 181);
                pbox.Visible = true;
                //pbox.Show();
                if (!croupier_boxes.Contains(pbox)) croupier_boxes.Add(pbox);
                if (!Controls.Contains(pbox)) Controls.Add(pbox);
            }

            this.player_score.Text = game.getPoints(Game.Person.Player).ToString();
            this.croupier_score.Text = game.getPoints(Game.Person.Croupier).ToString();
        }

        private void RemoveControls(Control control, Type type)
        {
            List<Control> controls = new List<Control>();
            Stack<Control> stack = new Stack<Control>();
            stack.Push(control);
            while (stack.Count > 0)
            {
                Control ctrl = stack.Pop();
                foreach (Control child in ctrl.Controls)
                {
                    if (child.GetType() == type)
                    {
                        controls.Add(child);
                    }
                    else if (true == child.HasChildren)
                    {
                        stack.Push(child);
                    }
                }
            }
            foreach (Control ctrl in controls)
            {
                control.Controls.Remove(ctrl);
                ctrl.Dispose();
            }
        }

        public void clearControls()
        {
            if (this.player_boxes.Count() == 0 || this.croupier_boxes.Count() == 0) return;
            foreach (PictureBox pbox in this.player_boxes)
            {
                pbox.Visible = false;
                pbox.Image.Dispose();
                pbox.Image = null;
                pbox.Hide();
                pbox.Dispose();
                this.Controls.Remove(pbox);
            }
            foreach (PictureBox pbox in this.croupier_boxes)
            {
                pbox.Visible = false;
                pbox.Image.Dispose();
                pbox.Image = null;
                pbox.Hide();
                pbox.Dispose();
                this.Controls.Remove(pbox);
            }
            croupier_boxes.Clear();
            player_boxes.Clear();
        }

        private void hit_btn_Click(object sender, EventArgs e)
        {
            if (game.isBlackJack(Game.Person.Player))
            {
                stand_btn_Click(stand_btn, new EventArgs());
                return;
            }
            game.hit();
            PictureBox pbox = new PictureBox();
            pbox.Image = game.PlayerCards.Last().Image;
            pbox.Location = new Point((player_boxes.Count() * 125), 206);
            pbox.SizeMode = PictureBoxSizeMode.StretchImage;
            pbox.Visible = true;
            pbox.Size = new Size(125, 181);

            int i_score = game.getPoints(Game.Person.Player);
            this.player_score.Text = i_score.ToString();
            pbox.Show();
            player_boxes.Add(pbox);
            this.Controls.Add(pbox);

            if (game.isCroupierWin())
            {
                MessageBox.Show("Krupier wygrywa !", "Przegrana!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                game.start();
                player_boxes.Clear();
                croupier_boxes.Clear();
                visualizeStartCards();
            }

            if (i_score == 21) stand_btn_Click(stand_btn, new EventArgs());
        }

        private void stand_btn_Click(object sender, EventArgs e)
        {
            int result = game.stand();
            this.hit_btn.Enabled = false;
            this.stand_btn.Enabled = false;
            
            foreach(Card card in game.CroupierCards) // wizualizacja
            {
                if (card == game.CroupierCards.First()) continue;
                PictureBox pbox = new PictureBox();
                pbox.Image = card.Image;
                pbox.SizeMode = PictureBoxSizeMode.StretchImage;
                pbox.Location = new Point((croupier_boxes.Count() * 125), 0);
                pbox.Visible = true;
                pbox.Size = new Size(125, 181);
                pbox.Show();

                if (!croupier_boxes.Contains(pbox)) croupier_boxes.Add(pbox);
                croupier_score.Text = game.getPoints(Game.Person.Croupier).ToString();
                if (!Controls.Contains(pbox)) Controls.Add(pbox);
            }

            switch (result)
            {
                case 0:
                    MessageBox.Show("Pokonałeś krupiera !", "Wygrana!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case 1:
                    MessageBox.Show("Zostałeś pokonany !", "Przegrana!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case 2:
                    MessageBox.Show("Zremisowałeś !", "Remis!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }
            this.hit_btn.Enabled = true;
            this.stand_btn.Enabled = true;
            game.start();
            if (game.getPoints(Game.Person.Player) == 21) stand_btn_Click(stand_btn, new EventArgs());
            else
            {
                player_boxes.Clear();
                croupier_boxes.Clear();
                visualizeStartCards();
            }
        }
    }
}
