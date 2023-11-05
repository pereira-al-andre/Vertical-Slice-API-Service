# Vertical Slice
Vertical slice architecture organizes software into self-contained feature slices, encompassing all layers from UI to data for specific functionality. Benefits include isolation, independent deployment, simplified testing, collaboration, scalability, and modular code for easier development and maintenance in complex projects. The goal is to increase coupling in a slice and reduce it between them.

### Key aspects
- Self-contained slices for specific features.
- Encompasses all layers (UI, business logic, data).
- Isolation to prevent side effects.
- Independent deployment.
- Simplified testing and quality assurance.
- Enables collaboration among teams.
- Scalable and modular code for efficient development and maintenance.

### Downsides
- Extended initial development effort: Adopting vertical slice architecture demands additional upfront planning and module creation, lengthening the initial development phase.
- Elevated complexity: Managing and maintaining multiple modules in this architecture elevates the system's overall complexity.
- Domain expertise essential: Implementing vertical slices effectively necessitates a deep understanding of the domain and the specific features or use cases involved.

# About the project
The project implements the vertical slice into a single file for each feature, containing the query/command, the handler and the endpoint. For this project I used:

- Fluent Validator: for validation;
- Carter: for the endpoints;
- Mediatr: to help me out with the meditor pattern implementation
- Entity Framework Core






