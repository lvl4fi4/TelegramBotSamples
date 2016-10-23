using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Helpers;
using System.IO;
using Newtonsoft.Json;
public partial class telbot : System.Web.UI.Page
{
    Api bot = new Api("token");
    protected void Page_Load(object sender, EventArgs e)
    {
        string json = "";
        try
        {
            Stream stream = Context.Request.InputStream;
            StreamReader SR = new StreamReader(stream);
            json = SR.ReadToEnd();
            Update update = JsonConvert.DeserializeObject<Update>(json);
            SR.Close();

            var s = Context.Request.InputStream;
            var Sreader = new StreamReader(s);
            json = Sreader.ReadToEnd();
            Sreader.Close();
            var up = JsonConvert.DeserializeObject<Update>(json);
            //log json
            //work with update
        }
        catch (Exception ex) {
            //log error to db or file
        }

    }
}