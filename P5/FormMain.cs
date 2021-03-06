using System.Windows.Forms;
using System;

namespace P5
{
    public partial class FormMain : Form
    {
        private AppUser _CurrentAppUser = new AppUser();
        private int _CurrentProjectId;
        private FakeAppUserRepository _CurrentFakeAppUserRepository = new FakeAppUserRepository();
        private FakeIssueRepository _CurrentFakeIssueRepository = new FakeIssueRepository();
        private FakeIssueStatusRepository _CurrentFakeIssueStatusRepository = new FakeIssueStatusRepository();
        private FakeFeatureRepository _CurrentFakeFeatureRepository = new FakeFeatureRepository();
        private FakeRequirementRepository _CurrentFakeRequirementRepository = new FakeRequirementRepository();
        private Issue _CurrentSelectedIssue;
        private Feature _CurrentSelectedFeature;
        private Requirement _CurrentSelectedRequirement;
        public FormMain()
        {
            InitializeComponent();
        }

        private void preferencesCreateProjectToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            FormCreateProject form = new FormCreateProject();
            form.ShowDialog();
        }

        private void FormMain_Load(object sender, System.EventArgs e)
        {
            this.CenterToScreen();
            // Force the user to login successfully or abort the application
            DialogResult isOK = DialogResult.OK;
            while (!_CurrentAppUser.IsAuthenticated && isOK == DialogResult.OK)
            {
                FormLogin login = new FormLogin();
                isOK = login.ShowDialog();
                _CurrentAppUser = login._CurrentAppUser;
                login.Dispose();
            }
            if (isOK != DialogResult.OK)
            {
                Close();
                return;
            }
            this.Text = "Main - No Project Selected";
            while (selectAProject() == "")
            {
                DialogResult result = MessageBox.Show("A project must be selected.", "Attention", MessageBoxButtons.OKCancel);
                if (result == DialogResult.Cancel)
                {
                    Close();
                    return;
                }
            }
        }

