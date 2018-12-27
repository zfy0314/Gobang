using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace gobang
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /// if gamestate == true User go first
        public bool FisrtPlayer = true;
        /// if Gamestate == true it's User's turn
        public bool GameState = false;
        /// chessboard
        public int[] ChessBoard = new int[361];
        public int steps = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            Button senderButton = (Button)sender;
            if ( GameState == false || ChessBoard[senderButton.TabIndex] != 0 ) { return; }
            if (FisrtPlayer)
                senderButton.Image = Properties.Resources.Image1;
            else
                senderButton.Image = Properties.Resources.Image2;
            int pos = senderButton.TabIndex;
            steps++;
            ChessBoard[pos] = steps;
            if (WinCheck(pos))
            {
                MessageBox.Show("You won");
                GameState = false;
                return;
            }
            byte[] byData = new byte[100];
            char[] chData = new char[100];
            string path = folderBrowserDialog1.SelectedPath;
            string filepath = string.Concat(path, "\\",steps.ToString(),".txt");
            byte[] input_data = Encoding.Default.GetBytes(pos.ToString());
            File.WriteAllBytes(filepath, input_data);
            steps++;
            filepath = string.Concat(path, "\\", steps.ToString(), ".txt");
            while (!File.Exists(filepath)) { GameState = false; }
            Thread.Sleep(100);
            string response_data = File.ReadAllText(filepath);
            pos = int.Parse(response_data);
            ChessBoard[pos] = steps;
            switch (pos)
            {
                case 0:
                    if (FisrtPlayer) button19.Image = Properties.Resources.Image2;
                    else button19.Image = Properties.Resources.Image1;
                    break;
                case 1:
                    if (FisrtPlayer) button18.Image = Properties.Resources.Image2;
                    else button18.Image = Properties.Resources.Image1;
                    break;
                case 2:
                    if (FisrtPlayer) button17.Image = Properties.Resources.Image2;
                    else button17.Image = Properties.Resources.Image1;
                    break;
                case 3:
                    if (FisrtPlayer) button16.Image = Properties.Resources.Image2;
                    else button16.Image = Properties.Resources.Image1;
                    break;
                case 4:
                    if (FisrtPlayer) button15.Image = Properties.Resources.Image2;
                    else button15.Image = Properties.Resources.Image1;
                    break;
                case 5:
                    if (FisrtPlayer) button14.Image = Properties.Resources.Image2;
                    else button14.Image = Properties.Resources.Image1;
                    break;
                case 6:
                    if (FisrtPlayer) button13.Image = Properties.Resources.Image2;
                    else button13.Image = Properties.Resources.Image1;
                    break;
                case 7:
                    if (FisrtPlayer) button12.Image = Properties.Resources.Image2;
                    else button12.Image = Properties.Resources.Image1;
                    break;
                case 8:
                    if (FisrtPlayer) button11.Image = Properties.Resources.Image2;
                    else button11.Image = Properties.Resources.Image1;
                    break;
                case 9:
                    if (FisrtPlayer) button10.Image = Properties.Resources.Image2;
                    else button10.Image = Properties.Resources.Image1;
                    break;
                case 10:
                    if (FisrtPlayer) button9.Image = Properties.Resources.Image2;
                    else button9.Image = Properties.Resources.Image1;
                    break;
                case 11:
                    if (FisrtPlayer) button8.Image = Properties.Resources.Image2;
                    else button8.Image = Properties.Resources.Image1;
                    break;
                case 12:
                    if (FisrtPlayer) button7.Image = Properties.Resources.Image2;
                    else button7.Image = Properties.Resources.Image1;
                    break;
                case 13:
                    if (FisrtPlayer) button6.Image = Properties.Resources.Image2;
                    else button6.Image = Properties.Resources.Image1;
                    break;
                case 14:
                    if (FisrtPlayer) button5.Image = Properties.Resources.Image2;
                    else button5.Image = Properties.Resources.Image1;
                    break;
                case 15:
                    if (FisrtPlayer) button4.Image = Properties.Resources.Image2;
                    else button4.Image = Properties.Resources.Image1;
                    break;
                case 16:
                    if (FisrtPlayer) button3.Image = Properties.Resources.Image2;
                    else button3.Image = Properties.Resources.Image1;
                    break;
                case 17:
                    if (FisrtPlayer) button2.Image = Properties.Resources.Image2;
                    else button2.Image = Properties.Resources.Image1;
                    break;
                case 18:
                    if (FisrtPlayer) button1.Image = Properties.Resources.Image2;
                    else button1.Image = Properties.Resources.Image1;
                    break;
                case 19:
                    if (FisrtPlayer) button38.Image = Properties.Resources.Image2;
                    else button38.Image = Properties.Resources.Image1;
                    break;
                case 20:
                    if (FisrtPlayer) button37.Image = Properties.Resources.Image2;
                    else button37.Image = Properties.Resources.Image1;
                    break;
                case 21:
                    if (FisrtPlayer) button36.Image = Properties.Resources.Image2;
                    else button36.Image = Properties.Resources.Image1;
                    break;
                case 22:
                    if (FisrtPlayer) button35.Image = Properties.Resources.Image2;
                    else button35.Image = Properties.Resources.Image1;
                    break;
                case 23:
                    if (FisrtPlayer) button34.Image = Properties.Resources.Image2;
                    else button34.Image = Properties.Resources.Image1;
                    break;
                case 24:
                    if (FisrtPlayer) button33.Image = Properties.Resources.Image2;
                    else button33.Image = Properties.Resources.Image1;
                    break;
                case 25:
                    if (FisrtPlayer) button32.Image = Properties.Resources.Image2;
                    else button32.Image = Properties.Resources.Image1;
                    break;
                case 26:
                    if (FisrtPlayer) button31.Image = Properties.Resources.Image2;
                    else button31.Image = Properties.Resources.Image1;
                    break;
                case 27:
                    if (FisrtPlayer) button30.Image = Properties.Resources.Image2;
                    else button30.Image = Properties.Resources.Image1;
                    break;
                case 28:
                    if (FisrtPlayer) button29.Image = Properties.Resources.Image2;
                    else button29.Image = Properties.Resources.Image1;
                    break;
                case 29:
                    if (FisrtPlayer) button28.Image = Properties.Resources.Image2;
                    else button28.Image = Properties.Resources.Image1;
                    break;
                case 30:
                    if (FisrtPlayer) button27.Image = Properties.Resources.Image2;
                    else button27.Image = Properties.Resources.Image1;
                    break;
                case 31:
                    if (FisrtPlayer) button26.Image = Properties.Resources.Image2;
                    else button26.Image = Properties.Resources.Image1;
                    break;
                case 32:
                    if (FisrtPlayer) button25.Image = Properties.Resources.Image2;
                    else button25.Image = Properties.Resources.Image1;
                    break;
                case 33:
                    if (FisrtPlayer) button24.Image = Properties.Resources.Image2;
                    else button24.Image = Properties.Resources.Image1;
                    break;
                case 34:
                    if (FisrtPlayer) button23.Image = Properties.Resources.Image2;
                    else button23.Image = Properties.Resources.Image1;
                    break;
                case 35:
                    if (FisrtPlayer) button22.Image = Properties.Resources.Image2;
                    else button22.Image = Properties.Resources.Image1;
                    break;
                case 36:
                    if (FisrtPlayer) button21.Image = Properties.Resources.Image2;
                    else button21.Image = Properties.Resources.Image1;
                    break;
                case 37:
                    if (FisrtPlayer) button20.Image = Properties.Resources.Image2;
                    else button20.Image = Properties.Resources.Image1;
                    break;
                case 38:
                    if (FisrtPlayer) button57.Image = Properties.Resources.Image2;
                    else button57.Image = Properties.Resources.Image1;
                    break;
                case 39:
                    if (FisrtPlayer) button56.Image = Properties.Resources.Image2;
                    else button56.Image = Properties.Resources.Image1;
                    break;
                case 40:
                    if (FisrtPlayer) button55.Image = Properties.Resources.Image2;
                    else button55.Image = Properties.Resources.Image1;
                    break;
                case 41:
                    if (FisrtPlayer) button54.Image = Properties.Resources.Image2;
                    else button54.Image = Properties.Resources.Image1;
                    break;
                case 42:
                    if (FisrtPlayer) button53.Image = Properties.Resources.Image2;
                    else button53.Image = Properties.Resources.Image1;
                    break;
                case 43:
                    if (FisrtPlayer) button52.Image = Properties.Resources.Image2;
                    else button52.Image = Properties.Resources.Image1;
                    break;
                case 44:
                    if (FisrtPlayer) button51.Image = Properties.Resources.Image2;
                    else button51.Image = Properties.Resources.Image1;
                    break;
                case 45:
                    if (FisrtPlayer) button50.Image = Properties.Resources.Image2;
                    else button50.Image = Properties.Resources.Image1;
                    break;
                case 46:
                    if (FisrtPlayer) button49.Image = Properties.Resources.Image2;
                    else button49.Image = Properties.Resources.Image1;
                    break;
                case 47:
                    if (FisrtPlayer) button48.Image = Properties.Resources.Image2;
                    else button48.Image = Properties.Resources.Image1;
                    break;
                case 48:
                    if (FisrtPlayer) button47.Image = Properties.Resources.Image2;
                    else button47.Image = Properties.Resources.Image1;
                    break;
                case 49:
                    if (FisrtPlayer) button46.Image = Properties.Resources.Image2;
                    else button46.Image = Properties.Resources.Image1;
                    break;
                case 50:
                    if (FisrtPlayer) button45.Image = Properties.Resources.Image2;
                    else button45.Image = Properties.Resources.Image1;
                    break;
                case 51:
                    if (FisrtPlayer) button44.Image = Properties.Resources.Image2;
                    else button44.Image = Properties.Resources.Image1;
                    break;
                case 52:
                    if (FisrtPlayer) button43.Image = Properties.Resources.Image2;
                    else button43.Image = Properties.Resources.Image1;
                    break;
                case 53:
                    if (FisrtPlayer) button42.Image = Properties.Resources.Image2;
                    else button42.Image = Properties.Resources.Image1;
                    break;
                case 54:
                    if (FisrtPlayer) button41.Image = Properties.Resources.Image2;
                    else button41.Image = Properties.Resources.Image1;
                    break;
                case 55:
                    if (FisrtPlayer) button40.Image = Properties.Resources.Image2;
                    else button40.Image = Properties.Resources.Image1;
                    break;
                case 56:
                    if (FisrtPlayer) button39.Image = Properties.Resources.Image2;
                    else button39.Image = Properties.Resources.Image1;
                    break;
                case 57:
                    if (FisrtPlayer) button76.Image = Properties.Resources.Image2;
                    else button76.Image = Properties.Resources.Image1;
                    break;
                case 58:
                    if (FisrtPlayer) button75.Image = Properties.Resources.Image2;
                    else button75.Image = Properties.Resources.Image1;
                    break;
                case 59:
                    if (FisrtPlayer) button74.Image = Properties.Resources.Image2;
                    else button74.Image = Properties.Resources.Image1;
                    break;
                case 60:
                    if (FisrtPlayer) button73.Image = Properties.Resources.Image2;
                    else button73.Image = Properties.Resources.Image1;
                    break;
                case 61:
                    if (FisrtPlayer) button72.Image = Properties.Resources.Image2;
                    else button72.Image = Properties.Resources.Image1;
                    break;
                case 62:
                    if (FisrtPlayer) button71.Image = Properties.Resources.Image2;
                    else button71.Image = Properties.Resources.Image1;
                    break;
                case 63:
                    if (FisrtPlayer) button70.Image = Properties.Resources.Image2;
                    else button70.Image = Properties.Resources.Image1;
                    break;
                case 64:
                    if (FisrtPlayer) button69.Image = Properties.Resources.Image2;
                    else button69.Image = Properties.Resources.Image1;
                    break;
                case 65:
                    if (FisrtPlayer) button68.Image = Properties.Resources.Image2;
                    else button68.Image = Properties.Resources.Image1;
                    break;
                case 66:
                    if (FisrtPlayer) button67.Image = Properties.Resources.Image2;
                    else button67.Image = Properties.Resources.Image1;
                    break;
                case 67:
                    if (FisrtPlayer) button66.Image = Properties.Resources.Image2;
                    else button66.Image = Properties.Resources.Image1;
                    break;
                case 68:
                    if (FisrtPlayer) button65.Image = Properties.Resources.Image2;
                    else button65.Image = Properties.Resources.Image1;
                    break;
                case 69:
                    if (FisrtPlayer) button64.Image = Properties.Resources.Image2;
                    else button64.Image = Properties.Resources.Image1;
                    break;
                case 70:
                    if (FisrtPlayer) button63.Image = Properties.Resources.Image2;
                    else button63.Image = Properties.Resources.Image1;
                    break;
                case 71:
                    if (FisrtPlayer) button62.Image = Properties.Resources.Image2;
                    else button62.Image = Properties.Resources.Image1;
                    break;
                case 72:
                    if (FisrtPlayer) button61.Image = Properties.Resources.Image2;
                    else button61.Image = Properties.Resources.Image1;
                    break;
                case 73:
                    if (FisrtPlayer) button60.Image = Properties.Resources.Image2;
                    else button60.Image = Properties.Resources.Image1;
                    break;
                case 74:
                    if (FisrtPlayer) button59.Image = Properties.Resources.Image2;
                    else button59.Image = Properties.Resources.Image1;
                    break;
                case 75:
                    if (FisrtPlayer) button58.Image = Properties.Resources.Image2;
                    else button58.Image = Properties.Resources.Image1;
                    break;
                case 76:
                    if (FisrtPlayer) button95.Image = Properties.Resources.Image2;
                    else button95.Image = Properties.Resources.Image1;
                    break;
                case 77:
                    if (FisrtPlayer) button94.Image = Properties.Resources.Image2;
                    else button94.Image = Properties.Resources.Image1;
                    break;
                case 78:
                    if (FisrtPlayer) button93.Image = Properties.Resources.Image2;
                    else button93.Image = Properties.Resources.Image1;
                    break;
                case 79:
                    if (FisrtPlayer) button92.Image = Properties.Resources.Image2;
                    else button92.Image = Properties.Resources.Image1;
                    break;
                case 80:
                    if (FisrtPlayer) button91.Image = Properties.Resources.Image2;
                    else button91.Image = Properties.Resources.Image1;
                    break;
                case 81:
                    if (FisrtPlayer) button90.Image = Properties.Resources.Image2;
                    else button90.Image = Properties.Resources.Image1;
                    break;
                case 82:
                    if (FisrtPlayer) button89.Image = Properties.Resources.Image2;
                    else button89.Image = Properties.Resources.Image1;
                    break;
                case 83:
                    if (FisrtPlayer) button88.Image = Properties.Resources.Image2;
                    else button88.Image = Properties.Resources.Image1;
                    break;
                case 84:
                    if (FisrtPlayer) button87.Image = Properties.Resources.Image2;
                    else button87.Image = Properties.Resources.Image1;
                    break;
                case 85:
                    if (FisrtPlayer) button86.Image = Properties.Resources.Image2;
                    else button86.Image = Properties.Resources.Image1;
                    break;
                case 86:
                    if (FisrtPlayer) button85.Image = Properties.Resources.Image2;
                    else button85.Image = Properties.Resources.Image1;
                    break;
                case 87:
                    if (FisrtPlayer) button84.Image = Properties.Resources.Image2;
                    else button84.Image = Properties.Resources.Image1;
                    break;
                case 88:
                    if (FisrtPlayer) button83.Image = Properties.Resources.Image2;
                    else button83.Image = Properties.Resources.Image1;
                    break;
                case 89:
                    if (FisrtPlayer) button82.Image = Properties.Resources.Image2;
                    else button82.Image = Properties.Resources.Image1;
                    break;
                case 90:
                    if (FisrtPlayer) button81.Image = Properties.Resources.Image2;
                    else button81.Image = Properties.Resources.Image1;
                    break;
                case 91:
                    if (FisrtPlayer) button80.Image = Properties.Resources.Image2;
                    else button80.Image = Properties.Resources.Image1;
                    break;
                case 92:
                    if (FisrtPlayer) button79.Image = Properties.Resources.Image2;
                    else button79.Image = Properties.Resources.Image1;
                    break;
                case 93:
                    if (FisrtPlayer) button78.Image = Properties.Resources.Image2;
                    else button78.Image = Properties.Resources.Image1;
                    break;
                case 94:
                    if (FisrtPlayer) button77.Image = Properties.Resources.Image2;
                    else button77.Image = Properties.Resources.Image1;
                    break;
                case 95:
                    if (FisrtPlayer) button114.Image = Properties.Resources.Image2;
                    else button114.Image = Properties.Resources.Image1;
                    break;
                case 96:
                    if (FisrtPlayer) button113.Image = Properties.Resources.Image2;
                    else button113.Image = Properties.Resources.Image1;
                    break;
                case 97:
                    if (FisrtPlayer) button112.Image = Properties.Resources.Image2;
                    else button112.Image = Properties.Resources.Image1;
                    break;
                case 98:
                    if (FisrtPlayer) button111.Image = Properties.Resources.Image2;
                    else button111.Image = Properties.Resources.Image1;
                    break;
                case 99:
                    if (FisrtPlayer) button110.Image = Properties.Resources.Image2;
                    else button110.Image = Properties.Resources.Image1;
                    break;
                case 100:
                    if (FisrtPlayer) button109.Image = Properties.Resources.Image2;
                    else button109.Image = Properties.Resources.Image1;
                    break;
                case 101:
                    if (FisrtPlayer) button108.Image = Properties.Resources.Image2;
                    else button108.Image = Properties.Resources.Image1;
                    break;
                case 102:
                    if (FisrtPlayer) button107.Image = Properties.Resources.Image2;
                    else button107.Image = Properties.Resources.Image1;
                    break;
                case 103:
                    if (FisrtPlayer) button106.Image = Properties.Resources.Image2;
                    else button106.Image = Properties.Resources.Image1;
                    break;
                case 104:
                    if (FisrtPlayer) button105.Image = Properties.Resources.Image2;
                    else button105.Image = Properties.Resources.Image1;
                    break;
                case 105:
                    if (FisrtPlayer) button104.Image = Properties.Resources.Image2;
                    else button104.Image = Properties.Resources.Image1;
                    break;
                case 106:
                    if (FisrtPlayer) button103.Image = Properties.Resources.Image2;
                    else button103.Image = Properties.Resources.Image1;
                    break;
                case 107:
                    if (FisrtPlayer) button102.Image = Properties.Resources.Image2;
                    else button102.Image = Properties.Resources.Image1;
                    break;
                case 108:
                    if (FisrtPlayer) button101.Image = Properties.Resources.Image2;
                    else button101.Image = Properties.Resources.Image1;
                    break;
                case 109:
                    if (FisrtPlayer) button100.Image = Properties.Resources.Image2;
                    else button100.Image = Properties.Resources.Image1;
                    break;
                case 110:
                    if (FisrtPlayer) button99.Image = Properties.Resources.Image2;
                    else button99.Image = Properties.Resources.Image1;
                    break;
                case 111:
                    if (FisrtPlayer) button98.Image = Properties.Resources.Image2;
                    else button98.Image = Properties.Resources.Image1;
                    break;
                case 112:
                    if (FisrtPlayer) button97.Image = Properties.Resources.Image2;
                    else button97.Image = Properties.Resources.Image1;
                    break;
                case 113:
                    if (FisrtPlayer) button96.Image = Properties.Resources.Image2;
                    else button96.Image = Properties.Resources.Image1;
                    break;
                case 114:
                    if (FisrtPlayer) button133.Image = Properties.Resources.Image2;
                    else button133.Image = Properties.Resources.Image1;
                    break;
                case 115:
                    if (FisrtPlayer) button132.Image = Properties.Resources.Image2;
                    else button132.Image = Properties.Resources.Image1;
                    break;
                case 116:
                    if (FisrtPlayer) button131.Image = Properties.Resources.Image2;
                    else button131.Image = Properties.Resources.Image1;
                    break;
                case 117:
                    if (FisrtPlayer) button130.Image = Properties.Resources.Image2;
                    else button130.Image = Properties.Resources.Image1;
                    break;
                case 118:
                    if (FisrtPlayer) button129.Image = Properties.Resources.Image2;
                    else button129.Image = Properties.Resources.Image1;
                    break;
                case 119:
                    if (FisrtPlayer) button128.Image = Properties.Resources.Image2;
                    else button128.Image = Properties.Resources.Image1;
                    break;
                case 120:
                    if (FisrtPlayer) button127.Image = Properties.Resources.Image2;
                    else button127.Image = Properties.Resources.Image1;
                    break;
                case 121:
                    if (FisrtPlayer) button126.Image = Properties.Resources.Image2;
                    else button126.Image = Properties.Resources.Image1;
                    break;
                case 122:
                    if (FisrtPlayer) button125.Image = Properties.Resources.Image2;
                    else button125.Image = Properties.Resources.Image1;
                    break;
                case 123:
                    if (FisrtPlayer) button124.Image = Properties.Resources.Image2;
                    else button124.Image = Properties.Resources.Image1;
                    break;
                case 124:
                    if (FisrtPlayer) button123.Image = Properties.Resources.Image2;
                    else button123.Image = Properties.Resources.Image1;
                    break;
                case 125:
                    if (FisrtPlayer) button122.Image = Properties.Resources.Image2;
                    else button122.Image = Properties.Resources.Image1;
                    break;
                case 126:
                    if (FisrtPlayer) button121.Image = Properties.Resources.Image2;
                    else button121.Image = Properties.Resources.Image1;
                    break;
                case 127:
                    if (FisrtPlayer) button120.Image = Properties.Resources.Image2;
                    else button120.Image = Properties.Resources.Image1;
                    break;
                case 128:
                    if (FisrtPlayer) button119.Image = Properties.Resources.Image2;
                    else button119.Image = Properties.Resources.Image1;
                    break;
                case 129:
                    if (FisrtPlayer) button118.Image = Properties.Resources.Image2;
                    else button118.Image = Properties.Resources.Image1;
                    break;
                case 130:
                    if (FisrtPlayer) button117.Image = Properties.Resources.Image2;
                    else button117.Image = Properties.Resources.Image1;
                    break;
                case 131:
                    if (FisrtPlayer) button116.Image = Properties.Resources.Image2;
                    else button116.Image = Properties.Resources.Image1;
                    break;
                case 132:
                    if (FisrtPlayer) button115.Image = Properties.Resources.Image2;
                    else button115.Image = Properties.Resources.Image1;
                    break;
                case 133:
                    if (FisrtPlayer) button152.Image = Properties.Resources.Image2;
                    else button152.Image = Properties.Resources.Image1;
                    break;
                case 134:
                    if (FisrtPlayer) button151.Image = Properties.Resources.Image2;
                    else button151.Image = Properties.Resources.Image1;
                    break;
                case 135:
                    if (FisrtPlayer) button150.Image = Properties.Resources.Image2;
                    else button150.Image = Properties.Resources.Image1;
                    break;
                case 136:
                    if (FisrtPlayer) button149.Image = Properties.Resources.Image2;
                    else button149.Image = Properties.Resources.Image1;
                    break;
                case 137:
                    if (FisrtPlayer) button148.Image = Properties.Resources.Image2;
                    else button148.Image = Properties.Resources.Image1;
                    break;
                case 138:
                    if (FisrtPlayer) button147.Image = Properties.Resources.Image2;
                    else button147.Image = Properties.Resources.Image1;
                    break;
                case 139:
                    if (FisrtPlayer) button146.Image = Properties.Resources.Image2;
                    else button146.Image = Properties.Resources.Image1;
                    break;
                case 140:
                    if (FisrtPlayer) button145.Image = Properties.Resources.Image2;
                    else button145.Image = Properties.Resources.Image1;
                    break;
                case 141:
                    if (FisrtPlayer) button144.Image = Properties.Resources.Image2;
                    else button144.Image = Properties.Resources.Image1;
                    break;
                case 142:
                    if (FisrtPlayer) button143.Image = Properties.Resources.Image2;
                    else button143.Image = Properties.Resources.Image1;
                    break;
                case 143:
                    if (FisrtPlayer) button142.Image = Properties.Resources.Image2;
                    else button142.Image = Properties.Resources.Image1;
                    break;
                case 144:
                    if (FisrtPlayer) button141.Image = Properties.Resources.Image2;
                    else button141.Image = Properties.Resources.Image1;
                    break;
                case 145:
                    if (FisrtPlayer) button140.Image = Properties.Resources.Image2;
                    else button140.Image = Properties.Resources.Image1;
                    break;
                case 146:
                    if (FisrtPlayer) button139.Image = Properties.Resources.Image2;
                    else button139.Image = Properties.Resources.Image1;
                    break;
                case 147:
                    if (FisrtPlayer) button138.Image = Properties.Resources.Image2;
                    else button138.Image = Properties.Resources.Image1;
                    break;
                case 148:
                    if (FisrtPlayer) button137.Image = Properties.Resources.Image2;
                    else button137.Image = Properties.Resources.Image1;
                    break;
                case 149:
                    if (FisrtPlayer) button136.Image = Properties.Resources.Image2;
                    else button136.Image = Properties.Resources.Image1;
                    break;
                case 150:
                    if (FisrtPlayer) button135.Image = Properties.Resources.Image2;
                    else button135.Image = Properties.Resources.Image1;
                    break;
                case 151:
                    if (FisrtPlayer) button134.Image = Properties.Resources.Image2;
                    else button134.Image = Properties.Resources.Image1;
                    break;
                case 152:
                    if (FisrtPlayer) button171.Image = Properties.Resources.Image2;
                    else button171.Image = Properties.Resources.Image1;
                    break;
                case 153:
                    if (FisrtPlayer) button170.Image = Properties.Resources.Image2;
                    else button170.Image = Properties.Resources.Image1;
                    break;
                case 154:
                    if (FisrtPlayer) button169.Image = Properties.Resources.Image2;
                    else button169.Image = Properties.Resources.Image1;
                    break;
                case 155:
                    if (FisrtPlayer) button168.Image = Properties.Resources.Image2;
                    else button168.Image = Properties.Resources.Image1;
                    break;
                case 156:
                    if (FisrtPlayer) button167.Image = Properties.Resources.Image2;
                    else button167.Image = Properties.Resources.Image1;
                    break;
                case 157:
                    if (FisrtPlayer) button166.Image = Properties.Resources.Image2;
                    else button166.Image = Properties.Resources.Image1;
                    break;
                case 158:
                    if (FisrtPlayer) button165.Image = Properties.Resources.Image2;
                    else button165.Image = Properties.Resources.Image1;
                    break;
                case 159:
                    if (FisrtPlayer) button164.Image = Properties.Resources.Image2;
                    else button164.Image = Properties.Resources.Image1;
                    break;
                case 160:
                    if (FisrtPlayer) button163.Image = Properties.Resources.Image2;
                    else button163.Image = Properties.Resources.Image1;
                    break;
                case 161:
                    if (FisrtPlayer) button162.Image = Properties.Resources.Image2;
                    else button162.Image = Properties.Resources.Image1;
                    break;
                case 162:
                    if (FisrtPlayer) button161.Image = Properties.Resources.Image2;
                    else button161.Image = Properties.Resources.Image1;
                    break;
                case 163:
                    if (FisrtPlayer) button160.Image = Properties.Resources.Image2;
                    else button160.Image = Properties.Resources.Image1;
                    break;
                case 164:
                    if (FisrtPlayer) button159.Image = Properties.Resources.Image2;
                    else button159.Image = Properties.Resources.Image1;
                    break;
                case 165:
                    if (FisrtPlayer) button158.Image = Properties.Resources.Image2;
                    else button158.Image = Properties.Resources.Image1;
                    break;
                case 166:
                    if (FisrtPlayer) button157.Image = Properties.Resources.Image2;
                    else button157.Image = Properties.Resources.Image1;
                    break;
                case 167:
                    if (FisrtPlayer) button156.Image = Properties.Resources.Image2;
                    else button156.Image = Properties.Resources.Image1;
                    break;
                case 168:
                    if (FisrtPlayer) button155.Image = Properties.Resources.Image2;
                    else button155.Image = Properties.Resources.Image1;
                    break;
                case 169:
                    if (FisrtPlayer) button154.Image = Properties.Resources.Image2;
                    else button154.Image = Properties.Resources.Image1;
                    break;
                case 170:
                    if (FisrtPlayer) button153.Image = Properties.Resources.Image2;
                    else button153.Image = Properties.Resources.Image1;
                    break;
                case 171:
                    if (FisrtPlayer) button190.Image = Properties.Resources.Image2;
                    else button190.Image = Properties.Resources.Image1;
                    break;
                case 172:
                    if (FisrtPlayer) button189.Image = Properties.Resources.Image2;
                    else button189.Image = Properties.Resources.Image1;
                    break;
                case 173:
                    if (FisrtPlayer) button188.Image = Properties.Resources.Image2;
                    else button188.Image = Properties.Resources.Image1;
                    break;
                case 174:
                    if (FisrtPlayer) button187.Image = Properties.Resources.Image2;
                    else button187.Image = Properties.Resources.Image1;
                    break;
                case 175:
                    if (FisrtPlayer) button186.Image = Properties.Resources.Image2;
                    else button186.Image = Properties.Resources.Image1;
                    break;
                case 176:
                    if (FisrtPlayer) button185.Image = Properties.Resources.Image2;
                    else button185.Image = Properties.Resources.Image1;
                    break;
                case 177:
                    if (FisrtPlayer) button184.Image = Properties.Resources.Image2;
                    else button184.Image = Properties.Resources.Image1;
                    break;
                case 178:
                    if (FisrtPlayer) button183.Image = Properties.Resources.Image2;
                    else button183.Image = Properties.Resources.Image1;
                    break;
                case 179:
                    if (FisrtPlayer) button182.Image = Properties.Resources.Image2;
                    else button182.Image = Properties.Resources.Image1;
                    break;
                case 180:
                    if (FisrtPlayer) button181.Image = Properties.Resources.Image2;
                    else button181.Image = Properties.Resources.Image1;
                    break;
                case 181:
                    if (FisrtPlayer) button180.Image = Properties.Resources.Image2;
                    else button180.Image = Properties.Resources.Image1;
                    break;
                case 182:
                    if (FisrtPlayer) button179.Image = Properties.Resources.Image2;
                    else button179.Image = Properties.Resources.Image1;
                    break;
                case 183:
                    if (FisrtPlayer) button178.Image = Properties.Resources.Image2;
                    else button178.Image = Properties.Resources.Image1;
                    break;
                case 184:
                    if (FisrtPlayer) button177.Image = Properties.Resources.Image2;
                    else button177.Image = Properties.Resources.Image1;
                    break;
                case 185:
                    if (FisrtPlayer) button176.Image = Properties.Resources.Image2;
                    else button176.Image = Properties.Resources.Image1;
                    break;
                case 186:
                    if (FisrtPlayer) button175.Image = Properties.Resources.Image2;
                    else button175.Image = Properties.Resources.Image1;
                    break;
                case 187:
                    if (FisrtPlayer) button174.Image = Properties.Resources.Image2;
                    else button174.Image = Properties.Resources.Image1;
                    break;
                case 188:
                    if (FisrtPlayer) button173.Image = Properties.Resources.Image2;
                    else button173.Image = Properties.Resources.Image1;
                    break;
                case 189:
                    if (FisrtPlayer) button172.Image = Properties.Resources.Image2;
                    else button172.Image = Properties.Resources.Image1;
                    break;
                case 190:
                    if (FisrtPlayer) button209.Image = Properties.Resources.Image2;
                    else button209.Image = Properties.Resources.Image1;
                    break;
                case 191:
                    if (FisrtPlayer) button208.Image = Properties.Resources.Image2;
                    else button208.Image = Properties.Resources.Image1;
                    break;
                case 192:
                    if (FisrtPlayer) button207.Image = Properties.Resources.Image2;
                    else button207.Image = Properties.Resources.Image1;
                    break;
                case 193:
                    if (FisrtPlayer) button206.Image = Properties.Resources.Image2;
                    else button206.Image = Properties.Resources.Image1;
                    break;
                case 194:
                    if (FisrtPlayer) button205.Image = Properties.Resources.Image2;
                    else button205.Image = Properties.Resources.Image1;
                    break;
                case 195:
                    if (FisrtPlayer) button204.Image = Properties.Resources.Image2;
                    else button204.Image = Properties.Resources.Image1;
                    break;
                case 196:
                    if (FisrtPlayer) button203.Image = Properties.Resources.Image2;
                    else button203.Image = Properties.Resources.Image1;
                    break;
                case 197:
                    if (FisrtPlayer) button202.Image = Properties.Resources.Image2;
                    else button202.Image = Properties.Resources.Image1;
                    break;
                case 198:
                    if (FisrtPlayer) button201.Image = Properties.Resources.Image2;
                    else button201.Image = Properties.Resources.Image1;
                    break;
                case 199:
                    if (FisrtPlayer) button200.Image = Properties.Resources.Image2;
                    else button200.Image = Properties.Resources.Image1;
                    break;
                case 200:
                    if (FisrtPlayer) button199.Image = Properties.Resources.Image2;
                    else button199.Image = Properties.Resources.Image1;
                    break;
                case 201:
                    if (FisrtPlayer) button198.Image = Properties.Resources.Image2;
                    else button198.Image = Properties.Resources.Image1;
                    break;
                case 202:
                    if (FisrtPlayer) button197.Image = Properties.Resources.Image2;
                    else button197.Image = Properties.Resources.Image1;
                    break;
                case 203:
                    if (FisrtPlayer) button196.Image = Properties.Resources.Image2;
                    else button196.Image = Properties.Resources.Image1;
                    break;
                case 204:
                    if (FisrtPlayer) button195.Image = Properties.Resources.Image2;
                    else button195.Image = Properties.Resources.Image1;
                    break;
                case 205:
                    if (FisrtPlayer) button194.Image = Properties.Resources.Image2;
                    else button194.Image = Properties.Resources.Image1;
                    break;
                case 206:
                    if (FisrtPlayer) button193.Image = Properties.Resources.Image2;
                    else button193.Image = Properties.Resources.Image1;
                    break;
                case 207:
                    if (FisrtPlayer) button192.Image = Properties.Resources.Image2;
                    else button192.Image = Properties.Resources.Image1;
                    break;
                case 208:
                    if (FisrtPlayer) button191.Image = Properties.Resources.Image2;
                    else button191.Image = Properties.Resources.Image1;
                    break;
                case 209:
                    if (FisrtPlayer) button228.Image = Properties.Resources.Image2;
                    else button228.Image = Properties.Resources.Image1;
                    break;
                case 210:
                    if (FisrtPlayer) button227.Image = Properties.Resources.Image2;
                    else button227.Image = Properties.Resources.Image1;
                    break;
                case 211:
                    if (FisrtPlayer) button226.Image = Properties.Resources.Image2;
                    else button226.Image = Properties.Resources.Image1;
                    break;
                case 212:
                    if (FisrtPlayer) button225.Image = Properties.Resources.Image2;
                    else button225.Image = Properties.Resources.Image1;
                    break;
                case 213:
                    if (FisrtPlayer) button224.Image = Properties.Resources.Image2;
                    else button224.Image = Properties.Resources.Image1;
                    break;
                case 214:
                    if (FisrtPlayer) button223.Image = Properties.Resources.Image2;
                    else button223.Image = Properties.Resources.Image1;
                    break;
                case 215:
                    if (FisrtPlayer) button222.Image = Properties.Resources.Image2;
                    else button222.Image = Properties.Resources.Image1;
                    break;
                case 216:
                    if (FisrtPlayer) button221.Image = Properties.Resources.Image2;
                    else button221.Image = Properties.Resources.Image1;
                    break;
                case 217:
                    if (FisrtPlayer) button220.Image = Properties.Resources.Image2;
                    else button220.Image = Properties.Resources.Image1;
                    break;
                case 218:
                    if (FisrtPlayer) button219.Image = Properties.Resources.Image2;
                    else button219.Image = Properties.Resources.Image1;
                    break;
                case 219:
                    if (FisrtPlayer) button218.Image = Properties.Resources.Image2;
                    else button218.Image = Properties.Resources.Image1;
                    break;
                case 220:
                    if (FisrtPlayer) button217.Image = Properties.Resources.Image2;
                    else button217.Image = Properties.Resources.Image1;
                    break;
                case 221:
                    if (FisrtPlayer) button216.Image = Properties.Resources.Image2;
                    else button216.Image = Properties.Resources.Image1;
                    break;
                case 222:
                    if (FisrtPlayer) button215.Image = Properties.Resources.Image2;
                    else button215.Image = Properties.Resources.Image1;
                    break;
                case 223:
                    if (FisrtPlayer) button214.Image = Properties.Resources.Image2;
                    else button214.Image = Properties.Resources.Image1;
                    break;
                case 224:
                    if (FisrtPlayer) button213.Image = Properties.Resources.Image2;
                    else button213.Image = Properties.Resources.Image1;
                    break;
                case 225:
                    if (FisrtPlayer) button212.Image = Properties.Resources.Image2;
                    else button212.Image = Properties.Resources.Image1;
                    break;
                case 226:
                    if (FisrtPlayer) button211.Image = Properties.Resources.Image2;
                    else button211.Image = Properties.Resources.Image1;
                    break;
                case 227:
                    if (FisrtPlayer) button210.Image = Properties.Resources.Image2;
                    else button210.Image = Properties.Resources.Image1;
                    break;
                case 228:
                    if (FisrtPlayer) button247.Image = Properties.Resources.Image2;
                    else button247.Image = Properties.Resources.Image1;
                    break;
                case 229:
                    if (FisrtPlayer) button246.Image = Properties.Resources.Image2;
                    else button246.Image = Properties.Resources.Image1;
                    break;
                case 230:
                    if (FisrtPlayer) button245.Image = Properties.Resources.Image2;
                    else button245.Image = Properties.Resources.Image1;
                    break;
                case 231:
                    if (FisrtPlayer) button244.Image = Properties.Resources.Image2;
                    else button244.Image = Properties.Resources.Image1;
                    break;
                case 232:
                    if (FisrtPlayer) button243.Image = Properties.Resources.Image2;
                    else button243.Image = Properties.Resources.Image1;
                    break;
                case 233:
                    if (FisrtPlayer) button242.Image = Properties.Resources.Image2;
                    else button242.Image = Properties.Resources.Image1;
                    break;
                case 234:
                    if (FisrtPlayer) button241.Image = Properties.Resources.Image2;
                    else button241.Image = Properties.Resources.Image1;
                    break;
                case 235:
                    if (FisrtPlayer) button240.Image = Properties.Resources.Image2;
                    else button240.Image = Properties.Resources.Image1;
                    break;
                case 236:
                    if (FisrtPlayer) button239.Image = Properties.Resources.Image2;
                    else button239.Image = Properties.Resources.Image1;
                    break;
                case 237:
                    if (FisrtPlayer) button238.Image = Properties.Resources.Image2;
                    else button238.Image = Properties.Resources.Image1;
                    break;
                case 238:
                    if (FisrtPlayer) button237.Image = Properties.Resources.Image2;
                    else button237.Image = Properties.Resources.Image1;
                    break;
                case 239:
                    if (FisrtPlayer) button236.Image = Properties.Resources.Image2;
                    else button236.Image = Properties.Resources.Image1;
                    break;
                case 240:
                    if (FisrtPlayer) button235.Image = Properties.Resources.Image2;
                    else button235.Image = Properties.Resources.Image1;
                    break;
                case 241:
                    if (FisrtPlayer) button234.Image = Properties.Resources.Image2;
                    else button234.Image = Properties.Resources.Image1;
                    break;
                case 242:
                    if (FisrtPlayer) button233.Image = Properties.Resources.Image2;
                    else button233.Image = Properties.Resources.Image1;
                    break;
                case 243:
                    if (FisrtPlayer) button232.Image = Properties.Resources.Image2;
                    else button232.Image = Properties.Resources.Image1;
                    break;
                case 244:
                    if (FisrtPlayer) button231.Image = Properties.Resources.Image2;
                    else button231.Image = Properties.Resources.Image1;
                    break;
                case 245:
                    if (FisrtPlayer) button230.Image = Properties.Resources.Image2;
                    else button230.Image = Properties.Resources.Image1;
                    break;
                case 246:
                    if (FisrtPlayer) button229.Image = Properties.Resources.Image2;
                    else button229.Image = Properties.Resources.Image1;
                    break;
                case 247:
                    if (FisrtPlayer) button266.Image = Properties.Resources.Image2;
                    else button266.Image = Properties.Resources.Image1;
                    break;
                case 248:
                    if (FisrtPlayer) button265.Image = Properties.Resources.Image2;
                    else button265.Image = Properties.Resources.Image1;
                    break;
                case 249:
                    if (FisrtPlayer) button264.Image = Properties.Resources.Image2;
                    else button264.Image = Properties.Resources.Image1;
                    break;
                case 250:
                    if (FisrtPlayer) button263.Image = Properties.Resources.Image2;
                    else button263.Image = Properties.Resources.Image1;
                    break;
                case 251:
                    if (FisrtPlayer) button262.Image = Properties.Resources.Image2;
                    else button262.Image = Properties.Resources.Image1;
                    break;
                case 252:
                    if (FisrtPlayer) button261.Image = Properties.Resources.Image2;
                    else button261.Image = Properties.Resources.Image1;
                    break;
                case 253:
                    if (FisrtPlayer) button260.Image = Properties.Resources.Image2;
                    else button260.Image = Properties.Resources.Image1;
                    break;
                case 254:
                    if (FisrtPlayer) button259.Image = Properties.Resources.Image2;
                    else button259.Image = Properties.Resources.Image1;
                    break;
                case 255:
                    if (FisrtPlayer) button258.Image = Properties.Resources.Image2;
                    else button258.Image = Properties.Resources.Image1;
                    break;
                case 256:
                    if (FisrtPlayer) button257.Image = Properties.Resources.Image2;
                    else button257.Image = Properties.Resources.Image1;
                    break;
                case 257:
                    if (FisrtPlayer) button256.Image = Properties.Resources.Image2;
                    else button256.Image = Properties.Resources.Image1;
                    break;
                case 258:
                    if (FisrtPlayer) button255.Image = Properties.Resources.Image2;
                    else button255.Image = Properties.Resources.Image1;
                    break;
                case 259:
                    if (FisrtPlayer) button254.Image = Properties.Resources.Image2;
                    else button254.Image = Properties.Resources.Image1;
                    break;
                case 260:
                    if (FisrtPlayer) button253.Image = Properties.Resources.Image2;
                    else button253.Image = Properties.Resources.Image1;
                    break;
                case 261:
                    if (FisrtPlayer) button252.Image = Properties.Resources.Image2;
                    else button252.Image = Properties.Resources.Image1;
                    break;
                case 262:
                    if (FisrtPlayer) button251.Image = Properties.Resources.Image2;
                    else button251.Image = Properties.Resources.Image1;
                    break;
                case 263:
                    if (FisrtPlayer) button250.Image = Properties.Resources.Image2;
                    else button250.Image = Properties.Resources.Image1;
                    break;
                case 264:
                    if (FisrtPlayer) button249.Image = Properties.Resources.Image2;
                    else button249.Image = Properties.Resources.Image1;
                    break;
                case 265:
                    if (FisrtPlayer) button248.Image = Properties.Resources.Image2;
                    else button248.Image = Properties.Resources.Image1;
                    break;
                case 266:
                    if (FisrtPlayer) button285.Image = Properties.Resources.Image2;
                    else button285.Image = Properties.Resources.Image1;
                    break;
                case 267:
                    if (FisrtPlayer) button284.Image = Properties.Resources.Image2;
                    else button284.Image = Properties.Resources.Image1;
                    break;
                case 268:
                    if (FisrtPlayer) button283.Image = Properties.Resources.Image2;
                    else button283.Image = Properties.Resources.Image1;
                    break;
                case 269:
                    if (FisrtPlayer) button282.Image = Properties.Resources.Image2;
                    else button282.Image = Properties.Resources.Image1;
                    break;
                case 270:
                    if (FisrtPlayer) button281.Image = Properties.Resources.Image2;
                    else button281.Image = Properties.Resources.Image1;
                    break;
                case 271:
                    if (FisrtPlayer) button280.Image = Properties.Resources.Image2;
                    else button280.Image = Properties.Resources.Image1;
                    break;
                case 272:
                    if (FisrtPlayer) button279.Image = Properties.Resources.Image2;
                    else button279.Image = Properties.Resources.Image1;
                    break;
                case 273:
                    if (FisrtPlayer) button278.Image = Properties.Resources.Image2;
                    else button278.Image = Properties.Resources.Image1;
                    break;
                case 274:
                    if (FisrtPlayer) button277.Image = Properties.Resources.Image2;
                    else button277.Image = Properties.Resources.Image1;
                    break;
                case 275:
                    if (FisrtPlayer) button276.Image = Properties.Resources.Image2;
                    else button276.Image = Properties.Resources.Image1;
                    break;
                case 276:
                    if (FisrtPlayer) button275.Image = Properties.Resources.Image2;
                    else button275.Image = Properties.Resources.Image1;
                    break;
                case 277:
                    if (FisrtPlayer) button274.Image = Properties.Resources.Image2;
                    else button274.Image = Properties.Resources.Image1;
                    break;
                case 278:
                    if (FisrtPlayer) button273.Image = Properties.Resources.Image2;
                    else button273.Image = Properties.Resources.Image1;
                    break;
                case 279:
                    if (FisrtPlayer) button272.Image = Properties.Resources.Image2;
                    else button272.Image = Properties.Resources.Image1;
                    break;
                case 280:
                    if (FisrtPlayer) button271.Image = Properties.Resources.Image2;
                    else button271.Image = Properties.Resources.Image1;
                    break;
                case 281:
                    if (FisrtPlayer) button270.Image = Properties.Resources.Image2;
                    else button270.Image = Properties.Resources.Image1;
                    break;
                case 282:
                    if (FisrtPlayer) button269.Image = Properties.Resources.Image2;
                    else button269.Image = Properties.Resources.Image1;
                    break;
                case 283:
                    if (FisrtPlayer) button268.Image = Properties.Resources.Image2;
                    else button268.Image = Properties.Resources.Image1;
                    break;
                case 284:
                    if (FisrtPlayer) button267.Image = Properties.Resources.Image2;
                    else button267.Image = Properties.Resources.Image1;
                    break;
                case 285:
                    if (FisrtPlayer) button304.Image = Properties.Resources.Image2;
                    else button304.Image = Properties.Resources.Image1;
                    break;
                case 286:
                    if (FisrtPlayer) button303.Image = Properties.Resources.Image2;
                    else button303.Image = Properties.Resources.Image1;
                    break;
                case 287:
                    if (FisrtPlayer) button302.Image = Properties.Resources.Image2;
                    else button302.Image = Properties.Resources.Image1;
                    break;
                case 288:
                    if (FisrtPlayer) button301.Image = Properties.Resources.Image2;
                    else button301.Image = Properties.Resources.Image1;
                    break;
                case 289:
                    if (FisrtPlayer) button300.Image = Properties.Resources.Image2;
                    else button300.Image = Properties.Resources.Image1;
                    break;
                case 290:
                    if (FisrtPlayer) button299.Image = Properties.Resources.Image2;
                    else button299.Image = Properties.Resources.Image1;
                    break;
                case 291:
                    if (FisrtPlayer) button298.Image = Properties.Resources.Image2;
                    else button298.Image = Properties.Resources.Image1;
                    break;
                case 292:
                    if (FisrtPlayer) button297.Image = Properties.Resources.Image2;
                    else button297.Image = Properties.Resources.Image1;
                    break;
                case 293:
                    if (FisrtPlayer) button296.Image = Properties.Resources.Image2;
                    else button296.Image = Properties.Resources.Image1;
                    break;
                case 294:
                    if (FisrtPlayer) button295.Image = Properties.Resources.Image2;
                    else button295.Image = Properties.Resources.Image1;
                    break;
                case 295:
                    if (FisrtPlayer) button294.Image = Properties.Resources.Image2;
                    else button294.Image = Properties.Resources.Image1;
                    break;
                case 296:
                    if (FisrtPlayer) button293.Image = Properties.Resources.Image2;
                    else button293.Image = Properties.Resources.Image1;
                    break;
                case 297:
                    if (FisrtPlayer) button292.Image = Properties.Resources.Image2;
                    else button292.Image = Properties.Resources.Image1;
                    break;
                case 298:
                    if (FisrtPlayer) button291.Image = Properties.Resources.Image2;
                    else button291.Image = Properties.Resources.Image1;
                    break;
                case 299:
                    if (FisrtPlayer) button290.Image = Properties.Resources.Image2;
                    else button290.Image = Properties.Resources.Image1;
                    break;
                case 300:
                    if (FisrtPlayer) button289.Image = Properties.Resources.Image2;
                    else button289.Image = Properties.Resources.Image1;
                    break;
                case 301:
                    if (FisrtPlayer) button288.Image = Properties.Resources.Image2;
                    else button288.Image = Properties.Resources.Image1;
                    break;
                case 302:
                    if (FisrtPlayer) button287.Image = Properties.Resources.Image2;
                    else button287.Image = Properties.Resources.Image1;
                    break;
                case 303:
                    if (FisrtPlayer) button286.Image = Properties.Resources.Image2;
                    else button286.Image = Properties.Resources.Image1;
                    break;
                case 304:
                    if (FisrtPlayer) button323.Image = Properties.Resources.Image2;
                    else button323.Image = Properties.Resources.Image1;
                    break;
                case 305:
                    if (FisrtPlayer) button322.Image = Properties.Resources.Image2;
                    else button322.Image = Properties.Resources.Image1;
                    break;
                case 306:
                    if (FisrtPlayer) button321.Image = Properties.Resources.Image2;
                    else button321.Image = Properties.Resources.Image1;
                    break;
                case 307:
                    if (FisrtPlayer) button320.Image = Properties.Resources.Image2;
                    else button320.Image = Properties.Resources.Image1;
                    break;
                case 308:
                    if (FisrtPlayer) button319.Image = Properties.Resources.Image2;
                    else button319.Image = Properties.Resources.Image1;
                    break;
                case 309:
                    if (FisrtPlayer) button318.Image = Properties.Resources.Image2;
                    else button318.Image = Properties.Resources.Image1;
                    break;
                case 310:
                    if (FisrtPlayer) button317.Image = Properties.Resources.Image2;
                    else button317.Image = Properties.Resources.Image1;
                    break;
                case 311:
                    if (FisrtPlayer) button316.Image = Properties.Resources.Image2;
                    else button316.Image = Properties.Resources.Image1;
                    break;
                case 312:
                    if (FisrtPlayer) button315.Image = Properties.Resources.Image2;
                    else button315.Image = Properties.Resources.Image1;
                    break;
                case 313:
                    if (FisrtPlayer) button314.Image = Properties.Resources.Image2;
                    else button314.Image = Properties.Resources.Image1;
                    break;
                case 314:
                    if (FisrtPlayer) button313.Image = Properties.Resources.Image2;
                    else button313.Image = Properties.Resources.Image1;
                    break;
                case 315:
                    if (FisrtPlayer) button312.Image = Properties.Resources.Image2;
                    else button312.Image = Properties.Resources.Image1;
                    break;
                case 316:
                    if (FisrtPlayer) button311.Image = Properties.Resources.Image2;
                    else button311.Image = Properties.Resources.Image1;
                    break;
                case 317:
                    if (FisrtPlayer) button310.Image = Properties.Resources.Image2;
                    else button310.Image = Properties.Resources.Image1;
                    break;
                case 318:
                    if (FisrtPlayer) button309.Image = Properties.Resources.Image2;
                    else button309.Image = Properties.Resources.Image1;
                    break;
                case 319:
                    if (FisrtPlayer) button308.Image = Properties.Resources.Image2;
                    else button308.Image = Properties.Resources.Image1;
                    break;
                case 320:
                    if (FisrtPlayer) button307.Image = Properties.Resources.Image2;
                    else button307.Image = Properties.Resources.Image1;
                    break;
                case 321:
                    if (FisrtPlayer) button306.Image = Properties.Resources.Image2;
                    else button306.Image = Properties.Resources.Image1;
                    break;
                case 322:
                    if (FisrtPlayer) button305.Image = Properties.Resources.Image2;
                    else button305.Image = Properties.Resources.Image1;
                    break;
                case 323:
                    if (FisrtPlayer) button342.Image = Properties.Resources.Image2;
                    else button342.Image = Properties.Resources.Image1;
                    break;
                case 324:
                    if (FisrtPlayer) button341.Image = Properties.Resources.Image2;
                    else button341.Image = Properties.Resources.Image1;
                    break;
                case 325:
                    if (FisrtPlayer) button340.Image = Properties.Resources.Image2;
                    else button340.Image = Properties.Resources.Image1;
                    break;
                case 326:
                    if (FisrtPlayer) button339.Image = Properties.Resources.Image2;
                    else button339.Image = Properties.Resources.Image1;
                    break;
                case 327:
                    if (FisrtPlayer) button338.Image = Properties.Resources.Image2;
                    else button338.Image = Properties.Resources.Image1;
                    break;
                case 328:
                    if (FisrtPlayer) button337.Image = Properties.Resources.Image2;
                    else button337.Image = Properties.Resources.Image1;
                    break;
                case 329:
                    if (FisrtPlayer) button336.Image = Properties.Resources.Image2;
                    else button336.Image = Properties.Resources.Image1;
                    break;
                case 330:
                    if (FisrtPlayer) button335.Image = Properties.Resources.Image2;
                    else button335.Image = Properties.Resources.Image1;
                    break;
                case 331:
                    if (FisrtPlayer) button334.Image = Properties.Resources.Image2;
                    else button334.Image = Properties.Resources.Image1;
                    break;
                case 332:
                    if (FisrtPlayer) button333.Image = Properties.Resources.Image2;
                    else button333.Image = Properties.Resources.Image1;
                    break;
                case 333:
                    if (FisrtPlayer) button332.Image = Properties.Resources.Image2;
                    else button332.Image = Properties.Resources.Image1;
                    break;
                case 334:
                    if (FisrtPlayer) button331.Image = Properties.Resources.Image2;
                    else button331.Image = Properties.Resources.Image1;
                    break;
                case 335:
                    if (FisrtPlayer) button330.Image = Properties.Resources.Image2;
                    else button330.Image = Properties.Resources.Image1;
                    break;
                case 336:
                    if (FisrtPlayer) button329.Image = Properties.Resources.Image2;
                    else button329.Image = Properties.Resources.Image1;
                    break;
                case 337:
                    if (FisrtPlayer) button328.Image = Properties.Resources.Image2;
                    else button328.Image = Properties.Resources.Image1;
                    break;
                case 338:
                    if (FisrtPlayer) button327.Image = Properties.Resources.Image2;
                    else button327.Image = Properties.Resources.Image1;
                    break;
                case 339:
                    if (FisrtPlayer) button326.Image = Properties.Resources.Image2;
                    else button326.Image = Properties.Resources.Image1;
                    break;
                case 340:
                    if (FisrtPlayer) button325.Image = Properties.Resources.Image2;
                    else button325.Image = Properties.Resources.Image1;
                    break;
                case 341:
                    if (FisrtPlayer) button324.Image = Properties.Resources.Image2;
                    else button324.Image = Properties.Resources.Image1;
                    break;
                case 342:
                    if (FisrtPlayer) button361.Image = Properties.Resources.Image2;
                    else button361.Image = Properties.Resources.Image1;
                    break;
                case 343:
                    if (FisrtPlayer) button360.Image = Properties.Resources.Image2;
                    else button360.Image = Properties.Resources.Image1;
                    break;
                case 344:
                    if (FisrtPlayer) button359.Image = Properties.Resources.Image2;
                    else button359.Image = Properties.Resources.Image1;
                    break;
                case 345:
                    if (FisrtPlayer) button358.Image = Properties.Resources.Image2;
                    else button358.Image = Properties.Resources.Image1;
                    break;
                case 346:
                    if (FisrtPlayer) button357.Image = Properties.Resources.Image2;
                    else button357.Image = Properties.Resources.Image1;
                    break;
                case 347:
                    if (FisrtPlayer) button356.Image = Properties.Resources.Image2;
                    else button356.Image = Properties.Resources.Image1;
                    break;
                case 348:
                    if (FisrtPlayer) button355.Image = Properties.Resources.Image2;
                    else button355.Image = Properties.Resources.Image1;
                    break;
                case 349:
                    if (FisrtPlayer) button354.Image = Properties.Resources.Image2;
                    else button354.Image = Properties.Resources.Image1;
                    break;
                case 350:
                    if (FisrtPlayer) button353.Image = Properties.Resources.Image2;
                    else button353.Image = Properties.Resources.Image1;
                    break;
                case 351:
                    if (FisrtPlayer) button352.Image = Properties.Resources.Image2;
                    else button352.Image = Properties.Resources.Image1;
                    break;
                case 352:
                    if (FisrtPlayer) button351.Image = Properties.Resources.Image2;
                    else button351.Image = Properties.Resources.Image1;
                    break;
                case 353:
                    if (FisrtPlayer) button350.Image = Properties.Resources.Image2;
                    else button350.Image = Properties.Resources.Image1;
                    break;
                case 354:
                    if (FisrtPlayer) button349.Image = Properties.Resources.Image2;
                    else button349.Image = Properties.Resources.Image1;
                    break;
                case 355:
                    if (FisrtPlayer) button348.Image = Properties.Resources.Image2;
                    else button348.Image = Properties.Resources.Image1;
                    break;
                case 356:
                    if (FisrtPlayer) button347.Image = Properties.Resources.Image2;
                    else button347.Image = Properties.Resources.Image1;
                    break;
                case 357:
                    if (FisrtPlayer) button346.Image = Properties.Resources.Image2;
                    else button346.Image = Properties.Resources.Image1;
                    break;
                case 358:
                    if (FisrtPlayer) button345.Image = Properties.Resources.Image2;
                    else button345.Image = Properties.Resources.Image1;
                    break;
                case 359:
                    if (FisrtPlayer) button344.Image = Properties.Resources.Image2;
                    else button344.Image = Properties.Resources.Image1;
                    break;
                case 360:
                    if (FisrtPlayer) button343.Image = Properties.Resources.Image2;
                    else button343.Image = Properties.Resources.Image1;
                    break;


            }
            GameState = true;
            if (WinCheck(pos))
            {
                MessageBox.Show("AI Won");
                GameState = false;
            }
        }
        public bool WinCheck(int x)
        {
            int check = ChessBoard[x] % 2;
            int count = 1;
            int chpos = x;
            //lu-rd
            while (true)
            {
                if (chpos >= 20 && chpos % 19 != 1 && chpos / 19 > 0)
                    if (ChessBoard[chpos - 20] % 2 == check && ChessBoard[chpos - 20] != 0)
                        count++;
                    else break;
                else break;
                chpos = chpos - 20;
                if (count == 5) return true;
            }
            chpos = x;
            while (true)
            {
                if (chpos <= 340 && chpos % 19 > 0 && chpos / 19 < 18)
                    if (ChessBoard[chpos + 20] % 2 == check && ChessBoard[chpos + 20] != 0)
                        count++;
                    else break;
                else break;
                chpos = chpos + 20;
                if (count == 5) return true;
            }
            chpos = x;
            count = 1;

            //ld-ru
            while (true)
            {
                if (chpos >= 18 && chpos % 19 > 0 && chpos / 19 > 0)
                    if (ChessBoard[chpos - 18] % 2 == check && ChessBoard[chpos - 18] != 0)
                        count++;
                    else break;
                else break;
                chpos = chpos - 18;
                if (count == 5) return true;
            }
            chpos = x;
            while (true)
            {
                if (chpos <= 342 && chpos % 19 != 1 && chpos / 19 < 18)
                    if (ChessBoard[chpos + 18] % 2 == check && ChessBoard[chpos + 18] != 0)
                        count++;
                    else break;
                else break;
                chpos = chpos + 18;
                if (count == 5) return true;
            }
            chpos = x;
            count = 1;

            //l-r
            while (true)
            {
                if (chpos >= 1 && chpos % 19 != 1)
                    if (ChessBoard[chpos - 1] % 2 == check && ChessBoard[chpos - 1] != 0)
                        count++;
                    else break;
                else break;
                chpos = chpos - 1;
                if (count == 5) return true;
            }
            chpos = x;
            while (true)
            {
                if (chpos <= 359 && chpos % 19 > 0)
                    if (ChessBoard[chpos + 1] % 2 == check && ChessBoard[chpos + 1] != 0)
                        count++;
                    else break;
                else break;
                chpos = chpos + 1;
                if (count == 5) return true;
            }
            chpos = x;
            count = 1;

            //u-d
            while (true)
            {
                if (chpos >= 19 && chpos / 19 > 0)
                    if (ChessBoard[chpos - 19] % 2 == check && ChessBoard[chpos - 19] != 0)
                        count++;
                    else break;
                else break;
                chpos = chpos - 19;
                if (count == 5) return true;
            }
            chpos = x;
            while (true)
            {
                if (chpos <= 341 && chpos / 19 < 18)
                    if (ChessBoard[chpos + 19] % 2 == check && ChessBoard[chpos + 19] != 0)
                        count++;
                    else break;
                else break;
                chpos = chpos + 19;
                if (count == 5) return true;
            }
            return false;
        }
        private void button362_Click(object sender, EventArgs e)
        {
            ChessBoard = new int[361];
            button1.Image = Properties.Resources.blank;
            button2.Image = Properties.Resources.blank;
            button3.Image = Properties.Resources.blank;
            button4.Image = Properties.Resources.blank;
            button5.Image = Properties.Resources.blank;
            button6.Image = Properties.Resources.blank;
            button7.Image = Properties.Resources.blank;
            button8.Image = Properties.Resources.blank;
            button9.Image = Properties.Resources.blank;
            button10.Image = Properties.Resources.blank;
            button11.Image = Properties.Resources.blank;
            button12.Image = Properties.Resources.blank;
            button13.Image = Properties.Resources.blank;
            button14.Image = Properties.Resources.blank;
            button15.Image = Properties.Resources.blank;
            button16.Image = Properties.Resources.blank;
            button17.Image = Properties.Resources.blank;
            button18.Image = Properties.Resources.blank;
            button19.Image = Properties.Resources.blank;
            button20.Image = Properties.Resources.blank;
            button21.Image = Properties.Resources.blank;
            button22.Image = Properties.Resources.blank;
            button23.Image = Properties.Resources.blank;
            button24.Image = Properties.Resources.blank;
            button25.Image = Properties.Resources.blank;
            button26.Image = Properties.Resources.blank;
            button27.Image = Properties.Resources.blank;
            button28.Image = Properties.Resources.blank;
            button29.Image = Properties.Resources.blank;
            button30.Image = Properties.Resources.blank;
            button31.Image = Properties.Resources.blank;
            button32.Image = Properties.Resources.blank;
            button33.Image = Properties.Resources.blank;
            button34.Image = Properties.Resources.blank;
            button35.Image = Properties.Resources.blank;
            button36.Image = Properties.Resources.blank;
            button37.Image = Properties.Resources.blank;
            button38.Image = Properties.Resources.blank;
            button39.Image = Properties.Resources.blank;
            button40.Image = Properties.Resources.blank;
            button41.Image = Properties.Resources.blank;
            button42.Image = Properties.Resources.blank;
            button43.Image = Properties.Resources.blank;
            button44.Image = Properties.Resources.blank;
            button45.Image = Properties.Resources.blank;
            button46.Image = Properties.Resources.blank;
            button47.Image = Properties.Resources.blank;
            button48.Image = Properties.Resources.blank;
            button49.Image = Properties.Resources.blank;
            button50.Image = Properties.Resources.blank;
            button51.Image = Properties.Resources.blank;
            button52.Image = Properties.Resources.blank;
            button53.Image = Properties.Resources.blank;
            button54.Image = Properties.Resources.blank;
            button55.Image = Properties.Resources.blank;
            button56.Image = Properties.Resources.blank;
            button57.Image = Properties.Resources.blank;
            button58.Image = Properties.Resources.blank;
            button59.Image = Properties.Resources.blank;
            button60.Image = Properties.Resources.blank;
            button61.Image = Properties.Resources.blank;
            button62.Image = Properties.Resources.blank;
            button63.Image = Properties.Resources.blank;
            button64.Image = Properties.Resources.blank;
            button65.Image = Properties.Resources.blank;
            button66.Image = Properties.Resources.blank;
            button67.Image = Properties.Resources.blank;
            button68.Image = Properties.Resources.blank;
            button69.Image = Properties.Resources.blank;
            button70.Image = Properties.Resources.blank;
            button71.Image = Properties.Resources.blank;
            button72.Image = Properties.Resources.blank;
            button73.Image = Properties.Resources.blank;
            button74.Image = Properties.Resources.blank;
            button75.Image = Properties.Resources.blank;
            button76.Image = Properties.Resources.blank;
            button77.Image = Properties.Resources.blank;
            button78.Image = Properties.Resources.blank;
            button79.Image = Properties.Resources.blank;
            button80.Image = Properties.Resources.blank;
            button81.Image = Properties.Resources.blank;
            button82.Image = Properties.Resources.blank;
            button83.Image = Properties.Resources.blank;
            button84.Image = Properties.Resources.blank;
            button85.Image = Properties.Resources.blank;
            button86.Image = Properties.Resources.blank;
            button87.Image = Properties.Resources.blank;
            button88.Image = Properties.Resources.blank;
            button89.Image = Properties.Resources.blank;
            button90.Image = Properties.Resources.blank;
            button91.Image = Properties.Resources.blank;
            button92.Image = Properties.Resources.blank;
            button93.Image = Properties.Resources.blank;
            button94.Image = Properties.Resources.blank;
            button95.Image = Properties.Resources.blank;
            button96.Image = Properties.Resources.blank;
            button97.Image = Properties.Resources.blank;
            button98.Image = Properties.Resources.blank;
            button99.Image = Properties.Resources.blank;
            button100.Image = Properties.Resources.blank;
            button101.Image = Properties.Resources.blank;
            button102.Image = Properties.Resources.blank;
            button103.Image = Properties.Resources.blank;
            button104.Image = Properties.Resources.blank;
            button105.Image = Properties.Resources.blank;
            button106.Image = Properties.Resources.blank;
            button107.Image = Properties.Resources.blank;
            button108.Image = Properties.Resources.blank;
            button109.Image = Properties.Resources.blank;
            button110.Image = Properties.Resources.blank;
            button111.Image = Properties.Resources.blank;
            button112.Image = Properties.Resources.blank;
            button113.Image = Properties.Resources.blank;
            button114.Image = Properties.Resources.blank;
            button115.Image = Properties.Resources.blank;
            button116.Image = Properties.Resources.blank;
            button117.Image = Properties.Resources.blank;
            button118.Image = Properties.Resources.blank;
            button119.Image = Properties.Resources.blank;
            button120.Image = Properties.Resources.blank;
            button121.Image = Properties.Resources.blank;
            button122.Image = Properties.Resources.blank;
            button123.Image = Properties.Resources.blank;
            button124.Image = Properties.Resources.blank;
            button125.Image = Properties.Resources.blank;
            button126.Image = Properties.Resources.blank;
            button127.Image = Properties.Resources.blank;
            button128.Image = Properties.Resources.blank;
            button129.Image = Properties.Resources.blank;
            button130.Image = Properties.Resources.blank;
            button131.Image = Properties.Resources.blank;
            button132.Image = Properties.Resources.blank;
            button133.Image = Properties.Resources.blank;
            button134.Image = Properties.Resources.blank;
            button135.Image = Properties.Resources.blank;
            button136.Image = Properties.Resources.blank;
            button137.Image = Properties.Resources.blank;
            button138.Image = Properties.Resources.blank;
            button139.Image = Properties.Resources.blank;
            button140.Image = Properties.Resources.blank;
            button141.Image = Properties.Resources.blank;
            button142.Image = Properties.Resources.blank;
            button143.Image = Properties.Resources.blank;
            button144.Image = Properties.Resources.blank;
            button145.Image = Properties.Resources.blank;
            button146.Image = Properties.Resources.blank;
            button147.Image = Properties.Resources.blank;
            button148.Image = Properties.Resources.blank;
            button149.Image = Properties.Resources.blank;
            button150.Image = Properties.Resources.blank;
            button151.Image = Properties.Resources.blank;
            button152.Image = Properties.Resources.blank;
            button153.Image = Properties.Resources.blank;
            button154.Image = Properties.Resources.blank;
            button155.Image = Properties.Resources.blank;
            button156.Image = Properties.Resources.blank;
            button157.Image = Properties.Resources.blank;
            button158.Image = Properties.Resources.blank;
            button159.Image = Properties.Resources.blank;
            button160.Image = Properties.Resources.blank;
            button161.Image = Properties.Resources.blank;
            button162.Image = Properties.Resources.blank;
            button163.Image = Properties.Resources.blank;
            button164.Image = Properties.Resources.blank;
            button165.Image = Properties.Resources.blank;
            button166.Image = Properties.Resources.blank;
            button167.Image = Properties.Resources.blank;
            button168.Image = Properties.Resources.blank;
            button169.Image = Properties.Resources.blank;
            button170.Image = Properties.Resources.blank;
            button171.Image = Properties.Resources.blank;
            button172.Image = Properties.Resources.blank;
            button173.Image = Properties.Resources.blank;
            button174.Image = Properties.Resources.blank;
            button175.Image = Properties.Resources.blank;
            button176.Image = Properties.Resources.blank;
            button177.Image = Properties.Resources.blank;
            button178.Image = Properties.Resources.blank;
            button179.Image = Properties.Resources.blank;
            button180.Image = Properties.Resources.blank;
            button181.Image = Properties.Resources.blank;
            button182.Image = Properties.Resources.blank;
            button183.Image = Properties.Resources.blank;
            button184.Image = Properties.Resources.blank;
            button185.Image = Properties.Resources.blank;
            button186.Image = Properties.Resources.blank;
            button187.Image = Properties.Resources.blank;
            button188.Image = Properties.Resources.blank;
            button189.Image = Properties.Resources.blank;
            button190.Image = Properties.Resources.blank;
            button191.Image = Properties.Resources.blank;
            button192.Image = Properties.Resources.blank;
            button193.Image = Properties.Resources.blank;
            button194.Image = Properties.Resources.blank;
            button195.Image = Properties.Resources.blank;
            button196.Image = Properties.Resources.blank;
            button197.Image = Properties.Resources.blank;
            button198.Image = Properties.Resources.blank;
            button199.Image = Properties.Resources.blank;
            button200.Image = Properties.Resources.blank;
            button201.Image = Properties.Resources.blank;
            button202.Image = Properties.Resources.blank;
            button203.Image = Properties.Resources.blank;
            button204.Image = Properties.Resources.blank;
            button205.Image = Properties.Resources.blank;
            button206.Image = Properties.Resources.blank;
            button207.Image = Properties.Resources.blank;
            button208.Image = Properties.Resources.blank;
            button209.Image = Properties.Resources.blank;
            button210.Image = Properties.Resources.blank;
            button211.Image = Properties.Resources.blank;
            button212.Image = Properties.Resources.blank;
            button213.Image = Properties.Resources.blank;
            button214.Image = Properties.Resources.blank;
            button215.Image = Properties.Resources.blank;
            button216.Image = Properties.Resources.blank;
            button217.Image = Properties.Resources.blank;
            button218.Image = Properties.Resources.blank;
            button219.Image = Properties.Resources.blank;
            button220.Image = Properties.Resources.blank;
            button221.Image = Properties.Resources.blank;
            button222.Image = Properties.Resources.blank;
            button223.Image = Properties.Resources.blank;
            button224.Image = Properties.Resources.blank;
            button225.Image = Properties.Resources.blank;
            button226.Image = Properties.Resources.blank;
            button227.Image = Properties.Resources.blank;
            button228.Image = Properties.Resources.blank;
            button229.Image = Properties.Resources.blank;
            button230.Image = Properties.Resources.blank;
            button231.Image = Properties.Resources.blank;
            button232.Image = Properties.Resources.blank;
            button233.Image = Properties.Resources.blank;
            button234.Image = Properties.Resources.blank;
            button235.Image = Properties.Resources.blank;
            button236.Image = Properties.Resources.blank;
            button237.Image = Properties.Resources.blank;
            button238.Image = Properties.Resources.blank;
            button239.Image = Properties.Resources.blank;
            button240.Image = Properties.Resources.blank;
            button241.Image = Properties.Resources.blank;
            button242.Image = Properties.Resources.blank;
            button243.Image = Properties.Resources.blank;
            button244.Image = Properties.Resources.blank;
            button245.Image = Properties.Resources.blank;
            button246.Image = Properties.Resources.blank;
            button247.Image = Properties.Resources.blank;
            button248.Image = Properties.Resources.blank;
            button249.Image = Properties.Resources.blank;
            button250.Image = Properties.Resources.blank;
            button251.Image = Properties.Resources.blank;
            button252.Image = Properties.Resources.blank;
            button253.Image = Properties.Resources.blank;
            button254.Image = Properties.Resources.blank;
            button255.Image = Properties.Resources.blank;
            button256.Image = Properties.Resources.blank;
            button257.Image = Properties.Resources.blank;
            button258.Image = Properties.Resources.blank;
            button259.Image = Properties.Resources.blank;
            button260.Image = Properties.Resources.blank;
            button261.Image = Properties.Resources.blank;
            button262.Image = Properties.Resources.blank;
            button263.Image = Properties.Resources.blank;
            button264.Image = Properties.Resources.blank;
            button265.Image = Properties.Resources.blank;
            button266.Image = Properties.Resources.blank;
            button267.Image = Properties.Resources.blank;
            button268.Image = Properties.Resources.blank;
            button269.Image = Properties.Resources.blank;
            button270.Image = Properties.Resources.blank;
            button271.Image = Properties.Resources.blank;
            button272.Image = Properties.Resources.blank;
            button273.Image = Properties.Resources.blank;
            button274.Image = Properties.Resources.blank;
            button275.Image = Properties.Resources.blank;
            button276.Image = Properties.Resources.blank;
            button277.Image = Properties.Resources.blank;
            button278.Image = Properties.Resources.blank;
            button279.Image = Properties.Resources.blank;
            button280.Image = Properties.Resources.blank;
            button281.Image = Properties.Resources.blank;
            button282.Image = Properties.Resources.blank;
            button283.Image = Properties.Resources.blank;
            button284.Image = Properties.Resources.blank;
            button285.Image = Properties.Resources.blank;
            button286.Image = Properties.Resources.blank;
            button287.Image = Properties.Resources.blank;
            button288.Image = Properties.Resources.blank;
            button289.Image = Properties.Resources.blank;
            button290.Image = Properties.Resources.blank;
            button291.Image = Properties.Resources.blank;
            button292.Image = Properties.Resources.blank;
            button293.Image = Properties.Resources.blank;
            button294.Image = Properties.Resources.blank;
            button295.Image = Properties.Resources.blank;
            button296.Image = Properties.Resources.blank;
            button297.Image = Properties.Resources.blank;
            button298.Image = Properties.Resources.blank;
            button299.Image = Properties.Resources.blank;
            button300.Image = Properties.Resources.blank;
            button301.Image = Properties.Resources.blank;
            button302.Image = Properties.Resources.blank;
            button303.Image = Properties.Resources.blank;
            button304.Image = Properties.Resources.blank;
            button305.Image = Properties.Resources.blank;
            button306.Image = Properties.Resources.blank;
            button307.Image = Properties.Resources.blank;
            button308.Image = Properties.Resources.blank;
            button309.Image = Properties.Resources.blank;
            button310.Image = Properties.Resources.blank;
            button311.Image = Properties.Resources.blank;
            button312.Image = Properties.Resources.blank;
            button313.Image = Properties.Resources.blank;
            button314.Image = Properties.Resources.blank;
            button315.Image = Properties.Resources.blank;
            button316.Image = Properties.Resources.blank;
            button317.Image = Properties.Resources.blank;
            button318.Image = Properties.Resources.blank;
            button319.Image = Properties.Resources.blank;
            button320.Image = Properties.Resources.blank;
            button321.Image = Properties.Resources.blank;
            button322.Image = Properties.Resources.blank;
            button323.Image = Properties.Resources.blank;
            button324.Image = Properties.Resources.blank;
            button325.Image = Properties.Resources.blank;
            button326.Image = Properties.Resources.blank;
            button327.Image = Properties.Resources.blank;
            button328.Image = Properties.Resources.blank;
            button329.Image = Properties.Resources.blank;
            button330.Image = Properties.Resources.blank;
            button331.Image = Properties.Resources.blank;
            button332.Image = Properties.Resources.blank;
            button333.Image = Properties.Resources.blank;
            button334.Image = Properties.Resources.blank;
            button335.Image = Properties.Resources.blank;
            button336.Image = Properties.Resources.blank;
            button337.Image = Properties.Resources.blank;
            button338.Image = Properties.Resources.blank;
            button339.Image = Properties.Resources.blank;
            button340.Image = Properties.Resources.blank;
            button341.Image = Properties.Resources.blank;
            button342.Image = Properties.Resources.blank;
            button343.Image = Properties.Resources.blank;
            button344.Image = Properties.Resources.blank;
            button345.Image = Properties.Resources.blank;
            button346.Image = Properties.Resources.blank;
            button347.Image = Properties.Resources.blank;
            button348.Image = Properties.Resources.blank;
            button349.Image = Properties.Resources.blank;
            button350.Image = Properties.Resources.blank;
            button351.Image = Properties.Resources.blank;
            button352.Image = Properties.Resources.blank;
            button353.Image = Properties.Resources.blank;
            button354.Image = Properties.Resources.blank;
            button355.Image = Properties.Resources.blank;
            button356.Image = Properties.Resources.blank;
            button357.Image = Properties.Resources.blank;
            button358.Image = Properties.Resources.blank;
            button359.Image = Properties.Resources.blank;
            button360.Image = Properties.Resources.blank;
            button361.Image = Properties.Resources.blank;

            for (int i=0;i<361;i++)
            {
                string path = folderBrowserDialog1.SelectedPath;
                string filepath = string.Concat(path, "\\", i.ToString(), ".txt");
                if (File.Exists(filepath)) File.Delete(filepath);
            }
            if (listBox1.SelectedIndex == 0)
            {
                steps = 0;
                FisrtPlayer = true;
                GameState = true;
            }
            else
            {
                steps = 0;
                FisrtPlayer = false;
                GameState = false;
                string path = folderBrowserDialog1.SelectedPath;
                string filepath = string.Concat(path, "\\", steps.ToString(), ".txt");
                File.Create(filepath);
                steps++;
                filepath = string.Concat(path, "\\", steps.ToString(), ".txt");
                while (!File.Exists(filepath)) { GameState = false; }
                Thread.Sleep(100);
                string response_data = File.ReadAllText(filepath);
                int pos = int.Parse(response_data);
                ChessBoard[pos] = steps;
                switch (pos)
                {
                    case 0:
                        if (FisrtPlayer) button19.Image = Properties.Resources.Image2;
                        else button19.Image = Properties.Resources.Image1;
                        break;
                    case 1:
                        if (FisrtPlayer) button18.Image = Properties.Resources.Image2;
                        else button18.Image = Properties.Resources.Image1;
                        break;
                    case 2:
                        if (FisrtPlayer) button17.Image = Properties.Resources.Image2;
                        else button17.Image = Properties.Resources.Image1;
                        break;
                    case 3:
                        if (FisrtPlayer) button16.Image = Properties.Resources.Image2;
                        else button16.Image = Properties.Resources.Image1;
                        break;
                    case 4:
                        if (FisrtPlayer) button15.Image = Properties.Resources.Image2;
                        else button15.Image = Properties.Resources.Image1;
                        break;
                    case 5:
                        if (FisrtPlayer) button14.Image = Properties.Resources.Image2;
                        else button14.Image = Properties.Resources.Image1;
                        break;
                    case 6:
                        if (FisrtPlayer) button13.Image = Properties.Resources.Image2;
                        else button13.Image = Properties.Resources.Image1;
                        break;
                    case 7:
                        if (FisrtPlayer) button12.Image = Properties.Resources.Image2;
                        else button12.Image = Properties.Resources.Image1;
                        break;
                    case 8:
                        if (FisrtPlayer) button11.Image = Properties.Resources.Image2;
                        else button11.Image = Properties.Resources.Image1;
                        break;
                    case 9:
                        if (FisrtPlayer) button10.Image = Properties.Resources.Image2;
                        else button10.Image = Properties.Resources.Image1;
                        break;
                    case 10:
                        if (FisrtPlayer) button9.Image = Properties.Resources.Image2;
                        else button9.Image = Properties.Resources.Image1;
                        break;
                    case 11:
                        if (FisrtPlayer) button8.Image = Properties.Resources.Image2;
                        else button8.Image = Properties.Resources.Image1;
                        break;
                    case 12:
                        if (FisrtPlayer) button7.Image = Properties.Resources.Image2;
                        else button7.Image = Properties.Resources.Image1;
                        break;
                    case 13:
                        if (FisrtPlayer) button6.Image = Properties.Resources.Image2;
                        else button6.Image = Properties.Resources.Image1;
                        break;
                    case 14:
                        if (FisrtPlayer) button5.Image = Properties.Resources.Image2;
                        else button5.Image = Properties.Resources.Image1;
                        break;
                    case 15:
                        if (FisrtPlayer) button4.Image = Properties.Resources.Image2;
                        else button4.Image = Properties.Resources.Image1;
                        break;
                    case 16:
                        if (FisrtPlayer) button3.Image = Properties.Resources.Image2;
                        else button3.Image = Properties.Resources.Image1;
                        break;
                    case 17:
                        if (FisrtPlayer) button2.Image = Properties.Resources.Image2;
                        else button2.Image = Properties.Resources.Image1;
                        break;
                    case 18:
                        if (FisrtPlayer) button1.Image = Properties.Resources.Image2;
                        else button1.Image = Properties.Resources.Image1;
                        break;
                    case 19:
                        if (FisrtPlayer) button38.Image = Properties.Resources.Image2;
                        else button38.Image = Properties.Resources.Image1;
                        break;
                    case 20:
                        if (FisrtPlayer) button37.Image = Properties.Resources.Image2;
                        else button37.Image = Properties.Resources.Image1;
                        break;
                    case 21:
                        if (FisrtPlayer) button36.Image = Properties.Resources.Image2;
                        else button36.Image = Properties.Resources.Image1;
                        break;
                    case 22:
                        if (FisrtPlayer) button35.Image = Properties.Resources.Image2;
                        else button35.Image = Properties.Resources.Image1;
                        break;
                    case 23:
                        if (FisrtPlayer) button34.Image = Properties.Resources.Image2;
                        else button34.Image = Properties.Resources.Image1;
                        break;
                    case 24:
                        if (FisrtPlayer) button33.Image = Properties.Resources.Image2;
                        else button33.Image = Properties.Resources.Image1;
                        break;
                    case 25:
                        if (FisrtPlayer) button32.Image = Properties.Resources.Image2;
                        else button32.Image = Properties.Resources.Image1;
                        break;
                    case 26:
                        if (FisrtPlayer) button31.Image = Properties.Resources.Image2;
                        else button31.Image = Properties.Resources.Image1;
                        break;
                    case 27:
                        if (FisrtPlayer) button30.Image = Properties.Resources.Image2;
                        else button30.Image = Properties.Resources.Image1;
                        break;
                    case 28:
                        if (FisrtPlayer) button29.Image = Properties.Resources.Image2;
                        else button29.Image = Properties.Resources.Image1;
                        break;
                    case 29:
                        if (FisrtPlayer) button28.Image = Properties.Resources.Image2;
                        else button28.Image = Properties.Resources.Image1;
                        break;
                    case 30:
                        if (FisrtPlayer) button27.Image = Properties.Resources.Image2;
                        else button27.Image = Properties.Resources.Image1;
                        break;
                    case 31:
                        if (FisrtPlayer) button26.Image = Properties.Resources.Image2;
                        else button26.Image = Properties.Resources.Image1;
                        break;
                    case 32:
                        if (FisrtPlayer) button25.Image = Properties.Resources.Image2;
                        else button25.Image = Properties.Resources.Image1;
                        break;
                    case 33:
                        if (FisrtPlayer) button24.Image = Properties.Resources.Image2;
                        else button24.Image = Properties.Resources.Image1;
                        break;
                    case 34:
                        if (FisrtPlayer) button23.Image = Properties.Resources.Image2;
                        else button23.Image = Properties.Resources.Image1;
                        break;
                    case 35:
                        if (FisrtPlayer) button22.Image = Properties.Resources.Image2;
                        else button22.Image = Properties.Resources.Image1;
                        break;
                    case 36:
                        if (FisrtPlayer) button21.Image = Properties.Resources.Image2;
                        else button21.Image = Properties.Resources.Image1;
                        break;
                    case 37:
                        if (FisrtPlayer) button20.Image = Properties.Resources.Image2;
                        else button20.Image = Properties.Resources.Image1;
                        break;
                    case 38:
                        if (FisrtPlayer) button57.Image = Properties.Resources.Image2;
                        else button57.Image = Properties.Resources.Image1;
                        break;
                    case 39:
                        if (FisrtPlayer) button56.Image = Properties.Resources.Image2;
                        else button56.Image = Properties.Resources.Image1;
                        break;
                    case 40:
                        if (FisrtPlayer) button55.Image = Properties.Resources.Image2;
                        else button55.Image = Properties.Resources.Image1;
                        break;
                    case 41:
                        if (FisrtPlayer) button54.Image = Properties.Resources.Image2;
                        else button54.Image = Properties.Resources.Image1;
                        break;
                    case 42:
                        if (FisrtPlayer) button53.Image = Properties.Resources.Image2;
                        else button53.Image = Properties.Resources.Image1;
                        break;
                    case 43:
                        if (FisrtPlayer) button52.Image = Properties.Resources.Image2;
                        else button52.Image = Properties.Resources.Image1;
                        break;
                    case 44:
                        if (FisrtPlayer) button51.Image = Properties.Resources.Image2;
                        else button51.Image = Properties.Resources.Image1;
                        break;
                    case 45:
                        if (FisrtPlayer) button50.Image = Properties.Resources.Image2;
                        else button50.Image = Properties.Resources.Image1;
                        break;
                    case 46:
                        if (FisrtPlayer) button49.Image = Properties.Resources.Image2;
                        else button49.Image = Properties.Resources.Image1;
                        break;
                    case 47:
                        if (FisrtPlayer) button48.Image = Properties.Resources.Image2;
                        else button48.Image = Properties.Resources.Image1;
                        break;
                    case 48:
                        if (FisrtPlayer) button47.Image = Properties.Resources.Image2;
                        else button47.Image = Properties.Resources.Image1;
                        break;
                    case 49:
                        if (FisrtPlayer) button46.Image = Properties.Resources.Image2;
                        else button46.Image = Properties.Resources.Image1;
                        break;
                    case 50:
                        if (FisrtPlayer) button45.Image = Properties.Resources.Image2;
                        else button45.Image = Properties.Resources.Image1;
                        break;
                    case 51:
                        if (FisrtPlayer) button44.Image = Properties.Resources.Image2;
                        else button44.Image = Properties.Resources.Image1;
                        break;
                    case 52:
                        if (FisrtPlayer) button43.Image = Properties.Resources.Image2;
                        else button43.Image = Properties.Resources.Image1;
                        break;
                    case 53:
                        if (FisrtPlayer) button42.Image = Properties.Resources.Image2;
                        else button42.Image = Properties.Resources.Image1;
                        break;
                    case 54:
                        if (FisrtPlayer) button41.Image = Properties.Resources.Image2;
                        else button41.Image = Properties.Resources.Image1;
                        break;
                    case 55:
                        if (FisrtPlayer) button40.Image = Properties.Resources.Image2;
                        else button40.Image = Properties.Resources.Image1;
                        break;
                    case 56:
                        if (FisrtPlayer) button39.Image = Properties.Resources.Image2;
                        else button39.Image = Properties.Resources.Image1;
                        break;
                    case 57:
                        if (FisrtPlayer) button76.Image = Properties.Resources.Image2;
                        else button76.Image = Properties.Resources.Image1;
                        break;
                    case 58:
                        if (FisrtPlayer) button75.Image = Properties.Resources.Image2;
                        else button75.Image = Properties.Resources.Image1;
                        break;
                    case 59:
                        if (FisrtPlayer) button74.Image = Properties.Resources.Image2;
                        else button74.Image = Properties.Resources.Image1;
                        break;
                    case 60:
                        if (FisrtPlayer) button73.Image = Properties.Resources.Image2;
                        else button73.Image = Properties.Resources.Image1;
                        break;
                    case 61:
                        if (FisrtPlayer) button72.Image = Properties.Resources.Image2;
                        else button72.Image = Properties.Resources.Image1;
                        break;
                    case 62:
                        if (FisrtPlayer) button71.Image = Properties.Resources.Image2;
                        else button71.Image = Properties.Resources.Image1;
                        break;
                    case 63:
                        if (FisrtPlayer) button70.Image = Properties.Resources.Image2;
                        else button70.Image = Properties.Resources.Image1;
                        break;
                    case 64:
                        if (FisrtPlayer) button69.Image = Properties.Resources.Image2;
                        else button69.Image = Properties.Resources.Image1;
                        break;
                    case 65:
                        if (FisrtPlayer) button68.Image = Properties.Resources.Image2;
                        else button68.Image = Properties.Resources.Image1;
                        break;
                    case 66:
                        if (FisrtPlayer) button67.Image = Properties.Resources.Image2;
                        else button67.Image = Properties.Resources.Image1;
                        break;
                    case 67:
                        if (FisrtPlayer) button66.Image = Properties.Resources.Image2;
                        else button66.Image = Properties.Resources.Image1;
                        break;
                    case 68:
                        if (FisrtPlayer) button65.Image = Properties.Resources.Image2;
                        else button65.Image = Properties.Resources.Image1;
                        break;
                    case 69:
                        if (FisrtPlayer) button64.Image = Properties.Resources.Image2;
                        else button64.Image = Properties.Resources.Image1;
                        break;
                    case 70:
                        if (FisrtPlayer) button63.Image = Properties.Resources.Image2;
                        else button63.Image = Properties.Resources.Image1;
                        break;
                    case 71:
                        if (FisrtPlayer) button62.Image = Properties.Resources.Image2;
                        else button62.Image = Properties.Resources.Image1;
                        break;
                    case 72:
                        if (FisrtPlayer) button61.Image = Properties.Resources.Image2;
                        else button61.Image = Properties.Resources.Image1;
                        break;
                    case 73:
                        if (FisrtPlayer) button60.Image = Properties.Resources.Image2;
                        else button60.Image = Properties.Resources.Image1;
                        break;
                    case 74:
                        if (FisrtPlayer) button59.Image = Properties.Resources.Image2;
                        else button59.Image = Properties.Resources.Image1;
                        break;
                    case 75:
                        if (FisrtPlayer) button58.Image = Properties.Resources.Image2;
                        else button58.Image = Properties.Resources.Image1;
                        break;
                    case 76:
                        if (FisrtPlayer) button95.Image = Properties.Resources.Image2;
                        else button95.Image = Properties.Resources.Image1;
                        break;
                    case 77:
                        if (FisrtPlayer) button94.Image = Properties.Resources.Image2;
                        else button94.Image = Properties.Resources.Image1;
                        break;
                    case 78:
                        if (FisrtPlayer) button93.Image = Properties.Resources.Image2;
                        else button93.Image = Properties.Resources.Image1;
                        break;
                    case 79:
                        if (FisrtPlayer) button92.Image = Properties.Resources.Image2;
                        else button92.Image = Properties.Resources.Image1;
                        break;
                    case 80:
                        if (FisrtPlayer) button91.Image = Properties.Resources.Image2;
                        else button91.Image = Properties.Resources.Image1;
                        break;
                    case 81:
                        if (FisrtPlayer) button90.Image = Properties.Resources.Image2;
                        else button90.Image = Properties.Resources.Image1;
                        break;
                    case 82:
                        if (FisrtPlayer) button89.Image = Properties.Resources.Image2;
                        else button89.Image = Properties.Resources.Image1;
                        break;
                    case 83:
                        if (FisrtPlayer) button88.Image = Properties.Resources.Image2;
                        else button88.Image = Properties.Resources.Image1;
                        break;
                    case 84:
                        if (FisrtPlayer) button87.Image = Properties.Resources.Image2;
                        else button87.Image = Properties.Resources.Image1;
                        break;
                    case 85:
                        if (FisrtPlayer) button86.Image = Properties.Resources.Image2;
                        else button86.Image = Properties.Resources.Image1;
                        break;
                    case 86:
                        if (FisrtPlayer) button85.Image = Properties.Resources.Image2;
                        else button85.Image = Properties.Resources.Image1;
                        break;
                    case 87:
                        if (FisrtPlayer) button84.Image = Properties.Resources.Image2;
                        else button84.Image = Properties.Resources.Image1;
                        break;
                    case 88:
                        if (FisrtPlayer) button83.Image = Properties.Resources.Image2;
                        else button83.Image = Properties.Resources.Image1;
                        break;
                    case 89:
                        if (FisrtPlayer) button82.Image = Properties.Resources.Image2;
                        else button82.Image = Properties.Resources.Image1;
                        break;
                    case 90:
                        if (FisrtPlayer) button81.Image = Properties.Resources.Image2;
                        else button81.Image = Properties.Resources.Image1;
                        break;
                    case 91:
                        if (FisrtPlayer) button80.Image = Properties.Resources.Image2;
                        else button80.Image = Properties.Resources.Image1;
                        break;
                    case 92:
                        if (FisrtPlayer) button79.Image = Properties.Resources.Image2;
                        else button79.Image = Properties.Resources.Image1;
                        break;
                    case 93:
                        if (FisrtPlayer) button78.Image = Properties.Resources.Image2;
                        else button78.Image = Properties.Resources.Image1;
                        break;
                    case 94:
                        if (FisrtPlayer) button77.Image = Properties.Resources.Image2;
                        else button77.Image = Properties.Resources.Image1;
                        break;
                    case 95:
                        if (FisrtPlayer) button114.Image = Properties.Resources.Image2;
                        else button114.Image = Properties.Resources.Image1;
                        break;
                    case 96:
                        if (FisrtPlayer) button113.Image = Properties.Resources.Image2;
                        else button113.Image = Properties.Resources.Image1;
                        break;
                    case 97:
                        if (FisrtPlayer) button112.Image = Properties.Resources.Image2;
                        else button112.Image = Properties.Resources.Image1;
                        break;
                    case 98:
                        if (FisrtPlayer) button111.Image = Properties.Resources.Image2;
                        else button111.Image = Properties.Resources.Image1;
                        break;
                    case 99:
                        if (FisrtPlayer) button110.Image = Properties.Resources.Image2;
                        else button110.Image = Properties.Resources.Image1;
                        break;
                    case 100:
                        if (FisrtPlayer) button109.Image = Properties.Resources.Image2;
                        else button109.Image = Properties.Resources.Image1;
                        break;
                    case 101:
                        if (FisrtPlayer) button108.Image = Properties.Resources.Image2;
                        else button108.Image = Properties.Resources.Image1;
                        break;
                    case 102:
                        if (FisrtPlayer) button107.Image = Properties.Resources.Image2;
                        else button107.Image = Properties.Resources.Image1;
                        break;
                    case 103:
                        if (FisrtPlayer) button106.Image = Properties.Resources.Image2;
                        else button106.Image = Properties.Resources.Image1;
                        break;
                    case 104:
                        if (FisrtPlayer) button105.Image = Properties.Resources.Image2;
                        else button105.Image = Properties.Resources.Image1;
                        break;
                    case 105:
                        if (FisrtPlayer) button104.Image = Properties.Resources.Image2;
                        else button104.Image = Properties.Resources.Image1;
                        break;
                    case 106:
                        if (FisrtPlayer) button103.Image = Properties.Resources.Image2;
                        else button103.Image = Properties.Resources.Image1;
                        break;
                    case 107:
                        if (FisrtPlayer) button102.Image = Properties.Resources.Image2;
                        else button102.Image = Properties.Resources.Image1;
                        break;
                    case 108:
                        if (FisrtPlayer) button101.Image = Properties.Resources.Image2;
                        else button101.Image = Properties.Resources.Image1;
                        break;
                    case 109:
                        if (FisrtPlayer) button100.Image = Properties.Resources.Image2;
                        else button100.Image = Properties.Resources.Image1;
                        break;
                    case 110:
                        if (FisrtPlayer) button99.Image = Properties.Resources.Image2;
                        else button99.Image = Properties.Resources.Image1;
                        break;
                    case 111:
                        if (FisrtPlayer) button98.Image = Properties.Resources.Image2;
                        else button98.Image = Properties.Resources.Image1;
                        break;
                    case 112:
                        if (FisrtPlayer) button97.Image = Properties.Resources.Image2;
                        else button97.Image = Properties.Resources.Image1;
                        break;
                    case 113:
                        if (FisrtPlayer) button96.Image = Properties.Resources.Image2;
                        else button96.Image = Properties.Resources.Image1;
                        break;
                    case 114:
                        if (FisrtPlayer) button133.Image = Properties.Resources.Image2;
                        else button133.Image = Properties.Resources.Image1;
                        break;
                    case 115:
                        if (FisrtPlayer) button132.Image = Properties.Resources.Image2;
                        else button132.Image = Properties.Resources.Image1;
                        break;
                    case 116:
                        if (FisrtPlayer) button131.Image = Properties.Resources.Image2;
                        else button131.Image = Properties.Resources.Image1;
                        break;
                    case 117:
                        if (FisrtPlayer) button130.Image = Properties.Resources.Image2;
                        else button130.Image = Properties.Resources.Image1;
                        break;
                    case 118:
                        if (FisrtPlayer) button129.Image = Properties.Resources.Image2;
                        else button129.Image = Properties.Resources.Image1;
                        break;
                    case 119:
                        if (FisrtPlayer) button128.Image = Properties.Resources.Image2;
                        else button128.Image = Properties.Resources.Image1;
                        break;
                    case 120:
                        if (FisrtPlayer) button127.Image = Properties.Resources.Image2;
                        else button127.Image = Properties.Resources.Image1;
                        break;
                    case 121:
                        if (FisrtPlayer) button126.Image = Properties.Resources.Image2;
                        else button126.Image = Properties.Resources.Image1;
                        break;
                    case 122:
                        if (FisrtPlayer) button125.Image = Properties.Resources.Image2;
                        else button125.Image = Properties.Resources.Image1;
                        break;
                    case 123:
                        if (FisrtPlayer) button124.Image = Properties.Resources.Image2;
                        else button124.Image = Properties.Resources.Image1;
                        break;
                    case 124:
                        if (FisrtPlayer) button123.Image = Properties.Resources.Image2;
                        else button123.Image = Properties.Resources.Image1;
                        break;
                    case 125:
                        if (FisrtPlayer) button122.Image = Properties.Resources.Image2;
                        else button122.Image = Properties.Resources.Image1;
                        break;
                    case 126:
                        if (FisrtPlayer) button121.Image = Properties.Resources.Image2;
                        else button121.Image = Properties.Resources.Image1;
                        break;
                    case 127:
                        if (FisrtPlayer) button120.Image = Properties.Resources.Image2;
                        else button120.Image = Properties.Resources.Image1;
                        break;
                    case 128:
                        if (FisrtPlayer) button119.Image = Properties.Resources.Image2;
                        else button119.Image = Properties.Resources.Image1;
                        break;
                    case 129:
                        if (FisrtPlayer) button118.Image = Properties.Resources.Image2;
                        else button118.Image = Properties.Resources.Image1;
                        break;
                    case 130:
                        if (FisrtPlayer) button117.Image = Properties.Resources.Image2;
                        else button117.Image = Properties.Resources.Image1;
                        break;
                    case 131:
                        if (FisrtPlayer) button116.Image = Properties.Resources.Image2;
                        else button116.Image = Properties.Resources.Image1;
                        break;
                    case 132:
                        if (FisrtPlayer) button115.Image = Properties.Resources.Image2;
                        else button115.Image = Properties.Resources.Image1;
                        break;
                    case 133:
                        if (FisrtPlayer) button152.Image = Properties.Resources.Image2;
                        else button152.Image = Properties.Resources.Image1;
                        break;
                    case 134:
                        if (FisrtPlayer) button151.Image = Properties.Resources.Image2;
                        else button151.Image = Properties.Resources.Image1;
                        break;
                    case 135:
                        if (FisrtPlayer) button150.Image = Properties.Resources.Image2;
                        else button150.Image = Properties.Resources.Image1;
                        break;
                    case 136:
                        if (FisrtPlayer) button149.Image = Properties.Resources.Image2;
                        else button149.Image = Properties.Resources.Image1;
                        break;
                    case 137:
                        if (FisrtPlayer) button148.Image = Properties.Resources.Image2;
                        else button148.Image = Properties.Resources.Image1;
                        break;
                    case 138:
                        if (FisrtPlayer) button147.Image = Properties.Resources.Image2;
                        else button147.Image = Properties.Resources.Image1;
                        break;
                    case 139:
                        if (FisrtPlayer) button146.Image = Properties.Resources.Image2;
                        else button146.Image = Properties.Resources.Image1;
                        break;
                    case 140:
                        if (FisrtPlayer) button145.Image = Properties.Resources.Image2;
                        else button145.Image = Properties.Resources.Image1;
                        break;
                    case 141:
                        if (FisrtPlayer) button144.Image = Properties.Resources.Image2;
                        else button144.Image = Properties.Resources.Image1;
                        break;
                    case 142:
                        if (FisrtPlayer) button143.Image = Properties.Resources.Image2;
                        else button143.Image = Properties.Resources.Image1;
                        break;
                    case 143:
                        if (FisrtPlayer) button142.Image = Properties.Resources.Image2;
                        else button142.Image = Properties.Resources.Image1;
                        break;
                    case 144:
                        if (FisrtPlayer) button141.Image = Properties.Resources.Image2;
                        else button141.Image = Properties.Resources.Image1;
                        break;
                    case 145:
                        if (FisrtPlayer) button140.Image = Properties.Resources.Image2;
                        else button140.Image = Properties.Resources.Image1;
                        break;
                    case 146:
                        if (FisrtPlayer) button139.Image = Properties.Resources.Image2;
                        else button139.Image = Properties.Resources.Image1;
                        break;
                    case 147:
                        if (FisrtPlayer) button138.Image = Properties.Resources.Image2;
                        else button138.Image = Properties.Resources.Image1;
                        break;
                    case 148:
                        if (FisrtPlayer) button137.Image = Properties.Resources.Image2;
                        else button137.Image = Properties.Resources.Image1;
                        break;
                    case 149:
                        if (FisrtPlayer) button136.Image = Properties.Resources.Image2;
                        else button136.Image = Properties.Resources.Image1;
                        break;
                    case 150:
                        if (FisrtPlayer) button135.Image = Properties.Resources.Image2;
                        else button135.Image = Properties.Resources.Image1;
                        break;
                    case 151:
                        if (FisrtPlayer) button134.Image = Properties.Resources.Image2;
                        else button134.Image = Properties.Resources.Image1;
                        break;
                    case 152:
                        if (FisrtPlayer) button171.Image = Properties.Resources.Image2;
                        else button171.Image = Properties.Resources.Image1;
                        break;
                    case 153:
                        if (FisrtPlayer) button170.Image = Properties.Resources.Image2;
                        else button170.Image = Properties.Resources.Image1;
                        break;
                    case 154:
                        if (FisrtPlayer) button169.Image = Properties.Resources.Image2;
                        else button169.Image = Properties.Resources.Image1;
                        break;
                    case 155:
                        if (FisrtPlayer) button168.Image = Properties.Resources.Image2;
                        else button168.Image = Properties.Resources.Image1;
                        break;
                    case 156:
                        if (FisrtPlayer) button167.Image = Properties.Resources.Image2;
                        else button167.Image = Properties.Resources.Image1;
                        break;
                    case 157:
                        if (FisrtPlayer) button166.Image = Properties.Resources.Image2;
                        else button166.Image = Properties.Resources.Image1;
                        break;
                    case 158:
                        if (FisrtPlayer) button165.Image = Properties.Resources.Image2;
                        else button165.Image = Properties.Resources.Image1;
                        break;
                    case 159:
                        if (FisrtPlayer) button164.Image = Properties.Resources.Image2;
                        else button164.Image = Properties.Resources.Image1;
                        break;
                    case 160:
                        if (FisrtPlayer) button163.Image = Properties.Resources.Image2;
                        else button163.Image = Properties.Resources.Image1;
                        break;
                    case 161:
                        if (FisrtPlayer) button162.Image = Properties.Resources.Image2;
                        else button162.Image = Properties.Resources.Image1;
                        break;
                    case 162:
                        if (FisrtPlayer) button161.Image = Properties.Resources.Image2;
                        else button161.Image = Properties.Resources.Image1;
                        break;
                    case 163:
                        if (FisrtPlayer) button160.Image = Properties.Resources.Image2;
                        else button160.Image = Properties.Resources.Image1;
                        break;
                    case 164:
                        if (FisrtPlayer) button159.Image = Properties.Resources.Image2;
                        else button159.Image = Properties.Resources.Image1;
                        break;
                    case 165:
                        if (FisrtPlayer) button158.Image = Properties.Resources.Image2;
                        else button158.Image = Properties.Resources.Image1;
                        break;
                    case 166:
                        if (FisrtPlayer) button157.Image = Properties.Resources.Image2;
                        else button157.Image = Properties.Resources.Image1;
                        break;
                    case 167:
                        if (FisrtPlayer) button156.Image = Properties.Resources.Image2;
                        else button156.Image = Properties.Resources.Image1;
                        break;
                    case 168:
                        if (FisrtPlayer) button155.Image = Properties.Resources.Image2;
                        else button155.Image = Properties.Resources.Image1;
                        break;
                    case 169:
                        if (FisrtPlayer) button154.Image = Properties.Resources.Image2;
                        else button154.Image = Properties.Resources.Image1;
                        break;
                    case 170:
                        if (FisrtPlayer) button153.Image = Properties.Resources.Image2;
                        else button153.Image = Properties.Resources.Image1;
                        break;
                    case 171:
                        if (FisrtPlayer) button190.Image = Properties.Resources.Image2;
                        else button190.Image = Properties.Resources.Image1;
                        break;
                    case 172:
                        if (FisrtPlayer) button189.Image = Properties.Resources.Image2;
                        else button189.Image = Properties.Resources.Image1;
                        break;
                    case 173:
                        if (FisrtPlayer) button188.Image = Properties.Resources.Image2;
                        else button188.Image = Properties.Resources.Image1;
                        break;
                    case 174:
                        if (FisrtPlayer) button187.Image = Properties.Resources.Image2;
                        else button187.Image = Properties.Resources.Image1;
                        break;
                    case 175:
                        if (FisrtPlayer) button186.Image = Properties.Resources.Image2;
                        else button186.Image = Properties.Resources.Image1;
                        break;
                    case 176:
                        if (FisrtPlayer) button185.Image = Properties.Resources.Image2;
                        else button185.Image = Properties.Resources.Image1;
                        break;
                    case 177:
                        if (FisrtPlayer) button184.Image = Properties.Resources.Image2;
                        else button184.Image = Properties.Resources.Image1;
                        break;
                    case 178:
                        if (FisrtPlayer) button183.Image = Properties.Resources.Image2;
                        else button183.Image = Properties.Resources.Image1;
                        break;
                    case 179:
                        if (FisrtPlayer) button182.Image = Properties.Resources.Image2;
                        else button182.Image = Properties.Resources.Image1;
                        break;
                    case 180:
                        if (FisrtPlayer) button181.Image = Properties.Resources.Image2;
                        else button181.Image = Properties.Resources.Image1;
                        break;
                    case 181:
                        if (FisrtPlayer) button180.Image = Properties.Resources.Image2;
                        else button180.Image = Properties.Resources.Image1;
                        break;
                    case 182:
                        if (FisrtPlayer) button179.Image = Properties.Resources.Image2;
                        else button179.Image = Properties.Resources.Image1;
                        break;
                    case 183:
                        if (FisrtPlayer) button178.Image = Properties.Resources.Image2;
                        else button178.Image = Properties.Resources.Image1;
                        break;
                    case 184:
                        if (FisrtPlayer) button177.Image = Properties.Resources.Image2;
                        else button177.Image = Properties.Resources.Image1;
                        break;
                    case 185:
                        if (FisrtPlayer) button176.Image = Properties.Resources.Image2;
                        else button176.Image = Properties.Resources.Image1;
                        break;
                    case 186:
                        if (FisrtPlayer) button175.Image = Properties.Resources.Image2;
                        else button175.Image = Properties.Resources.Image1;
                        break;
                    case 187:
                        if (FisrtPlayer) button174.Image = Properties.Resources.Image2;
                        else button174.Image = Properties.Resources.Image1;
                        break;
                    case 188:
                        if (FisrtPlayer) button173.Image = Properties.Resources.Image2;
                        else button173.Image = Properties.Resources.Image1;
                        break;
                    case 189:
                        if (FisrtPlayer) button172.Image = Properties.Resources.Image2;
                        else button172.Image = Properties.Resources.Image1;
                        break;
                    case 190:
                        if (FisrtPlayer) button209.Image = Properties.Resources.Image2;
                        else button209.Image = Properties.Resources.Image1;
                        break;
                    case 191:
                        if (FisrtPlayer) button208.Image = Properties.Resources.Image2;
                        else button208.Image = Properties.Resources.Image1;
                        break;
                    case 192:
                        if (FisrtPlayer) button207.Image = Properties.Resources.Image2;
                        else button207.Image = Properties.Resources.Image1;
                        break;
                    case 193:
                        if (FisrtPlayer) button206.Image = Properties.Resources.Image2;
                        else button206.Image = Properties.Resources.Image1;
                        break;
                    case 194:
                        if (FisrtPlayer) button205.Image = Properties.Resources.Image2;
                        else button205.Image = Properties.Resources.Image1;
                        break;
                    case 195:
                        if (FisrtPlayer) button204.Image = Properties.Resources.Image2;
                        else button204.Image = Properties.Resources.Image1;
                        break;
                    case 196:
                        if (FisrtPlayer) button203.Image = Properties.Resources.Image2;
                        else button203.Image = Properties.Resources.Image1;
                        break;
                    case 197:
                        if (FisrtPlayer) button202.Image = Properties.Resources.Image2;
                        else button202.Image = Properties.Resources.Image1;
                        break;
                    case 198:
                        if (FisrtPlayer) button201.Image = Properties.Resources.Image2;
                        else button201.Image = Properties.Resources.Image1;
                        break;
                    case 199:
                        if (FisrtPlayer) button200.Image = Properties.Resources.Image2;
                        else button200.Image = Properties.Resources.Image1;
                        break;
                    case 200:
                        if (FisrtPlayer) button199.Image = Properties.Resources.Image2;
                        else button199.Image = Properties.Resources.Image1;
                        break;
                    case 201:
                        if (FisrtPlayer) button198.Image = Properties.Resources.Image2;
                        else button198.Image = Properties.Resources.Image1;
                        break;
                    case 202:
                        if (FisrtPlayer) button197.Image = Properties.Resources.Image2;
                        else button197.Image = Properties.Resources.Image1;
                        break;
                    case 203:
                        if (FisrtPlayer) button196.Image = Properties.Resources.Image2;
                        else button196.Image = Properties.Resources.Image1;
                        break;
                    case 204:
                        if (FisrtPlayer) button195.Image = Properties.Resources.Image2;
                        else button195.Image = Properties.Resources.Image1;
                        break;
                    case 205:
                        if (FisrtPlayer) button194.Image = Properties.Resources.Image2;
                        else button194.Image = Properties.Resources.Image1;
                        break;
                    case 206:
                        if (FisrtPlayer) button193.Image = Properties.Resources.Image2;
                        else button193.Image = Properties.Resources.Image1;
                        break;
                    case 207:
                        if (FisrtPlayer) button192.Image = Properties.Resources.Image2;
                        else button192.Image = Properties.Resources.Image1;
                        break;
                    case 208:
                        if (FisrtPlayer) button191.Image = Properties.Resources.Image2;
                        else button191.Image = Properties.Resources.Image1;
                        break;
                    case 209:
                        if (FisrtPlayer) button228.Image = Properties.Resources.Image2;
                        else button228.Image = Properties.Resources.Image1;
                        break;
                    case 210:
                        if (FisrtPlayer) button227.Image = Properties.Resources.Image2;
                        else button227.Image = Properties.Resources.Image1;
                        break;
                    case 211:
                        if (FisrtPlayer) button226.Image = Properties.Resources.Image2;
                        else button226.Image = Properties.Resources.Image1;
                        break;
                    case 212:
                        if (FisrtPlayer) button225.Image = Properties.Resources.Image2;
                        else button225.Image = Properties.Resources.Image1;
                        break;
                    case 213:
                        if (FisrtPlayer) button224.Image = Properties.Resources.Image2;
                        else button224.Image = Properties.Resources.Image1;
                        break;
                    case 214:
                        if (FisrtPlayer) button223.Image = Properties.Resources.Image2;
                        else button223.Image = Properties.Resources.Image1;
                        break;
                    case 215:
                        if (FisrtPlayer) button222.Image = Properties.Resources.Image2;
                        else button222.Image = Properties.Resources.Image1;
                        break;
                    case 216:
                        if (FisrtPlayer) button221.Image = Properties.Resources.Image2;
                        else button221.Image = Properties.Resources.Image1;
                        break;
                    case 217:
                        if (FisrtPlayer) button220.Image = Properties.Resources.Image2;
                        else button220.Image = Properties.Resources.Image1;
                        break;
                    case 218:
                        if (FisrtPlayer) button219.Image = Properties.Resources.Image2;
                        else button219.Image = Properties.Resources.Image1;
                        break;
                    case 219:
                        if (FisrtPlayer) button218.Image = Properties.Resources.Image2;
                        else button218.Image = Properties.Resources.Image1;
                        break;
                    case 220:
                        if (FisrtPlayer) button217.Image = Properties.Resources.Image2;
                        else button217.Image = Properties.Resources.Image1;
                        break;
                    case 221:
                        if (FisrtPlayer) button216.Image = Properties.Resources.Image2;
                        else button216.Image = Properties.Resources.Image1;
                        break;
                    case 222:
                        if (FisrtPlayer) button215.Image = Properties.Resources.Image2;
                        else button215.Image = Properties.Resources.Image1;
                        break;
                    case 223:
                        if (FisrtPlayer) button214.Image = Properties.Resources.Image2;
                        else button214.Image = Properties.Resources.Image1;
                        break;
                    case 224:
                        if (FisrtPlayer) button213.Image = Properties.Resources.Image2;
                        else button213.Image = Properties.Resources.Image1;
                        break;
                    case 225:
                        if (FisrtPlayer) button212.Image = Properties.Resources.Image2;
                        else button212.Image = Properties.Resources.Image1;
                        break;
                    case 226:
                        if (FisrtPlayer) button211.Image = Properties.Resources.Image2;
                        else button211.Image = Properties.Resources.Image1;
                        break;
                    case 227:
                        if (FisrtPlayer) button210.Image = Properties.Resources.Image2;
                        else button210.Image = Properties.Resources.Image1;
                        break;
                    case 228:
                        if (FisrtPlayer) button247.Image = Properties.Resources.Image2;
                        else button247.Image = Properties.Resources.Image1;
                        break;
                    case 229:
                        if (FisrtPlayer) button246.Image = Properties.Resources.Image2;
                        else button246.Image = Properties.Resources.Image1;
                        break;
                    case 230:
                        if (FisrtPlayer) button245.Image = Properties.Resources.Image2;
                        else button245.Image = Properties.Resources.Image1;
                        break;
                    case 231:
                        if (FisrtPlayer) button244.Image = Properties.Resources.Image2;
                        else button244.Image = Properties.Resources.Image1;
                        break;
                    case 232:
                        if (FisrtPlayer) button243.Image = Properties.Resources.Image2;
                        else button243.Image = Properties.Resources.Image1;
                        break;
                    case 233:
                        if (FisrtPlayer) button242.Image = Properties.Resources.Image2;
                        else button242.Image = Properties.Resources.Image1;
                        break;
                    case 234:
                        if (FisrtPlayer) button241.Image = Properties.Resources.Image2;
                        else button241.Image = Properties.Resources.Image1;
                        break;
                    case 235:
                        if (FisrtPlayer) button240.Image = Properties.Resources.Image2;
                        else button240.Image = Properties.Resources.Image1;
                        break;
                    case 236:
                        if (FisrtPlayer) button239.Image = Properties.Resources.Image2;
                        else button239.Image = Properties.Resources.Image1;
                        break;
                    case 237:
                        if (FisrtPlayer) button238.Image = Properties.Resources.Image2;
                        else button238.Image = Properties.Resources.Image1;
                        break;
                    case 238:
                        if (FisrtPlayer) button237.Image = Properties.Resources.Image2;
                        else button237.Image = Properties.Resources.Image1;
                        break;
                    case 239:
                        if (FisrtPlayer) button236.Image = Properties.Resources.Image2;
                        else button236.Image = Properties.Resources.Image1;
                        break;
                    case 240:
                        if (FisrtPlayer) button235.Image = Properties.Resources.Image2;
                        else button235.Image = Properties.Resources.Image1;
                        break;
                    case 241:
                        if (FisrtPlayer) button234.Image = Properties.Resources.Image2;
                        else button234.Image = Properties.Resources.Image1;
                        break;
                    case 242:
                        if (FisrtPlayer) button233.Image = Properties.Resources.Image2;
                        else button233.Image = Properties.Resources.Image1;
                        break;
                    case 243:
                        if (FisrtPlayer) button232.Image = Properties.Resources.Image2;
                        else button232.Image = Properties.Resources.Image1;
                        break;
                    case 244:
                        if (FisrtPlayer) button231.Image = Properties.Resources.Image2;
                        else button231.Image = Properties.Resources.Image1;
                        break;
                    case 245:
                        if (FisrtPlayer) button230.Image = Properties.Resources.Image2;
                        else button230.Image = Properties.Resources.Image1;
                        break;
                    case 246:
                        if (FisrtPlayer) button229.Image = Properties.Resources.Image2;
                        else button229.Image = Properties.Resources.Image1;
                        break;
                    case 247:
                        if (FisrtPlayer) button266.Image = Properties.Resources.Image2;
                        else button266.Image = Properties.Resources.Image1;
                        break;
                    case 248:
                        if (FisrtPlayer) button265.Image = Properties.Resources.Image2;
                        else button265.Image = Properties.Resources.Image1;
                        break;
                    case 249:
                        if (FisrtPlayer) button264.Image = Properties.Resources.Image2;
                        else button264.Image = Properties.Resources.Image1;
                        break;
                    case 250:
                        if (FisrtPlayer) button263.Image = Properties.Resources.Image2;
                        else button263.Image = Properties.Resources.Image1;
                        break;
                    case 251:
                        if (FisrtPlayer) button262.Image = Properties.Resources.Image2;
                        else button262.Image = Properties.Resources.Image1;
                        break;
                    case 252:
                        if (FisrtPlayer) button261.Image = Properties.Resources.Image2;
                        else button261.Image = Properties.Resources.Image1;
                        break;
                    case 253:
                        if (FisrtPlayer) button260.Image = Properties.Resources.Image2;
                        else button260.Image = Properties.Resources.Image1;
                        break;
                    case 254:
                        if (FisrtPlayer) button259.Image = Properties.Resources.Image2;
                        else button259.Image = Properties.Resources.Image1;
                        break;
                    case 255:
                        if (FisrtPlayer) button258.Image = Properties.Resources.Image2;
                        else button258.Image = Properties.Resources.Image1;
                        break;
                    case 256:
                        if (FisrtPlayer) button257.Image = Properties.Resources.Image2;
                        else button257.Image = Properties.Resources.Image1;
                        break;
                    case 257:
                        if (FisrtPlayer) button256.Image = Properties.Resources.Image2;
                        else button256.Image = Properties.Resources.Image1;
                        break;
                    case 258:
                        if (FisrtPlayer) button255.Image = Properties.Resources.Image2;
                        else button255.Image = Properties.Resources.Image1;
                        break;
                    case 259:
                        if (FisrtPlayer) button254.Image = Properties.Resources.Image2;
                        else button254.Image = Properties.Resources.Image1;
                        break;
                    case 260:
                        if (FisrtPlayer) button253.Image = Properties.Resources.Image2;
                        else button253.Image = Properties.Resources.Image1;
                        break;
                    case 261:
                        if (FisrtPlayer) button252.Image = Properties.Resources.Image2;
                        else button252.Image = Properties.Resources.Image1;
                        break;
                    case 262:
                        if (FisrtPlayer) button251.Image = Properties.Resources.Image2;
                        else button251.Image = Properties.Resources.Image1;
                        break;
                    case 263:
                        if (FisrtPlayer) button250.Image = Properties.Resources.Image2;
                        else button250.Image = Properties.Resources.Image1;
                        break;
                    case 264:
                        if (FisrtPlayer) button249.Image = Properties.Resources.Image2;
                        else button249.Image = Properties.Resources.Image1;
                        break;
                    case 265:
                        if (FisrtPlayer) button248.Image = Properties.Resources.Image2;
                        else button248.Image = Properties.Resources.Image1;
                        break;
                    case 266:
                        if (FisrtPlayer) button285.Image = Properties.Resources.Image2;
                        else button285.Image = Properties.Resources.Image1;
                        break;
                    case 267:
                        if (FisrtPlayer) button284.Image = Properties.Resources.Image2;
                        else button284.Image = Properties.Resources.Image1;
                        break;
                    case 268:
                        if (FisrtPlayer) button283.Image = Properties.Resources.Image2;
                        else button283.Image = Properties.Resources.Image1;
                        break;
                    case 269:
                        if (FisrtPlayer) button282.Image = Properties.Resources.Image2;
                        else button282.Image = Properties.Resources.Image1;
                        break;
                    case 270:
                        if (FisrtPlayer) button281.Image = Properties.Resources.Image2;
                        else button281.Image = Properties.Resources.Image1;
                        break;
                    case 271:
                        if (FisrtPlayer) button280.Image = Properties.Resources.Image2;
                        else button280.Image = Properties.Resources.Image1;
                        break;
                    case 272:
                        if (FisrtPlayer) button279.Image = Properties.Resources.Image2;
                        else button279.Image = Properties.Resources.Image1;
                        break;
                    case 273:
                        if (FisrtPlayer) button278.Image = Properties.Resources.Image2;
                        else button278.Image = Properties.Resources.Image1;
                        break;
                    case 274:
                        if (FisrtPlayer) button277.Image = Properties.Resources.Image2;
                        else button277.Image = Properties.Resources.Image1;
                        break;
                    case 275:
                        if (FisrtPlayer) button276.Image = Properties.Resources.Image2;
                        else button276.Image = Properties.Resources.Image1;
                        break;
                    case 276:
                        if (FisrtPlayer) button275.Image = Properties.Resources.Image2;
                        else button275.Image = Properties.Resources.Image1;
                        break;
                    case 277:
                        if (FisrtPlayer) button274.Image = Properties.Resources.Image2;
                        else button274.Image = Properties.Resources.Image1;
                        break;
                    case 278:
                        if (FisrtPlayer) button273.Image = Properties.Resources.Image2;
                        else button273.Image = Properties.Resources.Image1;
                        break;
                    case 279:
                        if (FisrtPlayer) button272.Image = Properties.Resources.Image2;
                        else button272.Image = Properties.Resources.Image1;
                        break;
                    case 280:
                        if (FisrtPlayer) button271.Image = Properties.Resources.Image2;
                        else button271.Image = Properties.Resources.Image1;
                        break;
                    case 281:
                        if (FisrtPlayer) button270.Image = Properties.Resources.Image2;
                        else button270.Image = Properties.Resources.Image1;
                        break;
                    case 282:
                        if (FisrtPlayer) button269.Image = Properties.Resources.Image2;
                        else button269.Image = Properties.Resources.Image1;
                        break;
                    case 283:
                        if (FisrtPlayer) button268.Image = Properties.Resources.Image2;
                        else button268.Image = Properties.Resources.Image1;
                        break;
                    case 284:
                        if (FisrtPlayer) button267.Image = Properties.Resources.Image2;
                        else button267.Image = Properties.Resources.Image1;
                        break;
                    case 285:
                        if (FisrtPlayer) button304.Image = Properties.Resources.Image2;
                        else button304.Image = Properties.Resources.Image1;
                        break;
                    case 286:
                        if (FisrtPlayer) button303.Image = Properties.Resources.Image2;
                        else button303.Image = Properties.Resources.Image1;
                        break;
                    case 287:
                        if (FisrtPlayer) button302.Image = Properties.Resources.Image2;
                        else button302.Image = Properties.Resources.Image1;
                        break;
                    case 288:
                        if (FisrtPlayer) button301.Image = Properties.Resources.Image2;
                        else button301.Image = Properties.Resources.Image1;
                        break;
                    case 289:
                        if (FisrtPlayer) button300.Image = Properties.Resources.Image2;
                        else button300.Image = Properties.Resources.Image1;
                        break;
                    case 290:
                        if (FisrtPlayer) button299.Image = Properties.Resources.Image2;
                        else button299.Image = Properties.Resources.Image1;
                        break;
                    case 291:
                        if (FisrtPlayer) button298.Image = Properties.Resources.Image2;
                        else button298.Image = Properties.Resources.Image1;
                        break;
                    case 292:
                        if (FisrtPlayer) button297.Image = Properties.Resources.Image2;
                        else button297.Image = Properties.Resources.Image1;
                        break;
                    case 293:
                        if (FisrtPlayer) button296.Image = Properties.Resources.Image2;
                        else button296.Image = Properties.Resources.Image1;
                        break;
                    case 294:
                        if (FisrtPlayer) button295.Image = Properties.Resources.Image2;
                        else button295.Image = Properties.Resources.Image1;
                        break;
                    case 295:
                        if (FisrtPlayer) button294.Image = Properties.Resources.Image2;
                        else button294.Image = Properties.Resources.Image1;
                        break;
                    case 296:
                        if (FisrtPlayer) button293.Image = Properties.Resources.Image2;
                        else button293.Image = Properties.Resources.Image1;
                        break;
                    case 297:
                        if (FisrtPlayer) button292.Image = Properties.Resources.Image2;
                        else button292.Image = Properties.Resources.Image1;
                        break;
                    case 298:
                        if (FisrtPlayer) button291.Image = Properties.Resources.Image2;
                        else button291.Image = Properties.Resources.Image1;
                        break;
                    case 299:
                        if (FisrtPlayer) button290.Image = Properties.Resources.Image2;
                        else button290.Image = Properties.Resources.Image1;
                        break;
                    case 300:
                        if (FisrtPlayer) button289.Image = Properties.Resources.Image2;
                        else button289.Image = Properties.Resources.Image1;
                        break;
                    case 301:
                        if (FisrtPlayer) button288.Image = Properties.Resources.Image2;
                        else button288.Image = Properties.Resources.Image1;
                        break;
                    case 302:
                        if (FisrtPlayer) button287.Image = Properties.Resources.Image2;
                        else button287.Image = Properties.Resources.Image1;
                        break;
                    case 303:
                        if (FisrtPlayer) button286.Image = Properties.Resources.Image2;
                        else button286.Image = Properties.Resources.Image1;
                        break;
                    case 304:
                        if (FisrtPlayer) button323.Image = Properties.Resources.Image2;
                        else button323.Image = Properties.Resources.Image1;
                        break;
                    case 305:
                        if (FisrtPlayer) button322.Image = Properties.Resources.Image2;
                        else button322.Image = Properties.Resources.Image1;
                        break;
                    case 306:
                        if (FisrtPlayer) button321.Image = Properties.Resources.Image2;
                        else button321.Image = Properties.Resources.Image1;
                        break;
                    case 307:
                        if (FisrtPlayer) button320.Image = Properties.Resources.Image2;
                        else button320.Image = Properties.Resources.Image1;
                        break;
                    case 308:
                        if (FisrtPlayer) button319.Image = Properties.Resources.Image2;
                        else button319.Image = Properties.Resources.Image1;
                        break;
                    case 309:
                        if (FisrtPlayer) button318.Image = Properties.Resources.Image2;
                        else button318.Image = Properties.Resources.Image1;
                        break;
                    case 310:
                        if (FisrtPlayer) button317.Image = Properties.Resources.Image2;
                        else button317.Image = Properties.Resources.Image1;
                        break;
                    case 311:
                        if (FisrtPlayer) button316.Image = Properties.Resources.Image2;
                        else button316.Image = Properties.Resources.Image1;
                        break;
                    case 312:
                        if (FisrtPlayer) button315.Image = Properties.Resources.Image2;
                        else button315.Image = Properties.Resources.Image1;
                        break;
                    case 313:
                        if (FisrtPlayer) button314.Image = Properties.Resources.Image2;
                        else button314.Image = Properties.Resources.Image1;
                        break;
                    case 314:
                        if (FisrtPlayer) button313.Image = Properties.Resources.Image2;
                        else button313.Image = Properties.Resources.Image1;
                        break;
                    case 315:
                        if (FisrtPlayer) button312.Image = Properties.Resources.Image2;
                        else button312.Image = Properties.Resources.Image1;
                        break;
                    case 316:
                        if (FisrtPlayer) button311.Image = Properties.Resources.Image2;
                        else button311.Image = Properties.Resources.Image1;
                        break;
                    case 317:
                        if (FisrtPlayer) button310.Image = Properties.Resources.Image2;
                        else button310.Image = Properties.Resources.Image1;
                        break;
                    case 318:
                        if (FisrtPlayer) button309.Image = Properties.Resources.Image2;
                        else button309.Image = Properties.Resources.Image1;
                        break;
                    case 319:
                        if (FisrtPlayer) button308.Image = Properties.Resources.Image2;
                        else button308.Image = Properties.Resources.Image1;
                        break;
                    case 320:
                        if (FisrtPlayer) button307.Image = Properties.Resources.Image2;
                        else button307.Image = Properties.Resources.Image1;
                        break;
                    case 321:
                        if (FisrtPlayer) button306.Image = Properties.Resources.Image2;
                        else button306.Image = Properties.Resources.Image1;
                        break;
                    case 322:
                        if (FisrtPlayer) button305.Image = Properties.Resources.Image2;
                        else button305.Image = Properties.Resources.Image1;
                        break;
                    case 323:
                        if (FisrtPlayer) button342.Image = Properties.Resources.Image2;
                        else button342.Image = Properties.Resources.Image1;
                        break;
                    case 324:
                        if (FisrtPlayer) button341.Image = Properties.Resources.Image2;
                        else button341.Image = Properties.Resources.Image1;
                        break;
                    case 325:
                        if (FisrtPlayer) button340.Image = Properties.Resources.Image2;
                        else button340.Image = Properties.Resources.Image1;
                        break;
                    case 326:
                        if (FisrtPlayer) button339.Image = Properties.Resources.Image2;
                        else button339.Image = Properties.Resources.Image1;
                        break;
                    case 327:
                        if (FisrtPlayer) button338.Image = Properties.Resources.Image2;
                        else button338.Image = Properties.Resources.Image1;
                        break;
                    case 328:
                        if (FisrtPlayer) button337.Image = Properties.Resources.Image2;
                        else button337.Image = Properties.Resources.Image1;
                        break;
                    case 329:
                        if (FisrtPlayer) button336.Image = Properties.Resources.Image2;
                        else button336.Image = Properties.Resources.Image1;
                        break;
                    case 330:
                        if (FisrtPlayer) button335.Image = Properties.Resources.Image2;
                        else button335.Image = Properties.Resources.Image1;
                        break;
                    case 331:
                        if (FisrtPlayer) button334.Image = Properties.Resources.Image2;
                        else button334.Image = Properties.Resources.Image1;
                        break;
                    case 332:
                        if (FisrtPlayer) button333.Image = Properties.Resources.Image2;
                        else button333.Image = Properties.Resources.Image1;
                        break;
                    case 333:
                        if (FisrtPlayer) button332.Image = Properties.Resources.Image2;
                        else button332.Image = Properties.Resources.Image1;
                        break;
                    case 334:
                        if (FisrtPlayer) button331.Image = Properties.Resources.Image2;
                        else button331.Image = Properties.Resources.Image1;
                        break;
                    case 335:
                        if (FisrtPlayer) button330.Image = Properties.Resources.Image2;
                        else button330.Image = Properties.Resources.Image1;
                        break;
                    case 336:
                        if (FisrtPlayer) button329.Image = Properties.Resources.Image2;
                        else button329.Image = Properties.Resources.Image1;
                        break;
                    case 337:
                        if (FisrtPlayer) button328.Image = Properties.Resources.Image2;
                        else button328.Image = Properties.Resources.Image1;
                        break;
                    case 338:
                        if (FisrtPlayer) button327.Image = Properties.Resources.Image2;
                        else button327.Image = Properties.Resources.Image1;
                        break;
                    case 339:
                        if (FisrtPlayer) button326.Image = Properties.Resources.Image2;
                        else button326.Image = Properties.Resources.Image1;
                        break;
                    case 340:
                        if (FisrtPlayer) button325.Image = Properties.Resources.Image2;
                        else button325.Image = Properties.Resources.Image1;
                        break;
                    case 341:
                        if (FisrtPlayer) button324.Image = Properties.Resources.Image2;
                        else button324.Image = Properties.Resources.Image1;
                        break;
                    case 342:
                        if (FisrtPlayer) button361.Image = Properties.Resources.Image2;
                        else button361.Image = Properties.Resources.Image1;
                        break;
                    case 343:
                        if (FisrtPlayer) button360.Image = Properties.Resources.Image2;
                        else button360.Image = Properties.Resources.Image1;
                        break;
                    case 344:
                        if (FisrtPlayer) button359.Image = Properties.Resources.Image2;
                        else button359.Image = Properties.Resources.Image1;
                        break;
                    case 345:
                        if (FisrtPlayer) button358.Image = Properties.Resources.Image2;
                        else button358.Image = Properties.Resources.Image1;
                        break;
                    case 346:
                        if (FisrtPlayer) button357.Image = Properties.Resources.Image2;
                        else button357.Image = Properties.Resources.Image1;
                        break;
                    case 347:
                        if (FisrtPlayer) button356.Image = Properties.Resources.Image2;
                        else button356.Image = Properties.Resources.Image1;
                        break;
                    case 348:
                        if (FisrtPlayer) button355.Image = Properties.Resources.Image2;
                        else button355.Image = Properties.Resources.Image1;
                        break;
                    case 349:
                        if (FisrtPlayer) button354.Image = Properties.Resources.Image2;
                        else button354.Image = Properties.Resources.Image1;
                        break;
                    case 350:
                        if (FisrtPlayer) button353.Image = Properties.Resources.Image2;
                        else button353.Image = Properties.Resources.Image1;
                        break;
                    case 351:
                        if (FisrtPlayer) button352.Image = Properties.Resources.Image2;
                        else button352.Image = Properties.Resources.Image1;
                        break;
                    case 352:
                        if (FisrtPlayer) button351.Image = Properties.Resources.Image2;
                        else button351.Image = Properties.Resources.Image1;
                        break;
                    case 353:
                        if (FisrtPlayer) button350.Image = Properties.Resources.Image2;
                        else button350.Image = Properties.Resources.Image1;
                        break;
                    case 354:
                        if (FisrtPlayer) button349.Image = Properties.Resources.Image2;
                        else button349.Image = Properties.Resources.Image1;
                        break;
                    case 355:
                        if (FisrtPlayer) button348.Image = Properties.Resources.Image2;
                        else button348.Image = Properties.Resources.Image1;
                        break;
                    case 356:
                        if (FisrtPlayer) button347.Image = Properties.Resources.Image2;
                        else button347.Image = Properties.Resources.Image1;
                        break;
                    case 357:
                        if (FisrtPlayer) button346.Image = Properties.Resources.Image2;
                        else button346.Image = Properties.Resources.Image1;
                        break;
                    case 358:
                        if (FisrtPlayer) button345.Image = Properties.Resources.Image2;
                        else button345.Image = Properties.Resources.Image1;
                        break;
                    case 359:
                        if (FisrtPlayer) button344.Image = Properties.Resources.Image2;
                        else button344.Image = Properties.Resources.Image1;
                        break;
                    case 360:
                        if (FisrtPlayer) button343.Image = Properties.Resources.Image2;
                        else button343.Image = Properties.Resources.Image1;
                        break;

                }
                GameState = true;
            }

        }

        private void button363_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
        }
    }
}
