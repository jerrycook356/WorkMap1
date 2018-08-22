using System;
using CoreLocation;
using MapKit;
namespace MapTest2
{
    public class CoalAnnotation : MKAnnotation
    {
        string stockpileNumber;
        string company;
        CLLocationCoordinate2D coord;
        static double id = 0;


        public CoalAnnotation()
        {
        }

        public CoalAnnotation(string stockPileNumberIn, string companyIn, CLLocationCoordinate2D coordinate2D)
        {
            if ((stockpileNumber != "") && (company != ""))
            {
                this.stockpileNumber = stockPileNumberIn;
                this.company = companyIn;
                this.coord = coordinate2D;
            }
        }

        public override CLLocationCoordinate2D Coordinate => coord;

        public CLLocationCoordinate2D GetCoord()
        {
            return coord;
        }

        public void IncrementId()
        {
            id++;
        }
        public override string Title{
            get{
                return stockpileNumber;
            }
        }
        public override string Subtitle => company;

    }
}
