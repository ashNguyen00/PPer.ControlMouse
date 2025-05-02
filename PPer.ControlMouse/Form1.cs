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
using Gma.System.MouseKeyHook;
using System.Reflection.Emit;

namespace PPer.ControlMouse
{
    public partial class Form1 : Form
    {
        public enum run_mode
        {
            auto,
            manual
        }
        private Point mouseLocation;
        private Point mouseLocSelected;
        private static IKeyboardMouseEvents m_globalHook;
        private static object lockClick = new object();
        private string pathConf = "binConf.bin";
        private Dictionary<string, Point> m_keyList = new Dictionary<string, Point>();


        [DllImport("user32.dll")]
        public static extern bool SetCursorPos(int X, int Y);

        [DllImport("user32.dll")]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, UIntPtr dwExtraInfo);

        const uint MOUSEEVENTF_LEFTDOWN = 0x0002;
        const uint MOUSEEVENTF_LEFTUP = 0x0004;
        const uint MOUSEEVENTF_RIGHTDOWN = 0x0008;
        const uint MOUSEEVENTF_RIGHTUP = 0x0010;
        private bool useClick = false;
        public void MouseLeftClick(int x, int y)
        {
            if (useClick == true) return;
            useClick = true;

            SetCursorPos(x, y);
            mouse_event(MOUSEEVENTF_LEFTDOWN, (uint)x, (uint)y, 0, UIntPtr.Zero);
            Thread.Sleep(5);
            mouse_event(MOUSEEVENTF_LEFTUP, (uint)x, (uint)y, 0, UIntPtr.Zero);
            useClick = false;
        }

        public void MouseRightClick(int x, int y)
        {
            SetCursorPos(x, y);
            mouse_event(MOUSEEVENTF_RIGHTDOWN, (uint)x, (uint)y, 0, UIntPtr.Zero);
            mouse_event(MOUSEEVENTF_RIGHTUP, (uint)x, (uint)y, 0, UIntPtr.Zero);
        }

        public void MouseLeftDown(int x, int y)
        {
            SetCursorPos(x, y);
            mouse_event(MOUSEEVENTF_LEFTDOWN, (uint)x, (uint)y, 0, UIntPtr.Zero);
        }

        public void MouseLeftUp(int x, int y)
        {
            SetCursorPos(x, y);
            mouse_event(MOUSEEVENTF_LEFTUP, (uint)x, (uint)y, 0, UIntPtr.Zero);
        }

        public static void MouseRightDown(int x, int y)
        {
            SetCursorPos(x, y);
            mouse_event(MOUSEEVENTF_RIGHTDOWN, (uint)x, (uint)y, 0, UIntPtr.Zero);
        }

        public static void MouseRightUp(int x, int y)
        {
            SetCursorPos(x, y);
            mouse_event(MOUSEEVENTF_RIGHTUP, (uint)x, (uint)y, 0, UIntPtr.Zero);
        }


        public static ToolStripTextBox txtKeySel;
        public static ToolStripTextBox txtPosSel; 
 
        public Form1()
        {

            InitializeComponent();
            this.TopLevel = true;
            txtKeySel = txtKeySelected;
            txtPosSel = txtPosSelected;
            string[] listNames = Enum.GetNames(typeof(run_mode)).ToArray();

            cbbRunMode.Items.AddRange(listNames);
            cbbRunMode.SelectedIndex = 0;
            m_globalHook = Hook.GlobalEvents();
            m_globalHook.KeyDown += GlobalHookKeyDown;
            
            m_globalHook.MouseDown += GlobalHookMouseDown;
            m_globalHook.MouseUp += GlobalHookMouseUp;
            m_globalHook.MouseClick += GlobalHookMouseClick;
            //m_globalHook.MouseMove += GlobalHookMouseMove;
            Console.WriteLine("Listening for global key presses. Press ESC to exit...");

            this.mousePosTimer.Start();
            deserialize();
            ReloadButtons();
        }
        // Xử lý sự kiện nhấn chuột
        private void GlobalHookMouseDown(object sender, MouseEventArgs e)
        {
            //txtKeySel.Text = $"Mouse Down at: {e.Location} | Button: {e.Button}";
        }

