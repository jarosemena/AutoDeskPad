using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PADesign
{
    public partial class FormHome : Form
    {
        public FormHome()
        {
            InitializeComponent();
        }

        public void InitiateForm()
        {
            cmbCategory.Items.Clear();
           foreach ( char code in WindModuleParameters.ExposureCategoryCodes.ToList())
            {
                cmbCategory.Items.Add(code);
            }
            if (cmbCode.Items.Count == 0)
            {
                foreach (string code in WindModuleParameters.Codes.Values.ToList())
                {
                    cmbCode.Items.Add(code);
                    cmbCode.SelectedIndex = 0;
                }
            }
            else
            {
                cmbCode.SelectedIndex = 0;
            }

            txtKzt.Text = "1.00";
            if (cmbKd.Items.Count == 0)
            {
                cmbKd.Items.Add(0.85);
                cmbKd.Items.Add(1.0);
                cmbKd.SelectedIndex = 0;
            }
            else
            {
                cmbKd.SelectedIndex = 0;
            }
            txtKe.Text = "1.00";
            if (cmbRoofSlope.Items.Count == 0)
            {
                for (int num = 1; num <= 360; num++)
                {
                    cmbRoofSlope.Items.Add(num);
                }
               
            }
            if (cmbRoofDegree.Items.Count == 0)
            {
                foreach (string opt in WindModuleParameters.RoofSlopeDegreeCodes.ToList())
                {
                    cmbRoofDegree.Items.Add(opt);
                }
                cmbRoofDegree.SelectedIndex = 0;
            }
            else
            {
                cmbRoofDegree.SelectedIndex = 0;
            }

            txtMeanRoof.Text = "30";
            checkparapet.Checked = false;


        }

        private void FormHome_Load(object sender, EventArgs e)
        {

            FFDModule mmod1 = new FFDModule("Model1", 1, 'B', 1);
            FFDModule mmod2 = new FFDModule("Model2", 1, 'D', 3);

            DesignGroup DG = new DesignGroup("Model1",mmod1,"Desing Group 1");
            DG.Add("Model2", mmod2);



            treeGroupDesign.Nodes.Add(DG.Name);
            foreach ( string Module in DG.GetModules() ) {

                treeGroupDesign.Nodes[0].Nodes.Add(Module);
               
            }


            InitiateForm();

        }

        private void TreeGroupDesign_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Label9_Click(object sender, EventArgs e)
        {

        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void TxtMeanRoof_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(txtMeanRoof.Text, out int meanroof))
            {
                if (meanroof > 90)
                {
                    MessageBox.Show("Hey, you put an integer grather than 90 try with lower number.");
                    txtMeanRoof.Text = "30";
                }
                else if (meanroof < 60)
                {

                    if (MessageBox.Show("Hey, you are trying to Use a number lower than 60 please verify it is OK", "Verified Value", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        txtMeanRoof.Text = "30";
                    }

                }

            }
            else
            { MessageBox.Show("Hey, we need an int over here."); }

        }

        private void CmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
