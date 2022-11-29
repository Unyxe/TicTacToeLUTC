using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class QueueForm : Form
    {
        public static string RootFolderPath = @"S:\Eng\TTT\";
        public static string QueueFolderPath = RootFolderPath + @"Queue\";
        public static string DuelsFolderPath = RootFolderPath + @"Duels\";
        public static string TargetFolderPath = "";
        public static string app_id = "";
        public static string oppenent_id = "";
        public static bool in_queue = true;
        public static bool synch = false;
        public static List<string> queue_ids = new List<string>();
        
        
        public QueueForm()
        {
            InitializeComponent();
            if (!Directory.Exists(RootFolderPath))
            {
                RootFolderPath = @"C:\TTT\";
                DuelsFolderPath = RootFolderPath + @"Duels\";
                QueueFolderPath = RootFolderPath + @"Queue\";
            }
            Random rnd = new Random();
            app_id = CreateMD5(rnd.Next().ToString());
            app_id_lbl.Text = app_id;

            var main_users_thread = new Thread(() =>
            {
                while (true)
                {
                    DateTime dt = new DateTime(DateTime.UtcNow.Ticks);
                    int sec = dt.Second;
                    if (sec % 5 == 0)
                    {
                        if (!synch)
                        {
                            synch = true;
                            continue;
                        }
                        Thread.Sleep(1000);
                        if (TargetFolderPath == "")
                        {
                            Thread.Sleep(2000);
                            continue;
                        }
                        queue_ids.Clear();
                        string sourcePath = TargetFolderPath;
                        DirectoryInfo di = new DirectoryInfo(sourcePath);
                        foreach (FileInfo file in di.GetFiles())
                        {
                            try
                            {
                                file.Delete();
                            }
                            catch { }
                        }
                        Thread.Sleep(1000);
                        FileStream fs = new FileStream(sourcePath + app_id, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
                        fs.Close();
                        Thread.Sleep(1000);
                        di = new DirectoryInfo(sourcePath);
                        if(!in_queue && di.GetFiles().Length < 2)
                        {
                            in_queue = true;
                            TargetFolderPath = "";
                            enter_queue_btn.Invoke((MethodInvoker)(() =>
                            {
                                enter_queue_btn.Text = "Queue";
                            }));
                            opponent_id_lbl.Invoke((MethodInvoker)(() =>
                            {
                                opponent_id_lbl.Text = oppenent_id;
                            }));
                            Console.WriteLine("LEaved");
                            queue_ids.Clear();
                            oppenent_id = "";
                            continue;
                        }
                        if (in_queue) { 
                            di = new DirectoryInfo(sourcePath);
                            int ind = -2;
                            int c = 0;
                            foreach (FileInfo file in di.GetFiles())
                            {
                                queue_ids.Add(file.Name);
                                //Console.WriteLine(file.Name + "\n");
                            }
                            queue_ids.Sort();
                            Console.WriteLine("\n\n\n");
                            foreach(string id in queue_ids)
                            {
                                if (id == app_id)
                                {
                                    ind = c;
                                }
                                c++;
                                Console.WriteLine(id + "\n");
                            }
                            Console.WriteLine("\n\n\n");
                            if (ind % 2 == 0 && queue_ids.Count > 1)
                            {
                                if (ind + 1 != queue_ids.Count)
                                {
                                    oppenent_id = queue_ids[ind + 1];
                                }
                            } else if(queue_ids.Count > 1)
                            {
                                oppenent_id = queue_ids[ind - 1];
                            }
                            if(oppenent_id != "" && oppenent_id != app_id)
                            {
                                opponent_id_lbl.Invoke((MethodInvoker)(() => 
                                {
                                    opponent_id_lbl.Text = oppenent_id;
                                }));
                                if (String.Compare(app_id, oppenent_id) > 0) {
                                    TargetFolderPath = DuelsFolderPath + CreateMD5(app_id + oppenent_id) + @"\";
                                } else
                                {
                                    TargetFolderPath = DuelsFolderPath + CreateMD5(oppenent_id + app_id) + @"\";
                                }
                                if (!Directory.Exists(TargetFolderPath))
                                {
                                    Directory.CreateDirectory(TargetFolderPath);
                                }
                                Console.WriteLine("Found");
                                in_queue = false;
                            }
                            continue;
                        }


                    }
                    Thread.Sleep(10);
                }
            });
            main_users_thread.IsBackground = true;
            main_users_thread.Start();


        }


        //Cryptography Functions
        //__________________________________
        public static string ToBase64(string input)
        {
            return Convert.ToBase64String(Encoding.ASCII.GetBytes(input));
        }
        public static string FromBase64(string input)
        {
            return Encoding.Default.GetString(Convert.FromBase64String(input));
        }
        public static string CreateMD5(string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }

        private void enter_queue_btn_Click(object sender, EventArgs e)
        {
            TargetFolderPath = QueueFolderPath;
            oppenent_id = "";
            enter_queue_btn.Invoke((MethodInvoker)(() =>
            {
                enter_queue_btn.Text = "Waiting...";
            }));
            in_queue = true;

        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //throw new Exception();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //throw new Exception();
        }
    }
}
