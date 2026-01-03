namespace EmployeeCsvProcessor.Interface.Writer;

using EmployeeCsvProcessor.Model;


public interface IWriter{

     void Write(IEnumerable<Employee> employee, Stream output);
}