# GreenFlux QA (Back-End) Assignment

_Version 1_

This assignment is part of the job application process for the position of QA Engineer at [GreenFlux](https://www.greenflux.com/).

## Assignment

### Objective

Your objective is to define and implement BDD-style test scenarios for a simplified *Smart Charging API*. The scenarios must be defined in the [Gherkin](https://en.wikipedia.org/wiki/Cucumber_(software)#Gherkin_language) language and implemented using [SpecFlow](https://docs.specflow.org/) on .NET. You are encouraged to use the scaffolded project in this repository as a starting point, but you are free to set up your own solution.

### General Requirements

1. Your test scenarios must be clearly (human)readable.
1. You must test **business cases**, not technical (implementation) details.
1. The name of each group you create in the API should be prefixed with your name.
1. Your test suite should cleanup (remove from server by API calls) all your test data after execution.
1. You don’t need to cover all test cases, but try to cover the most interesting (in your opinion) scenarios.
1. Be kind to the API you are calling and don't DDOS it. It is running on very modest infrastructure.

### Evaluation

We mostly judge your assignment on structure and cohesion (can we understand your reasoning, does it cover the most important business cases), readability (not over-engineered nor hacked together), and maintainability (what if we need to extend your solution in the future). Completing this assignment shouldn’t take more than a couple of hours. The result doesn’t need to be fully finished, as long as it demonstrates your skills as a QA engineer.

Please send us back the complete source code, preferrably as a Git repository. You could send us a zipped archive or invite us to a private GitHub repository. Sharing your solution publicly on the internet will disqualify your submission. Please include this `Readme.md` file in your submission.

## Smart Charging API

The API is available at https://gfx-smartcharging-assignment-api.azurewebsites.net/. It also has [OpenAPI (Swagger) documentation](https://gfx-smartcharging-assignment-api.azurewebsites.net/swagger/).

### Domain model

![domain.png](/images/domain.png)

The simplified Smart Charging domain deals with three entities:
 
- **Group**: has a unique *identifier* (cannot be changed), *name* (can be changed), and a *capacity in amps* (can be changed, positive value). A *Group* can contain multiple *Charge Stations*.
- **Charge Station**: has a unique *identifier* (cannot be changed) and a *name* (can be changed). A Charge Stations has at least 1 and at most 5 *Connectors*.
- **Connector**: has a numerical *identifier* unique within the scope of the Charge Station (possible range of values from 1 to 5) and *amps* (can be changed, positive value).

### Functional requirements

1. Group/Charge Station/Connector can be created, updated, and removed.
1. If a Group is removed, all Charge Stations in the Group should be removed as well.
1. Only one Charge Station can be added/removed to a Group in one call.
1. A Charge Station can only be in one Group at the same time. A Charge Station cannot exist without a Group.
1. A Connector cannot exist in the domain without a Charge Station.
1. The amps of an existing Connector can be changed (updated).
1. The capacity in amps of a Group should **always** be greater than or equal to the sum of the amps of the Connector of all Charge Stations in the Group.
1. All operations not meeting the above requirement should be rejected.

## Scaffolded sample

This repo contains a skeleton that you can use for your solution. It requires .NET 6. You can run the test suite by executing

    dotnet test

## Useful Tools

There are SpecFlow plugins available for [Visual Studio](https://marketplace.visualstudio.com/items?itemName=TechTalkSpecFlowTeam.SpecFlowForVisualStudio2022), and [JetBrains Rider](https://docs.specflow.org/projects/specflow/en/latest/Rider/rider-installation.html).