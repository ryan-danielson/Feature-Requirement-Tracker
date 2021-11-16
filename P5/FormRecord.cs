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
    public partial class FormRecord : Form
    {
        FakeIssueRepository fakeIssueRepository;
        FakeIssueStatusRepository fakeIssueStatusRepository;
        FakeAppUserRepository fakeAppUserRepository;
        public string result;
        private Issue newIssue;
        private int ProjectId;
        private int issueId;
        private AppUser appUser;
        private string[] statusValues =  
            { 
                "Open", 
                "Assigned", 
                "Fixed", 
                "Closed - Won't fix", 
                "Closed - Fixed", 
                "Closed - by design" 
            };
        public FormRecord(AppUser _CurrentAppUser, int _CurrentProjectId, FakeIssueRepository _CurrentFakeIssueRepository, FakeIssueStatusRepository _CurrentFakeIssueStatusRepository, FakeAppUserRepository _CurrentFakeAppUserRepository)
        {
            InitializeComponent();
            fakeIssueRepository = _CurrentFakeIssueRepository;
            fakeIssueStatusRepository = _CurrentFakeIssueStatusRepository;
            fakeAppUserRepository = _CurrentFakeAppUserRepository;
            ProjectId = _CurrentProjectId;
            appUser = _CurrentAppUser;
            int highId = 0;
            foreach (Issue i in fakeIssueRepository.GetAll(ProjectId))
            {
                if (i.Id > highId)
                    highId = i.Id;
            }
            issueId = highId + 1;
            textBoxId.Text = issueId.ToString();
            foreach (AppUser a in fakeAppUserRepository.GetAll())
                comboBoxDiscoverer.Items.Add(a.LastName + ", " + a.FirstName);
            comboBoxDiscoverer.Text = comboBoxDiscoverer.Items[0].ToString();
            comboBoxStatus.Items.AddRange(statusValues);
            comboBoxStatus.Text = statusValues[0];
        }

        private void FormRecord_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }

        private void buttonCreateIssue_Click(object sender, EventArgs e)
        {
            newIssue = new Issue();
            newIssue.Id = issueId;
            newIssue.ProjectId = ProjectId;
            newIssue.Title = textBoxTitle.Text;
            newIssue.DiscoveryDate = dateTimePickerDiscoveryDate.Value;
            newIssue.Discoverer = comboBoxDiscoverer.Text;
            newIssue.InitialDescription = textBoxDescription.Text;
            newIssue.Component = textBoxComponent.Text;
            newIssue.issueStatusId = comboBoxStatus.SelectedIndex;
            fakeIssueStatusRepository.Add(newIssue.Id, statusValues[newIssue.issueStatusId]);

            result = fakeIssueRepository.Add(newIssue);
            if (result != "")
                MessageBox.Show(result);
        }
    }
}
