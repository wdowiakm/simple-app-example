namespace MediApp.Domain.Models.Doctor;

public record struct MedicalLicenseNumber(string Value)
{
    public string Value { get; } = IsValid(Value)
        ? Value.Trim().ToUpper()
        : throw new ArgumentException("Invalid Medical License Number");

    public static implicit operator string(MedicalLicenseNumber self) => self.Value;
    public static implicit operator MedicalLicenseNumber(string value) => new(value);
    
    private static bool IsValid(string value) => !string.IsNullOrWhiteSpace(value);
}