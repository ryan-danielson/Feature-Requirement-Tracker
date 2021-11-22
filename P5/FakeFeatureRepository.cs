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
        {
            if (feature.Title == "")
                return EMPTY_TITLE_ERROR;
            foreach (Feature f in features)
            {
                if (f.Title == feature.Title)
                    return DUPLICATE_TITLE_ERROR;
            }
            features.Add(feature);
            return NO_ERROR;
        }
        public List<Feature> GetAll(int ProjectId)
        {
            List<Feature> getFeatures = new List<Feature>();
            foreach (Feature f in features)
            {
                if (f.ProjectId == ProjectId)
                    getFeatures.Add(f);
            }
            return getFeatures;
        }
        public string Remove(Feature feature)
        {
            foreach (Feature f in features)
            {
                if (f.Title == feature.Title)
                {
                    features.Remove(f);
                    return NO_ERROR;
                }
            }
            return NOT_FOUND_ERROR;
        }
        public string Modify(Feature feature)
        {
            return "";
        }
        public Feature GetFeatureById(int projectId, int featureId)
        {
            Feature getFeatureByID = new Feature();
            foreach (Feature f in features)
            {
                if (f.ProjectId == projectId && f.Id == featureId)
                    getFeatureByID = f;
            }
            return getFeatureByID;
        }
        public Feature GetFeatureByTitle(int projectId, string title)
        {
            Feature getFeatureByTitle = new Feature();
            foreach (Feature f in features)
            {
                if (f.ProjectId == projectId && f.Title == title)
                    getFeatureByTitle = f;
            }
            return getFeatureByTitle;
        }
    }
}
