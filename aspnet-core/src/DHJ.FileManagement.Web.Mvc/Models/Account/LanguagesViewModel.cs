﻿using System.Collections.Generic;
using Abp.Localization;

namespace DHJ.FileManagement.Web.Models.Account
{
    public class LanguagesViewModel
    {
        public LanguageInfo CurrentLanguage { get; set; }

        public IReadOnlyList<LanguageInfo> AllLanguages { get; set; }
    }
}