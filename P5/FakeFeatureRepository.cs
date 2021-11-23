using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P5
{
    public class FakeFeatureRepository : IFeatureRepository
    {
        public string NO_ERROR = "";
        public string DUPLICATE_TITLE_ERROR = "Title must be unique.";
        public string EMPTY_TITLE_ERROR = "Title must have a value.";
        public string NOT_FOUND_ERROR = "Feature not found.";
        public string INVALID_PROJECT_ID_ERROR = "Invalid Project Id for Feature.";
        private List<Feature> features;

        public FakeFeatureRepository()
        {
            features = new List<Feature>();

        }
        public string Add(Feature feature)
        {
            if (feature.Title == "")
                return EMPTY_TITLE_ERROR;
            foreach (Feature f in features)
            {
                if (f.Title == feature.Title)
                    return DUPLICATE_TITLE_ERROR;
            }
            int featureID = 1;
            foreach (Feature f in features)
            {
                if (f.Id >= featureID)
                    featureID = f.Id + 1;
            }
            feature.Id = featureID;
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
            if (feature.Title == "")
                return EMPTY_TITLE_ERROR;
            foreach (Feature f in features)
            {
                if (f.Title == feature.Title)
                    return DUPLICATE_TITLE_ERROR;
            }
            
            int index = 0;
            foreach (Feature f in features)
            {
                if (feature.Id == f.Id)
                {
                    break;
                }
                index++;
            }
            features[index].Title = feature.Title;
            return NO_ERROR;

        }
        public Feature GetFeatureById(int projectId, int featureId)
        {
            Feature getFeatureByID = new Feature();
            if (features != null)
            {
                foreach (Feature f in features)
                {
                    if (f.ProjectId == projectId && f.Id == featureId)
                        getFeatureByID = f;
                }
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
