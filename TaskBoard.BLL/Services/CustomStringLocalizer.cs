using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace TaskBoard.BLL.Services
{
    public class CustomStringLocalizer: IStringLocalizer
    {
        Dictionary<string, Dictionary<string, string>> resources;

        const string USEREXIST = "UserExist";
        const string PASSWORDERORR = "PasswordError";
        const string BADCRED = "BadCredentianal";
        public CustomStringLocalizer()
        {
 
            Dictionary<string, string> enDict = new Dictionary<string, string>
            {
                {USEREXIST, "This email is used" },
                {PASSWORDERORR , "Password should contain at lear one numeric, upper and lowercase alphabet, and non numeric/alphabet symbol." },
                { BADCRED , "Wrong password or login" }
            };

            Dictionary<string, string> uaDict = new Dictionary<string, string>
            {
                {USEREXIST, "Користувач  таким Email вже існує" },
                {PASSWORDERORR , "пароль повинен містити як мінімум цифри, букви нижнього і верхнього регістру, та нецифрові і неалфавітні символи" },
                { BADCRED , "Неправильний логін чи пароль" } }
            ;

            resources = new Dictionary<string, Dictionary<string, string>>
            {
                {"en", enDict },
                {"uk-UA", uaDict },
            };
        }
        public LocalizedString this[string name]
        {
            get
            {
                var currentCulture = CultureInfo.CurrentUICulture;
                string val = "";
                if (resources.ContainsKey(currentCulture.Name))
                {
                    if (resources[currentCulture.Name].ContainsKey(name))
                    {
                        val = resources[currentCulture.Name][name];
                    }
                }
                return new LocalizedString(name, val);
            }
        }
        public LocalizedString this[string name, params object[] arguments] => throw new NotImplementedException();

        public IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures)
        {
            throw new NotImplementedException();
        }

        public IStringLocalizer WithCulture(CultureInfo culture)
        {
            return this;
        }
    }
}
