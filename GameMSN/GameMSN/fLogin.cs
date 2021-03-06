﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Media;

namespace GameMSN
{
    public partial class fLogin : Form
    {
        #region 繼承Net資料
        private string _Lip;private string _Lport;private string _Lname;
        public string Netip { get { return _Lip; } set { _Lip = value; } }
        public string Netport { get { return _Lport; } set { _Lport = value; } }
        public string Netname { get { return _Lname; } set { _Lname = value; } }
        #endregion

        public fLogin()
        {
            InitializeComponent();
        }
        private void FLogin_Load(object sender, EventArgs e)
        {
            iptxt.Text =   Netip ;
            porttxt.Text = Netport ;
            playtxt.Text = Netname;
        }
        private void Cls_btu_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void Create_btu_Click(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            fServer f_Ser = new fServer();
            f_Ser.Show();
            iptxt.Text =f_Ser.Netip;
            porttxt.Text = f_Ser.Netport;
            SoundPlayer sound = new SoundPlayer
            {
                SoundLocation = Application.StartupPath + @"//Click.wav"
            };
            sound.Play();
        }
        private void Login_btu_Click(object sender, EventArgs e)
        {
            if (iptxt.Text == "" || porttxt.Text == "" || playtxt.Text == "")
                MessageBox.Show("尚未輸入完全 !!", "注意");
            else
            {
                SoundPlayer sound = new SoundPlayer
                {
                    SoundLocation = Application.StartupPath + @"//Click.wav"
                };
                sound.Play();
                fDraw fdraw = new fDraw()
                {
                    Netip = iptxt.Text,
                    Netport = porttxt.Text,
                    Netname = playtxt.Text,
                };
                this.Hide();
                fdraw.Show();
            }
        }
    }
}