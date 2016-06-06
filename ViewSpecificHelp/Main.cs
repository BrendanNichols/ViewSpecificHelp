using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;



using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB.Structure;


namespace ViewSpecificHelp
{
    [TransactionAttribute(TransactionMode.Manual)]
    [RegenerationAttribute(RegenerationOption.Manual)]

    public class Main : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            GetViewInfo(commandData.Application.ActiveUIDocument);
            return Result.Succeeded;
        }


        public void GetViewInfo (UIDocument uiDoc)
        {
            string viewTitle = uiDoc.ActiveView.Title;
            ViewRulesTester(viewTitle);
        }

        public void ViewRulesTester (string viewTitle)
        {
            ProcessStartInfo google = new ProcessStartInfo(@"http://lmgtfy.com/?q=How+to+Revit%3F");
            Process.Start(google);
        }
    }
}
