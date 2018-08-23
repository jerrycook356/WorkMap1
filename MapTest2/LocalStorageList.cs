using System;
using System.Collections.Generic;
using CoreLocation;
namespace MapTest2
{
    public class LocalStorageList
    {
        public static List<CoalAnnotation> annotations = new List<CoalAnnotation>();

        public void AddAnnotation(CoalAnnotation anno)
        {
            lock (annotations)
            {
                annotations.Add(anno);
            }
        }
        public List<CoalAnnotation> GetAllAnnotations()
        {
            return annotations;
        }
        public  void RemoveAnnotation(CLLocationCoordinate2D coord)
        {
            List<CoalAnnotation> foundList = new List<CoalAnnotation>();
            lock (annotations)
            {

                foreach (CoalAnnotation annot in annotations)
                {
                    
                    if (annot.Coordinate.Equals(coord))
                    {
                        foundList.Add(annot);
                    }
                }
                foreach( var a in foundList){
                    annotations.Remove(a);
                }
            }
        }
    }
}
