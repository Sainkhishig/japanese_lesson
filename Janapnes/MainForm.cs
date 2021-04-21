using System;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Speech.Synthesis;
using System.Globalization;

namespace Janapnes
{
    public partial class MainForm : Form
    {
        string saveName = "";
        List<string> lstHiragana = new List<string> { "あ", "い", "う", "え", "お", "か", "き", "く", "け", "こ", "が", "ぎ", "ぐ", "げ", "ご", "さ", "し", "す", "せ", "そ", "ざ", "じ", "ず", "ぜ", "ぞ", "た", "ち", "つ", "て", "と", "だ", "ぢ", "づ", "で", "ど", "な", "に", "ぬ", "ね", "の", "は", "ひ", "ふ", "へ", "ほ", "ば", "び", "ぶ", "べ", "ぼ", "ぱ", "ぴ", "ぷ", "ぺ", "ぽ", "ま", "み", "む", "め", "も", "や", "ゆ", "よ", "ら", "り", "る", "れ", "ろ", "わ", "を", "ん", "きゃ", "きゅ", "きょ", "ぎゃ", "ぎゅ", "ぎょ", "しゃ", "しゅ", "しょ", "じゃ", "じゅ", "じょ", "ちゃ", "ちゅ", "ちょ", "にゃ", "にゅ", "にょ", "ひゃ", "ひゅ", "ひょ", "びゃ", "びゅ", "びょ", "ぴゃ", "ぴゅ", "ぴょ", "みゃ", "みゅ", "みょ", "りゃ", "りゅ", "りょ" };
        List<string> lstKatakana = new List<string> { "ア", "イ", "ウ", "エ", "オ", "カ", "キ", "ク", "ケ", "コ", "ガ", "ギ", "グ", "ゲ", "ゴ", "サ", "シ", "ス", "セ", "ソ", "ザ", "ジ", "ズ", "ゼ", "ゾ", "タ", "チ", "ツ", "テ", "ト", "ダ", "ヂ", "ヅ", "デ", "ド", "ナ", "ニ", "ヌ", "ネ", "ノ", "ハ", "ヒ", "フ", "ヘ", "ホ", "バ", "ビ", "ブ", "ベ", "ボ", "パ", "ピ", "プ", "ペ", "ポ", "マ", "ミ", "ム", "メ", "モ", "ヤ", "ユ", "ヨ", "ラ", "リ", "ル", "レ", "ロ", "ワ", "ヲ", "ン", "キャ", "キュ", "キョ", "ギャ", "ギュ", "ギョ", "シャ", "シュ", "ショ", "ジャ", "ジュ", "ジョ", "チャ", "チュ", "チョ", "ニャ", "ニュ", "ニョ", "ヒャ", "ヒュ", "ヒョ", "ビャ", "ビュ", "ビョ", "ピャ", "ピュ", "ピョ", "ミャ", "ミュ", "ミョ", "リャ", "リュ", "リョ", "ャ" };
        List<Vocabulary> lstVocabulary = new List<Vocabulary>();
        List<VocabularyJP> lstVocabularyJP = new List<VocabularyJP>();
        Vocabulary currentVocab;
        int currentVocabIndex = 0;
        private int counter = 9;
        SpeechSynthesizer reader;
        [DllImport("winmm.dll")]

        

        private static extern long mciSendString(string command, StringBuilder restring, int ReturnLength, IntPtr callBack);
        public MainForm()
        {
            InitializeComponent();
           
            btnRecord.Click += BtnRecord_Click;
            reader = new SpeechSynthesizer();
            //reader.SelectVoiceByHints(VoiceGender.Female);
            var culture = new CultureInfo("en-gb");
            //var voice = new VoiceInfo();
            //voice.Culture = culture;
            //reader.voice = voice;

            reader.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Adult, 0, culture); 
            reader.StateChanged += Reader_StateChanged;
        }        

        private void BtnRecord_Click(object sender, EventArgs e)
        {
            record();
        }

        
        private void BtnRecordStop_Click(object sender, EventArgs e)
        {
            recordStop("hello");
        }

