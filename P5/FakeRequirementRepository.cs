using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P5
{
    class FakeRequirementRepository : IRequirementRepository
    {
        public string NO_ERROR = "";
        public string DUPLICATE_STATEMENT_ERROR = "Statements must be unique.";
        public string EMPTY_STATEMENT_ERROR = "Statement must have a value.";
        public string REQUIREMENT_NOT_FOUND_ERROR = "Requirement does not exist.";
        public string MISSING_FEATUREDID_ERROR = "Must select a feature for this requirement.";
        public string MISSING_PROJECTID_ERROR = "Must select a project for this requirement.";
        private List<Requirement> requirements;

        public string Add(Requirement requirement)
        {
            foreach (Requirement r in requirements)
            {
                if (r.Statement == requirement.Statement)
                    return DUPLICATE_STATEMENT_ERROR;
            }
            if (requirement.Statement == "")
                return EMPTY_STATEMENT_ERROR;
            return NO_ERROR;
        }
    
        public List<Requirement> GetAll(int ProjectId)
        {
            List<Requirement> getAll = new List<Requirement>();
            foreach (Requirement r in requirements)
            {
                if (r.ProjectId == ProjectId)
                    getAll.Add(r);
            }

            return getAll;
        }

        public string Remove(Requirement requirement)
        {
            foreach (Requirement r in requirements)
            {
                if (r == requirement)
                {
                    requirements.Remove(r);
                    return NO_ERROR;
                }
            }
            return REQUIREMENT_NOT_FOUND_ERROR;
        }

        public string Modify(Requirement requirement)
        {
            return NO_ERROR;
        }

        public Requirement GetRequirementById(int requirementId)
        {
            Requirement requirement = new Requirement();

            foreach (Requirement r in requirements)
            {
                if (r.Id == requirementId)
                    requirement = r;
            }

            return requirement;
        }

        public int CountByFeatureId(int featureId)
        {
            int count = 0;
            foreach (Requirement r in requirements)
            {
                if (r.FeaturedId == featureId)
                    count++;
            }
            return count;
        }

        public void RemoveByFeatureId(int featureId)
        { 
            foreach (Requirement r in requirements)
            {
                if (r.FeaturedId == featureId)
                    requirements.Remove(r);
            }
        }
    }
}
