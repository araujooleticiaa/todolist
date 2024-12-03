﻿using Domain.Enums;
using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class TaskItem : BaseModel
    {
        public TaskItem()
        {
            
        }
        public TaskItem(string title, string description, DateTime dueDate, EStatus status, EProperty properties, Guid projectId, Project project)
        {
            Title = title;
            Description = description;
            DueDate = dueDate;
            Status = status;
            Properties = properties;
            ProjectId = projectId;
            Project = project;
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public EStatus Status { get; set; }
        public EProperty Properties { get; set; }
        public Guid ProjectId { get; set; }

        public Project Project { get; set; }

        [JsonIgnore]
        public ICollection<History> Histories { get; set; } = new List<History>();
    }
}