       private void button1_Click(object sender, EventArgs e)
        {
            lstVocabulary = new List<Vocabulary>();
            lstVocabularyJP = new List<VocabularyJP>();
            if (chkEnglish.Checked)
                excel();
            else
                excelJp();
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
        }

        private void excel()
        {
            string wordMain = "";
            try
            {
                string fname = "";
                OpenFileDialog fdlg = new OpenFileDialog();
                fdlg.Title = "Excel File Dialog";
                fdlg.InitialDirectory = @"c:\";
                fdlg.Filter = "All files (*.*)|*.*|All files (*.*)|*.*";
                fdlg.FilterIndex = 2;
                fdlg.RestoreDirectory = true;
                if (fdlg.ShowDialog() == DialogResult.OK)
                {
                    fname = fdlg.FileName;
                    saveName = fname;
                }


                Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(fname);
                Microsoft.Office.Interop.Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
                Microsoft.Office.Interop.Excel.Range xlRange = xlWorksheet.UsedRange;
                int rCnt;
                int cCnt;
                int rw = 0;
                int cl = 0;

                rw = xlRange.Rows.Count;
                cl = xlRange.Columns.Count;
                string str;

                for (rCnt = (int)startNo.Value; rCnt <= (int)endNo.Value; rCnt++)
                {
                    string word = "" + ((xlRange.Cells[rCnt, 2] as Microsoft.Office.Interop.Excel.Range).Value2) + "";
                    string translation = "" + ((xlRange.Cells[rCnt, 3] as Microsoft.Office.Interop.Excel.Range).Value2) + "";
                    string translationVerb = "" + ((xlRange.Cells[rCnt, 4] as Microsoft.Office.Interop.Excel.Range).Value2) + "";
                    string inOtherWord = "" + ((xlRange.Cells[rCnt, 5] as Microsoft.Office.Interop.Excel.Range).Value2) + "";

                    lstVocabulary.Add(new Vocabulary(word, translation, translationVerb, inOtherWord));
                    //for (cCnt = 1; cCnt <= cl; cCnt++)
                    //{       
                    //    str = "" + ((xlRange.Cells[rCnt, cCnt] as Microsoft.Office.Interop.Excel.Range).Value2) + "";
                    //}
                }

                //cleanup  
                GC.Collect();
                GC.WaitForPendingFinalizers();

                //release com objects to fully kill excel process from running in the background  
                Marshal.ReleaseComObject(xlRange);
                Marshal.ReleaseComObject(xlWorksheet);

                //close and release  
                xlWorkbook.Close();
                Marshal.ReleaseComObject(xlWorkbook);

                //quit and release  
                xlApp.Quit();
                Marshal.ReleaseComObject(xlApp);
                if (chkRecord.Checked)
                {
                    readAndRecord();
                }                    
                else
                    notify();
            }
            catch (Exception ex){
                MessageBox.Show("Error; " + wordMain);
            }
        }
        
        private void readAndRecord()
        {

            //foreach(Vocabulary voc in lstVocabulary)
            //{
            //    reader.SetOutputToWaveFile(@"c:\\ari\\" + voc.word + "En.wav");
            //}

            if (lstVocabulary.Count > currentVocabIndex)
            {
                StringBuilder bldr = new StringBuilder();
                
                currentVocab = lstVocabulary[currentVocabIndex];
                bldr.AppendLine(currentVocab.word + ":");
                bldr.AppendLine(currentVocab.translation);
                bldr.AppendLine(currentVocab.translationVerb);
                txTranslation.Text = bldr.ToString();
                counter = 3;
                //reader.SetOutputToWaveFile(@"c:\\ari\\" + currentVocab.word + "En.wav");
                reader.Speak(currentVocab.word);
            }
        }
        private void Reader_StateChanged(object sender, StateChangedEventArgs e)
        {
            if (reader.State != SynthesizerState.Speaking)
            {
                record();
                StartTime();
            }
        }

        private void record()
        {
            mciSendString("open new Type waveaudio alias recsound", null, 0, IntPtr.Zero);
            mciSendString("record recsound", null, 0, IntPtr.Zero);
            btnRecordStop.Click += BtnRecordStop_Click;
        }

