using System;
using System.Collections.Specialized;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Globalization;
using System.Windows.Forms;
using application;
using commonClass;

namespace Trade
{
    public static class AppLibs
    {
        public static void OrderForm(string stockCode)
        {
            Trade.Forms.transactionNew form = Trade.Forms.transactionNew.GetForm("");
            form.ClearEditData();
            form.LockEdit(false);
            form.myCode = (stockCode != null ? stockCode : "");
            form.ShowDialog();
        }
    }
}
