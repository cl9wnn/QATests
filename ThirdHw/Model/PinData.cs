namespace PinterestTests
{
    public class PinData
    {
        public PinData(string title, string description, string imagePath)
        {
            Title = title;
            Description = description;
            ImagePath = imagePath;
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
    }
}