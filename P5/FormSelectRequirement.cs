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
    public partial class FormSelectRequirement : Form
    {
        public FakeRequirementRepository fakeRequirementRepository;
        public FakeFeatureRepository fakeFeatureRepository;
        public int projectId;
        public DataTable dt;
        public Requirement selectedRequirement;
        private int comboBoxIndex = -1;
        public FormSelectRequirement(ref FakeRequirementRepository _CurrentFakeRequirementRepository, ref FakeFeatureRepository _CurrentFakeFeatureRepository, int projectId)
        {
            InitializeComponent();
            this.fakeRequirementRepository = _CurrentFakeRequirementRepository;
            this.fakeFeatureRepository = _CurrentFakeFeatureRepository;
            this.projectId = projectId;
            dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("Requirement");
            dataGridView1.ColumnHeadersVisible = false;
            label2.ForeColor = Color.Gray;

            foreach (Feature f in fakeFeatureRepository.GetAll(projectId))
            {
                comboBox1.Items.Add(f.Title);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (fakeRequirementRepository.CountByFeatureId(fakeFeatureRepository.GetFeatureByTitle(projectId, comboBox1.SelectedItem.ToString()).Id) > 0)
            {
                /* enable table and components */

                dataGridView1.Enabled = true;
                buttonSelectRequirement.Enabled = true;
                label2.ForeColor = Color.Black;
                label1.ForeColor = Color.Black;
                dataGridView1.ColumnHeadersVisible = true;

                dt.Rows.Clear();
                foreach (Requirement r in fakeRequirementRepository.GetAll(projectId))
                {
                    if (r.FeaturedId == fakeFeatureRepository.GetFeatureByTitle(projectId, comboBox1.Text).Id)
                        dt.Rows.Add(new object[] { r.Id, r.Statement });
                }
            } 
            else
            {
                /* disable table and components */

                dataGridView1.Enabled = false;
                buttonSelectRequirement.Enabled = false;
                label2.ForeColor = Color.Gray;
                dataGridView1.ColumnHeadersVisible = false;
                dt.Rows.Clear();
            }

        }

        private void FormSelectRequirement_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            comboBoxIndex = comboBox1.SelectedIndex;
            dataGridView1.DataSource = dt;

            foreach (Requirement r in fakeRequirementRepository.GetAll(projectId))
            {
                Console.WriteLine(r.Statement);
            }


            if (dataGridView1.Rows.Count > 0)
                selectedRequirement = fakeRequirementRepository.GetRequirementById(Convert.ToInt32(dataGridView1[0, 0].Value));
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonSelectRequirement_Click(object sender, EventArgs e)
        {
            int selectedRow = 0;

            if (dataGridView1.SelectedCells.Count > 0)
            {
                selectedRow = dataGridView1.SelectedCells[0].RowIndex;
                selectedRequirement = fakeRequirementRepository.GetRequirementById(Convert.ToInt32(dataGridView1[0, selectedRow].Value));
            }
           this.Close();
        }
    }
}
