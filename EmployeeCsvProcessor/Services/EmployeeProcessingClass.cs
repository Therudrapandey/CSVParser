using System;
using System.Collections.Generic;
using System.IO;
using EmployeeCsvProcessor.Model;
using EmployeeCsvProcessor.Interface;

namespace EmployeeCsvProcessor.Services
{
    public class EmployeeProcessor
    {
        private readonly IParser<ParsedEmployee> _parser;
        private readonly IValidator<Employee> _validator;
        private readonly IWriter<Employee> _writer;

        public EmployeeProcessor(
            IParser<ParsedEmployee> parser,
            IValidator<Employee> validator,
            IWriter<Employee> writer)
        {
            _parser = parser;
            _validator = validator;
            _writer = writer;
        }

        public void Process(string inputPath, string outputPath)
        {
            var validEmployees = new List<Employee>();

            using var inputStream = File.OpenRead(inputPath);

            foreach (var parsed in _parser.Parse(inputStream))
            {
                // Parse failure
                if (parsed.Employee == null)
                {
                    Console.WriteLine($"[Parse Error] Line {parsed.LineNumber}: {parsed.ParseError} | Raw: {parsed.RawLine}");
                    continue;
                }

                // Validation
                var result = _validator.Validate(parsed.Employee);
                if (!result.IsValid)
                {
                    Console.WriteLine($"[Validation Error] Line {parsed.LineNumber}: {string.Join("; ", result.Errors)}");
                    continue;
                }

                validEmployees.Add(parsed.Employee);
            }

            using var outputStream = File.Create(outputPath);
            _writer.Write(validEmployees, outputStream);
        }
    }
}
