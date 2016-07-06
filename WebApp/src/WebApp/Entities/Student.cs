namespace WebApp.Entities
{
    public enum Personality
    {
        Introversion,
        Extroversion,
        Sensing,
        Intuition,
        Thinking,
        Feeling,
        Judging,
        Perceiving
    }

    public class Student
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Personality Personality { get; set; }
    }
}