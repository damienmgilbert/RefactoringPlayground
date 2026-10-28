using System.Text;
using System.Collections.Generic;

// REFACTOR [IDE0161]: Convert to file-scoped namespace (this file uses a block-scoped one on purpose)
namespace RefactoringPlayground.CodeStyle.UnnecessaryCode
{
    // REFACTOR [IDE0065]: Move 'using' directive outside the namespace
    using System.Globalization;

    public class LegacyStyleExamples
    {
        // REFACTOR [IDE0040]: Add accessibility modifier ('private')
        int _calls;

        // REFACTOR [IDE0036]: Order modifiers ('public static')
        // REFACTOR [IDE0049]: Use language keywords ('string', 'int') instead of 'String', 'Int32'
        // REFACTOR [refactoring]: Convert 'String.Format' to an interpolated string
        static public String Describe(Customer customer, Int32 index)
        {
            return String.Format(CultureInfo.InvariantCulture, "{0}: {1}", index, customer.Name);
        }

        // REFACTOR [IDE0003]: Remove 'this.' qualification
        // REFACTOR [IDE0054]: Use compound assignment ('_calls++' / '_calls += 1')
        // REFACTOR [IDE0047]: Remove unnecessary parentheses
        public int NextCall()
        {
            this._calls = this._calls + 1;
            return (this._calls);
        }

        // REFACTOR [IDE0004]: Remove unnecessary cast
        public static int Identity(int value)
        {
            int copy = (int)value;
            return copy;
        }

        // REFACTOR [IDE0034]: Simplify 'default' expression ('default')
        public static int Zero()
        {
            int zero = default(int);
            return zero;
        }

        // REFACTOR [IDE0037]: Use inferred member names ('new { customer.Name, customer.Tier }')
        public static object Summarize(Customer customer)
        {
            return new { Name = customer.Name, Tier = customer.Tier };
        }
    }
}
