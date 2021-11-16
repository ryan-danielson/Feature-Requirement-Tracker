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
    public partial class FormModifyIssue : Form
    {
        public Issue currentIssue;
        public FakeIssueStatusRepository fakeIssueStatusRepository;
        public FakeIssueRepository fakeIssueRepository;
        public FakeAppUserRepository fakeAppUserRepository;
        public int ProjectId;
        public string result;
        private string[] statusValues =
            {
                "Open",
                "Assigned",
                "Fixed",
                "Closed - Won't fix",
                "Closed - Fixed",
                "Closed - by design"
            };
        public FormModifyIssue(Issue _CurrentIssue, FakeIssueStatusRepository _CurrentFakeIssueStatusRepository, 
            FakeIssueRepository _CurrentFakeIssueRepository, int _CurrentProjectId, FakeAppUserRepository _CurrentFakeAppUserRepository)
        {
            InitializeComponent();
            this.currentIssue = _CurrentIssue;
            this.fakeIssueStatusRepository = _CurrentFakeIssueStatusRepository;
            this.fakeIssueRepository = _CurrentFakeIssueRepository;
            this.fakeAppUserRepository = _CurrentFakeAppUserRepository;
            this.ProjectId = _CurrentProjectId;

            this.textBoxId.Text = currentIssue.Id.ToString();
            this.textBoxTitle.Text = currentIssue.Title;
            this.dateTimePickerDiscoveryDate.Value = currentIssue.DiscoveryDate;
            foreach (AppUser a in fakeAppUserRepository.GetAll())
                comboBoxDiscoverer.Items.Add(a.LastName + ", " + a.FirstName);
            comboBoxDiscoverer.Text = comboBoxDiscoverer.Items[0].ToString();
            this.textBoxComponent.Text = currentIssue.Component;
            this.comboBoxStatus.Items.AddRange(statusValues);
            this.comboBoxStatus.Text = statusValues[currentIssue.issueStatusId];
            this.textBoxDescription.Text = currentIssue.InitialDescription;

        }

        private void buttonCreateIssue_Click(object sender, EventArgs e)
        {
            currentIssue.Title = textBoxTitle.Text;
            currentIssue.DiscoveryDate = dateTimePickerDiscoveryDate.Value;
            currentIssue.Discoverer = comboBoxDiscoverer.Text;
            currentIssue.InitialDescription = textBoxDescription.Text;
            currentIssue.Component = textBoxComponent.Text;
            currentIssue.issueStatusId = comboBoxStatus.SelectedIndex;
            fakeIssueStatusRepository.Add(currentIssue.Id, statusValues[currentIssue.issueStatusId]);

            result = fakeIssueRepository.Modify(currentIssue);

            if (result != "")
                MessageBox.Show(result);
        }

        private void FormModifyIssue_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }
    }
}
