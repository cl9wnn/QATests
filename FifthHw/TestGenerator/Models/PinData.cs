namespace TestGenerator.Models;

using System;

[Serializable]
public class PinData
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string ImagePath { get; set; }

    public PinData() { }

    public PinData(string title, string description, string imagePath)
    {
        Title = title;
        Description = description;
        ImagePath = imagePath;
    }
}