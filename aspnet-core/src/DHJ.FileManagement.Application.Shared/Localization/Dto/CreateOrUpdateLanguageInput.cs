﻿using System.ComponentModel.DataAnnotations;

namespace DHJ.FileManagement.Localization.Dto
{
    public class CreateOrUpdateLanguageInput
    {
        [Required]
        public ApplicationLanguageEditDto Language { get; set; }
    }
}