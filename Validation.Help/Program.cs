using Validation.Help.Models;
using Validation.Help;

var person = new Person
{
    Name = "John",
    Age = 17,
    Country = "Canada"
};

var result = RuleEngine<Person>
    .Create()
    .AddRule(p => p.Age >= 18, "Person must be 18 or older")
    .AddRule(p => !string.IsNullOrWhiteSpace(p.Name), "Name cannot be empty")
    .AddRule(p => p.Country == "USA", "Only U.S. citizens allowed")
    .Validate(person);

if (!result.IsValid)
{
    Console.WriteLine("❌ Validation failed:");
    foreach (var error in result.Errors)
    {
        Console.WriteLine($"- {error}");
    }
}
else
{
    Console.WriteLine("✅ Validation passed!");
}
