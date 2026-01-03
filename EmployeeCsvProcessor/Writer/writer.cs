using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using EmployeeCsvProcessor.Model;
using EmployeeCsvProcessor.Interface.Writer;


public class Writer :IWriter {
    public void Write(IEnumerable<Employee> employees, Stream outputStream)
    {
        using var writer = new StreamWriter(outputStream);
        
        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = true
        };

        using var csv = new CsvWriter(writer, config);

        // Write header automatically based on Employee properties
        csv.WriteHeader<Employee>();
        csv.NextRecord();

        // Write each valid employee
        foreach (var emp in employees)
        {
            csv.WriteRecord(emp);
            csv.NextRecord();
        }

        writer.Flush();
    }
}