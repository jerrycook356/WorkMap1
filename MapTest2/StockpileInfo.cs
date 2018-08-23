using System;
using MapKit;
using CoreLocation;
namespace MapTest2
{
    public class StockpileInfo
    {
        static string stockpileNumber;
        static string company;
        static CLLocationCoordinate2D coord;


        public StockpileInfo()
        {
        }

        public void setStockpileNumber(string stockPileNumberIn)
        {
            stockpileNumber = stockPileNumberIn;
        }

        public string getStockPileNumber (){
            return stockpileNumber;
        }

        public void setCompany(string companyIn)
        {
            company = companyIn;
        }

        public string getCompany(){
            return company;
        }

        public void setCoord(CLLocationCoordinate2D coordinate2D){
            coord = coordinate2D;
        }

        public CLLocationCoordinate2D getCoord()
        {
            return coord;
        }

        public void Clear()
        {
            stockpileNumber = null;
            company = null;
        }
    }
}
