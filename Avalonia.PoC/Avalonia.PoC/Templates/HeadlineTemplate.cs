using System.Collections.Generic;

namespace Avalonia.PoC.Templates;

public class HeadlineTemplate
{
    public string Title { get; set; }
    public List<string> Fields { get; set; }
    public bool CanRepeat { get; set; } = true;
    public bool IsExpandedByDefault { get; set; } = true;

    public HeadlineTemplate Repeat()
    {
        var newTemplate = (HeadlineTemplate)MemberwiseClone();
        newTemplate.Title += " ( R )";
        return newTemplate;
    }
}