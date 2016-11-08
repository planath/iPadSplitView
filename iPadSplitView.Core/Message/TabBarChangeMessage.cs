namespace iPadSplitView.iOS
{
    public class TabBarChangeMessage
    {
        public int SelectedTabIs { get; set; }
        public int? SelectedRowWas { get { return _selectedRowWas; } set { _selectedRowWas = value; } }
        private int? _selectedRowWas = null;
    }
}