        private bool recordStop(string word)
        {
            mciSendString("save recsound c:\\ari\\" + word + ".wav", null, 0, IntPtr.Zero);
            mciSendString("close recsound", null, 0, IntPtr.Zero);
            return true;
        }
        private void StartTime()
        {
            timer1 = new System.Windows.Forms.Timer();
            timer1.Tick += new EventHandler(timer_Tick);
            timer1.Interval = 1000; // 1 second
            timer1.Start();
            lblCountDown.Text = counter.ToString();
        }

        void timer_Tick(object sender, EventArgs e)
        {
           
            if (counter == 0)
            {
                currentVocabIndex++;
                if (recordStop(currentVocab.word))
                {
                    readAndRecord();
                }
                timer1.Stop();
            }
            else
            {
                lblCountDown.Text = counter.ToString();
                counter--;
            }
        }

        private void excelJp()
        {
            string wordMain = "";
            try
            {
                string fname = "";
                OpenFileDialog fdlg = new OpenFileDialog();
                fdlg.Title = "Excel File Dialog";
                fdlg.InitialDirectory = @"c:\";
                fdlg.Filter = "All files (*.*)|*.*|All files (*.*)|*.*";
                fdlg.FilterIndex = 2;
                fdlg.RestoreDirectory = true;
                if (fdlg.ShowDialog() == DialogResult.OK)
                {
                    fname = fdlg.FileName;
                    saveName = fname;
                }

                Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(fname);
                Microsoft.Office.Interop.Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
                Microsoft.Office.Interop.Excel.Range xlRange = xlWorksheet.UsedRange;
                int rCnt;
                int rw = 0;
                int cl = 0;

                rw = xlRange.Rows.Count;
                cl = xlRange.Columns.Count;
                string str;

                for (rCnt = 1; rCnt <= rw; rCnt++)
                {
                    string kanji = "" + ((xlRange.Cells[rCnt, 2] as Microsoft.Office.Interop.Excel.Range).Value2) + "";
                    string translation = "" + ((xlRange.Cells[rCnt, 5] as Microsoft.Office.Interop.Excel.Range).Value2) + "";
                    string kana = "" + ((xlRange.Cells[rCnt, 3] as Microsoft.Office.Interop.Excel.Range).Value2) + "";
                    string gana = "" + ((xlRange.Cells[rCnt, 4] as Microsoft.Office.Interop.Excel.Range).Value2) + "";

                    lstVocabularyJP.Add(new VocabularyJP(kanji, translation, kana, gana));
                }

                //cleanup  
                GC.Collect();
                GC.WaitForPendingFinalizers();

                //release com objects to fully kill excel process from running in the background  
                Marshal.ReleaseComObject(xlRange);
                Marshal.ReleaseComObject(xlWorksheet);

                //close and release  
                xlWorkbook.Close();
                Marshal.ReleaseComObject(xlWorkbook);

                //quit and release  
                xlApp.Quit();
                Marshal.ReleaseComObject(xlApp);

                notifyJP();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error; " + wordMain);
            }
        }
        
