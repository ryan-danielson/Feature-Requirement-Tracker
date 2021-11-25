using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P5
{
    public class FakeRequirementRepository : IRequirementRepository
    {
        public string NO_ERROR = "";
        public string DUPLICATE_STATEMENT_ERROR = "Statements must be unique.";
        public string EMPTY_STATEMENT_ERROR = "Statement must have a value.";
        public string REQUIREMENT_NOT_FOUND_ERROR = "Requirement does not exist.";
        public string MISSING_FEATUREDID_ERROR = "Must select a feature for this requirement.";
        public string MISSING_PROJECTID_ERROR = "Must select a project for this requirement.";
        private List<Requirement> requirements = new List<Requirement>();

        public string Add(Requirement requirement)
        {

            if (requirements.Exists(item => item.Statement == requirement.Statement))
                return DUPLICATE_STATEMENT_ERROR;

            if (requirement.Statement == "")
                return EMPTY_STATEMENT_ERROR;
            
            int requirementId = 1;

            foreach (Requirement r in requirements)
            {
                if (r.Id >= requirementId)
                    requirementId = r.Id + 1;
            }
            requirement.Id = requirementId;
            requirements.Add(requirement);
            return NO_ERROR;
        }
    
        public List<Requirement> GetAll(int ProjectId)
        {
            return requirements.FindAll(items => items.ProjectId == ProjectId);
        }

        public string Remove(Requirement requirement)
        {
            if (requirements.Remove(requirements.Find(item => item == requirement)))
            {
                foreach (Requirement r in requirements)
                    Console.WriteLine("Still in repo: {0}",r.Statement);

                return NO_ERROR;
            }
            else
                return REQUIREMENT_NOT_FOUND_ERROR;
        }

        public string Modify(Requirement requirement)
        {
            if (requirement.Statement == "")
                return EMPTY_STATEMENT_ERROR;
            
            requirement.Id = requirements.Find(item => item.FeaturedId == requirement.FeaturedId).Id;

            requirements[requirement.Id-1].Statement = requirement.Statement;
            return NO_ERROR;
            
        }

        public Requirement GetRequirementById(int requirementId)
        {
            return requirements.Find(item => item.Id == requirementId);
        }

        public int CountByFeatureId(int featureId)
        {
            return requirements.FindAll(item => item.FeaturedId == featureId).Count();
        }

        public void RemoveByFeatureId(int featureId)
        {
            requirements.RemoveAll(item => item.FeaturedId == featureId);
        }
    }
}
