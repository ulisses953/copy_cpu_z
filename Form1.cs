using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;

namespace extratorDeInformacao
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Ram memoria = new Ram();

            for (var i = 0; i >= memoria.Velocidade.Count; i++)
            {
                label1.Text = memoria.Velocidade[i] + "   ";
            }
            


        }
    }
}
