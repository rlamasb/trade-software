using System;
using System.Collections;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Threading;
using System.IO;
using System.Xml; 
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Management;
using System.Net.Mail;
using System.Drawing;

namespace common
{
    public class sendMail
    {
        public class sendMailInfo
        {
            public sendMailInfo()
            {
            }
            public System.Text.Encoding encoding = System.Text.Encoding.UTF8;
            public string authAccount = "";
            public string authPassword = "";
            public string smtpAddress = "127.0.0.1";
            public int smtpPort = 25;
            public bool smtpSSL = false;
        }
        public static sendMailInfo sysSendMailInfo = new sendMailInfo();

        public void SendMail(string frEmail, string toEmail, string msgSubject, string msgBody)
        {
            SendMail(frEmail, toEmail, msgSubject, msgBody, null, null, null);
        }
        public void SendMail(string frEmail, string toEmail, string msgSubject, string msgBody,
                             string[] ccList, string[] bccList, string[] attachedFiles)
        {
            MailAddress SendFrom = new MailAddress(frEmail);
            MailAddress SendTo = new MailAddress(toEmail);
            MailMessage mail = new MailMessage(SendFrom, SendTo);
            mail.Subject = msgSubject;
            mail.Body = msgBody;
            mail.SubjectEncoding = System.Text.Encoding.UTF8;
            mail.BodyEncoding = System.Text.Encoding.UTF8;
            if (attachedFiles != null)
            {
                for (int idx = 0; idx < attachedFiles.Length; idx++)
                    mail.Attachments.Add(new Attachment(attachedFiles[idx]));
            }
            if (ccList != null)
            {
                for (int idx = 0; idx < ccList.Length; idx++)
                    mail.CC.Add(new MailAddress(ccList[idx]));
            }
            if (bccList != null)
            {
                for (int idx = 0; idx < bccList.Length; idx++)
                    mail.Bcc.Add(new MailAddress(bccList[idx]));
            }

            SmtpClient client = new SmtpClient(sysSendMailInfo.smtpAddress, sysSendMailInfo.smtpPort);
            if (sysSendMailInfo.authAccount != null && sysSendMailInfo.authAccount.Trim()!="" &&
                sysSendMailInfo.authPassword != null && sysSendMailInfo.authPassword.Trim() != "")
            {
                System.Net.NetworkCredential SMTPUserInfo = new System.Net.NetworkCredential(sysSendMailInfo.authAccount, sysSendMailInfo.authPassword);
                client.UseDefaultCredentials = sysSendMailInfo.smtpSSL;
                client.Credentials = SMTPUserInfo;
            }
            else client.UseDefaultCredentials = true;
            client.Send(mail);
        }
 
    }
    public class myAutoKeyInfo
    {
        public string key = "", value = "", editKey = "";
        public myAutoKeyInfo(string _key, string _value, string _editKey)
        {
            key = _key; value = _value; editKey = _editKey;
        }
    }
    public class extSortedList : SortedList
    {
        //private SortedList sortedList;
        public extSortedList()
        {
            //this.sortedList = new SortedList();
        }

        public void Add(string key, object value)
        {
            if (this.ContainsKey(key))
            {
                this[key] = value;
            }
            else this.Add(key, value);
        }
        public new StringCollection Keys()
        {
            StringCollection retList = new StringCollection();
            for (int idx = 0; idx < this.Count;idx++) retList.Add(this.GetKey(idx).ToString());
            return retList;
        }
        public new SortedList Values()
        {
            SortedList retList = new SortedList();
            foreach (DictionaryEntry item in this)
            {
                retList.Add(item.Key.ToString(), item.Value);
            }
            return retList;
        }
        public object GetValue(string code)
        {
            if (this.ContainsKey(code)) return this[code];
            return null;
        }
    }

    public class distribution
    {
        private class distributeObj
        {
            public distributeObj(decimal w, decimal v)
            {
                this.weight = w; this.value = v;
            }
            public decimal weight = 0, value = 0;
        }
        private decimal totalWeight;
        private SortedList distributionList;
        public distribution()
        {
            this.totalWeight = 0;
            this.distributionList = new SortedList();
        }

        public void Remove(string code)
        {
            if (this.distributionList.ContainsKey(code))
            {
                distributeObj obj = (distributeObj)this.distributionList[code];
                this.distributionList.Remove(code);
                this.totalWeight -= obj.weight;
            }
        }
        public void Add(string code, decimal weight)
        {
            if (this.distributionList.ContainsKey(code)) 
            {
                distributeObj obj = (distributeObj)this.distributionList[code];
                obj.weight += weight;
                this.distributionList[code] = obj;
            }
            else this.distributionList.Add(code, new distributeObj(weight, 0));
            this.totalWeight += weight;
            
        }
        public bool Distribute(decimal value)
        {
            return Distribute(value, 0);
        }
        public bool Distribute(decimal value,int precision)
        {
            if (value == 0) return true;
            if (this.totalWeight == 0) return false;
            decimal remainValue = value, tmp;
            distributeObj obj;
            int idx = 0;
            foreach (DictionaryEntry item in this.distributionList)
            {
                obj = (distributeObj)item.Value;
                idx++;
                if (idx == this.distributionList.Count) tmp = remainValue;
                else tmp = Math.Round(value * obj.weight / this.totalWeight,precision);
                obj.value += tmp;
                remainValue -= tmp;
            }
            return true;
        }
        public void ResetValues()
        {
            foreach (DictionaryEntry item in this.distributionList)
            {
                ((distributeObj)item.Value).value=0;
            }
        }
        public void Reset()
        {
            this.distributionList.Clear();
            this.totalWeight = 0;
        }
        public SortedList GetDistribution()
        {
            distributeObj obj;
            SortedList retList = new SortedList();
            foreach (DictionaryEntry item in this.distributionList)
            {
                obj = (distributeObj)item.Value;
                retList.Add(item.Key.ToString(), obj.value);
            }
            return retList;
        }
        public SortedList GetWeights()
        {
            distributeObj obj;
            SortedList retList = new SortedList();
            foreach (DictionaryEntry item in this.distributionList)
            {
                obj = (distributeObj)item.Value;
                retList.Add(item.Key.ToString(), obj.weight);
            }
            return retList;
        }
        public SortedList GetValues()
        {
            distributeObj obj;
            SortedList retList = new SortedList();
            foreach (DictionaryEntry item in this.distributionList)
            {
                obj = (distributeObj)item.Value;
                retList.Add(item.Key.ToString(), obj.value);
            }
            return retList;
        }
        public decimal GetWeight(string code)
        {
            if (this.distributionList.ContainsKey(code))
                return ((distributeObj)this.distributionList[code]).weight;
            return 0;
        }
        public decimal GetValue(string code)
        {
            if (this.distributionList.ContainsKey(code))
                return ((distributeObj)this.distributionList[code]).value;
            return 0;
        }
        public distribution Clone()
        {
            distributeObj obj;
            distribution clone = new distribution();
            foreach (DictionaryEntry item in this.distributionList)
            {
                obj = (distributeObj)item.Value;
                clone.Add(item.Key.ToString(), obj.weight);
            }
            return clone;
        }
    }

    public class errorHandler
    {
        private static string _lastErrorMsg = "";
        public static string lastErrorMessage
        {
            get
            {
                string tmp = _lastErrorMsg; _lastErrorMsg = ""; return tmp;
            }
            set { _lastErrorMsg = value; }
        }
    }

    public class globalSettings
    {
        public static CultureInfo CurrentCulture
        {
            get { return Thread.CurrentThread.CurrentCulture;}
            set { Thread.CurrentThread.CurrentCulture=value;}
        }
    }

    public class myKeyValueExt : IComparable
    {
        private string _sortCode, _text, _value, _attrib1, _attrib2;

        public myKeyValueExt(string text, string value)
        {
            _text = text; _value = value;
            _attrib1 = ""; _attrib2 = "";
            _sortCode = "";
        }
        //The item will display in the combo box based on how you implemented
        //ToString(). In this case, the name is displayed. But, when the object is
        //selected, you have this object, which may contain as much data as you need.
        public override string ToString()
        {
            return _text;
        }
        public virtual string Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public virtual string Text
        {
            get { return _text; }
            set { _text = value; }
        }

        public virtual string SortCode
        {
            get { return _sortCode; }
            set { _sortCode = value; }
        }


        public virtual string Attribute1
        {
            get { return _attrib1; }
            set { _attrib1 = value; }
        }
        public virtual string Attribute2
        {
            get { return _attrib2; }
            set { _attrib2 = value; }
        }

        public int CompareTo(object obj)
        {
            return this.SortCode.CompareTo(((myKeyValueExt)obj).SortCode);
        }
    }
    public class myComboBoxItem
    {
        private string _text;
        private string _value;

