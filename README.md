# Coding Challenges - a practice repo

This repository exists solely for pracitce purposes. I made it public, so that people can see how I think and solve problems. If you find anything in here that is wrong or you find it didn't hold up in some ways, you have a better solution or a general suggestion, please feel free to reach out, or create a pull request.

I do these challenges for fun and to get better at coding, there is no other purpose of this repository.

If you decide to use it, do it at your own risk, solutions might be wrong or misleading.

## RULES

> [!IMPORTANT]
> A few things to note:
> - I strictly use this repo to solve problems by myself I don't use AI to write the code at all.
> - Where AI is permitted: To ask about theoretical problems, to help troubleshoot or help me determine the Big O notation of a problem. I use it to ENHANCE my thinking not to REPLACE it.
> - If you contribute, adhere to the above rules as well.

## Structure

> [!WARNING]
> This repo is a constant work- and trial-and-error-process in progress. Expect inconsistencies in naming and function. 

This repo is structured in the following way:

```
.
├── CodingChallenges.sln
├── LICENSE
├── README.md
├── runner                                  # Console application for testing solutions manually
│   └── Solutions.Runner
├── src
│   └── Solutions                           # Solution library - Contains solutions to various coding problems
│       ├── FreeCodeCampDailyChallenges     # ...
│       └── LeetCode                        # ... each sub-folder categorizes the types of solutions further
└── tests                                   
    └── Solutions.Tests                     # Tests to assure accuracy for a given implementation
```

This repository, as mentioned above, is a learning repo. The structure should reflect that. Writing tests is just as much a learning curve as writing algorithms and optimizing them. Feel free to utilize this structure to your advantage.

The naming of the implementations so far are categorized by estimates of Big O in time complexity. Example from my TwoSum implementation:

```csharp
public static int[] ONSquared(int[] numbers, int target)
{
    // ...rest of code
}

public static int[] ONLogN(int[] numbers, int target)
{
    // ...rest of code
}
```

> [!NOTE]
> If you have a better way to document the implementations, feel free suggest one in a pull request or an issue. I might add docs to the implementations later for more precise information about a given solution to a problem.

## How to Contribute

- Make sure your code runs
- Submit a pull request
- Adhere to the rules stated under the [rules](#rules) above

## LICENSE

This project is licensed under the [MIT License](/LICENSE).