using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P5
{
    class FakeFeatureRepository : IFeatureRepository
    {
        public string NO_ERROR = "";
        public string DUPLICATE_TITLE_ERROR = "Title must be unique.";
        public string EMPTY_TITLE_ERROR = "Title must have a value.";
        public string NOT_FOUND_ERROR = "Feature not found.";
        public string INVALID_PROJECT_ID_ERROR = "Invalid Project Id for Feature.";
        private List<Feature> features;

        public string Add(Feature feature)
        { }
        public List<Feature> GetAll(int ProjectId)
        { }
        public string Remove(Feature feature)
        { }
        public string Modify(Feature feature)
        { }
        public Feature GetFeatureById(int projectId, int featureId)
        { }
        public Feature GetFeatureByTitle(int projectId, string title)
        { }
    }
}