        public myComboBoxItem(string text, string value)
        {
            _text = text;
            _value = value;
        }
        //The item will display in the combo box based on how you implemented
        //ToString(). In this case, the name is displayed. But, when the object is
        //selected, you have this object, which may contain as much data as you need.
        public override string ToString()
        {
            return _text;
        }
        public virtual string Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public virtual string Text
        {
            get { return _text; }
            set { _text = value; }
        }
    }
    public class myKeyValueItem
    {
        private string _key;
        private string _value;

        public myKeyValueItem(string key, string value)
        {
            _key = key;
            _value = value;
        }
        //The item will display in the combo box based on how you implemented
        //ToString(). In this case, the name is displayed. But, when the object is
        //selected, you have this object, which may contain as much data as you need.
        public override string ToString()
        {
            return _key;
        }
        public virtual string Value
        {
            get {return _value;}
            set {_value =value;}
        }
        
        public virtual string Key
        {
            get { return _key; }
            set { _key = value; }
        }
    }
    public static class system
    {
        public static string Time2String(DateTime time,string timeMask)
        {
            string timeStr= "";
            string[] maskItems = timeMask.Split(new char[]{':'}, StringSplitOptions.RemoveEmptyEntries);
            timeStr = time.Hour.ToString().PadLeft(2, '0'); 
            if (maskItems.Length > 1) timeStr += ":" + time.Minute.ToString().PadLeft(2, '0');
            if (maskItems.Length > 2) timeStr += ":" + time.Second.ToString().PadLeft(2, '0');
            return timeStr;
        }                    
    
        public static bool ParseTime(string timeStr, out byte hour, out byte min, out byte sec)
        {
            hour = 0; min = 0; sec = 0;
            string[] items = timeStr.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
            if (items.Length != 2 && items.Length != 3) return false;
            if (!byte.TryParse(items[0], out hour)) return false;
            if (hour < 0 || hour >= 24) return false;

            if (!byte.TryParse(items[1], out min)) return false;
            if (min < 0 || min >= 60) return false;

            if (items.Length == 3)
            {
                if (!byte.TryParse(items[2], out sec)) return false;
                if (min < 0 || sec >= 60) return false;
            }
            return true;
        }
        public static void ViewFile(string fileName)
        {
            System.Diagnostics.Process.Start(fileName);
        }

        public static string MakeFileDialogFilter_Image()
        {
            myKeyValueItem[] list = new myKeyValueItem[2];
            list[0] = new myKeyValueItem("Images", "*.jpg;*.jpeg;*.gif;*.png");
            list[1] = new myKeyValueItem("All Types" , "*.*");
            return MakeFileDialogFilter(list);
        }
        public static string MakeFileDialogFilter_Document()
        {
            myKeyValueItem[] list = new myKeyValueItem[6];
            list[0] = new myKeyValueItem("Word", "*.doc;*.docx");
            list[1] = new myKeyValueItem("Excel", "*.xls;*.xlsx");
            list[2] = new myKeyValueItem("Power point", "*.ppt;*.pptx");
            list[3] = new myKeyValueItem("PDF", "*.pdf");
            list[4] = new myKeyValueItem("HTML", "*.htm;*.html");
            list[5] = new myKeyValueItem("All Types", "*.*");
            return MakeFileDialogFilter(list);
        }

        public static string MakeFileDialogFilter_ImageAndDocument()
        {
            myKeyValueItem[] list = new myKeyValueItem[7];
            list[0] = new myKeyValueItem("Images", "*.jpg;*.jpeg;*.gif;*.png");
            list[1] = new myKeyValueItem("Word", "*.doc;*.docx");
            list[2] = new myKeyValueItem("Excel", "*.xls;*.xlsx");
            list[3] = new myKeyValueItem("Power point", "*.ppt;*.pptx");
            list[4] = new myKeyValueItem("PDF", "*.pdf");
            list[5] = new myKeyValueItem("HTML", "*.htm;*.html");
            list[6] = new myKeyValueItem("All Types", "*.*");
            return MakeFileDialogFilter(list);
        }
        public static string MakeFileDialogFilter(myKeyValueItem[] list)
        {
            string filter = "";
            for (int idx=0;idx<list.Length;idx++)
            {
                filter += (filter == "" ? "" : "|") + list[idx].Key + "(" + list[idx].Value  + ")" + "|" + list[idx].Value; 
            }
            return filter;
        }

        public enum searchOptions : int { Exact, StartWith, EndWith, Contain }; // Export format enumeration		
        public static string MakeSearchExpression(string searchBy, string searchTerm, searchOptions option)
        {
            return MakeSearchExpression(searchBy, searchTerm, option, false);
        }
        public static string MakeSearchExpression(string searchBy, string searchTerm, searchOptions option, bool withUnicode)
        {
            string unicodeMark = (withUnicode ? "N" : "");
            switch (option)
            {
                case searchOptions.Exact: return searchBy + "=" + unicodeMark + "'" + searchTerm + "'";
                case searchOptions.EndWith: return searchBy + " LIKE " + unicodeMark + "'" + Consts.SQL_CMD_ALL_MARKER + searchTerm + "'";
                case searchOptions.StartWith: return searchBy + " LIKE " + unicodeMark + "'" + searchTerm + Consts.SQL_CMD_ALL_MARKER + "'";
                case searchOptions.Contain: return searchBy + " LIKE " + unicodeMark + "'" + Consts.SQL_CMD_ALL_MARKER + searchTerm + Consts.SQL_CMD_ALL_MARKER + "'";
            }
            return "";
        }

        public static string GetOriginalData(DataRowView row, string fldName)
        {
            if (row.Row.HasVersion(DataRowVersion.Original)) return row.Row[fldName, DataRowVersion.Original].ToString();
            return row.Row[fldName].ToString();
        }

        public static string GetExecuteDirectory()
        {
            return common.fileFuncs.FileNamePath(Application.ExecutablePath);
        }

        public static StringCollection ParseString(string str, int maxItem)
        {
            StringCollection retList = new StringCollection();
            if (str != "")
            {
                string[] items = str.Split(common.settings.sysSeparatorList, StringSplitOptions.RemoveEmptyEntries);
                int len = Math.Min(items.Length, maxItem);
                for (int idx = 0; idx < len; idx++) retList.Add(items[idx]);
            }
            for (int idx = retList.Count - 1; idx < maxItem; idx++) retList.Add("");
            return retList;
        }

        //This function to protect the calling from outside into sensitive functions
        public static bool isValidCall()
        {
            if (Consts.constValidCallString == Consts.constValidCallMarker) return true;
            //common.system.ShowErrorMessage("Invalid use.");
            return false;
        }

        /// <summary>
        /// This function mimic the mail-merge to create a merged text from a template file.
        /// </summary>
        /// <param name="str"> string to merge </param>
        /// <param name="tagList"> ArrayList of myKeyValueItem object</param>
        /// <returns></returns>
        public static string MergeText(string str, ArrayList tagList)
        {
            myKeyValueItem item;
            int idx = 0;
            while (idx < tagList.Count)
            {
                item = (myKeyValueItem)tagList[idx];
                str = str.Replace(item.Key, item.Value);
                idx++;
            }
            return str;
        }

        // Number functions
        public static void ResetVar(ref decimal[] var)
        {
            if (var == null) return;
            for (int i = 0; i < var.Length; i++) var[i] = 0;
        }
        public static void AddNumber(ref decimal[] operand1, decimal[] operand2)
        {
            if (operand1 == null || operand2==null) return;
            int sz = System.Math.Min(operand1.Length, operand2.Length);
            for (int i = 0; i < sz; i++) operand1[i] += operand2[i];
        }
        public static decimal[] AddNumber(decimal[] operand1, decimal[] operand2)
        {
            int sz = System.Math.Min(operand1.Length, operand2.Length);
            decimal[] retVal = new decimal[sz];
            ResetVar(ref retVal);
            AddNumber(ref retVal, operand1);
            AddNumber(ref retVal, operand2);
            return retVal;
        }
        public static void SubtractNumber(ref decimal[] operand1, decimal[] operand2)
        {
            if (operand1 == null || operand2 == null) return;
            int sz = System.Math.Min(operand1.Length, operand2.Length);
            for (int i = 0; i < sz; i++) operand1[i] -= operand2[i];
        }

        // Parse expression string and return a list of operands and operators.
        // Input  :
        //  - expression : expression string
        //  - operators : operator list
        // Return a list of [operand] [operator] [operand]...

