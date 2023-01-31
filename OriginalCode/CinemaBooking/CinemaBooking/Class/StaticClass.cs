using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace CinemaBooking
{
    public static class StaticClass
    {
        //public static DialogResult ShowInfo(string Message)
        //{
        //    return MessageBox.Show(Message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //}
        //public static DialogResult ShowWarning(string Message)
        //{
        //    return ShowWarning(Message, "Warning");
        //}
        //public static DialogResult ShowWarning(string Message, string Caption)
        //{
        //    return MessageBox.Show(Message, Caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //}
        //public static DialogResult ShowError(string Message)
        //{
        //    return ShowError(Message, "Error");
        //}
        //public static DialogResult ShowError(string Message, string Caption)
        //{
        //    return MessageBox.Show(Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //}
        //public static DialogResult ShowQuestion(string Message)
        //{
        //    return ShowQuestion(Message, "Question");
        //}
        //public static DialogResult ShowQuestion(string Message, string Caption)
        //{
        //    return MessageBox.Show(Message, Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
        //}
        public static string GetNewBarcodeId() { return Guid.NewGuid().ToString().Replace("-", "").ToUpper().Substring(0, 10); }
        static object someLock = new object();
        public static void WriteToLog(string Text, string FileName, bool DashCharTop, bool DashCharBottom, bool TimeStamp)
        {
            lock (someLock)
            {
                try
                {
                    if (FileName == null || FileName == "") FileName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
                    string filePath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase) + "\\" + FileName + ".log";
                    var uri = new Uri(filePath); filePath = uri.LocalPath;

                    string log = "";
                    if (DashCharTop) log += "================================================" + "\r\n";
                    if (TimeStamp) log += "Date/Time: " + DateTime.Now.ToString() + "\r\n";
                    if (TimeStamp) log += "Message: " + Text + "\r\n"; else log += Text + "\r\n";
                    if (DashCharBottom) log += "================================================" + "\r\n";
                    Console.Write(log);

                    StreamWriter stream;
                    if (!File.Exists(filePath)) stream = new StreamWriter(filePath); else stream = File.AppendText(filePath);
                    stream.Write(log);
                    stream.Close();

                }
                catch (Exception)
                {
                }
            }
        }

        public static IEnumerable<Control> GetAll(Control control)
        {
            var controls = control.Controls.Cast<Control>();
            return controls.SelectMany(ctrl => GetAll(ctrl))
                                      .Concat(controls);
        }
        public static void ChangeNames(object item)
        {
            using (var entities = new CinemaBookingEntities())
            {
                try
                {
                    var aa = entities.LabelDictionary.Where(o => o.Label == ((TextBox)item).Text && o.LanguagesId == LoginUser.LoggedLanguagesId).FirstOrDefault();
                    if (aa != null) ((TextBox)item).Text = aa.LabelLng;
                }
                catch { };

 

                try
                {
                    var aa = entities.LabelDictionary.Where(o => o.Label == ((RadioButton)item).Text && o.LanguagesId == LoginUser.LoggedLanguagesId).FirstOrDefault();
                    if (aa != null) ((RadioButton)item).Text = aa.LabelLng;
                }
                catch { };

                try
                {
                    var aa = entities.LabelDictionary.Where(o => o.Label == ((Label)item).Text && o.LanguagesId == LoginUser.LoggedLanguagesId).FirstOrDefault();
                    if (aa != null) ((Label)item).Text = aa.LabelLng;
                }
                catch { };

                try
                {
                    var aa = entities.LabelDictionary.Where(o => o.Label == ((Button)item).Text && o.LanguagesId == LoginUser.LoggedLanguagesId).FirstOrDefault();
                    if (aa != null) ((Button)item).Text = aa.LabelLng;
                }
                catch { };


                try
                {
                    var aa = entities.LabelDictionary.Where(o => o.Label == ((TabPage)item).Text && o.LanguagesId == LoginUser.LoggedLanguagesId).FirstOrDefault();
                    if (aa != null) ((TabPage)item).Text = aa.LabelLng;
                }
                catch { };
            }

        }

    }


}
