using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Encrypt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFrom.Text.Trim()))
            {
                MessageBox.Show("输入不能为空！");
                return;
            }
            if (string.IsNullOrEmpty(txtKey.Text.Trim()))
            {
                MessageBox.Show("Key不能为空！");
                return;
            }
            if (string.IsNullOrEmpty(txtIV.Text.Trim())) 
            {
                MessageBox.Show("IV不能为空！");
                return;
            }
            txtResult.Text = Secure.Encrypt(txtFrom.Text.Trim(), txtKey.Text.Trim(), txtIV.Text.Trim());
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFrom.Text.Trim()))
            {
                MessageBox.Show("输入不能为空！");
                return;
            }
            if (string.IsNullOrEmpty(txtKey.Text.Trim()))
            {
                MessageBox.Show("Key不能为空！");
                return;
            }
            if (string.IsNullOrEmpty(txtIV.Text.Trim()))
            {
                MessageBox.Show("IV不能为空！");
                return;
            }
            txtResult.Text = Secure.Decrypt(txtFrom.Text.Trim(), txtKey.Text.Trim(), txtIV.Text.Trim());
        }
    }
}
