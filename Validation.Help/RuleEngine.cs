using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validation.Help
{
    public class RuleEngine<T>
    {
        private readonly List<Rule<T>> _rules = new();

        private RuleEngine() { }

        public static RuleEngine<T> Create()
        {
            return new RuleEngine<T>();
        }

        public RuleEngine<T> AddRule(Func<T, bool> predicate, string errorMessage)
        {
            _rules.Add(new Rule<T>(predicate, errorMessage));
            return this;
        }

        public RuleResult Validate(T instance)
        {
            var result = new RuleResult();

            foreach (var rule in _rules)
            {
                if (!rule.Predicate(instance))
                {
                    result.Errors.Add(rule.ErrorMessage);
                }
            }

            result.IsValid = result.Errors.Count == 0;
            return result;
        }
    }

    public class Rule<T>
    {
        public Func<T, bool> Predicate { get; }
        public string ErrorMessage { get; }

        public Rule(Func<T, bool> predicate, string errorMessage)
        {
            Predicate = predicate;
            ErrorMessage = errorMessage;
        }
    }
}