        private void pdfToExcel()
        {
            string wordMain = "";
            try
            {
                
                string fname = "";
                OpenFileDialog fdlg = new OpenFileDialog();
                fdlg.Title = "Excel File Dialog";
                fdlg.InitialDirectory = @"c:\";
                fdlg.Filter = "All files (*.*)|*.*|All files (*.*)|*.*";
                fdlg.FilterIndex = 2;
                fdlg.RestoreDirectory = true;
                if (fdlg.ShowDialog() == DialogResult.OK)
                {
                    fname = fdlg.FileName;
                    saveName = fname;
                }


                Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(fname);
                Microsoft.Office.Interop.Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
                Microsoft.Office.Interop.Excel.Range xlRange = xlWorksheet.UsedRange;
                int rCnt;
                int rw = 0;
                int cl = 0;

                rw = xlRange.Rows.Count;
                cl = xlRange.Columns.Count;
                string str;

                VocabularyJP voc = new VocabularyJP();
                string kanaWord = "";
                string ganaWord = "";
                string translation = "";


                for (rCnt = 1; rCnt <= rw; rCnt++)
                {
                    string wordJP = "" + ((xlRange.Cells[rCnt, 1] as Microsoft.Office.Interop.Excel.Range).Value2) + "";
                    if (string.IsNullOrEmpty(wordJP))
                        continue;
                    string[] allData = Regex.Split(wordJP, " ");

                    foreach (string checkWord in allData)
                    {
                        wordMain = checkWord;
                        bool isNotNumbers = Regex.IsMatch(checkWord, @"^[^0-9]+$");
                        if (!isNotNumbers)
                        {
                            if (!string.IsNullOrEmpty(translation))
                            {
                                if (!string.IsNullOrEmpty(voc.num))
                                {
                                    voc.kana = kanaWord;
                                    voc.gana = ganaWord;
                                    voc.translation = translation;
                                    lstVocabularyJP.Add(voc);
                                }

                                voc = new VocabularyJP();
                                kanaWord = ganaWord = translation = "";
                            }
                        }

                        if ("-".Equals(checkWord))
                        {
                            if (string.IsNullOrEmpty(ganaWord))
                                kanaWord += " " + checkWord;
                            else
                                ganaWord += " " + checkWord;

                            continue;
                        }

                        string withoutComma = checkWord.Replace(",", "");
                        withoutComma = withoutComma.Replace("-", "");

                        char[] byChar = withoutComma.ToCharArray();
                        if (byChar.Length == 0)
                            continue;

                        if (lstHiragana.Contains(byChar[0].ToString()))
                        {
                            ganaWord += " " + checkWord;
                        }
                        else if (lstKatakana.Contains(byChar[0].ToString()))
                        {
                            kanaWord += " " + checkWord;
                        }
                        else if (!Regex.IsMatch(byChar[0].ToString(), @"\P{IsCyrillic}"))
                        {
                            translation += " " + checkWord;
                            // there are only cyrillic characters in the string
                        }
                        else
                        {
                            if (isNotNumbers)
                                voc.kanji = checkWord;
                            else if (allData[0].Equals(checkWord))
                                voc.num = checkWord;
                            else
                            {
                                translation = checkWord;
                            }
                        }
                    }
                    if (rCnt == rw)
                    {
                        if (!string.IsNullOrEmpty(translation))
                        {
                            if (!string.IsNullOrEmpty(voc.num))
                            {
                                voc.kana = kanaWord;
                                voc.gana = ganaWord;
                                voc.translation = translation;
                                lstVocabularyJP.Add(voc);
                            }
                        }
                    }
                }

                //cleanup  
                GC.Collect();
                GC.WaitForPendingFinalizers();

                //release com objects to fully kill excel process from running in the background  
                Marshal.ReleaseComObject(xlRange);
                Marshal.ReleaseComObject(xlWorksheet);

                //close and release  
                xlWorkbook.Close();
                Marshal.ReleaseComObject(xlWorkbook);

                //quit and release  
                xlApp.Quit();
                Marshal.ReleaseComObject(xlApp);


                writeExcel();
                //notify();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error; " + wordMain);
            }
        }

