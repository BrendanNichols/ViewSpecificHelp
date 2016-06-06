using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;

namespace ViewSpecificHelp
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class Entry:IExternalApplication
    {
        static string _path = typeof(Entry).Assembly.Location;


        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }

        public Result OnStartup(UIControlledApplication app)
        {
            RibbonPanel Room3d = app.CreateRibbonPanel("Beck", "Revit Help");
            PushButtonData buttonData = new PushButtonData("myButton", "Revit Help", _path, "ViewSpecificHelp.Main");

            Uri uriImage = new Uri("////Atlfs//public//BNichols//Coding//ViewSpecificHelp//QuestionMarkSmall.png");
            BitmapImage largeImage = new BitmapImage(uriImage);

            buttonData.LargeImage = largeImage;

            RibbonItem myButton = Room3d.AddItem(buttonData);



            return Result.Succeeded;

        }
    }
}
