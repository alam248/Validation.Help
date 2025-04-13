🧠 RuleEngine.NET
A simple, expressive, and extensible rule engine built in C# for evaluating complex business rules on any type of object.

🔍 Ideal for validation, decision engines, approval workflows, data quality checks, and more.

🚀 Features
✅ Chainable API for rule definition

🛠 Custom error messages

🔄 Works on any class or data model

♻️ Fully extensible for real-world logic

🧪 Easy to unit test and plug into services or pipelines

📦 Example Use Case
<pre> ```
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
        Console.WriteLine($"- {error}");
}
else
{
    Console.WriteLine("✅ Validation passed!");
}
``` </pre>
📁 Project Structure
RuleEngine.NET/
│
├── RuleEngine.cs       # Core rule engine
├── RuleResult.cs       # Result model with error tracking
├── Person.cs           # Sample data model
└── Program.cs          # Demo entry point
