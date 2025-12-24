using System;
using System.IO;
using System.Text.RegularExpressions;

string modelsFolder = @"C:\Users\admin\Desktop\24hNews\WebSport24hNews\WebSport24hNews\Models"; // 👈 sửa đường dẫn đến thư mục chứa entity
string baseClassName = "WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot";

foreach (var file in Directory.GetFiles(modelsFolder, "*.cs"))
{
    string[] lines = File.ReadAllLines(file);
    string[] IgnoreClassNames = { "HoangNamWebContext", "" };
    bool modified = false;

    for (int i = 0; i < lines.Length; i++)
    {
        // Tìm dòng khai báo class : public partial class Xxx [có thể có  : Something]
        var match = Regex.Match(lines[i], @"public\s+(partial\s+)?class\s+(\w+)(\s*:\s*[\w\s,]+)?");

        if (match.Success && !lines[i].Contains($" : {baseClassName}"))
        {
            string className = match.Groups[2].Value;
            string inheritance = match.Groups[3].Success ? match.Groups[3].Value : "";
            if (IgnoreClassNames.Contains(className))
            {
                break;
            }
            if (string.IsNullOrWhiteSpace(inheritance))
            {
                lines[i] = lines[i].Replace(className, $"{className}  : {baseClassName}");
            }
            else
            {
                lines[i] = lines[i].Replace(inheritance, inheritance.Trim() + $", {baseClassName}");
            }

            modified = true;
            break; // chỉ sửa dòng đầu tiên chứa class
        }
    }

    if (modified)
    {
        Console.WriteLine($"✅ Modified : {Path.GetFileName(file)}");
        File.WriteAllLines(file, lines);
    }
}
