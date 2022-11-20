using System.Globalization;
using CsvHelper;
using WiseConsulting.Application.Common.Interfaces;
using WiseConsulting.Application.TodoLists.Queries.ExportTodos;
using WiseConsulting.Infrastructure.Files.Maps;

namespace WiseConsulting.Infrastructure.Files;
public class CsvFileBuilder : ICsvFileBuilder
{
    public byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records)
    {
        using var memoryStream = new MemoryStream();
        using (var streamWriter = new StreamWriter(memoryStream))
        {
            using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);

            csvWriter.Configuration.RegisterClassMap<TodoItemRecordMap>();
            csvWriter.WriteRecords(records);
        }

        return memoryStream.ToArray();
    }
}