        public static StringCollection ParseExpression(string expression, char[] operators)
        {
            bool haveSepa = false;
            int pos;
            StringCollection retVal = new StringCollection();
            while (expression.Length > 0)
            {
                haveSepa = false;
                for (int idx2 = 0; idx2 < operators.Length; idx2++)
                {
                    pos = expression.IndexOf(operators[idx2]);
                    if (pos >= 0)
                    {
                        retVal.Add(expression.Substring(0, pos).Trim());
                        retVal.Add(operators[idx2].ToString());
                        expression = expression.Substring(pos + 1);
                        haveSepa = true;
                        continue;
                    }
                }
                if (!haveSepa && expression.Length > 0)
                {
                    retVal.Add(expression);
                    break;
                }
            }
            return retVal;
        }

        public static void ExitApplication()
        {
            ExitApplication(0);
        }
        public static void ExitApplication(int code)
        {
            if (settings.sysDebugMode)
            {
                common.system.ShowMessage("Exit application.");
                return;
            }          
            Application.Exit();
            Environment.Exit(code);
        }
        public static int VisibleGridColumnWidth(DataGridView gv)
        {
            int w = 0;
            for (int idx = 0; idx < gv.Columns.Count; idx++)
            {
                if (gv.Columns[idx].Visible)
                    w += gv.Columns[idx].Width;
            }
            return w;
        }

        public static void AutoFitGridColumn(DataGridView gv, string colName)
        {
            if (colName.Trim()=="" || gv.Columns[colName] == null)
            {
                AutoFitGridColumn(gv);
                return;
            }
            int w = VisibleGridColumnWidth(gv);
            w -= gv.Columns[colName].Width - gv.RowHeadersWidth - SystemInformation.VerticalScrollBarThumbHeight-2;
            gv.Columns[colName].Width = gv.Width - w;
            w = VisibleGridColumnWidth(gv);
        }
        public static void AutoFitGridColumn(DataGridView gv)
        {
            distribution widthDist = new distribution();
            int totalWidth = 0;
            for (int idx = 0; idx < gv.Columns.Count; idx++)
            {
                if (!gv.Columns[idx].Visible) continue;
                totalWidth += gv.Columns[idx].Width;
                widthDist.Add(gv.Columns[idx].Name, gv.Columns[idx].Width);
            }
            totalWidth = gv.Width - gv.RowHeadersWidth - SystemInformation.VerticalScrollBarThumbHeight - 2 - totalWidth;
            if (!widthDist.Distribute(totalWidth,0)) return;
            SortedList disResult = widthDist.GetDistribution();
            int value=0;
            string tmp;
            for (int idx = 0; idx < disResult.Count; idx++)
            {
                tmp =  disResult.GetKey(idx).ToString();
                //if (!int.TryParse(tmp,out colId)) continue;
                int.TryParse(disResult[tmp].ToString(), out value);
                gv.Columns[tmp].Width += value;
            }
        }

        //A single tick represents one hundred nanoseconds or one ten-millionth of a second. FROM MSDN.
        public static int TimeToSecond(DateTime dt)
        {
            return (int)(dt.Ticks / 10000000);
        }
        public static int Random()
        {
            return Random(0,int.MaxValue);
        }
        public static int Random(int min,int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
        public static void ThrowException(string msg)
        {
            throw new System.ArgumentException(msg);
        }
        public static void ThrowException(Exception er)
        {
            throw new System.ArgumentException(er.Message);
        }

        public static string ValidateFileName(string fn)
        {
            //fn.Replace("\\", "-");
            //fn.Replace("/", "-");
            //char[] invalidChar = System.IO.Path.GetInvalidFileNameChars();
            for (int idx = 0; idx < fn.Length; idx++)
            {
                if (!Char.IsLetterOrDigit(fn[idx])) fn = fn.Replace(fn[idx], '-');
            }
            return fn;
        }
        //public static bool HaveFindMarker(ref string code)
        //{
        //    bool retVal = code.Contains(settings.sysFindMarker);
        //    if (retVal) code = code.Replace(settings.sysFindMarker, "");
        //    return retVal;
        //}
        //public static bool HaveFindMarker(string code)
        //{
        //    return HaveFindMarker(ref code);
        //}

        public static void ShowMessage(string msg)
        {
            MessageBox.Show(msg, settings.sysApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void ShowErrorMessage()
        {
            MessageBox.Show("Hệ thống gặp lỗi", settings.sysApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public static void ShowErrorMessage(string msg)
        {
            MessageBox.Show(msg, settings.sysApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public static string MakeConditionStr(string itemList,string prefixStr, string postfixStr, string operatorStr)
        {
            StringCollection items = String2Collection(itemList);
            return MakeConditionStr(items,prefixStr,postfixStr,operatorStr);
        }
        public static string MakeConditionStr(StringCollection items, string prefixStr, string postfixStr, string operatorStr)
        {
            if (items==null || items.Count == 0 ) return "";
            string retStr = "";
            for (int idx = 0; idx < items.Count; idx++)
            {
                if (items[idx].Trim() == "") continue;
                retStr += (retStr == "" ? "" : " " + operatorStr + " ") +
                    "(" + prefixStr + items[idx].Trim() + postfixStr + ")";
            }
            return retStr;
        }

        public static string SayNumber(double number, string sepaChar, string unitStr)
        {
            string tmp = number.ToString();
            string[] numSplit = tmp.Split(Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator.ToCharArray());
            long p1 = 0; 
            if(numSplit.Length>0) long.TryParse(numSplit[0], out p1);
            long p2 = 0;
            if (numSplit.Length > 1) long.TryParse(numSplit[1], out p2);
            if (p2 != 0)
                 return SayNumber(p1, sepaChar,"") + " lẻ " + SayNumber(p2, sepaChar,"") + " " + unitStr;
            else return SayNumber(p1, sepaChar, unitStr);
        }

        public static string SayNumber(long number, string sepaChar, string unitStr)
        {
            int unitCount = 0;
            long remainder;
            bool flag = (number%1000)==0;
            string result = "";
            while (true)
            {
                remainder = number % 1000;
                number = (number - remainder) / 1000;
                if (remainder != 0)
                {
                    if (result != "") result = sepaChar + result;
                    result = NumberToString(remainder) + UnitStr(unitCount) + result;
                }
                if (number == 0) break;
                unitCount = unitCount + 1;
            }
            if (result != "")
            {
                result += " " + unitStr; 
                if (flag) result += " chẵn";
            }
            result = result.Trim();
            if(result!="") result = result.Substring(0,1).ToUpper() + result.Substring(1); 
            return result;
        }

        private static string UnitStr(int column)
        {
            switch (column)
            {
                case 0: return "";
                case 1: return " ngàn";
                case 2: return " triệu";
                case 3: return " tỉ";
                case 4: return " ngàn tỉ";
            }
            return "*";
        }

        private static string NumberToString(long number)
        {
            string result = "";
            long remainder = number % 100;
            long lcM100 = (number - remainder) / 100;
            if (lcM100 != 0)
            {
                if (result != "") result += " ";
                result += BasicNumberToString(lcM100, 0) + " trăm";
            }
            number = remainder;

            remainder = number % 10;
            long  lcM10 = (number - remainder) / 10;
            if (lcM10 != 0)
            {
                if (lcM10 == 1)
                {
                    result += " mười";
                    if (remainder != 0)
                    {
                        if (result != "") result += " ";
                    }
                    result += BasicNumberToString(remainder, 2);
                }
                else
                {
                    if (result != "") result += " ";
                    result += BasicNumberToString(lcM10, 0) + " mươi";
                    if (remainder != 0)
                    {
                        if (result != "") result += " ";
                        result += BasicNumberToString(remainder, 3);
                    }
                }
                return result;
            }

            if (remainder != 0)
            {
                if (lcM100 != 0) result += " lẻ";
                if (result != "") result += " ";
            }
            result += BasicNumberToString(remainder, 0);
            return result;
        }

        private static string BasicNumberToString(long num, int opt)
        {
            switch (num)
            {
                case 0: return ""; 
                case 1: 
                    return (opt == 1 || opt == 3) ? "mốt" : "một";
                case 2: return "hai";
                case 3: return "ba";
                case 4: return "bốn";
                case 5: return (opt == 2 || opt == 3) ? "lăm" : "năm";
                case 6: return "sáu";
                case 7: return "bảy";
                case 8: return "tám";
                case 9: return "chín";
            }
            return "*";
        }

        public static string UniqueString()
        {
            return Guid.NewGuid().ToString().Replace("-",""); 
        }

        public static string DateTimeToString(DateTime dt)
        {
            return dt.ToString(globalSettings.CurrentCulture);
        }

        /// <summary>
        /// Convert a formated-string to a double number
        /// </summary>
        /// <param name="doublStr">a formated-string of a double numer</param>
        /// <param name="db"> double nubmer converted form [doublStr]</param>
        /// <returns></returns>
        public static bool StrToDouble(string doublStr,out double db)
        {
            return double.TryParse(doublStr, NumberStyles.Float | NumberStyles.AllowThousands,globalSettings.CurrentCulture, out db);
        }
        public static bool StrToDecimal(string str, out decimal d)
        {
            return decimal.TryParse(str, NumberStyles.Float | NumberStyles.AllowThousands, globalSettings.CurrentCulture, out d);
        }
        
        /// <summary>
        /// Convert a string to date time 
        /// </summary>
        /// <param name="dateTimeTxt"> Dateime-formated string</param>
        /// <param name="dt"> Datetime from dateTimeTxt (if valid)</param>
        /// <returns></returns>
        public static bool StringToDateTime(string dateTimeTxt,out DateTime convertedDateTime)
        {
            return DateTime.TryParse(dateTimeTxt,globalSettings.CurrentCulture, DateTimeStyles.NoCurrentDateDefault, out convertedDateTime); 
        }

        public static bool MakeDate(int day,int month,int year,out DateTime dt)
        {
            dt = DateTime.Today;
            dt = dt.AddDays(-dt.Day+1).AddMonths(-dt.Month+1).AddYears(year - dt.Year);
            dt = dt.AddMonths(month-1).AddDays(day-1);
            return (dt.Day == day && dt.Month == month && dt.Year == year);
        }

        /// <summary>
        /// In SQL command, a double string is always  99999999.999 (no thousand separator and period is used as decimal placeholder) 
        /// The function convert a double to a string for use in a SQL command
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        public static string ConvertToSQLDoubleString(double db)
        {
            string[] parts = db.ToString().Split(new string[] { globalSettings.CurrentCulture.NumberFormat.CurrencyDecimalSeparator}, StringSplitOptions.RemoveEmptyEntries);  
            if (parts.Length==0) return "0";  
            if (parts.Length==1) return parts[0];
            return parts[0].Trim() + "." + parts[1].Trim();
        }
        
        /// <summary>
        /// In SQL command, a date is a string of MM/DD/YYYY hh:mm:ss OR YYYY/MM/DD hh:mm:ss. The function convert any date to SQL Date-stype.
        /// Return "" if the date is invalid
        /// </summary>
        /// <param name="dateTxt">Date time string in current culture format</param>
        /// <returns></returns>
        public static string ConvertToSQLDateString(string dateTxt)
        {
            return ConvertToSQLDateString(dateTxt, true);
        }
        public static string ConvertToSQLDateString(DateTime date, bool dateOnly)
        {
            string tmp = date.Year.ToString() + "/" + date.Month.ToString() + "/" + date.Day.ToString();
            if (!dateOnly) tmp += " " + date.Hour.ToString() + ":" + date.Minute.ToString() + ":" + date.Second.ToString();
            return tmp;
        }

        public static string ConvertToSQLDateString(string dateTxt,bool dateOnly)
        {
            DateTime date;
            if (!DateTime.TryParse(dateTxt, globalSettings.CurrentCulture, DateTimeStyles.NoCurrentDateDefault, out date)) return "";
            return ConvertToSQLDateString(date, dateOnly);
        }

        /// <summary>
        /// In SQL command, a date is a string of MM/DD/YYYY hh:mm:ss. The function convert any date to SQL Date-stype.
        /// Return "" if the date is invalid
        /// </summary>
        /// <param name="date">DateTime in current format</param>
        /// <returns></returns>
        public static string ConvertToSQLDateString(DateTime date)
        {
            return ConvertToSQLDateString(date,true);
        }
        // Return : what field to be used as unit price 
        public static string GetPriceSetting()
        {
            return "price1";
        }

        public static bool ExecuteSQLCmd(string strQuery, string connStr)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connStr);
                conn.Open();
                if (!ExecuteSQLCmd(strQuery, conn)) return false;
                conn.Close(); conn.Dispose();
            }
            catch (Exception er)
            {
                system.ShowErrorMessage(er.Message);
                return false;
            }
            return true;
        }

        public static bool ExecuteSQLCmd(string strQuery, SqlConnection conn)
        {
            try
            {
                SqlCommand tmpCommand = new SqlCommand(strQuery, conn);
                tmpCommand.ExecuteNonQuery();
                tmpCommand.Dispose();
            }
            catch (Exception er)
            {
                system.ShowErrorMessage(er.Message);
                return false;
            }
            return true;
        }
        public static bool LoadToListBox(ListBox lb, string SQLCmd, string fld, string connStr)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connStr);
                conn.Open();
                SqlCommand comm = new SqlCommand(SQLCmd, conn);
                SqlDataReader reader;
                reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    lb.Items.Add(reader[fld].ToString().Trim());
                }
            }
            catch(Exception er)
            {
                system.ShowErrorMessage(er.Message.ToString());
                return false;
            }
            finally
            {
                if (conn != null) conn.Close();
            }
            return true;
        }

