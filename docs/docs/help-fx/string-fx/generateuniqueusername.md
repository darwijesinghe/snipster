---
title: GenerateUniqueUsername()
---

## Description
Generates a unique username using the first and last name. Appends a number if the base username is already taken.

### Method Signature

```csharp
string GenerateUniqueUsername(string firstName, string lastName, Func<string, bool> isUsernameTaken)
```
### Examples

```csharp
using Snipster.Library.Helpers;

public class Example
{
    public static void Main()
    {
        // Generate a username based on first and last name
        string firstName = "John";
        string lastName  = "Doe";

        // Example function that checks if a username is already taken
        Func<string, bool> isUsernameTaken = username =>
        {
            // Simulate that "johndoe" and "johndoe1" already exist
            return username == "johndoe" || username == "johndoe1";
        };

        string uniqueUsername = StringFx.GenerateUniqueUsername(firstName, lastName, isUsernameTaken);
        Console.WriteLine(uniqueUsername);  // Output: "johndoe2"
    }
}
```