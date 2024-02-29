using System.Diagnostics.Contracts;
using System.Xml.Serialization;

public class Journal {
    public List<Entry> entries;

    public Journal(string import) 
    {
        entries = new List<Entry>();
    }

    public void Write()
    {
        Entry newEntry = new Entry();
        newEntry.prompt = Prompt.PromptGet();
        Console.WriteLine($"Prompt: {newEntry.prompt}");
        Console.WriteLine("Enter your response:");
        newEntry.response = Console.ReadLine();
        newEntry.date = DateTime.Now.ToString();
        entries.Add(newEntry);
        Console.WriteLine("Entry added successfully!");
    }
    public void Display()
    {
        foreach (var entry in entries)
        {
            if (string.IsNullOrEmpty(entry.date) || string.IsNullOrEmpty(entry.prompt) || string.IsNullOrEmpty(entry.response))
            {
                Console.WriteLine("Invalid entry format in loaded data.");
            }
            else
            {
                Console.WriteLine($"{entry.date}: {entry.prompt}: {entry.response}");
            }
        }
    }

    public void SaveToFile()
    {
        Console.WriteLine("Enter the name of the file to save the journal:");
        string fileName = Console.ReadLine() + ".txt";
        string filePath = Path.Combine(Directory.GetCurrentDirectory(), fileName);
        try
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var entry in entries)
                {
                    string entryLine = $"{entry.date}~{entry.prompt}~{entry.response}";
                    writer.WriteLine(entryLine);
                }
            }

            Console.WriteLine($"Journal saved to file '{filePath}' successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving journal to file: {ex.Message}");
        }
    }

    public void LoadFromFile()
    {
        Console.WriteLine("Enter the name of the file to load the journal:");
        string fileName = Console.ReadLine() + ".txt";
        string filePath = Path.Combine(Directory.GetCurrentDirectory(), fileName);
        if (!File.Exists(filePath))
        {
            Console.WriteLine($"File '{filePath}' does not exist. Cannot load journal.");
            return;
        }
        entries.Clear();
        try
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    string entryLine = reader.ReadLine();
                    string[] entryParts = entryLine.Split('~');
                    
                    if (entryParts.Length == 3)
                    {
                        Entry newEntry = new Entry
                        {
                            date = entryParts[0],
                            prompt = entryParts[1],
                            response = entryParts[2]
                        };
                        entries.Add(newEntry);
                    }
                    else
                    {
                        Console.WriteLine("Invalid entry format in loaded data.");
                    }
                }
            }

            Console.WriteLine($"Journal loaded from file '{filePath}' successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading journal from file: {ex.Message}");
        }
    }

}
