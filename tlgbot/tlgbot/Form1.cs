using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace tlgbot
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Api Bot = new Api("264260779:AAH9UXGUoaXzdcrBGPG3XWa1Clb6GcJ4hVI");
        int offset = 0;
        private void Form1_Load(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                try
                {
                    var x = Task.Run(async () => Bot.GetUpdates(offset, 100)).Result;
                    foreach (var u in x.Result)
                    {
                        Task.Run(async () => Bot.SendChatAction(u.Message.Chat.Id, ChatAction.Typing).ConfigureAwait(false));
                        switch (u.Type)
                        {
                            case UpdateType.MessageUpdate:
                                var keyboard = new InlineKeyboardMarkup();
                                var btns = new List<InlineKeyboardButton[]>();
                                btns.Add(new InlineKeyboardButton[] { new InlineKeyboardButton() { Text = "alert", CallbackData = "data" } });
                                keyboard.InlineKeyboard = btns.ToArray();
                                Task.Run(async () => Bot.SendTextMessage(u.Message.Chat.Id, u.Message.Text + " :)", false, 0, keyboard).ConfigureAwait(false));
                                break;

                        }
                        offset = u.Id +1 ;
                    }

                }
                catch (Exception ex)
                {
                    offset = 0;
                }
            }

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }
    }
}
