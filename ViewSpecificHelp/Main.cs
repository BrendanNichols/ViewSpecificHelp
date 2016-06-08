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
            if (commandData.Application.ActiveUIDocument.Selection != null)
            {
                GetElemInfo(commandData.Application.ActiveUIDocument);
            }
            else
            {
                GetViewInfo(commandData.Application.ActiveUIDocument);
            }
            return Result.Succeeded;
        }
        //development and git blank html pages are going here
        //public static string SuperBaseUri = @"C:\Users\brendannichols\Documents\Visual Studio 2015\Projects\ViewSpecificHelp\ViewSpecificHelp\Views";

        //real Beck revit training material going here- Not to be shared!!!
        public static string SuperBaseUri = @"\\dalfs\vbg\Research and Development\VBG Development\RevitHelpButton\Views";

        public void GetViewInfo (UIDocument uiDoc)
        {
            ElementId templateId = uiDoc.ActiveView.ViewTemplateId;
            Element template = uiDoc.Document.GetElement(templateId);
            string templateName = null;
            try
            {
                templateName = template.Name;
            }
            catch { }            
            
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
                case ViewType.Section:
                    ElevationViewRules(viewTitle, templateName);
                    break;
                case ViewType.Schedule:
                    ElevationViewRules(viewTitle, templateName);
                    break;


                default:
                    ProcessStartInfo link = new ProcessStartInfo(SuperBaseUri + @"/Misc/HowTo.html");
                    Process.Start(link);
                    break;
            }
            
        }

        public void GetElemInfo(UIDocument uidoc)
        {
            Document doc = uidoc.Document;
            List<ElementId> selectedIds = new List<ElementId>();
            selectedIds = uidoc.Selection.GetElementIds().ToList();
            //get only first id
            ElementId elemId = selectedIds[0];
            Element myElement = doc.GetElement(elemId);
            Category elemCategory = myElement.Category;
            ElementRules(elemCategory);
            
        }

        public void ElementRules(Category category)
        {
            string baseUri = SuperBaseUri + @"\Elements\";

            if (category.Name.Contains("Air Terminals") == true)
            {
                string partialUri = "AirTerminals" + ".html";
                ProcessStartInfo link = new ProcessStartInfo(baseUri + partialUri);
                Process.Start(link);
            }
            else if (category.Name.Contains("Cable Trays") == true)
            {
                string partialUri = "CableTrays" + ".html";
                ProcessStartInfo link = new ProcessStartInfo(baseUri + partialUri);
                Process.Start(link);
            }
            else if (category.Name.Contains("Casework") == true)
            {
                string partialUri = "Casework" + ".html";
                ProcessStartInfo link = new ProcessStartInfo(baseUri + partialUri);
                Process.Start(link);
            }
            else if (category.Name.Contains("Ceilings") == true)
            {
                string partialUri = "Ceilings" + ".html";
                ProcessStartInfo link = new ProcessStartInfo(baseUri + partialUri);
                Process.Start(link);
            }
            else if (category.Name.Contains("Columns") == true)
            {
                string partialUri = "Columns" + ".html";
                ProcessStartInfo link = new ProcessStartInfo(baseUri + partialUri);
                Process.Start(link);
            }
            else if (category.Name.Contains("Curtain Systems") == true)
            {
                string partialUri = "CurtainSystems" + ".html";
                ProcessStartInfo link = new ProcessStartInfo(baseUri + partialUri);
                Process.Start(link);
            }
            else if (category.Name.Contains("Curtain Wall Mullions") == true)
            {
                string partialUri = "CurtainWallMullions" + ".html";
                ProcessStartInfo link = new ProcessStartInfo(baseUri + partialUri);
                Process.Start(link);
            }
            else if (category.Name.Contains("Doors") == true)
            {
                string partialUri = "Doors" + ".html";
                ProcessStartInfo link = new ProcessStartInfo(baseUri + partialUri);
                Process.Start(link);
            }
            else if (category.Name.Contains("Ducts") == true)
            {
                string partialUri = "Ducts" + ".html";
                ProcessStartInfo link = new ProcessStartInfo(baseUri + partialUri);
                Process.Start(link);
            }
            else if (category.Name.Contains("Floors") == true)
            {
                string partialUri = "Floors" + ".html";
                ProcessStartInfo link = new ProcessStartInfo(baseUri + partialUri);
                Process.Start(link);
            }
            else if (category.Name.Contains("Furniture") == true)
            {
                string partialUri = "Furniture" + ".html";
                ProcessStartInfo link = new ProcessStartInfo(baseUri + partialUri);
                Process.Start(link);
            }
            else if (category.Name.Contains("Generic Models") == true)
            {
                string partialUri = "GenericModels" + ".html";
                ProcessStartInfo link = new ProcessStartInfo(baseUri + partialUri);
                Process.Start(link);
            }
            else if (category.Name.Contains("Grids") == true)
            {
                string partialUri = "Grids" + ".html";
                ProcessStartInfo link = new ProcessStartInfo(baseUri + partialUri);
                Process.Start(link);
            }
            else if (category.Name.Contains("Pads") == true)
            {
                string partialUri = "Pads" + ".html";
                ProcessStartInfo link = new ProcessStartInfo(baseUri + partialUri);
                Process.Start(link);
            }
            else if (category.Name.Contains("Plumbing Fixtures")==true)
            {
                string partialUri = "PlumbingFixtures" + ".html";
                ProcessStartInfo link = new ProcessStartInfo(baseUri + partialUri);
                Process.Start(link);
            }
            else if (category.Name.Contains("Point Clouds") == true)
            {
                string partialUri = "PointClouds" + ".html";
                ProcessStartInfo link = new ProcessStartInfo(baseUri + partialUri);
                Process.Start(link);
            }
            else if (category.Name.Contains("Railings") == true)
            {
                string partialUri = "Railings" + ".html";
                ProcessStartInfo link = new ProcessStartInfo(baseUri + partialUri);
                Process.Start(link);
            }
            else if (category.Name.Contains("Roofs") == true)
            {
                string partialUri = "Roofs" + ".html";
                ProcessStartInfo link = new ProcessStartInfo(baseUri + partialUri);
                Process.Start(link);
            }
            else if (category.Name.Contains("Rooms") == true)
            {
                string partialUri = "Rooms" + ".html";
                ProcessStartInfo link = new ProcessStartInfo(baseUri + partialUri);
                Process.Start(link);
            }
            else if (category.Name.Contains("Site") == true)
            {
                string partialUri = "Site" + ".html";
                ProcessStartInfo link = new ProcessStartInfo(baseUri + partialUri);
                Process.Start(link);
            }
            else if (category.Name.Contains("Stairs") == true)
            {
                string partialUri = "Stairs" + ".html";
                ProcessStartInfo link = new ProcessStartInfo(baseUri + partialUri);
                Process.Start(link);
            }
            else if (category.Name.Contains("Structural Beam Systems") == true)
            {
                string partialUri = "StructuralBeamSystems" + ".html";
                ProcessStartInfo link = new ProcessStartInfo(baseUri + partialUri);
                Process.Start(link);
            }
            else if (category.Name.Contains("Structural Columns") == true)
            {
                string partialUri = "StructuralColumns" + ".html";
                ProcessStartInfo link = new ProcessStartInfo(baseUri + partialUri);
                Process.Start(link);
            }
            else if (category.Name.Contains("Structural Foundations") == true)
            {
                string partialUri = "StructuralFoundations" + ".html";
                ProcessStartInfo link = new ProcessStartInfo(baseUri + partialUri);
                Process.Start(link);
            }
            else if (category.Name.Contains("Structural Framing") == true)
            {
                string partialUri = "StructuralFraming" + ".html";
                ProcessStartInfo link = new ProcessStartInfo(baseUri + partialUri);
                Process.Start(link);
            }
            else if (category.Name.Contains("Topography") == true)
            {
                string partialUri = "Topography" + ".html";
                ProcessStartInfo link = new ProcessStartInfo(baseUri + partialUri);
                Process.Start(link);
            }
            else if (category.Name.Contains("Wall Sweeps") == true)
            {
                string partialUri = "WallSweeps" + ".html";
                ProcessStartInfo link = new ProcessStartInfo(baseUri + partialUri);
                Process.Start(link);
            }
            else if (category.Name.Contains("Walls") == true)
            {
                string partialUri = "Walls" + ".html";
                ProcessStartInfo link = new ProcessStartInfo(baseUri + partialUri);
                Process.Start(link);
            }
            else if (category.Name.Contains("Windows") == true)
            {
                string partialUri = "Windows" + ".html";
                ProcessStartInfo link = new ProcessStartInfo(baseUri + partialUri);
                Process.Start(link);
            }

            else
            {
                ProcessStartInfo link = new ProcessStartInfo(SuperBaseUri + @"/Misc/HowTo.html");
                Process.Start(link);
            }
        }

        public void ScheduleViewRules(string viewTitle, string templateName)
        {
            string baseUri = SuperBaseUri + @"\Schedules\";

            if (viewTitle.Contains("Architecture- Door Schedule") == true)
            {
                string partialUri = "ArchitectureDoorSchedules" + ".html";
                ProcessStartInfo link = new ProcessStartInfo(baseUri + partialUri);
                Process.Start(link);
            }
            else if (viewTitle.Contains("Architecture- Finish Schedule") == true)
            {
                string partialUri = "ArchitectureFinishSchedules" + ".html";
                ProcessStartInfo link = new ProcessStartInfo(baseUri + partialUri);
                Process.Start(link);
            }
            else if (viewTitle.Contains("Architecture- Floor Schedules") == true)
            {
                string partialUri = "ArchitectureFloorSchedules" + ".html";
                ProcessStartInfo link = new ProcessStartInfo(baseUri + partialUri);
                Process.Start(link);
            }
            else if (viewTitle.Contains("Architecture- Parking Schedule") == true)
            {
                string partialUri = "ArchitectureParkingSchedules" + ".html";
                ProcessStartInfo link = new ProcessStartInfo(baseUri + partialUri);
                Process.Start(link);
            }
            else if (viewTitle.Contains("Architecture- Railing Schedule") == true)
            {
                string partialUri = "ArchitectureRailingSchedules" + ".html";
                ProcessStartInfo link = new ProcessStartInfo(baseUri + partialUri);
                Process.Start(link);
            }
            else if (viewTitle.Contains("Architecture- Roof Schedule") == true)
            {
                string partialUri = "ArchitectureRoofSchedules" + ".html";
                ProcessStartInfo link = new ProcessStartInfo(baseUri + partialUri);
                Process.Start(link);
            }
            else if (viewTitle.Contains("Architecture- Building Program") == true)
            {
                string partialUri = "ArchitectureBuildingPrograms" + ".html";
                ProcessStartInfo link = new ProcessStartInfo(baseUri + partialUri);
                Process.Start(link);
            }
            else if (viewTitle.Contains("Architecture- Ceiling Schedule") == true)
            {
                string partialUri = "ArchitectureCeilingSchedules" + ".html";
                ProcessStartInfo link = new ProcessStartInfo(baseUri + partialUri);
                Process.Start(link);
            }
            else if (viewTitle.Contains("Architecture- Dimension Guide") == true)
            {
                string partialUri = "ArchitectureDimensionGuides" + ".html";
                ProcessStartInfo link = new ProcessStartInfo(baseUri + partialUri);
                Process.Start(link);
            }
            else if (viewTitle.Contains("Architecture- Wall Mounted Device Schedule") == true)
            {
                string partialUri = "ArchitectureDeviceShedules" + ".html";
                ProcessStartInfo link = new ProcessStartInfo(baseUri + partialUri);
                Process.Start(link);
            }
            else if (viewTitle.Contains("Code- Area Schedule") == true)
            {
                string partialUri = "CodeAreaSchedules" + ".html";
                ProcessStartInfo link = new ProcessStartInfo(baseUri + partialUri);
                Process.Start(link);
            }
            else if (viewTitle.Contains("Code- Plumbing Fixtures") == true)
            {
                string partialUri = "CodePlumbingFixtures" + ".html";
                ProcessStartInfo link = new ProcessStartInfo(baseUri + partialUri);
                Process.Start(link);
            }
            else if (viewTitle.Contains("Code- Room Occupancy") == true)
            {
                string partialUri = "CodeRoomOccupancy" + ".html";
                ProcessStartInfo link = new ProcessStartInfo(baseUri + partialUri);
                Process.Start(link);
            }
            else if (viewTitle.Contains("Demolition- Note Block") == true)
            {
                string partialUri = "DemolitionNoteBlock" + ".html";
                ProcessStartInfo link = new ProcessStartInfo(baseUri + partialUri);
                Process.Start(link);
            }
            else if (viewTitle.Contains("Drawing List") == true)
            {
                string partialUri = "DrawingLists" + ".html";
                ProcessStartInfo link = new ProcessStartInfo(baseUri + partialUri);
                Process.Start(link);
            }
            else if (viewTitle.Contains("Estimating- Ceiling Schedule") == true)
            {
                string partialUri = "EstimatingCeilingSchedules" + ".html";
                ProcessStartInfo link = new ProcessStartInfo(baseUri + partialUri);
                Process.Start(link);
            }
            else if (viewTitle.Contains("Estimating- Curtain Panels") == true)
            {
                string partialUri = "EstimatingCurtainPanels" + ".html";
                ProcessStartInfo link = new ProcessStartInfo(baseUri + partialUri);
                Process.Start(link);
            }
            else if (viewTitle.Contains("Estimating- Door Schedule") == true)
            {
                string partialUri = "EstimatingDoorSchedules" + ".html";
                ProcessStartInfo link = new ProcessStartInfo(baseUri + partialUri);
                Process.Start(link);
            }
            else if (viewTitle.Contains("Estimating- Floor Finishes") == true)
            {
                string partialUri = "EstimatingFloorFinishSchedules" + ".html";
                ProcessStartInfo link = new ProcessStartInfo(baseUri + partialUri);
                Process.Start(link);
            }
            else if (viewTitle.Contains("Estimating- Glass") == true)
            {
                string partialUri = "EstimatingGlassSchedules" + ".html";
                ProcessStartInfo link = new ProcessStartInfo(baseUri + partialUri);
                Process.Start(link);
            }
            else if (viewTitle.Contains("Estimating- Railing Schedule") == true)
            {
                string partialUri = "EstimatingRailingSchedules" + ".html";
                ProcessStartInfo link = new ProcessStartInfo(baseUri + partialUri);
                Process.Start(link);
            }
            else if (viewTitle.Contains("Estimating- Roof") == true)
            {
                string partialUri = "EstimatingRoofSchedules" + ".html";
                ProcessStartInfo link = new ProcessStartInfo(baseUri + partialUri);
                Process.Start(link);
            }
            else if (viewTitle.Contains("Estimating- Room Finishes") == true)
            {
                string partialUri = "EstimatingRoomFinishSchedules" + ".html";
                ProcessStartInfo link = new ProcessStartInfo(baseUri + partialUri);
                Process.Start(link);
            }
            else if (viewTitle.Contains("Estimating- Structural Columns") == true)
            {
                string partialUri = "EstimatingStructuralColumnSchedules" + ".html";
                ProcessStartInfo link = new ProcessStartInfo(baseUri + partialUri);
                Process.Start(link);
            }
            else if (viewTitle.Contains("Estimating- Structural Foundations") == true)
            {
                string partialUri = "EstimatingStructuralFoundationSchedules" + ".html";
                ProcessStartInfo link = new ProcessStartInfo(baseUri + partialUri);
                Process.Start(link);
            }
            else if (viewTitle.Contains("Estimating- Structural Slabs") == true)
            {
                string partialUri = "EstimatingStructuralSlabSchedules" + ".html";
                ProcessStartInfo link = new ProcessStartInfo(baseUri + partialUri);
                Process.Start(link);
            }
            else if (viewTitle.Contains("Estimating- Wall Schedule") == true)
            {
                string partialUri = "EstimatingWallSchedules" + ".html";
                ProcessStartInfo link = new ProcessStartInfo(baseUri + partialUri);
                Process.Start(link);
            }
            else if (viewTitle.Contains("Estimating- Wall Finishes") == true)
            {
                string partialUri = "EstimatingWallFinishesSchedules" + ".html";
                ProcessStartInfo link = new ProcessStartInfo(baseUri + partialUri);
                Process.Start(link);
            }
            else if (viewTitle.Contains("Estimating- Equipment") == true)
            {
                string partialUri = "EstimatingEquipmentSchedules" + ".html";
                ProcessStartInfo link = new ProcessStartInfo(baseUri + partialUri);
                Process.Start(link);
            }
            else if (viewTitle.Contains("Estimating- Wall Protection") == true)
            {
                string partialUri = "EstimatingWallProtectionSchedules" + ".html";
                ProcessStartInfo link = new ProcessStartInfo(baseUri + partialUri);
                Process.Start(link);
            }
            else if (viewTitle.Contains("Millwork Type") == true)
            {
                string partialUri = "MillworkTypeSchedules" + ".html";
                ProcessStartInfo link = new ProcessStartInfo(baseUri + partialUri);
                Process.Start(link);
            }
            else if (viewTitle.Contains("QC- Door Frames") == true)
            {
                string partialUri = "QCDoorFrameSchedules" + ".html";
                ProcessStartInfo link = new ProcessStartInfo(baseUri + partialUri);
                Process.Start(link);
            }
            else if (viewTitle.Contains("QC- Door Panels") == true)
            {
                string partialUri = "QCDoorPanelSchedules" + ".html";
                ProcessStartInfo link = new ProcessStartInfo(baseUri + partialUri);
                Process.Start(link);
            }
            else if (viewTitle.Contains("QC- Material Description") == true)
            {
                string partialUri = "QCMaterialDescriptionSchedules" + ".html";
                ProcessStartInfo link = new ProcessStartInfo(baseUri + partialUri);
                Process.Start(link);
            }
            else
            {
                ProcessStartInfo link = new ProcessStartInfo(SuperBaseUri + @"/Misc/HowTo.html");
                Process.Start(link);
            }

        }

        public void SectionViewRules(string viewTitle, string templateName)
        {
            string baseUri = SuperBaseUri + @"\Sections\";

            if (viewTitle.Contains("Ceiling/Soffit Section") == true)
            {
                string partialUri = "CeilingSoffitSections" + ".html";
                ProcessStartInfo link = new ProcessStartInfo(baseUri + partialUri);
                Process.Start(link);
            }
            else if (templateName.Contains("Section- Building") == true || viewTitle.Contains("Building Section") == true)
            {
                string partialUri = "BuildingSections" + ".html";
                ProcessStartInfo link = new ProcessStartInfo(baseUri + partialUri);
                Process.Start(link);
            }
            else if (templateName.Contains("Section- Wall") == true || viewTitle.Contains("Wall Section") == true)
            {
                string partialUri = "WallSections" + ".html";
                ProcessStartInfo link = new ProcessStartInfo(baseUri + partialUri);
                Process.Start(link);
            }
            else if (viewTitle.Contains("Roofing Section") == true)
            {
                string partialUri = "RoofingSections" + ".html";
                ProcessStartInfo link = new ProcessStartInfo(baseUri + partialUri);
                Process.Start(link);
            }
            else if (templateName.Contains("Section- Millwork") == true || viewTitle.Contains("Millwork Section") == true)
            {
                string partialUri = "MillworkSections" + ".html";
                ProcessStartInfo link = new ProcessStartInfo(baseUri + partialUri);
                Process.Start(link);
            }
            else if (templateName.Contains("Section- Section Detail") == true)
            {
                string partialUri = "SectionDetails" + ".html";
                ProcessStartInfo link = new ProcessStartInfo(baseUri + partialUri);
                Process.Start(link);
            }
            else if (templateName.Contains("Section- Site") == true)
            {
                string partialUri = "SiteSections" + ".html";
                ProcessStartInfo link = new ProcessStartInfo(baseUri + partialUri);
                Process.Start(link);
            }
            else if (templateName.Contains("Design- Section") == true)
            {
                string partialUri = "DesignSections" + ".html";
                ProcessStartInfo link = new ProcessStartInfo(baseUri + partialUri);
                Process.Start(link);
            }
            else
            {
                ProcessStartInfo link = new ProcessStartInfo(SuperBaseUri + @"/Misc/HowTo.html");
                Process.Start(link);
            }
        }

        public void ElevationViewRules(string viewTitle, string templateName)
        {
            string baseUri = SuperBaseUri + @"\Elevations\";

            if (viewTitle.Contains("Design") == true)
            {
                string partialUri = "DesignElevations" + ".html";
                ProcessStartInfo link = new ProcessStartInfo(baseUri + partialUri);
                Process.Start(link);
            }
            else if (templateName.Contains("Elevation- Exterior") == true || viewTitle.Contains("Ext Elevations") == true)
            {
                string partialUri = "ExtElevations" + ".html";
                ProcessStartInfo link = new ProcessStartInfo(baseUri + partialUri);
                Process.Start(link);
            }
            else if (templateName.Contains("Elevation- Interior") == true || viewTitle.Contains("Int Elevations") == true)
            {
                string partialUri = "IntElevations" + ".html";
                ProcessStartInfo link = new ProcessStartInfo(baseUri + partialUri);
                Process.Start(link);
            }
            else if (viewTitle.Contains("Legend") == true)
            {
                string partialUri = "ElevationLegends" + ".html";
                ProcessStartInfo link = new ProcessStartInfo(baseUri + partialUri);
                Process.Start(link);
            }
            else if (templateName.Contains("Elevation- Demolition") == true)
            {
                string partialUri = "DemolitionElevations" + ".html";
                ProcessStartInfo link = new ProcessStartInfo(baseUri + partialUri);
                Process.Start(link);
            }
            else if (templateName.Contains("Elevation- Millwork") == true)
            {
                string partialUri = "MillworkElevations" + ".html";
                ProcessStartInfo link = new ProcessStartInfo(baseUri + partialUri);
                Process.Start(link);
            }
            else
            {
                ProcessStartInfo link = new ProcessStartInfo(SuperBaseUri + @"/Misc/HowTo.html");
                Process.Start(link);
            }
        }

        public void CeilingPlanViewRules(string viewTitle, string templateName)
        {
            string baseUri = SuperBaseUri +@"\Ceiling Plans\";

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
            else
            {
                ProcessStartInfo link = new ProcessStartInfo(SuperBaseUri + @"/Misc/HowTo.html");
                Process.Start(link);
            }
        }

        public void FloorPlanViewRules (string viewTitle, string templateName)
        {
            //ProcessStartInfo google = new ProcessStartInfo(@"http://lmgtfy.com/?q=How+to+Revit%3F");
            //Process.Start(google);

            string baseUri = SuperBaseUri + @"\Floor Plans\";
            
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
            else
            {
                ProcessStartInfo link = new ProcessStartInfo(SuperBaseUri + @"/Misc/HowTo.html");
                Process.Start(link);
            }

        }
    }
}