        private void preferencesSelectProjectToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            selectAProject();
        }

        private string selectAProject()
        {
            string selectedProject = "";
            FormSelectProject form = new FormSelectProject();
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
                FakePreferenceRepository preferenceRepository = new FakePreferenceRepository();
                preferenceRepository.SetPreference(_CurrentAppUser.UserName,
                                                   FakePreferenceRepository.PREFERENCE_PROJECT_NAME,
                                                   form._SelectedProjectName);
                int selectedProjectId = form._SelectedProjectId;
                this._CurrentProjectId = selectedProjectId;
                preferenceRepository.SetPreference(_CurrentAppUser.UserName,
                                                   FakePreferenceRepository.PREFERENCE_PROJECT_ID,
                                                   selectedProjectId.ToString());
                this.Text = "Main - " + form._SelectedProjectName;
                selectedProject = form._SelectedProjectName;

            }
            form.Dispose();
            return selectedProject;
        }

        private void preferencesModifyProjectToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            FormModifyProject form = new FormModifyProject(_CurrentAppUser);
            form.ShowDialog();
            form.Dispose();
        }

        private void preferencesRemoveProjectToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            FormRemoveProject form = new FormRemoveProject(_CurrentAppUser);
            form.ShowDialog();
            form.Dispose();
        }

        private void issuesDashboardToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            
            FormDashboard form = new FormDashboard(_CurrentAppUser, _CurrentProjectId, _CurrentFakeIssueRepository);
            form.ShowDialog();
            form.Dispose();
        }

        private void issuesRecordToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            FormRecord form = new FormRecord(_CurrentAppUser, _CurrentProjectId, _CurrentFakeIssueRepository, _CurrentFakeIssueStatusRepository, _CurrentFakeAppUserRepository);
            form.ShowDialog();
            while (form.DialogResult == DialogResult.OK && form.result != "")
            {
                form.ShowDialog(); 
            }
            form.Dispose();
        }

        private void issuesModifyToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            FormSelectIssue selectIssue = new FormSelectIssue(_CurrentProjectId, _CurrentFakeIssueRepository, _CurrentFakeIssueStatusRepository);
            selectIssue.ShowDialog();
            if (selectIssue.DialogResult == DialogResult.OK && selectIssue.selectedIssue != null)
            {
                _CurrentSelectedIssue = selectIssue.selectedIssue;
                FormModifyIssue modifyIssue = new FormModifyIssue(_CurrentSelectedIssue, _CurrentFakeIssueStatusRepository, _CurrentFakeIssueRepository, _CurrentProjectId, _CurrentFakeAppUserRepository);
                modifyIssue.ShowDialog();
                while (modifyIssue.DialogResult == DialogResult.OK && modifyIssue.result != "") 
                {
                    modifyIssue.ShowDialog();
                }
                modifyIssue.Dispose();
            }
            selectIssue.Dispose();
        }

        private void issuesRemoveToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            FormSelectIssue selectIssue = new FormSelectIssue(_CurrentProjectId, _CurrentFakeIssueRepository, _CurrentFakeIssueStatusRepository);
            selectIssue.ShowDialog();
            if (selectIssue.DialogResult == DialogResult.OK && selectIssue.selectedIssue != null)
            {
                _CurrentSelectedIssue = selectIssue.selectedIssue;
                string message = "Are you sure you want to remove: " + _CurrentSelectedIssue.Title;
                string title = "Confirmation";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {
                    _CurrentFakeIssueRepository.Remove(_CurrentSelectedIssue);
                    _CurrentSelectedIssue = null;
                }
                else
                {
                    message = "Remove canceled.";
                    title = "Attention";
                    buttons = MessageBoxButtons.OK;
                    MessageBox.Show(message, title, buttons);
                }
            }
            selectIssue.Dispose();
        }

        private void featureCreateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCreateFeature createFeature = new FormCreateFeature(_CurrentProjectId, _CurrentFakeFeatureRepository);
            createFeature.ShowDialog();

            while (createFeature.DialogResult == DialogResult.OK && createFeature.returnString != "")
            {
                createFeature.ShowDialog();

            }
            createFeature.Dispose();

        }

        private void featureModifyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSelectFeature formSelectFeature = new FormSelectFeature(_CurrentFakeFeatureRepository, _CurrentProjectId);
            DialogResult selectResult = formSelectFeature.ShowDialog();

            if (selectResult == DialogResult.OK)
            {
                _CurrentSelectedFeature = formSelectFeature.selectedFeature;
                FormModifyFeature formModifyFeature = new FormModifyFeature(_CurrentSelectedFeature, _CurrentFakeFeatureRepository);
                DialogResult modifyResult = formModifyFeature.ShowDialog();
                formModifyFeature.Dispose();
            }
            formSelectFeature.Dispose();

        }

        private void featureRemoveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSelectFeature formSelectFeature = new FormSelectFeature(_CurrentFakeFeatureRepository, _CurrentProjectId);
            formSelectFeature.ShowDialog();

            if (formSelectFeature.DialogResult == DialogResult.OK && formSelectFeature.selectedFeature != null)
            {
                _CurrentSelectedFeature = formSelectFeature.selectedFeature;
                string message = "Are you sure you want to remove: " + _CurrentSelectedFeature.Title;
                string title = "Confirmation";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {
                    if (_CurrentFakeRequirementRepository.CountByFeatureId(_CurrentSelectedFeature.Id) > 0)
                    {
                        message = "There are one or more requirements associated with this feature." +
                                         "These requirements will be destroyed if you remove this feature." +
                                         "Are you sure you want to remove: " + _CurrentSelectedFeature.Title + "?";
                        title = "Confirmation";
                        buttons = MessageBoxButtons.YesNo;
                        result = MessageBox.Show(message, title, buttons);
                        if (result == DialogResult.Yes)
                        {
                            _CurrentFakeRequirementRepository.RemoveByFeatureId(_CurrentSelectedFeature.Id);
                            _CurrentFakeFeatureRepository.Remove(_CurrentSelectedFeature);
                            _CurrentSelectedFeature = null;
                        }
                    } else
                    {
                        _CurrentFakeFeatureRepository.Remove(_CurrentSelectedFeature);
                        _CurrentSelectedFeature = null;
                    }

                }
                else
                {
                    message = "Remove canceled.";
                    title = "Attention";
                    buttons = MessageBoxButtons.OK;
                    MessageBox.Show(message, title, buttons);
                }
            }
            formSelectFeature.Dispose();
        }

        private void requirementCreateToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormCreateRequirement formCreateRequirement = new FormCreateRequirement(_CurrentFakeFeatureRepository, _CurrentFakeRequirementRepository, _CurrentProjectId);
            formCreateRequirement.ShowDialog();
            formCreateRequirement.Dispose();
        }

        private void requirementModifyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormSelectRequirement formSelectRequirement = new FormSelectRequirement(ref _CurrentFakeRequirementRepository, ref _CurrentFakeFeatureRepository, _CurrentProjectId);
            formSelectRequirement.ShowDialog();
            if (formSelectRequirement.DialogResult == DialogResult.OK)
            {
                _CurrentSelectedRequirement = formSelectRequirement.selectedRequirement;
                FormModifyRequirement formModifyRequirement = new FormModifyRequirement(_CurrentFakeRequirementRepository, _CurrentFakeFeatureRepository, _CurrentProjectId, _CurrentSelectedRequirement);
                formModifyRequirement.ShowDialog();
                if (formModifyRequirement.DialogResult == DialogResult.OK)
                {
                    _CurrentSelectedRequirement = null;
                }
                formModifyRequirement.Dispose();
            }
            formSelectRequirement.Dispose();
        }

        private void requirementRemoveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormSelectRequirement formSelectRequirement = new FormSelectRequirement(ref _CurrentFakeRequirementRepository, ref _CurrentFakeFeatureRepository, _CurrentProjectId);
            formSelectRequirement.ShowDialog();
            if (formSelectRequirement.DialogResult == DialogResult.OK)
            {
                _CurrentSelectedRequirement = formSelectRequirement.selectedRequirement;
                string message = "Are you sure you want to remove: " + _CurrentSelectedRequirement.Statement;
                string title = "Confirmation";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {
                    string success =_CurrentFakeRequirementRepository.Remove(_CurrentSelectedRequirement);

                    if (success != "")
                    {
                        message = success;
                        title = "Attention";
                        buttons = MessageBoxButtons.OK;
                        MessageBox.Show(message, title, buttons);
                    } else
                    {
                        _CurrentSelectedRequirement = null;
                    }
                }
            }
            formSelectRequirement.Dispose();
        }
    }
}
