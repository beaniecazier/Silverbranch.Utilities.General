namespace Gay.Silverbranch.Utilities.General;

public class Version
{
    public int Major { get; set; }
    public int Minor { get; set; }
    public int Patch { get; set; }
    public int? Build { get; set; }
    public string? Suffix { get; set; }

    public override string ToString()
    {
        string suffix = !string.IsNullOrWhiteSpace(Suffix) ? $"-{Suffix}" : "";
        suffix += Build.HasValue ? $".{Build.Value}" : "";
        return $"{Major}.{Minor}.{Patch}{suffix}";
    }
}