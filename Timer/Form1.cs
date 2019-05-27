using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Timer
{
    public partial class Form1 : Form
    {
        int CountOrgNum = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCount_Click(object sender, EventArgs e)
        {
            ProcessTimer();

        }

        private void ProcessTimer()
        {
            if (IntCheck())
            {
                this.CountOrgNum = Convert.ToInt32(this.txtNum.Text);
                this.txtNum.ReadOnly = true;  //값을 바꾸지 못하게
                this.Timer.Enabled = true;
            }
            else
            {
                this.txtNum.Focus();
                this.txtNum.Text = "";
            }
        }

        private bool IntCheck()
        {
            //칸에 숫자가 아닌 다른 걸 입력하면 메시지 창 띄움
            if (Information.IsNumeric(this.txtNum.Text)){
                return true;
            }
            else
            {
                MessageBox.Show("숫자만 입력해 주세요", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            //설정해준 시간마다 실행됨
            //0이 되지 않았을 때와 0이 되었을 때
            if (this.CountOrgNum < 1)
            {
                this.Timer.Enabled = false;
                MessageBox.Show("펑!","알림",MessageBoxButtons.OK, MessageBoxIcon.Information);
                //OK버튼을 클릭 해야지만 밑에 코드 실행
                this.txtNum.ReadOnly = false;
                this.txtNum.Text = "";
                this.txtNum.Focus();
            }
            else
            {
                this.CountOrgNum--;
                this.txtCountDown.Text = Convert.ToString(this.CountOrgNum);
            }
        }

        private void txtNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                ProcessTimer();
            }
        }
    }
}
