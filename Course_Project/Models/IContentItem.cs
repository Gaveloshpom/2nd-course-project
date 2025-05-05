using System;
using System.Collections.Generic;
using System.ComponentModel;
using Newtonsoft.Json;

namespace Course_Project.Models
{
    // Інтерфейс для лекцій і практичних завдань
    public interface IContentItem
    {
        //string GetTitle();
        //string GetContent();
        string Title { get; set; }
        string Content { get; set; }
    }
}
