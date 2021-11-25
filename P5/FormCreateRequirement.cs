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
    public partial class FormCreateRequirement : Form
    {
        public FakeFeatureRepository fakeFeatureRepository;
        public FakeRequirementRepository fakeRequirementRepository;
        public int projectId;
        public Feature selectedFeature;

        public FormCreateRequirement(FakeFeatureRepository _CurrenFeatureRepository, FakeRequirementRepository _CurrentFakeRequirementRepository, int _CurrentProjectId)
        {
            InitializeComponent();
            fakeFeatureRepository = _CurrenFeatureRepository;
            fakeRequirementRepository = _CurrentFakeRequirementRepository;
            projectId = _CurrentProjectId;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            textBox1.ReadOnly = false;
            buttonCreateRequirement.Enabled = true;

            label2.ForeColor = Color.Black;
        }

        private void FormCreateRequirement_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            foreach (Feature f in fakeFeatureRepository.GetAll(projectId))
            {
                comboBox1.Items.Add(f.Title);
            }
        }

        private void buttonCreateRequirement_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                Requirement requirement = new Requirement();

                requirement.Statement = textBox1.Text;
                requirement.FeaturedId = fakeFeatureRepository.GetFeatureByTitle(projectId, comboBox1.SelectedItem.ToString()).Id;
                requirement.ProjectId = projectId;

                string returnString = fakeRequirementRepository.Add(requirement);
                if (returnString != "")
                {
                    string message = returnString;
                    string title = "Attention";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    MessageBox.Show(message, title, buttons);
                }
            }
        }
    }
}
