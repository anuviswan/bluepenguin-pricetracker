# Copilot Instructions – .NET MAUI 

## Platform
- Target framework: .NET 10
- Use latest C# version
- Nullable enabled
- Implicit usings enabled
- All I/O must be async/await
- Always use `ConfigureAwait(false)` in library code for await

---
## Architecture

Layers:
 - PriceTracker (Core Mobile application)
 - Controls (Reusable User Controls)
 - Services (Reusable services)

Rules:
 - ViewModels should be thin and off-load interaction with APIs to Services
 - Use dedicated services for API interaction
 - Use CommunityToolkit.Maui feature when ever applicable
 - MAUI related code should only exist in PriceTracker project.

---
## Error Handling
- Do not throw exceptions for expected domain errors.
- Use Result<T> pattern for application API responses.

---
## Logging
- Use ILogger<T>.
- Never log sensitive data.

---
## Code Style
- Avoid complex LINQ chains.
- Keep methods concise and readable.
- Use meaningful names.
- No synchronous I/O.
- Always use namespace scoped files
---
