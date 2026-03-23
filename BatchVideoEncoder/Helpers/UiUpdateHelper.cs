using NLog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BatchVideoEncoder
{
    public static class UiUpdateHelper
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();

        
        public static  void updateGridView(DataGridView datagrid, int columnIndex, int rowIndex, string value)
        {
            if (datagrid.InvokeRequired)
            {
                datagrid.BeginInvoke((MethodInvoker)delegate ()
                {
                    datagrid.Rows[rowIndex].Cells[columnIndex].Value = value;

                });
            }
            else
            {
                datagrid.Rows[rowIndex].Cells[columnIndex].Value = value;
            }
        }
        public static string readGridViewCellValue(DataGridView GV, int columnIndex, int rowIndex)
        {
            string retValue = string.Empty;
            if (GV.InvokeRequired)
            {
                GV.BeginInvoke((MethodInvoker)delegate ()
                {
                    retValue = GV.Rows[rowIndex].Cells[columnIndex].Value.ToString();

                });
            }
            else
            {
                retValue = GV.Rows[rowIndex].Cells[columnIndex].Value.ToString();
            }
            return retValue;
        }
        public static void updateProgressBar(ProgressBar bar, int value, int maxValue)
        {
            if (bar.InvokeRequired)
            {
                bar.BeginInvoke((MethodInvoker)delegate ()
                {
                    bar.Value = value;
                    bar.Maximum = maxValue;

                });
            }
        }




        public static  void update_label(Label lbl, string text)
        {
            if (lbl.InvokeRequired)
            {
                lbl.BeginInvoke((MethodInvoker)delegate ()
                {
                    //update_label(label_status, "Stopped");
                    if (text == "Stopped") lbl.ForeColor = Color.Red;
                    if (text == "Running") lbl.ForeColor = Color.Green;

                    lbl.Text = text;

                });
            }
        }
        public static void update_btn(Button btn, bool isEnabled)
        {
            if(btn.InvokeRequired)
            {
                btn.BeginInvoke((MethodInvoker)delegate ()
                {
                    btn.Enabled = isEnabled;
                });
            }
        }

        public static void updateUI(Control ctrl, Action updateAction)
        {
            if (ctrl.InvokeRequired)
            {
                ctrl.BeginInvoke((MethodInvoker)delegate ()
                {
                    updateAction() ;
                });
            }
            else
            {
                updateAction();
            }
        }


       


        public static void updateTextBox(TextBox tb, string text)
        {
            if (tb.InvokeRequired)
            {
                tb.BeginInvoke((MethodInvoker)delegate ()
                {
                    //tb.AppendText(text);
                    tb.Text = text;

                });
            }
            else tb.Text = text;// tb.AppendText(text);
        }

        public static int to_nearest_16(double num)// runds float number to nearest mod16 integer
        {
            int int_num = (int)num; // closest integer to original num
            if ((int)num % 16 == 0)
                return int_num;

            else if ((int)num % 16 > 8)
            {
                do
                {
                    int_num++;
                }
                while (int_num % 16 != 0);
            }
            else
            {
                do
                {
                    int_num--;
                }
                while (int_num % 16 != 0);
            }
            return int_num;
        }


    }
}