        private void writeExcel()
        {
            Microsoft.Office.Interop.Excel.Application oXL;
            Microsoft.Office.Interop.Excel._Workbook oWB;
            Microsoft.Office.Interop.Excel._Worksheet oSheet;
            Microsoft.Office.Interop.Excel.Range oRng;
            object misvalue = System.Reflection.Missing.Value;
            try
            {
                //Start Excel and get Application object.
                oXL = new Microsoft.Office.Interop.Excel.Application();
                oXL.Visible = false;

                //Get a new workbook.
                oWB = (Microsoft.Office.Interop.Excel._Workbook)(oXL.Workbooks.Add(""));
                oSheet = (Microsoft.Office.Interop.Excel._Worksheet)oWB.ActiveSheet;

                //Add table headers going cell by cell.
                oSheet.Cells[1, 1] = "No";
                oSheet.Cells[1, 2] = "ханз";
                oSheet.Cells[1, 3] = "он";
                oSheet.Cells[1, 4] = "күн";
                oSheet.Cells[1, 4] = "утга";

                //Format A1:D1 as bold, vertical alignment = center.
                oSheet.get_Range("A1", "E1").Font.Bold = true;
                oSheet.get_Range("A1", "E1").VerticalAlignment =
                    Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;

                int i = 0;
                foreach (VocabularyJP jpVoc in lstVocabularyJP)
                {
                    i++;
                    oSheet.Cells[i, 1] = jpVoc.num;
                    oSheet.Cells[i, 2] = jpVoc.kanji;
                    oSheet.Cells[i, 3] = jpVoc.kana;
                    oSheet.Cells[i, 4] = jpVoc.gana;
                    oSheet.Cells[i, 5] = jpVoc.translation;
                }

                //AutoFit columns A:D.
                oRng = oSheet.get_Range("A1", "D1");
                oRng.EntireColumn.AutoFit();

                oXL.Visible = false;
                oXL.UserControl = false;

                oWB.SaveAs("c:\\test\\n5kanji.xls", Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing,
                    false, false, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

                oWB.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("aldaa");
            }
            finally {
                MessageBox.Show("amjilttai duuslaa:>>"+saveName);
            }
        }

        private void notify() {
            int start = (int)startNo.Value;
            int end = (int)endNo.Value;
            end = end == 0 ? lstVocabulary.Count : end;
            List<Vocabulary> lstLearning = lstVocabulary.GetRange(start, end - start);
            for (int i = 0; i <= nmFrequency.Value; i++)
            {
                foreach (Vocabulary vocabulary in lstLearning)
                {
                    StringBuilder strBuilder = new StringBuilder();
                    strBuilder.AppendLine(vocabulary.word);
                    strBuilder.AppendLine("* " + vocabulary.translation);
                    strBuilder.AppendLine("* " + vocabulary.translationVerb);
                    strBuilder.AppendLine("* " + vocabulary.inOtherword);
                    string balloon = strBuilder.ToString();

                    var notification = new System.Windows.Forms.NotifyIcon()
                    {
                        Visible = true,
                        Icon = System.Drawing.SystemIcons.Information,
                        BalloonTipText = balloon,
                    };
                    
                    notification.ShowBalloonTip(5000);
                    Thread.Sleep(10000);
                    notification.Dispose();
                };
            }
        }
        
        private void notifyJP()
        {
            int start = (int)startNo.Value;
            int end = (int)endNo.Value;
            end = end == 0 ? lstVocabulary.Count : end;
            List<VocabularyJP> lstLearning = lstVocabularyJP.GetRange(start, end - start);
            for (int i = 0; i <= nmFrequency.Value; i++)
            {
                foreach (VocabularyJP vocabulary in lstLearning)
                {
                    StringBuilder strBuilder = new StringBuilder();
                    strBuilder.AppendLine(vocabulary.kanji);
                    strBuilder.AppendLine("* " + vocabulary.translation);
                    strBuilder.AppendLine("* " + vocabulary.kana);
                    strBuilder.AppendLine("* " + vocabulary.gana);
                    string balloon = strBuilder.ToString();

                    var notification = new System.Windows.Forms.NotifyIcon()
                    {
                        Visible = true,
                        Icon = System.Drawing.SystemIcons.Information,
                        // optional - BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info,
                        // optional - BalloonTipTitle = "My Title",
                        BalloonTipText = balloon,
                    };

                    // Display for 5 seconds.
                    notification.ShowBalloonTip(5000);
                    Thread.Sleep(10000);

                    notification.Dispose();
                };
            }
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            if (chkEnglish.Checked)
                notify();
            else
                notifyJP();
        }
    }
}

public class Vocabulary
{
    public string word { get; set; }
    public string translation { get; set; }
    public string translationVerb { get; set; }
    public string inOtherword { get; set; }
    public Vocabulary() { }

    public Vocabulary(string word, string translation, string translationVerb, string inOtherWord)
    {
        this.word = word;
        this.translation = translation;
        this.translationVerb = translationVerb;
        this.inOtherword = inOtherWord;
    }
}

public class VocabularyJP
{
    public string num { get; set; }
    public string kanji { get; set; }
    public string kana { get; set; }
    public string gana { get; set; }
    public string translation { get; set; }
    public VocabularyJP() { }
    public VocabularyJP(string kanji, string translation, string kana, string gana)
    {
        this.kanji = kanji;
        this.translation = translation;
        this.kana = kana;
        this.gana = gana;
    }
}
