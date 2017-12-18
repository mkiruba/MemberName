using System.Runtime.InteropServices;
using Office = Microsoft.Office.Core;
using Word = Microsoft.Office.Interop.Word;

namespace InsertMember
{
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    public partial class ThisDocument
    {
        private void ThisDocument_Startup(object sender, System.EventArgs e)
        {
            var application = Globals.ThisDocument.Application;
            application.KeyBindings.Add(Word.WdKeyCategory.wdKeyCategoryCommand, "InsertMember", application.BuildKeyCode(Word.WdKey.wdKeyControl, Word.WdKey.wdKeyM));
        }

        private void ThisDocument_Shutdown(object sender, System.EventArgs e)
        {
        }
        protected override object GetAutomationObject()
        {
            return this;
        }
        public string ShowMemberDialog()
        {
            return "Hello";
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
    }
}
