using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Waes.Api.Models
{
    public class CompareResult
    {
        readonly string left;
        readonly string right;
        public string Result { get; set; }
        public CompareResult(string left, string right)
        {
            this.left = left;
            this.right = right;

            if (left.Equals(right))
            {
                Result = "The compared strings are equal";
                return;
            }

            if (!left.Length.Equals(right.Length))
            {
                Result = "The compared strings have different sizes";
            }
            else
            {
                Result = "The compared strings have the same size but the content is different";
            }
        }
    }
}
