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
    public partial class FormSelectIssue : Form
    {
        public FakeIssueRepository fakeIssueRepository;
        public FakeIssueStatusRepository fakeIssueStatusRepository;
        public int ProjectId;
        public DataTable dt;
        public Issue selectedIssue;

        public FormSelectIssue(int _ProjectId, FakeIssueRepository _FakeIssueRepository, FakeIssueStatusRepository _FakeIssueStatusRepository)
        {
            fakeIssueRepository = _FakeIssueRepository;
            fakeIssueStatusRepository = _FakeIssueStatusRepository;
            ProjectId = _ProjectId;

            InitializeComponent();
            

            dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("Title");
            dt.Columns.Add("DiscoveryDate");
            dt.Columns.Add("Discoverer");
            dt.Columns.Add("InitialDescription");
            dt.Columns.Add("Component");
            dt.Columns.Add("Status");

            /* populate rows with Issue data */

            if (fakeIssueRepository != null)
            {
                foreach (Issue i in fakeIssueRepository.GetAll(ProjectId))
                    dt.Rows.Add(new object[] { i.Id, i.Title, i.DiscoveryDate, i.Discoverer, i.InitialDescription, i.Component, fakeIssueStatusRepository.GetValueById(i.Id) });
                
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedRow = 0;
            if (dataGridView1.SelectedCells.Count > 0)
                selectedRow = dataGridView1.SelectedCells[0].RowIndex;
            
            selectedIssue = fakeIssueRepository.GetIssueById(Convert.ToInt32(dataGridView1[0, selectedRow].Value));
        }

        private void FormSelectIssue_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            dataGridView1.DataSource = dt;
            if (dataGridView1.Rows.Count > 0)
                selectedIssue = fakeIssueRepository.GetIssueById(Convert.ToInt32(dataGridView1[0, 0].Value));
        }
    }
}
