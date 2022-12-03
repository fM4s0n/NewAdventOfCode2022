using AdventOfCode2022;
using System.Linq;

namespace aocDay1Again
{
    public partial class FrmMegaForm : Form
    {

        public FrmMegaForm()
        {
            InitializeComponent();            
        }

        private void BtnDay1_Click(object sender, EventArgs e)
        {
            Day1 day1 = new();
            lblDay1.Text = day1.CalculateElfCalories().ToString();
        }

        private void BtnDay2_Click(object sender, EventArgs e)
        {
            Day2 day2 = new();
            lblDay2AnswerPt1.Text = day2.CalculateGameScore().ToString();
            lblDay2AnswerPt2.Text = day2.CalcPart2().ToString();
        }

        private void BtnDay3_Click(object sender, EventArgs e)
        {
            Day3 day3 = new();

            LblDay3AnswerPt1.Text = day3.Part1().ToString();
            LblDay3AnswerPt2.Text = day3.Part2().ToString();
        }
    }
}