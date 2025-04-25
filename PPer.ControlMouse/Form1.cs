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
        private Point mouseLocation;
        private Point mouseLocSelected;
        private static IKeyboardMouseEvents m_globalHook;
        private static object lockClick = new object();
        private string pathConf = "binConf.bin";
        private Dictionary<string, Point> m_keyList = new Dictionary<string, Point>();

        public static ToolStripTextBox txtKeySel;
        public static ToolStripTextBox txtPosSel; 
        private void updateCBBWaitTimer()
        {
            cbbWaitTimer.Items.Clear();
            for (int i=1; i< 20; i++)
            {
                cbbWaitTimer.Items.Add(i);
            }
            cbbWaitTimer.SelectedIndex = 0;
        }
        public Form1()
        {
            InitializeComponent();

            updateCBBWaitTimer();
            txtKeySel = txtKeySelected;
            txtPosSel = txtPosSelected;
            
            m_globalHook = Hook.GlobalEvents();
            m_globalHook.KeyDown += GlobalHookKeyDown;
            
            m_globalHook.MouseDown += GlobalHookMouseDown;
            m_globalHook.MouseUp += GlobalHookMouseUp;
            m_globalHook.MouseClick += GlobalHookMouseClick;
            //m_globalHook.MouseMove += GlobalHookMouseMove;
            Console.WriteLine("Listening for global key presses. Press ESC to exit...");

            this.mousePosTimer.Start();
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

        private static void GlobalHookKeyDown(object sender, KeyEventArgs e)
        {
            Console.WriteLine($"Key pressed: {e.KeyCode}");
            txtKeySel.Text = e.KeyCode.ToString();
        }

        private void btnDeletePos_Click(object sender, EventArgs e)
        {
            //string 
            //m_keyList.Remove()
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

        private void btnClick(object sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                string name = btn.Text;
                string text = btn.Text;
                Console.WriteLine($"name: {name} | text: {m_keyList[btn.Text]}");
                MessageBox.Show($"Phím - {name}: {m_keyList[btn.Text]}");
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
            m_keyList = JsonConvert.DeserializeObject<Dictionary<string, Point>>(jsonDecoded);
            Console.WriteLine("Deserialized List: " + string.Join(", ", m_keyList));
        }

        private void setClick()
        {

        }

    }
}
