namespace Museum_Locator.DTOs
{
    public class FacilityDto
    {
        public int Id { get; set; }
        public string FacilityName { get; set; } = string.Empty;
        public List<string> MuseumNames { get; set; } = new();
    }
}