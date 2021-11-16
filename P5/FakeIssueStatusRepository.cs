using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P5
{
    public class FakeIssueStatusRepository : IIssueStatusRepository
    {
        private List<IssueStatus> IssueStatuses;

        public FakeIssueStatusRepository() 
        {
            IssueStatuses = new List<IssueStatus>();
        }

        public void Add(int Id, string value) 
        {

            IssueStatus issueStatus = new IssueStatus();
            issueStatus.Id = Id;
            issueStatus.Value = value;
            IssueStatuses.Add(issueStatus);
        }

        public List<IssueStatus> GetAll()
        {
            return IssueStatuses;
        }

        public int GetIdByStatus(string value) 
        {
            int id = -1;
            foreach (IssueStatus i in IssueStatuses)
            {
                if (i.Value == value)
                    id = i.Id;
            }
            return id;
        }

        public string GetValueById(int Id)
        {
            foreach (IssueStatus i in IssueStatuses)
            {
                if (i.Id == Id)
                {
                    return i.Value;
                }
            }
            return "ID not found";
        }
    }
}
