﻿using System;

namespace FossLock.Model
{
	/// <summary>
	/// Description of Activation.
	/// </summary>
	public class Activation
	{
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Indicates the date and time this activation was created.
        /// </summary>
        public DateTimeOffset ActivationDateTime { get; set; }

        /// <summary>
        /// Indicates the date and time that this acviation was made invalid.  
        /// This is only set when the activation is destoryed, so it can be recreated.  
        /// </summary>
        public DateTimeOffset? DeactivationDateTime { get; set; }

        /// <summary>
        /// A SHA
        /// </summary>
        public string HardwareFingerprint { get; set; }
        
        public virtual License License { get; set; }

	}
}
