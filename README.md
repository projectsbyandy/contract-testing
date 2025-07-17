# Contract Testing

## Introduction
Contract testing is a testing method that verifies compatibility between two systems to ensure they can communicate with each other. In a contract test, one party will generate a contract that the other must adhere to.

### Contract Testing enables
- :mag: Local Testing
- :rocket: Faster deployments
  - Reduce breaking changes
  - Reduce lead time for change
  - Reduce the cost of API integration testing
- :thought_balloon: Understanding your system usage
  - Documentation of APIs
- :arrow_down: Remove the need for complex data fixtures
- :arrow_down: Reduce the reliance on complex test environments

### There are 3 contract testing strategies, each differ depending on which party creates the contract
- Consumer Driven
- Provider Driven
- Bi-directional (both provider and consumer create contracts that the other needs to adhere to)

### Case Study

A film factory wants to making changes to their film stock service

| Timescale    | Activity                                                                   |
| ------------ | -------------------------------------------------------------------------- |
| Day 1-2      | Feature development work updating film stock service. Run unit tests       |
| Day 2        | Test on deployed env -> PR -> Deploy to Dev.... Release to Prod            |
| Day 3-4      | Consumer of the film service is invoked and an error occurs                |


### Case Study with Consumer Driven Contract Testing

| Timescale    | Activity                                                                                   |
| ------------ | -------------------------------------------------------------------------------------------|
| Day 1-2      | Feature development work updating film stock service. Run Unit and Contract tests          |
|              | Error, the change has broken a consumer contract and discovered in hours rather than days. |

### Considerations
- Contract testing works best when you have control over the Producer and Consumer
- Will benefit APIs that change on a relatively frequent basis. If an API doesn't change the cost of setting up contract testing should be taken into consideration.

## Project

This is an example of Contract Testing using Pact. Pact enables contracts to be developed with Consumer and Provider language agnostic tests as long as the contract aligns with a specific Pact schema version.

### In this project we have:
| API          | Description           | Language |
| ------------ | --------------------- | -------- |
| Provider     | Stock Service API     | C#       |
| Consumer A   | Photography Store     | C#       |
| Consumer B   | Film Museum           | JS / TS  |
| Consumer C   | Film Developer        | Python   |

### Provider example of breaking contract changes
- Breaking contract change 1 - Delete a property
- Breaking contract change 2 - Change in property type
- Breaking contract change 3 - Additional business logic in service e.g. validation in service

### Broker
In this example contracts are shared via common folder location. A more comprehensive solution would be to setup a dockerised broker from Pact-Foundations or use paid broker from smartbear.

## Project Setup

### Pre-requisite
- .NET8 or later
- node and npm
- python 3.12+

### C# Provider
1. In PS navigate to `Contract-Testing\src\Provider.EmulsiveFactory`
2. Run `dotnet build`. The solution should build without error.
3. Open the solution in Visual Studio and Rebuild once more.
4. Press Run button with Provider.EmulsiveFactory selected
5. You will be prompted to create a certificate, proceed with creation
6. The swagger page will sucessfully load.
7. Stop the process and navigate to Test Explorer, provider tests will be loaded.

### C# Consumer
1. In PS navigate `Contract-Testing\src\Provider.Consumer.PhotographyStore`
2. Run `dotnet build`. The solution should build without error.
3. Repeat steps 3 onwards from Provider.
4. Navigate to Test Explorer, consumer tests will be loaded.

### Python Consumer
via Pycharm
- open folder - `Contract-Testing\src\ConsumerPython`
- pre-req from requirements.txt should automatically install
- Navigate to the tests folder and file `test_emulsive_factory_stock_contract.py`
- Play icon should be enabled

via VSCode
- open folder - Contract-Testing\src\ConsumerPython
- open VS Command palette 
  - type Python Create environment
  - select `venv`
  - select installed intepreter e.g. python 3.12
  - select `requirements.txt`
- Navigate to the Test button of the left hand panel
  - Select Configure Python Test
  - Select Pytest
  - Select the tests folder
- Close and reopen the ConsumerPython folder in VSCode
- Examine the Testing area and they should have successfully populated

### Javascript Consumer
via VSCode
- In powershell navigate to `Contract-Testing\src\ConsumerJs.FilmMuseum`
- Run `npm install`
  - if there are any dependency failures please run `npm install --legacy-per-dep`
- Open in VS code from this folder
- Open extensions, search for `Jest` and install the extension called Jest.
- Navigate to the Testing area on the left hand panel
- Examine the Testing area and they should have successfully populated

### Running Tests
#### Consumer
- Based on the provider pact setup will spin up a mock wrapper service that intercepts calls to the real consumer service and respond with a pre-canned mock response that includes various matchers that implement rules e.g. value must be, value type must be, array must have 1 or more elements etc.
- The shared folder will be generated by any one of the consumer tests if it doesn't already exist.
- The contract naming convention in this example takes the format of <consumer>-<language>-<provider>.json

### Provider
- Includes a test per consumer
- Pact starts an instance of the real provider service and pass in the request from the contract file. The response will then be validated against the matchers defined in the contract.

