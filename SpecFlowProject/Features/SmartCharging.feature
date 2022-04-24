Feature: SmartCharging
Read more about Gherkin language: https://docs.specflow.org/projects/specflow/en/latest/Gherkin/Gherkin-Reference.html
Read more how to create C# code from scenario steps: https://docs.specflow.org/projects/specflow/en/latest/visualstudio/Generating-Skeleton-Code.html

@mytag
Scenario: Change capacity of a group
	Given a group of charge stations with capacity 100 A
	When capacity of the group changed to 50 A
	Then the group has capacity 50 A