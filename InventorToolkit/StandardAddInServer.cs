//using System;
//using System.Runtime.InteropServices;
//using Inventor;

//namespace InventorToolkit
//{
//    [Guid("b2c2c4cb-f15d-481e-8913-4a31b7cbf53e")]
//    public class StandardAddInServer : ApplicationAddInServer
//    {
//        private Inventor.Application m_inventorApplication;
//        private ButtonDefinition m_objectCounterButton;
//        private ButtonDefinition m_fileManagerButton;


//        public void Activate(ApplicationAddInSite addInSiteObject, bool firstTime)
//        {
//            m_inventorApplication = addInSiteObject.Application;
//            //////////////////////add in for object counter ////////////////////////////////
//            CommandHandler.AppInstance = m_inventorApplication;

//            Ribbon ribbon = m_inventorApplication.UserInterfaceManager.Ribbons["Part"];

//            RibbonTab tab;
//            try
//            {
//                tab = ribbon.RibbonTabs["toolkitTab"];
//            }
//            catch
//            {
//                tab = ribbon.RibbonTabs.Add(
//                    "Inventor Toolkit",
//                    "toolkitTab",
//                    "{b2c2c4cb-f15d-481e-8913-4a31b7cbf53e}");
//            }

//            RibbonPanel panel;
//            try
//            {
//                panel = tab.RibbonPanels["mainPanel"];
//            }
//            catch
//            {
//                panel = tab.RibbonPanels.Add(
//                    "Tools",
//                    "mainPanel",
//                    "{b2c2c4cb-f15d-481e-8913-4a31b7cbf53e}");
//            }

//            m_objectCounterButton =
//                m_inventorApplication.CommandManager.ControlDefinitions
//                .AddButtonDefinition(
//                    "Object Counter",
//                    "btnObjectCounter",
//                    CommandTypesEnum.kShapeEditCmdType,
//                    "{b2c2c4cb-f15d-481e-8913-4a31b7cbf53e}");

//            m_objectCounterButton.OnExecute += CommandHandler.RunObjectCounter;

//            panel.CommandControls.AddButton(m_objectCounterButton);
//        }

//        public void Deactivate()
//        {
//            m_inventorApplication = null;
//            GC.Collect();
//            GC.WaitForPendingFinalizers();
//        }

//        public void ExecuteCommand(int commandID) { }

//        public object Automation => null;
//    }
//}


using System;
using System.Runtime.InteropServices;
using Inventor;

namespace InventorToolkit
{
    [Guid("b2c2c4cb-f15d-481e-8913-4a31b7cbf53e")]
    public class StandardAddInServer : ApplicationAddInServer
    {
        private Inventor.Application m_inventorApplication;
        private ButtonDefinition m_objectCounterButton;
        private ButtonDefinition m_fileManagerButton;

        public void Activate(ApplicationAddInSite addInSiteObject, bool firstTime)
        {
            m_inventorApplication = addInSiteObject.Application;

            CommandHandler.AppInstance = m_inventorApplication;

            Ribbon ribbon = m_inventorApplication.UserInterfaceManager.Ribbons["Part"];

            RibbonTab tab;
            try
            {
                tab = ribbon.RibbonTabs["toolkitTab"];
            }
            catch
            {
                tab = ribbon.RibbonTabs.Add(
                    "Inventor Toolkit",
                    "toolkitTab",
                    "{b2c2c4cb-f15d-481e-8913-4a31b7cbf53e}");
            }

            RibbonPanel panel;
            try
            {
                panel = tab.RibbonPanels["mainPanel"];
            }
            catch
            {
                panel = tab.RibbonPanels.Add(
                    "Tools",
                    "mainPanel",
                    "{b2c2c4cb-f15d-481e-8913-4a31b7cbf53e}");
            }

            m_objectCounterButton =
                m_inventorApplication.CommandManager.ControlDefinitions
                .AddButtonDefinition(
                    "Object Counter",
                    "btnObjectCounter",
                    CommandTypesEnum.kShapeEditCmdType,
                    "{b2c2c4cb-f15d-481e-8913-4a31b7cbf53e}");

            m_objectCounterButton.OnExecute += CommandHandler.RunObjectCounter;
            panel.CommandControls.AddButton(m_objectCounterButton);

            m_fileManagerButton =
                m_inventorApplication.CommandManager.ControlDefinitions
                .AddButtonDefinition(
                    "File Manager",
                    "btnFileManager",
                    CommandTypesEnum.kFileOperationsCmdType,
                    "{b2c2c4cb-f15d-481e-8913-4a31b7cbf53e}");

            m_fileManagerButton.OnExecute += CommandHandler.RunFileManager;
            panel.CommandControls.AddButton(m_fileManagerButton);
        }

        public void Deactivate()
        {
            m_inventorApplication = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        public void ExecuteCommand(int commandID) { }

        public object Automation => null;
    }
}