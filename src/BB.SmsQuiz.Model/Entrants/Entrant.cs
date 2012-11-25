﻿using System;
using BB.SmsQuiz.Infrastructure.Domain;

namespace BB.SmsQuiz.Model.Entrants
{
    /// <summary>
    /// A competition entrant.
    /// </summary>
    public sealed class Entrant : EntityBase
    {
        /// <summary>
        /// Gets or sets the answer.
        /// </summary>
        /// <value>
        /// The answer.
        /// </value>
        public Competitions.CompetitionAnswer Answer { get; set; }

        /// <summary>
        /// Gets or sets the competition key.
        /// </summary>
        /// <value>
        /// The competition key.
        /// </value>
        public string CompetitionKey { get; set; }

        /// <summary>
        /// Gets or sets the contact.
        /// </summary>
        /// <value>
        /// The contact.
        /// </value>
        public IEntrantContact Contact { get; set; }

        /// <summary>
        /// Gets or sets the entry date.
        /// </summary>
        /// <value>
        /// The entry date.
        /// </value>
        public DateTime EntryDate { get; set; }

        /// <summary>
        /// Gets or sets the source e.g. SMS, Email.
        /// </summary>
        /// <value>
        /// The source.
        /// </value>
        public EntrantSource Source { get; set; }

        /// <summary>
        /// Validates this instance.
        /// </summary>
        protected override void Validate()
        {
            if (string.IsNullOrEmpty(CompetitionKey))
                ValidationErrors.Add("CompetitionKey", "There should be four possible answers");

            if (Answer == Competitions.CompetitionAnswer.NotSet)
                ValidationErrors.Add("Answer");

            if (Source == EntrantSource.NotSet)
                ValidationErrors.Add("EntryDate");

            if (!Contact.IsValid)
                ValidationErrors.AddRange(Contact.ValidationErrors.Items);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Entrant" /> class.
        /// </summary>
        public Entrant()
        {
            this.EntryDate = DateTime.Now;
        }
    }
}
