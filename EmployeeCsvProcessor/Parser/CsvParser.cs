using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using EmployeeCsvProcessor.Model;
using EmployeeCsvProcessor.Interface;

public class CsvParser: IParser{

    public IEnumerable<Employee> Parse(Stream stream){

        using var reader = new StreamReader(stream);

        var config = new CsvConfiguration(CultureInfo.InvariantCulture){
             HasHeaderRecord=true,
             BadDataFound=null
        };

        using var csv= new CsvReader(reader,config);
        while(csv.Read())
        {

            Employee e =new Employee();
            try{
                e= csv.GetRecord<Employee>();
            }catch(Exception ex ){
                Console.WriteLine(ex.Message);
            }

            yield return e;
        }

    }
}