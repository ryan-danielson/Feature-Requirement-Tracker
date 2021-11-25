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
    public partial class FormModifyRequirement : Form
    {
        public FakeRequirementRepository fakeRequirementRepository;
        public FakeFeatureRepository fakeFeatureRepository;
        public int projectId;
        public Requirement selectedRequirement;

        public FormModifyRequirement(FakeRequirementRepository _CurrentFakeRequirementRepository, FakeFeatureRepository _CurrentFakeFeatureRepository, int _CurrentProjectId, Requirement _SelectedRequirement)
        {
            InitializeComponent();

            fakeRequirementRepository = _CurrentFakeRequirementRepository;
            fakeFeatureRepository = _CurrentFakeFeatureRepository;
            projectId = _CurrentProjectId;
            selectedRequirement = _SelectedRequirement;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedRequirement = fakeRequirementRepository.GetRequirementById(comboBox1.SelectedIndex+1);
            textBox1.Text = selectedRequirement.Statement;  
        }

        private void buttonModifyRequirement_Click(object sender, EventArgs e)
        {     
            Requirement requirement = new Requirement();
            requirement.FeaturedId = selectedRequirement.FeaturedId;
            requirement.Id = selectedRequirement.Id;
            requirement.ProjectId = selectedRequirement.ProjectId;
            requirement.Statement = textBox1.Text;


            Feature feature = new Feature();
            feature.ProjectId = projectId;
            feature.Id = fakeFeatureRepository.GetFeatureById(projectId, selectedRequirement.FeaturedId).Id;
            feature.Title = fakeFeatureRepository.GetFeatureById(projectId, selectedRequirement.FeaturedId).Title;


            string featureReturnString;
            string requirementReturnString;

            if (comboBox1.Text != feature.Title)
            {
                feature.Title = comboBox1.Text;
                featureReturnString = fakeFeatureRepository.Modify(feature);

                if (featureReturnString != "")
                    MessageBox.Show(featureReturnString, "", MessageBoxButtons.OK);
            }

            requirementReturnString = fakeRequirementRepository.Modify(requirement);
            if (requirementReturnString != "")
                MessageBox.Show(requirementReturnString, "", MessageBoxButtons.OK);
            
        }

        private void FormModifyRequirement_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            comboBox1.Text = fakeFeatureRepository.GetFeatureById(projectId, selectedRequirement.FeaturedId).Title;
            textBox1.Text = selectedRequirement.Statement;
        }
    }
}
