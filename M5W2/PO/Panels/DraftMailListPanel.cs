namespace M5W2.M5W2.PO.Panels
{
    class DraftMailListPanel : MailListDecorator
    {
        private const string rowTemplate = "//div[@class='y6']/span[text()='{0}']/../span[contains(text(),'{1}')]"; 


        public DraftMailListPanel(MailListPanel mailListPanel): base(mailListPanel)
        {
        }

        public override string RowTemplate
        {
            get { return rowTemplate; }
            set {  }
        }
    }
}