        public static ArrayList LoadToArrayList(string SQLCmd, string fld, string connStr)
        {
            ArrayList arr = new ArrayList();
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connStr);
                conn.Open();
                SqlCommand comm = new SqlCommand(SQLCmd, conn);
                SqlDataReader reader;
                reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    arr.Add(reader[fld].ToString().Trim());
                }
            }
            catch (Exception er)
            {
                system.ShowErrorMessage(er.Message.ToString());
                return null;
            }
            finally
            {
                if (conn != null) conn.Close();
            }
            return arr;
        }
        public static ArrayList LoadToArrayList(DataTable tbl, string codeFldName, string descFldName)
        {
            ArrayList arr = new ArrayList();
            for(int idx=0;idx<tbl.Rows.Count;idx++)
            {
                arr.Add(tbl.Rows[idx][codeFldName].ToString().Trim());
            }
            return arr;
        }

        public static string GetSubStr(string orgStr, int numberOfWords)
        {
            return GetSubStr(orgStr, numberOfWords, "...");
        }
        public static string GetSubStr(string orgStr, int numberOfWords, string postFix)
        {
            orgStr = orgStr.Trim();
            string[] wordList = orgStr.Split(settings.sysSeparatorsWord , StringSplitOptions.RemoveEmptyEntries);
            string result = "";
            for (int idx = 0; idx < wordList.Length; idx++)
            {
                result += (result == "" ? "" : " ") + wordList[idx];
                if (idx >= numberOfWords - 1)
                {
                    result += postFix;
                    break;
                }
            }
            return result;
        }
  
        public static bool LoadToListBox(ListBox lb, ArrayList list)
        {
            try
            {
                lb.Items.Clear();
                for (int idx = 0; idx < list.Count; idx++)
                    lb.Items.Add(list[idx].ToString());
            }
            catch (Exception er)
            {
                system.ShowErrorMessage(er.Message.ToString());
                return false;
            }
            return true;
        }
        public static bool LoadToComboBox(ComboBox cb, SortedList sList)
        {
            cb.Items.Clear();
            foreach (DictionaryEntry de in sList)
            {
                myComboBoxItem cbItem = new myComboBoxItem(de.Value.ToString(), de.Key.ToString());
                cb.Items.Add(cbItem);
            }
            return true;
        }
        public static bool LoadToComboBox(ComboBox cb, ArrayList list)
        {
            cb.Items.Clear();
            for (int idx=0;idx<list.Count;idx++)
            {
                myComboBoxItem cbItem = (myComboBoxItem)list[idx];
                cb.Items.Add(cbItem);
            }
            return true;
        }
        public static bool LoadToComboBox(ComboBox cb,string SQLCmd, string valueFld, string textFld, string connStr)
        {
            try
            {
                SortedList sList = new SortedList();
                if (!LoadToSortedList(sList, SQLCmd, valueFld, textFld, connStr)) return false;
                LoadToComboBox(cb, sList);
            }
            catch
            {
                return false;
            }
            return true;
        }
        public static bool LoadToSortedList(SortedList sList, string SQLCmd, string valueFld, string textFld, string connStr)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connStr);
                conn.Open();
                SqlCommand comm = new SqlCommand(SQLCmd, conn);
                SqlDataReader reader;
                reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    sList.Add(reader[valueFld].ToString().ToString().Trim(), reader[textFld].ToString().ToString().Trim());
                }
            }
            catch
            {
                return false;
            }
            finally
            {
                if (conn != null) conn.Close();
            }
            return true;
        }

        //Alloting an amount 
        public static ArrayList Apportion(double totalAmt, ArrayList weightList)
        {
            return Apportion(totalAmt, weightList, 0);
        }
        public static ArrayList Apportion(double totalAmt, ArrayList weightList, int precision)
        {
            try
            {
                ArrayList retList = new ArrayList();
                double totalWeight = 0;
                for (int idx = 0; idx < weightList.Count; idx++) totalWeight += (double)weightList[idx];
                if (totalWeight == 0) return null;

                double remainAmt, amt;
                int lastApportionIdx = -1;
                remainAmt = totalAmt;
                for (int idx = 0; idx < weightList.Count; idx++)
                {
                    amt = Math.Round(totalAmt * (double)weightList[idx] / totalWeight,precision);
                    retList.Add(amt);  remainAmt -= amt;
                    if ( amt!=0 ) lastApportionIdx = idx;
                }
                if (remainAmt != 0)
                {
                    if (lastApportionIdx < 0) return null;
                    retList[lastApportionIdx] = (double)retList[lastApportionIdx] + remainAmt;
                }
                return retList;
            }
            catch (Exception er) 
            {
                system.ShowErrorMessage(er.Message.ToString());
            }
            return null;
        }

        public static bool ApportionGrid(double totalAmt,DataGridView detailGrid,string weightColName,string allotedColName)
        {
            return ApportionGrid(totalAmt,detailGrid,weightColName, allotedColName, 0);
        }
        public static bool ApportionGrid(double totalAmt,DataGridView detailGrid,string weightColName,string allotedColName,int precision)
        {
            try
            {
                string tmp; double amt=0;
                ArrayList weightList = new ArrayList();
                for (int idx = 0; idx < detailGrid.Rows.Count; idx++)
                {
                    if (detailGrid.Rows[idx].Cells[weightColName].Value == null) continue;
                    tmp = detailGrid.Rows[idx].Cells[weightColName].Value.ToString().Trim();
                    amt=0; double.TryParse(tmp,out amt); weightList.Add(amt);
                }
                ArrayList retList = Apportion(totalAmt, weightList,precision);
                if (retList == null) return false;
                int retListId = 0;
                for (int idx = 0; idx < detailGrid.Rows.Count; idx++)
                {
                    if (detailGrid.Rows[idx].Cells[weightColName].Value == null) continue;
                    tmp = detailGrid.Rows[idx].Cells[weightColName].ToString().Trim();
                    if (detailGrid.Rows[idx].Cells[weightColName].Value == null) continue;
                    if (detailGrid.Rows[idx].Cells[allotedColName].Value != null)
                        detailGrid.Rows[idx].Cells[allotedColName].Value = (double)retList[retListId]; 
                    retListId++;
                }
                return true;
            }
            catch (Exception er)
            {
                system.ShowErrorMessage(er.Message.ToString());
            }
            return false;
        }

        public static int TurnBitOn(int number, int position)
        {
            return number | (1 << position);
        }

        public static int TurnBitOff(int number, int position)
        {
            int tmp=1;
            tmp = 1 << position;
            tmp = ~tmp;
            return tmp & number;
        }

        public static bool BitIsOn(int number, int position)
        {
            int tmp;
            tmp = 1 << position;
            return ((number & tmp) > 0);
        }

        public static int IndexOf(string[] list, string s)
        {
            for (int idx = 0; idx < list.Length; idx++)
                if (list[idx] == s) return idx;
            return -1;
        }
        public static string List2String(string[] list)
        {
            return List2String(list, settings.sysSeparatorList[0].ToString(),"","");
        }
        public static string List2String(string[] list, string separator,string prefix,string postfix)
        {
            string retStr = "";
            for (int idx = 0; idx < list.Length; idx++)
            {
                retStr += (retStr == "" ? "" : separator) + prefix + list[idx] + postfix;
            }
            return retStr;
        }
        public static string List2String(StringCollection list)
        {
            return List2String(list, common.settings.sysSeparatorList[0].ToString(),"","");
        }
        public static string List2String(StringCollection list, string separator, string prefix, string postfix)
        {
            string tmp = "";
            for (int idx = 0; idx < list.Count; idx++) tmp += (tmp == "" ? "" : separator) + prefix + list[idx] + postfix;
            return tmp;
        }
        public static string List2String(int[] list, string separator)
        {
            return List2String(list, separator, "", "");
        }
        public static string List2String(int[] list, string separator,string prefix,string postfix)
        {
            string tmp = "";
            for (int idx = 0; idx < list.Length; idx++) tmp += (tmp == "" ? "" : separator) + prefix + list[idx].ToString() + postfix;
            return tmp;
        }

        public static decimal String2Decimal(string str)
        {
            decimal d = 0;
            decimal.TryParse(str, out d);
            return d;
        }
        public static int String2Int(string str)
        {
            int d = 0;
            int.TryParse(str, out d);
            return d;
        }

        public static string[] String2List(string str)
        {
            return str.Split(settings.sysSeparatorList, StringSplitOptions.RemoveEmptyEntries);
        }
        public static string[] String2List(string str,string separator)
        {
            return str.Split(new string[]{separator}, StringSplitOptions.RemoveEmptyEntries);
        }

        public static StringCollection String2Collection(string str)
        {
            return String2Collection(str, "", "");
        }
        public static StringCollection String2Collection(string str,string addPrefix,string addPostfix)
        {
            return String2Collection(String2List(str),addPrefix, addPostfix);
        }
        public static StringCollection String2Collection(string[] arr, string prefix, string postfix)
        {
            StringCollection strList = new StringCollection();
            for (int idx = 0; idx < arr.Length; idx++)
            {
                arr[idx] = arr[idx].Trim();
                if (arr[idx].StartsWith(prefix)) arr[idx] = arr[idx].Remove(0,1);
                int lastIdx = arr[idx].LastIndexOf(postfix);
                if (lastIdx >= 0) arr[idx] = arr[idx].Remove(lastIdx, 1);
                strList.Add(arr[idx]);
                //strList.Add(prefix + arr[idx] + postfix);
            }
            return strList;
        }
 
        public static bool InList(string[] list, string item)
        {
            return InList(list, item, false);
        }
        public static bool InList(string[] list, string item, bool force)
        {
            item = item.Trim();
            if (list == null) return true;
            if (force)
            {
                for (int idx = 0; idx < list.Length; idx++)
                {
                    if (item == list[idx]) return true;
                }
            }
            else
            {
                for (int idx = 0; idx < list.Length; idx++)
                {
                    if (item.Contains(list[idx])) return true;
                }
            }
            return false;
        }

        public static string GetHashString(string orgStr)
        {
            orgStr = Hash.MakeHash(orgStr.Trim());
            if (orgStr.Length < Consts.constCharOfHashDirNo) return orgStr;
            return orgStr.Substring(0, Consts.constCharOfHashDirNo);
        }

        public static string ConcatFileName(string fileName1,string fileName2)
        {
            fileName1 = fileName1.Trim();
            fileName2 = fileName2.Trim();
            if (fileName1.Substring(fileName1.Length-1)!="/") fileName1 += "/";
            return fileName1 + fileName2;
        }
    }
    public static class database
    {
        public static string BuidConnectionString(configuration.dbConnectionInfo info)
        {
            string configStr = "Data Source=" + info.serverName.Trim() + ";Initial Catalog=" + info.database.Trim() +
                                ";Persist Security Info=True;User ID=" + info.account.Trim();
            if (info.password.Trim() != "") configStr += ";password=" + info.password.Trim();
            if (info.timeoutInSecs!=0) configStr += ";Connection Timeout=" + info.timeoutInSecs.ToString();
            return configStr;
        }

        public static bool CheckDbConnection(string connectionString)
        {
            string errorMsg = "";
            return CheckDbConnection(connectionString, out errorMsg);
        }

        public static bool CheckDbConnection(string connectionString, out string errorMsg)
        {
            errorMsg = "";
            try
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = connectionString;
                conn.Open(); conn.Close(); conn.Close();
            }
            catch (Exception er)
            {
                errorMsg = er.Message.ToString();
                return false;
            }
            return true;
        }
    }

    public static class fileFuncs
    {
        public enum copyProtocol : int { HTTP, Local};
        private static copyProtocol myProtoUsed = copyProtocol.Local; 

        #region copy file
        private static string myUploadURL = "", myUploadCodeFile = "", myUploadAccount = "", myUploadPass = "";
        private static string myDataDir = ""; //Fullpath

        public static void LocalSetup(string toDir)
        {
            myDataDir = toDir;
            myProtoUsed = copyProtocol.Local;
        }
        public static void HttpSetup(string url, string myCodeFile)
        {
            HttpSetup(url,myCodeFile, "", "");
        }
        public static void HttpSetup(string url,string myCodeFile, string account, string pass)
        {
            myUploadURL = url; myUploadCodeFile = myCodeFile; 
            myUploadAccount = account; myUploadPass = pass;
            myProtoUsed = copyProtocol.HTTP;
        }

        public static string UploadFile(string fileName)
        {
            FileInfo fInfo = new FileInfo(fileName);
            string  toFileName = ShortFileName(fileName);
            return UploadFile(fileName, toFileName);
        }
        public static string UploadFile(string fileName, string toFileName)
        {
            string subDir = system.GetHashString(toFileName);
            switch (myProtoUsed)
            {
                case copyProtocol.HTTP:
                    if (fileName!=toFileName) 
                    {
                        toFileName = system.ConcatFileName(fileFuncs.GetTempPath(),fileFuncs.ShortFileName(toFileName));
                        fileFuncs.FileCopy(fileName, toFileName);  
                    }
                    if (myUploadURL.Trim() == "")
                        system.ThrowException("Please call HttpSetup() to initialize the functions.");
                    System.Net.WebClient client = new System.Net.WebClient();
                    if (myUploadAccount != "") client.Credentials = new System.Net.NetworkCredential(myUploadAccount, myUploadPass);
                    client.UploadFile(myUploadURL + "/" + myUploadCodeFile + "?subDir="+subDir, toFileName);
                    client.Dispose();
                    break;
                case copyProtocol.Local:
                    if (myDataDir.Trim() == "")
                        system.ThrowException("Please call LocalSetup() to initialize the functions.");
                    string toDir = system.ConcatFileName(myDataDir, subDir);
                    if (!Directory.Exists(toDir)) Directory.CreateDirectory(toDir);
                    FileCopy(fileName, system.ConcatFileName(toDir, toFileName));
                    break;
            }
            return system.ConcatFileName(subDir, fileFuncs.ShortFileName(toFileName));
        }
        public static string DownloadFile(string fileName)
        {
            string toFileName = system.ConcatFileName(GetTempPath(), ShortFileName(fileName));
            switch (myProtoUsed)
            {
                case copyProtocol.HTTP:
                    if (myUploadURL.Trim() == "")
                        system.ThrowException("Please call HttpSetup() to initialize the functions.");
                    System.Net.WebClient client = new System.Net.WebClient();
                    if (myUploadAccount != "") client.Credentials = new System.Net.NetworkCredential(myUploadAccount, myUploadPass);
                    client.DownloadFile(myUploadURL + "/" + fileName, toFileName);
                    client.Dispose();
                    break;
                case copyProtocol.Local:
                    if (myDataDir.Trim() == "")
                        system.ThrowException("Please call LocalSetup() to initialize the functions.");
                    string srcFileName = system.ConcatFileName(myDataDir, fileName);
                    FileCopy(srcFileName, toFileName);
                    break;
            }
            return toFileName;
        }

        #endregion

        public static bool FileExist(string fileName)
        {
            return (File.Exists(fileName));
        }
        public static long FileSize(string fileName)
        {
            FileInfo fInfo = new FileInfo(@fileName);
            return fInfo.Length;
        }
        public static string GetFullPath(string fileName)
        {
            if (fileName.Trim() == "") return "";
            return Path.GetFullPath(fileName);
        }
        public static string FileNamePath(string fileName)
        {
            FileInfo fInfo = new FileInfo(@fileName);
            return fInfo.DirectoryName;
        }
        public static string ShortFileName(string fileName)
        {
            FileInfo fInfo = new FileInfo(@fileName);
            return fInfo.Name;
        }
        public static string FileExtension(string fileName)
        {
            FileInfo fInfo = new FileInfo(@fileName);
            return fInfo.Extension;
        }
        public static string FileNameOnly(string fileName)
        {
            FileInfo fInfo = new FileInfo(@fileName);
            return fInfo.Name.Replace(fInfo.Extension,"");
        }

        public static void FileRemove(string fileName)
        {
            if (File.Exists(fileName)) File.Delete(fileName);
        }
        public static void FileCopy(string srcFileName, string dstFileName)
        {
            if (File.Exists(dstFileName)) File.Delete(dstFileName);
            File.Copy(srcFileName, dstFileName);
        }
        public static void FileMove(string srcFileName, string dstFileName)
        {
            if (File.Exists(dstFileName)) File.Delete(dstFileName);
            File.Move(srcFileName, dstFileName);
        }

        public static string GetTempPath()
         {
             return System.IO.Path.GetTempPath().Replace("\\","//");
         }
        public static string MakeFileName(string path,string fileName)
        {
            path = path.Trim();
            if (path.LastIndexOf("\\") == path.Length) path = path.Substring(0, path.Length - 1);
            return path + "\\" + fileName.Trim();
        }

        public static string MakeRelativePath(string rootPath, string fileName)
        {
            if (rootPath.Length > 0 && fileName.StartsWith(rootPath))
            {
                fileName = fileName.Substring(rootPath.Length);
                if (fileName.StartsWith("\\")) fileName = fileName.Substring(1);
            }
            return fileName;
        }
        public static string MakeRelativePath(string fileName)
        {
            string rootPath = system.GetExecuteDirectory();
            if (rootPath.Length > 0 && fileName.StartsWith(rootPath))
            {
                fileName = fileName.Substring(rootPath.Length);
                if (fileName.StartsWith("\\")) fileName = fileName.Substring(1);
            }
            return fileName;
        }

        
        /// <summary>
        /// This function mimic the mail-merge to create a merged text from a template file.
        /// </summary>
        /// <param name="templateFName"> Template file </param>
        /// <param name="tagList"> ArrayList of myKeyValueItem object</param>
        /// <returns></returns>
        public static string GetMergeText(string templateFName, ArrayList tagList)
        {
            myKeyValueItem item;
            string textFile = ReadFile(templateFName);
            int idx = 0;
            while (idx < tagList.Count)
            {
                item = (myKeyValueItem)tagList[idx];
                textFile = textFile.Replace(item.Key, item.Value);
                idx++;
            }
            return textFile;
        }
        public static string ReadFile(string fileName)
        {
            string value = "";
            if (!File.Exists(fileName)) return "";
            StreamReader file = File.OpenText(fileName);
            while (!file.EndOfStream) value += file.ReadLine();
            file.Close();
            return value;
        }
        public static void WriteFile(string text,string fileName)
        {
            System.IO.StreamWriter file = new System.IO.StreamWriter(fileName);
            file.Write(text);
            file.Close();
        }

        public static string GetTempFileName(string ext)
        {
            string fileName = null;
            string tmpPath = fileFuncs.GetTempPath();
            while (true)
            {
                fileName = common.fileFuncs.MakeFileName(tmpPath, system.UniqueString()) + ext;
                if (!fileFuncs.FileExist(fileName)) break;
            }
            return fileName;
        }
    }
    public static class registry
    {
        public static Microsoft.Win32.RegistryKey OpenSubKey(string[] list)
        {
            if (list.Length == 0) return null;
            Microsoft.Win32.RegistryKey pkey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(list[0]);
            Microsoft.Win32.RegistryKey ckey;
            for (int idx = 1; idx < list.Length; idx++)
            {
                ckey = pkey.CreateSubKey(list[idx]);
                pkey.Close(); pkey = ckey;
            }
            return pkey;
        }

        public static Microsoft.Win32.RegistryKey CreateSubKey(Microsoft.Win32.RegistryKey parentKey, string keyName)
        {
            return parentKey.CreateSubKey(keyName);
        }

        public static void SetValue(Microsoft.Win32.RegistryKey key, myKeyValueItem[] list)
        {
            for (int idx = 0; idx < list.Length; idx++) key.SetValue(list[idx].Key, list[idx].Value);
        }
        public static void GetValue(Microsoft.Win32.RegistryKey key, ref myKeyValueItem[] list)
        {
            for (int idx = 0; idx < list.Length; idx++)
            {
                list[idx].Value = (string)key.GetValue(list[idx].Key);
                if (list[idx].Value == null) list[idx].Value = "";
            }
        }
        public static void CloseSubKey(Microsoft.Win32.RegistryKey key)
        {
            key.Close();
        }
    }

    public static class license
    {
        public class myLicenseItem
        {
            public string productCode = "", prodVendorName = "";
            public string companyName = "", companyEmail = "", address = "", phone = "",fax="", serialKey = "";
            public DateTime validToDate = Consts.constNullDate;
            //Management only
            public string createBy = "";
            public DateTime createOn = Consts.constNullDate;

            public hardware.mySysInfo hwInfo = new hardware.mySysInfo();
            public myLicenseItem() { }
            public void Clear() 
            { 
                productCode = ""; prodVendorName = "";
                companyName = ""; companyEmail = ""; address = ""; phone = ""; fax=""; serialKey = "";
                validToDate = Consts.constNullDate;
                hwInfo.Clear();
            }
            public string MakeKey()
            {
                return this.MakeKey(5, 5, "-");
            }
            public string MakeKey(int grouptLen, int termCount, string groupSepa)
            {
                string salt = Hash.MakeHash(this.productCode.Trim(), HashType.RIPEMD160) +
                              Hash.MakeHash(this.companyName.Trim(), HashType.RIPEMD160) +
                              //Hash.MakeHash(this.address.Trim(), HashType.RIPEMD160) +
                              //Hash.MakeHash(this.companyEmail.Trim(), HashType.RIPEMD160) +
                              //Hash.MakeHash(this.validToDate.ToString(), HashType.RIPEMD160) +

                              Hash.MakeHash(this.hwInfo.cpuId, HashType.RIPEMD160) +
                              Hash.MakeHash(this.hwInfo.mainboardId, HashType.RIPEMD160) +
                              Hash.MakeHash(this.hwInfo.biosId, HashType.RIPEMD160) +
                              Hash.MakeHash(this.hwInfo.harddriveId, HashType.RIPEMD160);
                return common.license.GenerateKey(salt);
            }
        }
        public static string GenerateKey(string salt)
        {
            return GenerateKey(salt, 5, 5, "-");
        }
        public static string GenerateKey(string salt, int grouptLen, int termCount, string groupSepa)
        {
            if (!system.isValidCall()) return null;

            int validCharCount = ('Z' - 'A' + 1) + ('9' - '0' + 1);
            char[] validChars = new char[validCharCount];
            int num = 0;
            for (char ch = 'A'; ch <= 'Z'; ch++) validChars[num++] = ch;
            for (char ch = '0'; ch <= '9'; ch++) validChars[num++] = ch;
            string hashKey = Hash.MakeHash(salt.Trim(), HashType.RIPEMD160);
            hashKey = Hash.MakeHash(hashKey);
            while (hashKey.Length < termCount * grouptLen) hashKey += hashKey;

            string retVal = "";
            for (int idx = 0; idx < termCount * grouptLen; idx++)
            {
                num = hashKey[idx] % validCharCount;
                if (idx > 0 && (idx % grouptLen == 0)) retVal += groupSepa;
                retVal += validChars[num];
            }
            return retVal;
        }

        public static bool isSerialOk(myLicenseItem lic)
        {
            return (lic.serialKey == lic.MakeKey());
        }
        public static bool ChecLicence(string prodVendorName, string productCode,string fileName)
        {
            if (common.fileFuncs.FileExist(fileName))
            {
                common.license.myLicenseItem lic = common.license.GetLicence(fileName);
                if (lic == null) return false;
                return ChecLicence(prodVendorName, productCode, lic);
            }
            return false;
        }
        public static bool ChecLicence(string prodVendorName, string productCode, myLicenseItem lic)
        {
            if (lic == null) return false;
            if (!isSerialOk(lic) || (lic.prodVendorName != prodVendorName) || (lic.productCode != productCode)) return false;
            if (lic.validToDate<DateTime.Today) return false;
            return hardware.CheckHwInfo(lic.hwInfo);
        }

        public static StringCollection CompareLicence(myLicenseItem lic1,myLicenseItem lic2)
        {
            StringCollection errorList = new StringCollection();
            if (!isSerialOk(lic1)) errorList.Add("[Sêri 1]");
            if (!isSerialOk(lic2)) errorList.Add("[Sêri 2]");

            if (lic1.productCode != lic2.productCode) errorList.Add("[productCode]");
            if (lic1.prodVendorName != lic2.prodVendorName) errorList.Add("[prodVendorName]");

            if (lic1.companyName != lic2.companyName) errorList.Add("[companyName]");
            if (lic1.companyEmail != lic2.companyEmail) errorList.Add("[companyEmail]");
            if (lic1.address != lic2.address) errorList.Add("[address]");
            if (lic1.fax != lic2.fax) errorList.Add("[fax]");
            if (lic1.phone != lic2.phone) errorList.Add("[phone]");
            if (lic1.serialKey != lic2.serialKey) errorList.Add("[serialKey]");
            if (lic1.validToDate != lic2.validToDate) errorList.Add("[validToDate]");

            if (lic1.hwInfo.cpuId != lic2.hwInfo.cpuId) errorList.Add("[cpuId]");
            if (lic1.hwInfo.biosId != lic2.hwInfo.biosId) errorList.Add("[validToDate]");
            if (lic1.hwInfo.mainboardId != lic2.hwInfo.mainboardId) errorList.Add("[mainboardId]");
            if (lic1.hwInfo.harddriveId != lic2.hwInfo.harddriveId) errorList.Add("[harddriveId]");
            if (lic1.hwInfo.nicMAC != lic2.hwInfo.nicMAC) errorList.Add("[nicMAC]");

            return errorList;
        }

        public static myLicenseItem GetLicence(string fileName)
        {
            System.IO.StreamReader rFile = new System.IO.StreamReader(fileName);
            StringCollection lines = new StringCollection();
            while (!rFile.EndOfStream) lines.Add(rFile.ReadLine());
            rFile.Close();
            return DecryptLicence(lines);
        }
        
        public static void SaveLicence(myLicenseItem lic, string toFileName)
        {
            System.IO.StreamWriter wFile = new System.IO.StreamWriter(toFileName);
            StringCollection lines = EncryptLicence(lic);
            for (int idx = 0; idx < lines.Count; idx++) wFile.WriteLine(lines[idx]);
            wFile.Close();
        }

        private static myLicenseItem _GetLicence(string prodVendorName, string productCode)
        {
            //Create key list to read
            StringCollection lines = EncryptLicence(new myLicenseItem());
            myKeyValueItem[] list = new myKeyValueItem[lines.Count];
            for (int idx = 0; idx < lines.Count; idx++)
                list[idx] = new myKeyValueItem(idx.ToString().Trim(), "");

            Microsoft.Win32.RegistryKey key = registry.OpenSubKey(new string[] { prodVendorName, productCode });
            if (key == null) return null;
            registry.GetValue(key, ref list);
            registry.CloseSubKey(key);
            for (int idx = 0; idx < lines.Count; idx++)
                lines[idx] = list[idx].Value;
            return DecryptLicence(lines);
        }
        private static void _SaveLicence(myLicenseItem lic)
        {
            Microsoft.Win32.RegistryKey key = registry.OpenSubKey(new string[] { lic.prodVendorName, lic.productCode });
            if (key == null) return;

            StringCollection lines = EncryptLicence(lic);
            myKeyValueItem[] list = new myKeyValueItem[lines.Count];
            for (int idx = 0; idx < lines.Count; idx++)
                list[idx] = new myKeyValueItem(idx.ToString().Trim(), lines[idx]);
            registry.SetValue(key, list);
            registry.CloseSubKey(key);
        }

        public static StringCollection EncryptLicence(myLicenseItem lic)
        {
            string tmp;
            StringCollection lines = new StringCollection();

            lines.Add(""); //For check sum
            tmp = cryption.Encrypt(Consts.constVersionLIC); lines.Add(tmp);
            if (lic.prodVendorName == "") tmp = "";
            else tmp = cryption.Encrypt(lic.prodVendorName); 
            lines.Add(tmp);

            if (lic.productCode == "") tmp = "";
            else tmp = cryption.Encrypt(lic.productCode); 
            lines.Add(tmp);

            if (lic.companyName == "") tmp = "";
            else tmp = cryption.Encrypt(lic.companyName); 
            lines.Add(tmp);

            if (lic.address == "") tmp = "";
            else tmp = cryption.Encrypt(lic.address); 
            lines.Add(tmp);

            if (lic.phone == "") tmp = "";
            else tmp = cryption.Encrypt(lic.phone); 
            lines.Add(tmp);

            if (lic.fax == "") tmp = "";
            else tmp = cryption.Encrypt(lic.fax); 
            lines.Add(tmp);

            if (lic.companyEmail == "") tmp = "";
            else tmp = cryption.Encrypt(lic.companyEmail); 
            lines.Add(tmp);

            tmp = cryption.Encrypt(lic.validToDate.ToShortDateString()); 
            lines.Add(tmp);

            if (lic.serialKey == "") tmp = "";
            else tmp = cryption.Encrypt(lic.serialKey); 
            lines.Add(tmp);

            StringCollection hwLines = hardware.EncryptHwInfo(lic.hwInfo);
            for (int idx = 0; idx < hwLines.Count; idx++) lines.Add(hwLines[idx]);

            //Make checkSum
            string checkSum = "";
            for (int idx = 1; idx < lines.Count; idx++) checkSum += lines[idx];
            lines[0] = cryption.Encrypt(Hash.MakeHash(checkSum));
            return lines;
        }
        public static myLicenseItem DecryptLicence(StringCollection lines)
        {
            myLicenseItem lic = new myLicenseItem();
            if (lines.Count != EncryptLicence(lic).Count) return null; 
            //Check checkSum
            string checkSum = "";
            for (int idx = 1; idx < lines.Count; idx++) checkSum += lines[idx];
            if (lines[0] != cryption.Encrypt(Hash.MakeHash(checkSum))) return null;

            //Line[0] : check sum 
            if (cryption.Decrypt(lines[1]) != Consts.constVersionLIC) return null;
            lic.prodVendorName = (lines[2]==""?"":cryption.Decrypt(lines[2]));
            lic.productCode = (lines[3] == "" ? "" : cryption.Decrypt(lines[3]));
            lic.companyName = (lines[4] == "" ? "" : cryption.Decrypt(lines[4]));
            lic.address = (lines[5] == "" ? "" : cryption.Decrypt(lines[5]));
            lic.phone = (lines[6] == "" ? "" : cryption.Decrypt(lines[6]));
            lic.fax = (lines[7] == "" ? "" : cryption.Decrypt(lines[7]));
            lic.companyEmail = (lines[8] == "" ? "" : cryption.Decrypt(lines[8]));

            DateTime dt; 
            if (!DateTime.TryParse(cryption.Decrypt(lines[9]),out dt)) return null;
            lic.validToDate = dt;

            lic.serialKey = (lines[10] == "" ? "" : cryption.Decrypt(lines[10]));

            //Hardware
            StringCollection hwLines = new StringCollection();
            for (int idx = 11; idx < lines.Count; idx++) hwLines.Add(lines[idx]);
            lic.hwInfo = hardware.DecryptHwInfo(hwLines);
            if (lic.hwInfo == null) return null;
            return lic;
        }
    }
    public static class hardware
    {
        public class mySysInfo
        {
            public string cpuId = "", mainboardId = "", biosId = "", harddriveId = "",nicMAC="";
            public void Clear()
            {
                cpuId = ""; mainboardId = ""; biosId = ""; harddriveId = "";
            }
        }

        private static string GetHardwareInfo(string type, string key)
        {
            string[] retVal = GetHardwareInfo(type, new string[] { key });
            if (retVal == null) return null;
            return retVal[0];
        }

        public static bool CheckHwInfo(mySysInfo info)
        {
            mySysInfo curInfo = GetHardwareInfo();
            return (info.cpuId.Trim()=="" || info.cpuId == curInfo.cpuId) &&
                   (info.mainboardId.Trim() == "" || info.mainboardId == curInfo.mainboardId) &&
                   (info.biosId.Trim() == "" || info.biosId == curInfo.biosId) &&
                   (info.harddriveId.Trim() == "" || info.harddriveId == curInfo.harddriveId)&&
                   (info.nicMAC.Trim() == "" || info.nicMAC == curInfo.nicMAC);
        }
        public static mySysInfo GetHardwareInfo()
        {
            string tmp;
            mySysInfo sysInfo = new mySysInfo();
            string[] list = GetHardwareInfo("Win32_processor", new string[]{"ProcessorID","Manufacturer"});
            sysInfo.cpuId = (list == null ? "" : list[0] + " " + list[1]);

            list = GetHardwareInfo("Win32_BaseBoard", new string[] { "SerialNumber", "Manufacturer" });
            sysInfo.mainboardId = (list == null ? "" : list[0] + " " + list[1]);

            sysInfo.harddriveId = "";
            tmp = GetHardwareInfo("Win32_DiskDrive", "Model");
            sysInfo.harddriveId += (tmp == null ? "" : tmp); 
            tmp = GetHardwareInfo("Win32_PhysicalMedia", "SerialNumber");
            sysInfo.harddriveId += (tmp == null ? "" : tmp); 

            //tmp = GetHardwareInfo("Win32_IDEController", "DeviceId");
            //sysInfo.harddriveId += (tmp == null ? "" : tmp);
            //tmp = GetHardwareInfo("Win32_SCSIController", "DeviceId");
            //sysInfo.harddriveId += (tmp == null ? "" : tmp); 
            
            tmp = GetHardwareInfo("Win32_BIOS", "SerialNumber");
            sysInfo.biosId = (tmp == null ? "" : tmp); 

            tmp = GetHardwareInfo("Win32_NetworkAdapterConfiguration", "MacAddress");
            sysInfo.nicMAC = (tmp == null ? "" : tmp); 
            return sysInfo;
        }
        
        public static string[] GetHardwareInfo(string type, string[] keys)
        {
            try
            {
                string[] retVal = new string[keys.Length];
                ManagementObjectCollection mbsList = null;
                ManagementObjectSearcher mbs = new ManagementObjectSearcher("Select * From " + type);
                mbsList = mbs.Get();
                foreach (ManagementObject mo in mbsList)
                {
                    for (int idx = 0; idx < keys.Length; idx++)
                    {
                        retVal[idx] = mo[keys[idx]].ToString().Trim();
                    }
                    return retVal;
                }
                return null;
            }
            catch (Exception er)
            {
                common.errorHandler.lastErrorMessage = er.Message;
                return null;
            }
        }
        public static StringCollection GetAvailableDriveLetters()
        {
            StringCollection letters = new StringCollection();
            //Loop through each and remove it's drive letter from our list
            foreach (DriveInfo drive in DriveInfo.GetDrives())
                letters.Add(drive.Name.Substring(0, 1).ToUpper());
            return letters;
        }

        public static StringCollection EncryptHwInfo(mySysInfo info)
        {
            string tmp;
            StringCollection lines = new StringCollection();

            lines.Add(""); //For check sum
            tmp = cryption.Encrypt(Consts.constVersionHWD); lines.Add(tmp);

            if (info.cpuId == "") tmp = "";
            else tmp = cryption.Encrypt(info.cpuId); 
            lines.Add(tmp);

            if (info.mainboardId == "") tmp = "";
            else tmp = cryption.Encrypt(info.mainboardId); 
            lines.Add(tmp);

            if (info.harddriveId == "") tmp = "";
            else tmp = cryption.Encrypt(info.harddriveId); 
            lines.Add(tmp);

            if (info.biosId == "") tmp = "";
            else tmp = cryption.Encrypt(info.biosId); 
            lines.Add(tmp);

            if (info.nicMAC == "") tmp = "";
            else tmp = cryption.Encrypt(info.nicMAC); 
            lines.Add(tmp);

            //Make checkSum
            string checkSum = "";
            for (int idx = 1; idx < lines.Count; idx++) checkSum += lines[idx];
            lines[0] = cryption.Encrypt(Hash.MakeHash(checkSum));
            return lines;
        }
        public static mySysInfo DecryptHwInfo(StringCollection lines)
        {
            mySysInfo info = new mySysInfo();
            if (lines.Count != EncryptHwInfo(info).Count) return null;
            //Check checkSum
            string checkSum = "";
            for (int idx = 1; idx < lines.Count; idx++) checkSum += lines[idx];
            if (lines[0] != cryption.Encrypt(Hash.MakeHash(checkSum))) return null;

            //Line[0] : check sum 
            if (cryption.Decrypt(lines[1]) != Consts.constVersionHWD) return null;
            info.cpuId = (lines[2]==""?"":cryption.Decrypt(lines[2]));
            info.mainboardId = (lines[3] == "" ? "" : cryption.Decrypt(lines[3]));
            info.harddriveId = (lines[4] == "" ? "" : cryption.Decrypt(lines[4]));
            info.biosId = (lines[5] == "" ? "" : cryption.Decrypt(lines[5]));
            info.nicMAC = (lines[6] == "" ? "" : cryption.Decrypt(lines[6]));
            return info;
        }
        
        public static void SaveHwInfo(mySysInfo info, string toFileName)
        {
            System.IO.StreamWriter wFile = new System.IO.StreamWriter(toFileName);
            StringCollection lines = EncryptHwInfo(info);
            for (int idx = 0; idx < lines.Count; idx++) wFile.WriteLine(lines[idx]);
            wFile.Close();
        }
        public static mySysInfo GetHwInfo(string fileName)
        {
            System.IO.StreamReader rFile = new System.IO.StreamReader(fileName);
            StringCollection lines = new StringCollection();
            while (!rFile.EndOfStream) lines.Add(rFile.ReadLine());
            rFile.Close();
            return DecryptHwInfo(lines);
        }
    }

    public class financial
    {
        public static double EMI(double principalAmt, int noMonth, double yeInterrest)
        {
            double dROI = yeInterrest / (12 * 100); //ROI in formula is rate per conversion period

            //The value of Principal is mentioned as negative as per the functionality of this formula
            // For all arguments, cash paid out (such as deposits to savings) is represented by negative numbers;
            // cash received (such as dividend checks) is represented by positive numbers.
            return Microsoft.VisualBasic.Financial.Pmt(dROI, noMonth, -principalAmt, 0, Microsoft.VisualBasic.DueDate.BegOfPeriod);
        }
    }
}


