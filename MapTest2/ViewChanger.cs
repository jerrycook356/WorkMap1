using System;
using UIKit;

namespace MapTest2
{
    public class ViewChanger
    {
        public ViewChanger()
        {
        }
        public ViewChanger(UIViewController view,string changeTo){
            UIStoryboard board =  UIStoryboard.FromName("Main", null);
            UIViewController ctrl = (UIViewController)board.InstantiateViewController(changeTo);
            ctrl.ModalTransitionStyle = UIModalTransitionStyle.FlipHorizontal;
            view.PresentViewController(ctrl, true, null);
        }
    }
}
