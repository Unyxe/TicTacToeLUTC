using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class GameForm : Form
    {
        public static string RootFolderPath = @"S:\Eng\TTT\";
        public static string QueueFolderPath = RootFolderPath + @"Queue\";
        public static string DuelsFolderPath = RootFolderPath + @"Duels\";
        public static string GameFolderPath = "";
        public static string app_id = "";
        public static string oppenent_id = "";
        public static int[] game_field = {0, 0, 0, 0, 0, 0, 0, 0, 0};
        public static bool player_1;
        public static bool turn = false;
        public GameForm(string game_path, string app_id_, string opponent_id_, bool is_player1)
        {
            InitializeComponent();
            GameFolderPath = game_path + @"Game\";
            app_id = app_id_;
            oppenent_id = opponent_id_;
            player_1 = is_player1;
            if (player_1)
            {
                turn = true;
            }
            Thread refresh_thread = new Thread(() => 
            {
                int[] checker_arr = game_field;
                while (true)
                {
                    if(game_field != checker_arr)
                    {
                        checker_arr = game_field;
                        g1_btn.Invoke((MethodInvoker)(() => 
                        {
                            g1_btn.Text = game_field[0].ToString();
                            g2_btn.Text = game_field[1].ToString();
                            g3_btn.Text = game_field[2].ToString();
                            g4_btn.Text = game_field[3].ToString();
                            g5_btn.Text = game_field[4].ToString();
                            g6_btn.Text = game_field[5].ToString();
                            g7_btn.Text = game_field[6].ToString();
                            g8_btn.Text = game_field[7].ToString();
                            g9_btn.Text = game_field[8].ToString();

                        }));
                    }
                    Thread.Sleep(100);
                }
            });
            refresh_thread.IsBackground = true;
            refresh_thread.Start();
        }
        private void g1_btn_Click(object sender, EventArgs e)
        {
            if(game_field[0] == 0 && turn)
            {
                if (player_1)
                {
                    game_field[0] = 1;
                } else
                {
                    game_field[0] = 2;
                }
            }
        }

        private void g2_btn_Click(object sender, EventArgs e)
        {
            if (game_field[1] == 0 && turn)
            {
                if (player_1)
                {
                    game_field[1] = 1;
                }
                else
                {
                    game_field[1] = 2;
                }
            }
        }

        private void g3_btn_Click(object sender, EventArgs e)
        {
            if (game_field[2] == 0 && turn)
            {
                if (player_1)
                {
                    game_field[2] = 1;
                }
                else
                {
                    game_field[2] = 2;
                }
            }
        }

        private void g4_btn_Click(object sender, EventArgs e)
        {
            if (game_field[3] == 0 && turn)
            {
                if (player_1)
                {
                    game_field[3] = 1;
                }
                else
                {
                    game_field[3] = 2;
                }
            }
        }

        private void g5_btn_Click(object sender, EventArgs e)
        {
            if (game_field[4] == 0 && turn)
            {
                if (player_1)
                {
                    game_field[4] = 1;
                }
                else
                {
                    game_field[4] = 2;
                }
            }
        }

        private void g6_btn_Click(object sender, EventArgs e)
        {
            if (game_field[5] == 0 && turn)
            {
                if (player_1)
                {
                    game_field[5] = 1;
                }
                else
                {
                    game_field[5] = 2;
                }
            }
        }

        private void g7_btn_Click(object sender, EventArgs e)
        {
            if (game_field[6] == 0 && turn)
            {
                if (player_1)
                {
                    game_field[6] = 1;
                }
                else
                {
                    game_field[6] = 2;
                }
            }
        }

        private void g8_btn_Click(object sender, EventArgs e)
        {
            if (game_field[7] == 0 && turn)
            {
                if (player_1)
                {
                    game_field[7] = 1;
                }
                else
                {
                    game_field[7] = 2;
                }
            }
        }

        private void g9_btn_Click(object sender, EventArgs e)
        {
            if (game_field[8] == 0 && turn)
            {
                if (player_1)
                {
                    game_field[8] = 1;
                }
                else
                {
                    game_field[8] = 2;
                }
            }
        }
    }
}
