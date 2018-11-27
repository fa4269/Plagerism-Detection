using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using StringSearching;
using System.IO;


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

            Algorithms.Lcs(testLines, solutionLines, testLines.Length, solutionLines.Length);

            // KMP_
            var sentences = testLines.Split('.');
            int plagiarizedSentencesCount = 0;
            foreach (var s in sentences)
            {
                if (Algorithms.KMP_Search(s, solutionLines).Count > 0)
                    plagiarizedSentencesCount++;
            }

            Console.WriteLine($"KMP: {(float)plagiarizedSentencesCount * 100 / sentences.Length }% of sentences are plagiarized.");


        }
    }
}
