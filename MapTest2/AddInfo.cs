using Foundation;
using System;
using UIKit;

namespace MapTest2
{
    public partial class AddInfo : UIViewController
    {

        public AddInfo (IntPtr handle) : base (handle)
        {
        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            //hide keyboard when click off of it
            var tapOutside = new UITapGestureRecognizer(() => View.EndEditing(true));
            tapOutside.CancelsTouchesInView = false;
            View.AddGestureRecognizer(tapOutside);
            HideOnReturn(StockpileNumberTextField);
            HideOnReturn(CompanyTextField);

        }
        partial void CancelButton_TouchUpInside(UIButton sender)
        {
            ViewChanger changer = new ViewChanger(this, "MainView");
        }

partial void SaveButton_TouchUpInside(UIButton sender)
        {
            StockpileInfo stockpile = new StockpileInfo();
            stockpile.setStockpileNumber(StockpileNumberTextField.Text);
            stockpile.setCompany(CompanyTextField.Text);
            StockpileNumberTextField.Text = "";
            CompanyTextField.Text = "";
            ViewChanger changer = new ViewChanger(this, "MainView");
        }

        void HideOnReturn(UITextField field){
            field.ShouldReturn = (textField) =>
            {
                textField.ResignFirstResponder();
                return true;
            };
            
        }
    }
}