        // Xử lý sự kiện thả chuột
        private void GlobalHookMouseUp(object sender, MouseEventArgs e)
        {
            //txtKeySel.Text = $"Mouse Up at: {e.Location} | Button: {e.Button}";
        }
        private void GlobalHookMouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) { }
            //txtKeySel.Text = $"{e.Location}";
            else
            {
                mouseLocSelected = e.Location;
                txtPosSel.Text = $"{e.Location}";
            }

        }

        // Xử lý sự kiện di chuyển chuột
        private void GlobalHookMouseMove(object sender, MouseEventArgs e)
        {
            txtKeySel.Text = $"Mouse Move at: {e.Location}";
        }

        private object lockSetMouse = new object();
        private void GlobalHookKeyDown(object sender, KeyEventArgs e)
        {
            lock (lockSetMouse)
            {
                if (cbbRunMode.Text == run_mode.auto.ToString())
                {
                    if (m_keyList.ContainsKey(e.KeyCode.ToString()))
                    {
                        int _x = m_keyList[e.KeyCode.ToString()].X;
                        int _y = m_keyList[e.KeyCode.ToString()].Y;
                        MouseLeftClick(_x, _y);
                        // Click chuột trái
                        //mouse_event(MOUSEEVENTF_LEFTDOWN, (uint)_x, (uint)_y, 0, UIntPtr.Zero);
                        //mouse_event(MOUSEEVENTF_LEFTUP, (uint)_x, (uint)_y, 0, UIntPtr.Zero);
                        Thread.Sleep(50);

                    }
                }

            }
            Console.WriteLine($"Key pressed: {e.KeyCode}");
            txtKeySel.Text = e.KeyCode.ToString();
            
        }

        private void actionControl(string key)
        {
            Keys action = (Keys)Enum.Parse(typeof(Keys), key);
        }

        private void btnEditPos_Click(object sender, EventArgs e)
        {

            string _k = txtKeySel.Text;
            string _p = txtPosSel.Text;
            if (_k == "")
            {
                MessageBox.Show("Vui lòng chọn phím trước khi ADD");
                return;
            }
            if (txtPosSel.Text == "")
            {
                MessageBox.Show("Vui lòng chọn tọa độ lưu trước. \nDi chuột đến vị trí lưu và nhấn chuột phải để lưu tọa độ.");
                return;
            }
            bool existBtn = false;
            foreach (string key in m_keyList.Keys)
            {
                if (key.StartsWith(_k) == true)
                {
                    existBtn = true;
                    break;
                }
            }
            if (existBtn == false)
            {
                MessageBox.Show("Phím chưa được tạo. Vui lòng tạo phím mới.");
                return;
            }
            m_keyList[_k] = mouseLocSelected;
        }

        private void btnAddNewPos_Click(object sender, EventArgs e)
        {
            string _k = txtKeySel.Text;
            string _p = txtPosSel.Text;

            if (_k == "")
            {
                MessageBox.Show("Vui lòng chọn phím lưu trước");
                return;
            }
            if (_p == "")
            {
                MessageBox.Show("Vui lòng chọn tọa độ lưu trước. \nDi chuột đến vị trí lưu và nhấn chuột phải để lưu tọa độ.");
                return;
            }
            foreach (string key in m_keyList.Keys)
            {
                if (key.StartsWith(_k) == true)
                {
                    MessageBox.Show("Vị trí đã được chọn trước đó.\nNếu muốn update tọa độ thì chọn Edit.");
                    return;
                }
            }
            if (m_keyList.Keys.Contains(encodeKeyValue(_k, mouseLocSelected)) == true)
            {
                MessageBox.Show("Vị trí đã được chọn trước đó");
                return;
            }
            m_keyList[_k] = mouseLocSelected;
            addNewButton(_k);
        }

        private void addNewButton(string txtVal)
        {
            Button btn = new System.Windows.Forms.Button();
            this.panel1.Controls.Add(btn);
            btn.Dock = System.Windows.Forms.DockStyle.Left;
            btn.Location = new System.Drawing.Point(375, 0);
            btn.Name = txtVal;
            btn.Size = new System.Drawing.Size(75, 24);
            btn.TabIndex = 5;
            btn.Text = txtVal;
            btn.Click += btnClick;
            btn.UseVisualStyleBackColor = true;
        }

        private void RemoveButton(string txtVal)
        {
            Control btn = this.panel1.Controls[txtVal];
            if (btn != null && btn is Button)
            {
                this.panel1.Controls.Remove(btn);
                btn.Dispose(); // Giải phóng tài nguyên
            }
        }
        private void ReloadButtons()
        {
            lock (this.panel1.Controls)
            {
                this.panel1.Controls.Clear();
                
                foreach (string kList in m_keyList.Keys)
                {
                    addNewButton(kList);
                }
                GC.Collect();
            }

        }

        private void btnClick(object sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                string name = btn.Text;
                string text = btn.Text;
                Console.WriteLine($"name: {name} | text: {m_keyList[btn.Text]}");

                DialogResult result = MessageBox.Show(
                    $"Phím - {name}: {m_keyList[btn.Text]}.\n" +
                    $"Bạn có muốn xóa phím không?",
                    "Xác nhận",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question
                );
                if (result == DialogResult.OK)
                {
                    m_keyList.Remove(text);
                    RemoveButton(text);
                }
                // Thực hiện hành động click chuột tại vị trí po
            }
        }

        private void mousePosTimer_Tick(object sender, EventArgs e)
        {
            mouseLocation = Cursor.Position;
            this.Text = "Mouse Position: " + mouseLocation.ToString();
        }

    


        private void toolStripButton2_Click(object sender, EventArgs e)
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

            Console.WriteLine($"Binary Data: {pathConf}" + BitConverter.ToString(binaryData));
        }
        private void deserialize()
        {

            // Đọc
            byte[] bytes = File.ReadAllBytes(pathConf);

            // Giải mã lại từ byte[] (nhị phân) thành JSON string
            string jsonDecoded = System.Text.Encoding.UTF8.GetString(bytes);
            Console.WriteLine("Decoded JSON: " + jsonDecoded);

            // Deserialize JSON string thành List<string>
            m_keyList = JsonConvert.DeserializeObject<Dictionary<string, Point>>(jsonDecoded);
            Console.WriteLine("Deserialized List: " + string.Join(", ", m_keyList));

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            serialize();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            deserialize();
            ReloadButtons();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("" +
                "1. mouse right click to change mouse position. \r\n" +
                "2. press any keypress to set \r\n" +
                "3. features: add new, edit old, delete old, save, reload from file\r\n" +
                " - click chuột phải để điền tọa độ của chuột\r\n" +
                " - nhấn phím muốn cài đặt để control\r\n" +
                " - nhấn dấu cộng để lưu\r\n" +
                " - nhấn phím cạnh dấu cộng để sửa phím đã chọn ở bước trên\r\n" +
                " - khi có nút đã lưu bên dưới click vào đó để xóa phím." +
                " - save và load config từ 2 nút bên tay phải." +
                "");
        }
    }
}
