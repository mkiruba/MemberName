﻿using System.Runtime.InteropServices;
using Microsoft.Office.Interop.Word;

namespace MemberName
{
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    public partial class ThisDocument : IDocument
    {
        private void ThisDocument_Startup(object sender, System.EventArgs e)
        {
            var application = Globals.ThisDocument.Application;
            application.KeyBindings.Add(WdKeyCategory.wdKeyCategoryCommand, "InsertMember", application.BuildKeyCode(WdKey.wdKeyControl, WdKey.wdKeyM));
        }

        private void ThisDocument_Shutdown(object sender, System.EventArgs e)
        {
        }
        protected override object GetAutomationObject()
        {
            return this;
        }
        protected override Microsoft.Office.Core.IRibbonExtensibility CreateRibbonExtensibilityObject()
        {
            return new Ribbon();
        }

        #region VSTO Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisDocument_Startup);
            this.Shutdown += new System.EventHandler(ThisDocument_Shutdown);
        }

        #endregion

        public void ShowMemberDialog()
        {
            var adapter = new AddinAdapter.AddinAdapter();
            adapter.ShowMemberDialog();
        }
    }
}
