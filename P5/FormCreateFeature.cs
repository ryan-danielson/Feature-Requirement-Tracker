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
    public partial class FormCreateFeature : Form
    {
        public string title;
        private int currentProjectId;
        private FakeFeatureRepository currentFakeFeatureRepository;
        public string returnString;

        public FormCreateFeature(int _CurrentProjectId, FakeFeatureRepository _CurrentFakeFeatureRepository)
        {
            InitializeComponent();
            currentProjectId = _CurrentProjectId;
            currentFakeFeatureRepository = _CurrentFakeFeatureRepository;
        }

        private void buttonCreateFeature_Click(object sender, EventArgs e)
        {
            this.title = textBox1.Text;
            Feature newFeature = new Feature();
            newFeature.ProjectId = currentProjectId;
            newFeature.Title = title;
            returnString = currentFakeFeatureRepository.Add(newFeature);
            if (returnString != "")
                MessageBox.Show(returnString, "", MessageBoxButtons.OK);
            else
                this.Close();
        }

        private void FormCreateFeature_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }
    }
}
