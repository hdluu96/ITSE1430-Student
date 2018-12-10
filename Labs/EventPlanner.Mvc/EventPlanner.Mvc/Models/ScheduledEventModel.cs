/*
 * Hoa Luu
 * ITSE1430
 * December 8, 2018
 */

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EventPlanner
{
    /// <summary>Represents a scheduled event.</summary>
    public class ScheduledEventModel : IValidatableObject
    {
        public ScheduledEventModel() { }
        public ScheduledEventModel( ScheduledEvent item)
        {
            Id = item.Id;
            Name = item.Name;
            Description = item.Description;
            StartDate = item.StartDate;
            EndDate = item.EndDate;
            IsPublic = item.IsPublic;
        }

        public ScheduledEvent ToDomain()
        {
            return new ScheduledEvent()
            {
                Description = this.Description,
                EndDate = this.EndDate,
                Id = this.Id,
                IsPublic = this.IsPublic,
                Name = this.Name,
                StartDate = this.StartDate
            };
        }

        /// <summary>Gets or sets the unique ID.</summary>
        [Range(0, Int32.MaxValue)]
        public int Id { get; set; }

        /// <summary>Gets or sets the unique name.</summary>
        [Required(AllowEmptyStrings = false)]
        public string Name{get; set;}

        /// <summary>Gets or sets the description.</summary>
        public string Description { get; set; }

        /// <summary>Gets or sets the start date.</summary>
        public DateTime StartDate { get; set; }

        /// <summary>Gets or sets the end date.</summary>
        public DateTime EndDate{get; set;}

        /// <summary>Determines if this is private or public event.</summary>
        public bool IsPublic { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (EndDate < StartDate)
                yield return new ValidationResult("End date must be greater than or equal to start date.", new[] { nameof(EndDate) });
        }
    }
}
