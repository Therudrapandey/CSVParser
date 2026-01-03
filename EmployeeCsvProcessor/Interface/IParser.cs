namespace EmployeeCsvProcessor.Interface.Parser;


using EmployeeCsvProcessor.Model;

public interface IParser{
       IEnumerable<Employee> Parse(Stream stream);
}