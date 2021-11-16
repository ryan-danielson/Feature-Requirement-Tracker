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
    public partial class FormDashboard : Form
    {
        private FakeIssueRepository fakeIssueRepository;
        private FakePreferenceRepository preferenceRepository;
        public string preference;
        private int ProjectId;

        public FormDashboard(AppUser _CurrentAppUser, int _CurrentProjectId, FakeIssueRepository _CurrentFakeIssueRepository)
        {
            InitializeComponent();
            fakeIssueRepository = _CurrentFakeIssueRepository;
            preferenceRepository = new FakePreferenceRepository();
            preference = preferenceRepository.GetPreference(_CurrentAppUser.UserName, FakePreferenceRepository.PREFERENCE_PROJECT_NAME);
            ProjectId = _CurrentProjectId;
        }


        private void FormDashboard_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            numIssuesLabel.Text = fakeIssueRepository.GetTotalNumberOfIssues(ProjectId).ToString();

            List<string> issuesByMonth = this.fakeIssueRepository.GetIssuesByMonth(ProjectId);
            List<string> issuesByDiscoverer = this.fakeIssueRepository.GetIssuesByDiscoverer(ProjectId);
            
            foreach (string s in issuesByMonth)
                listBox1.Items.Add(s);

            foreach (string s in issuesByDiscoverer)
                listBox2.Items.Add(s);
        }
    }
}
