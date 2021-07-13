namespace smoking_meat_api.DTOs
{
    public class InstructionReadDto
    {
        public int Id { get; set; }

        public string Meat { get; set; }

        public int SmokingTemp { get; set; }

        public string CookTime { get; set; }

        public int CookedTemperature { get; set; }

        public string Notes { get; set; }

        public string Category { get; set; }
    }
}