# Employee Benefits Management Tool

###### An Admin tool allowing the user to enter employee information and see a preview of benefits deductions. 

## Tech Stack
- .Net Core (Dotnet CLI) 2.1.5 
- Angular 7.0 (Angular CLI)

## Run project locally
1. Run `git clone https://github.com/kljohnson2/EmployeeBenefitsManagement.git` to clone the repo 
2. `cd` into `EmployeeBenefitsManagement` to navigate to the project directory
   - If you run `ls` or `dir` on Windows, you will see the following two projects
     - BenefitsManagement: Angular 7 UI
     - BenefitsManagementAPI: .Net Core 2.1.5 web APIs
3. Run `code .` to open folder in Visual Studios Code (assuming you have it installed)
4. Open the integrated terminal, `cd` into `BenefitsManagementAPI` and run `dotnet run` to start up the web APIs on `localhost:5000`
5. Open a second terminal, `cd` into `BenefitsManagement`, and run `ng serve --open` to start the UI on `localhost:4200` and open it in the browser.

