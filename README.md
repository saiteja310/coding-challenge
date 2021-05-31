# coding-challenge

[WIP] Still need to work on the Integration tests, Part 2 of the project. Submitting whatever I did so far.


As part of part 1,
The project has been sub divided into 3 parts,
1) Console
2) Service
3) Tests

**Console App**: Main launch code of the application.
Deals with the launching of console application and binding dependencies(Dependency Injection).

**Services**: Deals with actual service implementation.
Interfaces: Public contracts exposed to the end user.
Models: Publicly exposed Models of the inputs.
Implementations: Loosely bound internal implementations of the above created interfaces.
Exceptions: Custom Exception wrote in order to validate the edge cases.

**Tests**: Deals with the unit tests of the services. 


[TODO] Integration Tests
Need to write integration tests for the above services.

[TODO] Part 2.
Idea for implementation:
Need to implement a proper 0-1 Knapsack for the weight balancing.
Need to implement a proper min-heap to get the available vehicle after assigning above weight balanced journeys.
