namespace Session_09
{
    public partial class Calculator : Form
    {
        private decimal? _value1 = null;
        private decimal? _value2 = null;
        private decimal? _result = null;
        public Calculator()
        {
            InitializeComponent();
        }

        private void Zerobutton_Click(object sender, EventArgs e)
        {
            {
                if (TxtBox.Text == "0")
                {
                    TtxBox.Text = "0";
                }
                else
                {
                    txtBox.Text += "0";
                }
            } 
        }
    }
}