using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StringSearching;

namespace PlagiarismDetectionApp
{
    class Program
    {
        static string[] FileSelection()
        {

            OpenFileDialog ofd1 = new OpenFileDialog();
            OpenFileDialog ofd2 = new OpenFileDialog();

            ofd1.Filter = "Text Files|*.txt";
            ofd1.Title = "Select Test Document";

            ofd2.Filter = "Text Files|*.txt";
            ofd2.Title = "Select Solution Document";

            while (ofd1.ShowDialog() != DialogResult.OK)
            {
                Console.WriteLine("Select Test Document");
            }

            while (ofd2.ShowDialog() != DialogResult.OK)
            {
                Console.WriteLine("Select Solution Document");
            }
            var fileStream1 = new FileStream(ofd1.FileName, FileMode.Open, FileAccess.Read);
            var fileStream2 = new FileStream(ofd2.FileName, FileMode.Open, FileAccess.Read);

            var testReader = new StreamReader(fileStream1, Encoding.UTF8);
            var solutionReader = new StreamReader(fileStream2, Encoding.UTF8);

            string testLines = testReader.ReadToEnd();
            string solutionLines = solutionReader.ReadToEnd();

            string[] lines = new string[] { testLines, solutionLines };

            return lines;
        }
        [STAThread]
        static void Main(string[] args)
        {

            string[] lines = FileSelection();
            string testLines = lines[0];
            string solutionLines = lines[1];

            Lcs(testLines, solutionLines, testLines.Length, solutionLines.Length);

        }
    }
}
