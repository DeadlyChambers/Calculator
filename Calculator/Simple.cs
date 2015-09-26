using System.Collections.Generic;
using System.Linq;

namespace Calculator
{
    /// <summary>
    /// Simple Calculator that will perform simple mathmatic operations given single spaced problem.
    /// Possible string characters: 0-9, ., (, ), +, -,*,/
    /// </summary>
    public class Simple
    {
        /// <summary>
        /// This will contain each part of the equation in order
        /// </summary>
        private List<string> ProblemParsed { get; set; }

        /// <summary>
        /// All numbers , operators, and parenthesis will be space separated.  The plan is
        /// to recursively drill down through all parans until it is down to just that problem.
        /// Then coming back up that part of the problem has already been solved. This way we
        /// can just run order of operations on it.
        /// </summary>
        /// <param name="math">4 * 8 + -5.3 / ( 9 + 7 )</param>
        /// <returns></returns>
        public double Solve(string math)
        {

            ProblemParsed = EnsureProperlySpacedProblem(math).Split(null).ToList();
            ParseProblemWithParans(ProblemParsed.Count);
           return SolveOrderOfOperations(ProblemParsed);
        }
        /// <summary>
        /// If I was going to ensure each piece of the math problem was properly spaced,
        /// I would do that right here. Might make public so I could write tests directly
        /// against this.
        /// </summary>
        /// <param name="math"></param>
        /// <returns></returns>
        private string EnsureProperlySpacedProblem(string math)
        {
            return math;
        }
      
        /// <summary>
        /// If the problem has parans we will turn those into doubles so that the problem will only
        /// need to follow order of operations. We go from right to left drilling into each set of parans
        /// as a right paran is found. Finding the answer for that set of parans as we go along. Then turning
        /// the left paran into the solved version of the paran and replacing the rest with an empty string.
        /// </summary>
        /// <param name="currentPos">Right position in ProblemParsed List</param>
        private void ParseProblemWithParans(int currentPos)
        {
            for (var x = currentPos - 1; x >= 0; x--)
            {
                switch (ProblemParsed[x])
                {
                    case ")":
                        ParseProblemWithParans(x);
                        break;
                    case "(":
                        SolveSectionWithParans(x, currentPos);
                        if(x>0)//We have to exit out of this scope for nested parans
                            return;
                        break;
                }
            }
        }


        /// <summary>
        /// We need to ensure order of operations occur first on paranthesis. This will pull out
        /// the core of a parans to evaluate and store back into the main list in the position of
        /// the left paran.
        /// </summary>
        /// <param name="leftParan"></param>
        /// <param name="rightParan"></param>
        /// <returns></returns>
        private void SolveSectionWithParans(int leftParan, int rightParan)
        {
            var coreProblemOfParans = ProblemParsed.GetRange(leftParan + 1, rightParan - leftParan - 1);
            ProblemParsed[leftParan] = SolveOrderOfOperations(coreProblemOfParans).ToString();
            for (var x = leftParan + 1; x <= rightParan; x++)
                ProblemParsed[x] = "";
        }


        /// <summary>
        /// This will do the order of operations as expected, multiplication and division then
        /// addition and subtraction. At this point we should not be getting anything that has 
        /// parans.
        /// </summary>
        /// <param name="section">A list of the operands and variables</param>
        /// <returns></returns>
        private double SolveOrderOfOperations(List<string> section)
        {
            var simplesection = PerformMultiplicationAndDivision(section);
            return PerformAdditionAndSubtration(simplesection);
        }
        /// <summary>
        /// For multiplication read left to right, clear everything except the value which will
        /// be stored in the last position to allow for more operations if they exist.
        /// </summary>
        /// <param name="section"></param>
        private List<string> PerformMultiplicationAndDivision(List<string> section)
        {
            var complexSection = section.Where(x => !string.IsNullOrEmpty(x)).ToList();
            for (var x = 0; x < complexSection.Count; x++)
            {
                if (complexSection[x] != "/" && complexSection[x] != "*") continue;
                complexSection[x + 1] = complexSection[x] == "/"
                    ? (double.Parse(complexSection[x - 1])/double.Parse(complexSection[x + 1])).ToString()
                    : (double.Parse(complexSection[x - 1])*double.Parse(complexSection[x + 1])).ToString();
                complexSection[x - 1] = complexSection[x] = "";
                x++;
            }
            return complexSection;
        }

        /// <summary>
        /// For addition and subtraction read right to left, clear everthing except the value which
        /// will be stored in the last postion to allow for more operation if they exist.
        /// </summary>
        /// <param name="section"></param>
        /// <returns></returns>
        private double PerformAdditionAndSubtration(List<string> section)
        {
            var simpleSection = section.Where(x => !string.IsNullOrEmpty(x)).ToList();
            for (var x = simpleSection.Count - 1; x >= 0; x--)
            {
                if (simpleSection[x] != "-" && simpleSection[x] != "+") continue;
                simpleSection[x - 1] = simpleSection[x] == "-"
                    ? (double.Parse(simpleSection[x - 1]) - double.Parse(simpleSection[x + 1])).ToString()
                    : (double.Parse(simpleSection[x - 1]) + double.Parse(simpleSection[x + 1])).ToString();
                simpleSection[x + 1] = simpleSection[x] = "";
                x--;
            }
            return simpleSection.Where(x => !string.IsNullOrEmpty(x)).Sum(s => double.Parse(s));
        }
    }
    
    
}
