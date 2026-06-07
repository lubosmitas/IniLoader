namespace IniLoaderDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var cfg = new Config();
            propertyGrid1.SelectedObject = cfg;
        }

        private void btnLoadIni_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Filter = "INI files (*.ini)|*.ini|All files (*.*)|*.*";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    var config = new Config();

                    var loader = new IniLoader.IniLoader();

                    loader.LoadObjects(dlg.FileName, config);

                    propertyGrid1.SelectedObject = config;
                }
            }
        }
    }
}
