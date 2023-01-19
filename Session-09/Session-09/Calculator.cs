namespace Session_09
{
    public partial class Calculator : Form
    {
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