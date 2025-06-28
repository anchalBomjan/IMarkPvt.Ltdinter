# ClinetApp

This project was generated with [Angular CLI](https://github.com/angular/angular-cli) version 16.2.12.

## Development server

Run `ng serve` for a dev server. Navigate to `http://localhost:4200/`. The application will automatically reload if you change any of the source files.

## Code scaffolding

Run `ng generate component component-name` to generate a new component. You can also use `ng generate directive|pipe|service|class|guard|interface|enum|module`.

## Build



Run `ng build` to build the project. The build artifacts will be stored in the `dist/` directory.

## Running unit tests

Run `ng test` to execute the unit tests via [Karma](https://karma-runner.github.io).

## Running end-to-end tests

Run `ng e2e` to execute the end-to-end tests via a platform of your choice. To use this command, you need to first add a package that implements end-to-end testing capabilities.

## Further help

To get more help on the Angular CLI use `ng help` or go check out the [Angular CLI Overview and Command Reference](https://angular.io/cli) page.

# 📚 Angular Demo: Lazy Loading, Cross-Cutting Concerns & PrimeNG (with Static Data)

This Angular project is a demonstration of key architectural and design practices including **Lazy Loading**, handling of **Cross-Cutting Concerns**, and UI development using **PrimeNG**. The project is configured to use **static mock data**, making it easy to run without a backend server.

---

## 🚀 Features

### ✅ Lazy Loading
The application is modularized using Angular's **Lazy Loading** mechanism:

- Each major feature (e.g., `Student`, `Employee`) is contained in its own module.
- Modules are loaded dynamically using Angular Router.
- Enhances performance by reducing initial bundle size.
♻️ Cross-Cutting Concerns
Cross-cutting services such as logging, message handling, and authentication are abstracted into reusable services and modules.

Services like AuthService, LoggerService, and MessageService are registered in the CoreModule.

Promotes separation of concerns and cleaner architecture.

Toast notifications, error handling, and utility functions are centralized.
🎨 PrimeNG Integration
The project uses PrimeNG for a modern, responsive UI:

Components used include: p-table, p-dialog, p-toast, p-dropdown, p-button, etc.

PrimeNG styles and themes are configured in angular.json.

Fully responsive and user-friendly interfaces.
📊 Static Data Simulation
Instead of calling live APIs, this project uses hardcoded static data to simulate server responses.

Ideal for UI prototyping and understanding flow without a backend.

Data is returned using RxJS of() operator.