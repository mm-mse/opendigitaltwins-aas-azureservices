﻿using System.Collections.Generic;
using AasCore.Aas3_0_RC02;
using AdtModels.AdtModels;
using AutoMapper;

namespace AAS_Services_Support.AutoMapper
{
    public class AdtBaseProfile : Profile
    {
        public List<LangString> ConvertAdtLangStringToGeneraLangString(AdtLanguageString adtLangString)
        {
            var languageStrings = new List<LangString>();

            if (adtLangString == null || adtLangString.LangStrings == null)
            {
                return null;
            }
            else
            {
                foreach (var langString in adtLangString.LangStrings)
                {
                    languageStrings.Add(new LangString(langString.Key, langString.Value));
                }

                return languageStrings;
            }
        }
    }
}