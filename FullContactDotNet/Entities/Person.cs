﻿using System.Collections.Generic;

namespace FullContactDotNet.Entities
{
    public class Person : FullContactResponse
    {
        /// <summary>
        /// Gets or sets the likelihood that the person provided matches the person requested.
        /// </summary>
        /// <value>
        /// The likelihood.
        /// </value>
        public double Likelihood { get; set; }

        /// <summary>
        /// Gets or sets the photos.
        /// </summary>
        /// <value>
        /// The photos.
        /// </value>
        public List<Photo> Photos { get; set; }

        /// <summary>
        /// Gets or sets the contact information.
        /// </summary>
        /// <value>
        /// The contact information.
        /// </value>
        public ContactInfo ContactInfo { get; set; }

        /// <summary>
        /// Gets or sets the organizations.
        /// </summary>
        /// <value>
        /// The organizations.
        /// </value>
        public List<Organization> Organizations { get; set; }

        /// <summary>
        /// Gets or sets the demographics.
        /// </summary>
        /// <value>
        /// The demographics.
        /// </value>
        public Demographics Demographics { get; set; }

        /// <summary>
        /// Gets or sets the social profiles.
        /// </summary>
        /// <value>
        /// The social profiles.
        /// </value>
        public List<SocialProfile> SocialProfiles { get; set; }

        /// <summary>
        /// Gets or sets the digital footprint.
        /// </summary>
        /// <value>
        /// The digital footprint.
        /// </value>
        public DigitalFootprint DigitalFootprint { get; set; }
    }
}
