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
        public FormModifyRequirement(FakeRequirementRepository _CurrentFakeRequirementRepository, FakeFeatureRepository _CurrentFakeFeatureRepository, int _CurrentProjectId)
        {
            InitializeComponent();

            fakeRequirementRepository = _CurrentFakeRequirementRepository;
            fakeFeatureRepository = _CurrentFakeFeatureRepository;
            projectId = _CurrentProjectId;

            foreach (Feature f in fakeFeatureRepository.GetAll(projectId))
            {
                comboBox1.Items.Add(f.Title);
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void buttonModifyRequirement_Click(object sender, EventArgs e)
        {
 
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormModifyRequirement_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }
    }
}
