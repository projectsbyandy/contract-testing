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

### Provider example of breaking contract changes
- Breaking contract change 1 - Delete a property
- Breaking contract change 2 - Change in property type
- Breaking contract change 3 - Additional business logic in service e.g. validation in service


