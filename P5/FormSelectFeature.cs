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
    public partial class FormSelectFeature : Form
    {
        public Feature selectedFeature;
        public FakeFeatureRepository fakeFeatureRepository;
        public int ProjectId;
        public DataTable dt;
        public int selectedRow = 0;
        public FormSelectFeature(FakeFeatureRepository _CurrentFakeFeatureRepository, int _CurrentProjectId)
        {
            InitializeComponent();
            fakeFeatureRepository = _CurrentFakeFeatureRepository;
            ProjectId = _CurrentProjectId;

            dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("Feature");

            /* populate rows with Issue data */

            if (fakeFeatureRepository != null)
            {
                foreach (Feature f in fakeFeatureRepository.GetAll(ProjectId))
                    dt.Rows.Add(new object[] { f.Id, f.Title });

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewSelectFeature.SelectedRows.Count > 0)
                selectedRow = dataGridViewSelectFeature.SelectedCells[0].RowIndex;
           
            selectedFeature = fakeFeatureRepository.GetFeatureById(ProjectId, Convert.ToInt32(dataGridViewSelectFeature[0, selectedRow].Value));

            if (dataGridViewSelectFeature.SelectedRows.Count == 0)
                buttonSelectFeature.Enabled = false;
            else
                buttonSelectFeature.Enabled = true;
        }

        private void FormSelectFeature_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            dataGridViewSelectFeature.DataSource = dt;
            if (dataGridViewSelectFeature.Rows.Count > 0)
                selectedFeature = fakeFeatureRepository.GetFeatureById(ProjectId, Convert.ToInt32(dataGridViewSelectFeature[0, 0].Value));
            if (dataGridViewSelectFeature.SelectedRows.Count == 0)
                buttonSelectFeature.Enabled = false;
            else
                buttonSelectFeature.Enabled = true;

        }

        private void buttonSelectFeature_Click(object sender, EventArgs e)
        {

        }
    }
}
