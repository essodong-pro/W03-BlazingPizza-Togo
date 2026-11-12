# Blazing Pizza - Togo

A responsive Blazor pizza shop demo for CSE 325 Week 3. It includes routed Home/Menu and Order pages, a shared interactive cart, category filters, and prices in Togo's West African CFA franc (FCFA / XOF).

## Run locally

Install the .NET 10 SDK, then from this folder run:

```powershell
dotnet run
```

Open the localhost URL printed in the terminal. Checkout is a demo confirmation only; the app does not collect payment or personal information.

## Assignment details

- All pizza prices use FCFA (XOF), formatted with the French-Togo number culture.
- The footer displays **Essodong N'GNAMA · Togo**.
- The app uses Blazor routing, NavLinks, a shared layout, reusable pizza data, and interactive server rendering.

## Publish and submit

Create a new public GitHub repository and push this folder. Submit that repository URL and a screenshot of the running app in Canvas. Make sure the screenshot shows the header, pizza list with FCFA prices, and footer; scroll or zoom out to fit all three if needed.
