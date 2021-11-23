using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P5
{
    public partial class FormModifyFeature : Form
    {
        public Feature selectedFeature;
        private FakeFeatureRepository fakeFeatureRepository;
        public FormModifyFeature(Feature _CurrentFeature, FakeFeatureRepository _CurrentFakeFeatureRepository)
        {
            InitializeComponent();
            selectedFeature = _CurrentFeature;
            fakeFeatureRepository = _CurrentFakeFeatureRepository;
        }

        private void FormModifyFeature_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            this.textBox1.Text = selectedFeature.Title;
        }

        private void buttonModifyFeature_Click(object sender, EventArgs e)
        {
            Feature newFeature = new Feature();
            newFeature.Title = textBox1.Text;
            newFeature.Id = selectedFeature.Id;
            string returnString = fakeFeatureRepository.Modify(newFeature);
            if (returnString != "")
                MessageBox.Show(returnString, "Attention", MessageBoxButtons.OK);
            else
                this.Close();
        }
    }
}
