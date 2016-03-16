# Fiken.Net
C# library for interacting with the Fiken API

See the documentation at https://fiken.no/api/doc/

The HAL browser for Fiken is accessible from https://fiken.no/api/browser/browser.html#/api/v1

# Usage
## Set up the session and fetch your company
```csharp
	var session = new FikenSession("<username>", "<password>");
	var company = FikenCompany.FindBySlug("<your-company-slug>", session);
```

## Get a list of products
```csharp
	var products = company.GetProducts();
```

