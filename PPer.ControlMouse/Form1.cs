using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PPer.ControlMouse
{
    public partial class Form1 : Form
    {
        private Point mouseLocation;
        private const int WH_MOUSE_LL = 14;
        private const int WH_KEYBOARD_LL = 13;
        const uint MOUSEEVENTF_LEFTDOWN = 0x02;
        const uint MOUSEEVENTF_LEFTUP = 0x04;
        private const int WM_KEYDOWN = 0x0100;
        public static ToolStripTextBox txtKeySel;
        public static ToolStripTextBox txtPosSel;
        private static LowLevelKeyboardProc _keyboardProc = KeyboardHookCallback;
        private static LowLevelKeyboardProc _keyboardProc = KeyboardHookCallback;
        private List<string> m_keyList = new List<string>();
        private static IntPtr _keyboardHookID = IntPtr.Zero;
        private string pathConf = "binConf.bin";
        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);
        private delegate IntPtr MouseProc(int nCode, IntPtr wParam, IntPtr lParam);


        // Hàm gọi WinAPI để click chuột
        [DllImport("user32.dll")]
        static extern bool SetCursorPos(int X, int Y);
        [DllImport("user32.dll")]
        static extern void mouse_event(uint dwFlags, int dx, int dy, uint dwData, UIntPtr dwExtraInfo);

        [DllImport("user32.dll")]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn,
            IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll")]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll")]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode,
            IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll")]
        private static extern IntPtr GetModuleHandle(string lpModuleName);
        public Form1()
        {
            InitializeComponent();
            txtKeySel = txtKeySelected;
            txtPosSel = txtPosSelected;
            this.mousePosTimer.Start();
            _keyboardHookID = SetKeyboardHook(_keyboardProc);
        }

        private void btnAddNewPos_Click(object sender, EventArgs e)
        {
            if (txtKeySel.Text == "")
            {
                MessageBox.Show("Vui lòng chọn Key trước khi click chuột");
                return;
            }
            if (txtKeySel.Text == "")
            {
                MessageBox.Show("Vui lòng chọn Key trước khi click chuột");
                return;
            }
            if (m_keyList.Contains(encodeKeyValue(txtKeySel.Text, mouseLocation)) == true)
            {
                MessageBox.Show("Vị trí đã được chọn trước đó");
                return;
            }
            m_keyList.Add(encodeKeyValue(txtKeySel.Text, mouseLocation));
        }

        private void btnSelectPos_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void btnSelectPos_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void mousePosTimer_Tick(object sender, EventArgs e)
        {
            mouseLocation = Cursor.Position;
            this.Text = "Mouse Position: " + mouseLocation.ToString();
        }
        private static IntPtr SetKeyboardHook(LowLevelKeyboardProc proc)
        {
            using (var curProcess = Process.GetCurrentProcess())
            using (var curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc, GetModuleHandle(curModule.ModuleName), 0);
            }
        }
        private static IntPtr SetMouseHook(MousePro proc)
        {
            using (var curProcess = Process.GetCurrentProcess())
            using (var curModule = curProcess.MainModule)
            {

                // Cài đặt hook khi ứng dụng bắt đầu
                moupr = new MouseProc(MouseHookProc);
                _mouseHookHandle = SetWindowsHookEx(WH_MOUSE_LL, _mouseProc, IntPtr.Zero, 0);
            }
        }
        private IntPtr MouseHookProc(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0)
            {
                // Nếu chuột được click trái
                if (wParam == (IntPtr)WM_LBUTTONDOWN)
                {
                    Console.WriteLine("Chuột trái đã được nhấn");
                }
                // Nếu chuột được click phải
                else if (wParam == (IntPtr)WM_RBUTTONDOWN)
                {
                    Console.WriteLine("Chuột phải đã được nhấn");
                }
            }

            // Chuyển tiếp sự kiện cho hook tiếp theo trong chuỗi
            return CallNextHookEx(_mouseHookHandle, nCode, wParam, lParam);
        }
        private static IntPtr KeyboardHookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
            {
                int vkCode = Marshal.ReadInt32(lParam);
                string keyName = ((Keys)vkCode).ToString();
                Console.WriteLine($"Bạn nhấn phím: {keyName}");
                txtKeySel.Text = keyName;
                // Có thể ghi log vào file, hiển thị, xử lý tùy ý
            }
            return CallNextHookEx(_keyboardHookID, nCode, wParam, lParam);
        }
        public void DoMouseClick(int x, int y)
        {
            SetCursorPos(x, y); // Đưa chuột tới vị trí cần click
            mouse_event(MOUSEEVENTF_LEFTDOWN, x, y, 0, UIntPtr.Zero); // Nhấn chuột trái
            mouse_event(MOUSEEVENTF_LEFTUP, x, y, 0, UIntPtr.Zero);   // Nhả chuột trái
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private string encodeKeyValue(string ke, Point po)
        {
            string pos = $"{ke}_0_{po.X}_0_{po.Y}";
            return pos;
        }
        private (string, Point) decodeKeyValue(string keyVal)
        {
            string[] pos = keyVal.Split(new string[] { "_0_" }, StringSplitOptions.None);
            string key = pos[0];
            int x = int.Parse(pos[1]);
            int y = int.Parse(pos[2]);
            Point po = new Point(x, y);
            return (key, po);
        }
        private void serialize()
        {
            // Serialize List<string> thành JSON string
            string json = JsonConvert.SerializeObject(m_keyList);
            Console.WriteLine("Serialized JSON: " + json);

            // Mã hóa thành byte[] (nhị phân) từ JSON
            byte[] binaryData = System.Text.Encoding.UTF8.GetBytes(json);

            File.WriteAllBytes(pathConf, binaryData);

            Console.WriteLine("Binary Data: " + BitConverter.ToString(binaryData));
        }
        private void deserialize(string path)
        {

            // Đọc
            byte[] bytes = File.ReadAllBytes(pathConf);

            // Giải mã lại từ byte[] (nhị phân) thành JSON string
            string jsonDecoded = System.Text.Encoding.UTF8.GetString(bytes);
            Console.WriteLine("Decoded JSON: " + jsonDecoded);

            // Deserialize JSON string thành List<string>
            m_keyList = JsonConvert.DeserializeObject<List<string>>(jsonDecoded);
            Console.WriteLine("Deserialized List: " + string.Join(", ", m_keyList));
        }
    }
}
