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

        public static string SuperBaseUri = @"C:\Users\brendannichols\Documents\Visual Studio 2015\Projects\ViewSpecificHelp\ViewSpecificHelp\Views";

        public void GetViewInfo (UIDocument uiDoc)
        {
            ElementId templateId = uiDoc.ActiveView.ViewTemplateId;
            Element template = uiDoc.Document.GetElement(templateId);
            string templateName = template.Name;

            string viewTitle = uiDoc.ActiveView.Title;
            switch (uiDoc.ActiveView.ViewType)
            {
                case ViewType.FloorPlan:
                    FloorPlanViewRules(viewTitle, templateName);
                    break;
                case ViewType.CeilingPlan:
                    CeilingPlanViewRules(viewTitle, templateName);
                    break;
                case ViewType.Elevation:
                    ElevationViewRules(viewTitle, templateName);
                    break;

            }
            
        }

        public void ElevationViewRules(string viewTitle, string templateName)
        {
            string baseUri = SuperBaseUri + @"\Elevations";

            if (viewTitle.Contains("Design") == true)
            {
                string partialUri = "DesignCeilingPlans" + ".html";
                ProcessStartInfo link = new ProcessStartInfo(baseUri + partialUri);
                Process.Start(link);
            }
            else if (viewTitle.Contains("Coordination Views") == true)
            {
                string partialUri = "CoordinationCeilingPlans" + ".html";
                ProcessStartInfo link = new ProcessStartInfo(baseUri + partialUri);
                Process.Start(link);
            }
        }

        public void CeilingPlanViewRules(string viewTitle, string templateName)
        {
            string baseUri = SuperBaseUri +@"\Ceiling Plans";

            if (templateName.Contains("Design- RCP") == true || viewTitle.Contains("Design") == true)
            {
                string partialUri = "DesignCeilingPlans" + ".html";
                ProcessStartInfo link = new ProcessStartInfo(baseUri + partialUri);
                Process.Start(link);
            }
            else if (viewTitle.Contains("Coordination Views") == true)
            {
                string partialUri = "CoordinationCeilingPlans" + ".html";
                ProcessStartInfo link = new ProcessStartInfo(baseUri + partialUri);
                Process.Start(link);
            }
            else if (templateName.Contains("RCP- Partial RCP") == true || viewTitle.Contains("Partial Ceiling Plan") == true)
            {
                string partialUri = "PartialCeilingPlans" + ".html";
                ProcessStartInfo link = new ProcessStartInfo(baseUri + partialUri);
                Process.Start(link);
            }
            else if (viewTitle.Contains("Generic") == true)
            {
                string partialUri = "GenericCeilingPlans" + ".html";
                ProcessStartInfo link = new ProcessStartInfo(baseUri + partialUri);
                Process.Start(link);
            }
            else if (viewTitle.Contains("Legends") == true)
            {
                string partialUri = "LegendsCeilingPlans" + ".html";
                ProcessStartInfo link = new ProcessStartInfo(baseUri + partialUri);
                Process.Start(link);
            }
        }

        public void FloorPlanViewRules (string viewTitle, string templateName)
        {
            //ProcessStartInfo google = new ProcessStartInfo(@"http://lmgtfy.com/?q=How+to+Revit%3F");
            //Process.Start(google);

            string baseUri = SuperBaseUri + @"\Floor Plans";
            
            if (viewTitle.Contains("Home View")==true)
            {
                string partialUri = "HomeView" + ".html";
                ProcessStartInfo link = new ProcessStartInfo(baseUri + partialUri);
                Process.Start(link);
            }
            else if (templateName.Contains("Design- Floor Plan") == true || viewTitle.Contains("Design- Floor Plan") == true)
            {
                string partialUri = "DesignFloorPlan" + ".html";
                ProcessStartInfo link = new ProcessStartInfo(baseUri + partialUri);
                Process.Start(link);
            }
            else if (templateName.Contains("Design- Site Plan") == true || viewTitle.Contains("Design- Site Plan") == true)
            {
                string partialUri = "DesignSitePlan" + ".html";
                ProcessStartInfo link = new ProcessStartInfo(baseUri + partialUri);
                Process.Start(link);
            }
            else if (templateName.Contains("Coord-Plan-All") == true || viewTitle.Contains("Coordination Views- All") == true)
            {
                string partialUri = "CoordinationViewAll" + ".html";
                ProcessStartInfo link = new ProcessStartInfo(baseUri + partialUri);
                Process.Start(link);
            }
            else if (templateName.Contains("Floor Plan- Code Compliance") == true || viewTitle.Contains("Code Compliance Plans") == true)
            {
                string partialUri = "CodeCompliancePlans" + ".html";
                ProcessStartInfo link = new ProcessStartInfo(baseUri + partialUri);
                Process.Start(link);
            }
            else if (templateName.Contains("Floor Plan- Site Plan") == true || viewTitle.Contains("Floor Plan- Site Plan") == true)
            {
                string partialUri = "FloorPlanSitePlan" + ".html";
                ProcessStartInfo link = new ProcessStartInfo(baseUri + partialUri);
                Process.Start(link);
            }
            else if (templateName.Contains("Floor Plan- Pad Plan") == true || viewTitle.Contains("Floor Plan- Pad Plan") == true)
            {
                string partialUri = "FloorPlanPadPlan" + ".html";
                ProcessStartInfo link = new ProcessStartInfo(baseUri + partialUri);
                Process.Start(link);
            }
            else if (templateName.Contains("Floor Plan- Demolition") == true || viewTitle.Contains("Demolition") == true)
            {
                string partialUri = "DemolitionPlan" + ".html";
                ProcessStartInfo link = new ProcessStartInfo(baseUri + partialUri);
                Process.Start(link);
            }
            else if (templateName.Contains("Floor Plan- Overall") == true || viewTitle.Contains("Dimensionsal Control") == true)
            {
                string partialUri = "DimensionalControl" + ".html";
                ProcessStartInfo link = new ProcessStartInfo(baseUri + partialUri);
                Process.Start(link);
            }
            else if (templateName.Contains("Demolition") == true || viewTitle.Contains("Overall") == true)
            {
                string partialUri = "FloorPlanOverall" + ".html";
                ProcessStartInfo link = new ProcessStartInfo(baseUri + partialUri);
                Process.Start(link);
            }
            else if (templateName.Contains("Floor Plan- Partial Floor Plan") == true || viewTitle.Contains("Partial Floor Plans") == true)
            {
                string partialUri = "PartialFloorPlans" + ".html";
                ProcessStartInfo link = new ProcessStartInfo(baseUri + partialUri);
                Process.Start(link);
            }
            else if (templateName.Contains("Partial Finish Plan") == true || viewTitle.Contains("Partial Finish Plan") == true)
            {
                string partialUri = "PartialFinishPlans" + ".html";
                ProcessStartInfo link = new ProcessStartInfo(baseUri + partialUri);
                Process.Start(link);
            }
            else if (templateName.Contains("Partial Floor Pattern Plan") == true || viewTitle.Contains("Partial Floor Pattern Plan") == true)
            {
                string partialUri = "PartialFloorPatternPlans" + ".html";
                ProcessStartInfo link = new ProcessStartInfo(baseUri + partialUri);
                Process.Start(link);
            }
            else if (viewTitle.Contains("Equipment Plans") == true)
            {
                string partialUri = "EquipmentPlans" + ".html";
                ProcessStartInfo link = new ProcessStartInfo(baseUri + partialUri);
                Process.Start(link);
            }
            else if (viewTitle.Contains("Generic") == true)
            {
                string partialUri = "GenericPlans" + ".html";
                ProcessStartInfo link = new ProcessStartInfo(baseUri + partialUri);
                Process.Start(link);
            }
            else if (viewTitle.Contains("Legends") == true)
            {
                string partialUri = "LegendsPlans" + ".html";
                ProcessStartInfo link = new ProcessStartInfo(baseUri + partialUri);
                Process.Start(link);
            }

        }
    }
}
