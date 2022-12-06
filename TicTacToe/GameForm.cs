using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        public static string GameFilePath = "";
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
            GameFilePath = GameFolderPath + "gamefile";
            app_id = app_id_;
            oppenent_id = opponent_id_;
            player_1 = is_player1;
            if (player_1)
            {
                turn = true;
            }
            if (!Directory.Exists(GameFolderPath)) 
            {
                Directory.CreateDirectory(GameFolderPath);
            }
            if (!File.Exists(GameFilePath))
            {
                FileStream fs = new FileStream(GameFilePath, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
                StreamWriter writer = new StreamWriter(fs);
                writer.WriteLine("0000000000");
                writer.Close();
            }
            Thread refresh_thread = new Thread(() => 
            {
                Thread.Sleep(500);
                int[] checker_arr = copy(game_field);
                bool turn_checker = turn;
                while (true)
                {
                    for (int i = 0; i < checker_arr.Length; i++) {
                        //Console.WriteLine(game_field[i] + "\t" + checker_arr[i]);
                    }
                    //Console.WriteLine("\n");
                    if(!compare(game_field, checker_arr))
                    {
                        checker_arr = copy(game_field);
                        g1_btn.Invoke((MethodInvoker)(() => 
                        {
                            g1_btn.Text = convert_to_symbol(game_field[0]);
                            g2_btn.Text = convert_to_symbol(game_field[1]);
                            g3_btn.Text = convert_to_symbol(game_field[2]);
                            g4_btn.Text = convert_to_symbol(game_field[3]);
                            g5_btn.Text = convert_to_symbol(game_field[4]);
                            g6_btn.Text = convert_to_symbol(game_field[5]);
                            g7_btn.Text = convert_to_symbol(game_field[6]);
                            g8_btn.Text = convert_to_symbol(game_field[7]);
                            g9_btn.Text = convert_to_symbol(game_field[8]);
                        }));
                    }
                    if(turn_checker != turn)
                    {
                        turn_checker = turn;
                        turn_lbl.Invoke((MethodInvoker)(() =>
                        {
                            turn_lbl.Text = turn.ToString();
                        }));
                    }
                    Thread.Sleep(100);
                }
            });
            Thread file_check = new Thread(() => 
            {
                Thread.Sleep(500);
                FileStream fs = new FileStream(GameFilePath, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
                StreamReader reader = new StreamReader(fs);
                string line = reader.ReadLine();
                reader.Close();
                string checker_str = line;
                while (true)
                {
                    if (!turn)
                    {
                        fs = new FileStream(GameFilePath, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
                        reader = new StreamReader(fs);
                        line = reader.ReadLine();
                        reader.Close();
                        if (line != checker_str)
                        {
                            checker_str = line;
                            //Console.WriteLine(line.Length);
                            try
                            {
                                if (line.Length >= 10)
                                {
                                    for (int i = 0; i < 9; i++)
                                    {
                                        //Console.WriteLine(i);
                                        game_field[i] = Int32.Parse(line[i].ToString());
                                    }
                                    if (1 - Int32.Parse(line[9].ToString()) == Convert.ToInt32(is_player1))
                                    {
                                        turn = true;
                                    }
                                }
                            }catch{ }
                        }
                    }
                    Thread.Sleep(100);
                }
            });
            file_check.IsBackground = true;
            refresh_thread.IsBackground = true;
            file_check.Start();
            refresh_thread.Start();

        }
        static string convert_to_symbol(int num)
        {
            if (num == 1)
            {
                return "x";
            }
            if(num == 2)
            {
                return "o";
            }
            return "";
        }
        static int[] copy(int[] inp)
        {
            int[] gg = new int[inp.Length];
            for(int i = 0;i< inp.Length; i++)
            {
                gg[i] = inp[i];
            }
            return gg;
        }
        static bool compare(int[] inp1, int[] inp2)
        {
            for (int i = 0; i < inp1.Length; i++)
            {
                if (inp1[i] != inp2[i])
                {
                    return false;
                }
            }
            return true;
        }
        static bool check_win()
        {
            int x,y,z;
            bool allEqual, not_0;
            for (int i = 0; i < 3; i++)
            {
                x = game_field[i];
                y = game_field[i+3];
                z = game_field[i+6];
                allEqual = new[] { x, y, z }.Distinct().Count() == 1;
                not_0 = new[] { x, y, z,0 }.Distinct().Count() == 1;
                if (allEqual && !not_0) { return true; }
            }
            for (int i = 0; i < 3; i++)
            {
                x = game_field[3*i];
                y = game_field[3*i + 1];
                z = game_field[3*i + 2];
                allEqual = new[] { x, y, z }.Distinct().Count() == 1;
                not_0 = new[] { x, y, z, 0 }.Distinct().Count() == 1;
                if (allEqual && !not_0) { return true; }
            }
            x = game_field[0];
            y = game_field[4];
            z = game_field[8];
            allEqual = new[] { x, y, z }.Distinct().Count() == 1;
            not_0 = new[] { x, y, z, 0 }.Distinct().Count() == 1;
            if (allEqual && !not_0) { return true; }
            x = game_field[2];
            y = game_field[4];
            z = game_field[6];
            allEqual = new[] { x, y, z }.Distinct().Count() == 1;
            not_0 = new[] { x, y, z, 0 }.Distinct().Count() == 1;
            if (allEqual && !not_0) { return true; }
            return false;
        }
        static void send_file()
        {
            //Console.WriteLine(turn);
            
            FileStream fs = new FileStream(GameFilePath, FileMode.Truncate, FileAccess.ReadWrite, FileShare.ReadWrite);
            fs.Close();
            fs = new FileStream(GameFilePath, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
            StreamWriter writer = new StreamWriter(fs);
            string line = string.Join("", game_field.Select(x => x.ToString()).ToArray());
            line += Convert.ToInt32(player_1).ToString();
            if (turn && check_win())
            {
                Console.WriteLine("win");
                line+=Convert.ToInt32(player_1).ToString();
            } else
            {
                line += 2.ToString();
            }
            writer.WriteLine(line);
            writer.Close();
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
                send_file();
                turn = false;
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
                send_file();
                turn = false;
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
                send_file();
                turn = false;
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
                send_file();
                turn = false;
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
                send_file();
                turn = false;
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
                send_file();
                turn = false;
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
                send_file();
                turn = false;
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
                send_file();
                turn = false;
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
                send_file();
                turn = false;
            }
        }

        private void GameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            QueueForm.Sho();
            QueueForm.TargetFolderPath = "";
            QueueForm.in_queue = false;
        }

    }
}
