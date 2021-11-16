using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P5
{
    public class FakeIssueRepository : IIssueRepository
    {
        public string NO_ERROR = "";
        public string EMPTY_TITLE_ERROR = "A Title is required.";
        public string EMPTY_DISCOVERY_DATETIME_ERROR = "Must select a Discovery Date/Time.";
        public string FUTURE_DISCOVERY_DATETIME_ERROR = "Issues can't be from the future.";
        public string EMPTY_DISCOVERER_ERROR = "A Discoverer is required.";
        private List<Issue> Issues { get; set; }


        public FakeIssueRepository()
        {
            Issues = new List<Issue>();
        }
        private string ValidateIssue(Issue issue)
        {
            if (issue.Title == "")
                return EMPTY_TITLE_ERROR;
            else if (issue.Discoverer == "")
                return EMPTY_DISCOVERER_ERROR;
            else if (issue.DiscoveryDate > DateTime.Now)
                return FUTURE_DISCOVERY_DATETIME_ERROR;
            else if (issue.DiscoveryDate == null)
                return EMPTY_DISCOVERY_DATETIME_ERROR;
            return NO_ERROR;
        }

        private bool IsDuplicate(string title)
        {
            if (Issues != null)
            {
                foreach (Issue issue in Issues)
                {
                    if (issue.Title == title)
                        return true;
                }
            }

            return false;
        }

        public string Add(Issue issue)
        {
            string result = ValidateIssue(issue);
            if (result == NO_ERROR)
            {
                if (!IsDuplicate(issue.Title))
                    Issues.Add(issue);
                else
                    result = "Title already exists";
            }
            return result;
        }

        public List<Issue> GetAll(int ProjectId)
        {
            List<Issue> newList = new List<Issue>();
            if (Issues != null)
            {
                foreach (Issue i in Issues)
                {
                    if (i.ProjectId == ProjectId)
                        newList.Add(i);
                }
            }

            return newList;
        }

        public bool Remove(Issue issue)
        {
            if (Issues != null)
            {
                foreach (Issue i in Issues)
                {
                    if (i == issue)
                    {
                        Issues.Remove(issue);
                        return true;
                    }
                }
            }

            return false;
        }

        public string Modify(Issue issue)
        {
            string result = ValidateIssue(issue);
            if (result == NO_ERROR)
            {
                Issue temp = GetIssueById(issue.Id);
                Issues.Remove(temp);
                Issues.Add(issue);
            }
            return result;
        }

        public int GetTotalNumberOfIssues(int ProjectId)
        {
            int ctr = 0;
            if (Issues != null)
            {
                foreach (Issue i in Issues)
                {
                    if (i.ProjectId == ProjectId)
                        ctr++;
                }
            }
            return ctr;
        }

        public List<string> GetIssuesByMonth(int ProjectId)
        {
            List<string> issuesByMonth = new List<string>();
            

            foreach (Issue i in Issues)
            {  
                if (i.ProjectId == ProjectId)
                {
                    issuesByMonth.Add(i.DiscoveryDate.Date.ToLongDateString());
                }
            }
 
            return issuesByMonth;
        }

        public List<string> GetIssuesByDiscoverer(int ProjectId)
        {
            List<string> issuesByDiscoverer = new List<string>();

            if (Issues != null)
            {
                foreach (Issue i in Issues)
                {
                    if (i.ProjectId == ProjectId)
                    {
                        issuesByDiscoverer.Add(i.Discoverer);
                    }
                }
            }

            return issuesByDiscoverer;
        }

        public Issue GetIssueById(int Id)
        {
            Issue issueById = new Issue();

            if (Issues != null)
            {
                foreach (Issue i in Issues)
                {
                    if (i.Id == Id)
                        issueById = i;
                }
            }

            return issueById;
        }
    }
}
