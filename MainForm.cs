using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;


namespace VKStoriesParser
{
    public partial class MainForm : Form
    {
        private Regex _globalPattern;
        private Regex _srcPattern;

        public MainForm()
        {
            InitializeComponent();

            _globalPattern = new Regex("class=\"stories_video\".*src=\"https://.*;");
            _srcPattern = new Regex("(?<=src=\").*(?=\"\\sstyle)");
        }

        private string GetUrl(Regex pattern, string text)
        {
            string result = String.Empty;

            MatchCollection matchCollection = pattern.Matches(text);

            foreach (var match in matchCollection)
            {
                result += match.ToString();
            }

            return result;
        }

        private void InputTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                OutputBox.Text = GetUrl(_srcPattern, GetUrl(_globalPattern, InputTextBox.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }
    }
}
