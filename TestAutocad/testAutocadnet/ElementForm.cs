using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testAutocadnet
{
    public partial class ElementForm : Form
    {
        List<ElementModel> elements = new List<ElementModel>();
        public ElementForm()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Class1 c = new Class1();           
            elements = c.LoadElements();

            foreach( ElementModel element in elements){
                cmbBlockID.Items.Add(element.ID);
            }
        }

        private void cmbBlockID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBlockID.SelectedItem != null)                 
            {
                ClearForm();
                ElementModel element = elements.Find(x => x.ID == (string)cmbBlockID.SelectedItem);
                txtName.Text = element.Name;
                txtBlockName.Text = element.Blockname;
                txtDepth.Text = element.Depth_feet().ToString();
                txtLength.Text = element.Length_feet().ToString();
                txtRotation.Text = element.Rotation_Degree().ToString();
                txtEndPoint.Text = element.EndPoint.Text();
                txtInitialPoint.Text = element.InitialPoint.Text();
                

            }
        }

        private void ClearForm()
        {
            txtName.Text = "";
            txtBlockName.Text = "";
            txtDepth.Text = "";
            txtLength.Text = "";
            txtRotation.Text = "";
            txtEndPoint.Text = "";
            txtInitialPoint.Text = "";
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
