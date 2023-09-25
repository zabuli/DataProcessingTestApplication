using System.Text;
using Microsoft.VisualBasic.FileIO;

namespace File;
public static class CsvParser
{
    public static List<T> GetlData<T>(Stream fileStream, out bool isFileValid)
    {
        var data = new List<T>();
        isFileValid = true;

        try
        {
            using (var csvParser = new TextFieldParser(fileStream, Encoding.GetEncoding("iso-8859-1")))
            {
                csvParser.CommentTokens = new string[] { "#" };
                csvParser.SetDelimiters(new string[] { ";" });
                csvParser.HasFieldsEnclosedInQuotes = true;

                // Skip the row with the column names
                var fields = csvParser.ReadFields();
                if (fields == null)
                {
                    isFileValid = false;
                    return data;
                }

                while (!csvParser.EndOfData)
                {
                    var line = csvParser.LineNumber.ToString();
                    fields = csvParser.ReadFields();
                    if (fields == null || fields.All(string.IsNullOrEmpty))
                    {
                        continue;
                    }
                    try
                    {
                        var newObject = (T)Activator.CreateInstance(typeof(T), fields);
                        if (newObject != null)
                        {
                            data.Add(newObject);
                        }
                    }
                    catch (Exception ex)
                    {
                        //logging
                        continue;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            throw;
        }

        return data;
    }
}