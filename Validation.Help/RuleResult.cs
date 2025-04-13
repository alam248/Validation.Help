using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validation.Help
{
    public class RuleResult
    {
        public bool IsValid { get; set; }
        public List<string> Errors { get; } = new();
    }
}
