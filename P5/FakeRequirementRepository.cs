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
        { }
        public List<Requirement> GetAll(int ProjectId)
        { }
        public string Remove(Requirement requirement)
        { }
        public string Modify(Requirement requirement)
        { }
        public Requirement GetRequirementById(int requirementId)
        { }
        public int CountByFeatureId(int featureId)
        { }
        public void RemoveByFeatureId(int featureId)
        { }
    }
}
