using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using EmployeeCsvProcessor.Model;
using EmployeeCsvProcessor.Interface;





public class EmployeeValidator: IValidator
{
  public ValidationResult validate(Employee employee){

    var res = new ValidationResult{
        IsValid=true
    };

    if(employee.Id<=0) res.IsValid=false; res.Errors.Add("Id cannot be 0 or less thazero");
    if(string.IsNullOrEmpty(employee.Name)) res.IsValid=false; res.Errors.Add("Name cannot be null");
    if(!employee.Email.Contains("@") || !employee.Email.Contains(".")) res.IsValid=false; res.Errors.Add("Email Not Valid");

    return res;

  }



}