namespace EmployeeCsvProcessor.Interface;

using EmployeeCsvProcessor.Model;


public class ValidationResult 
{ 
    public bool IsValid; 
    public List<string> Errors = new(); 
}

public interface IValidator{
        
    ValidationResult validate(Employee employee);
}